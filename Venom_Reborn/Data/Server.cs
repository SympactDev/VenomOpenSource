using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Venom_Reborn.Data
{
    class Server
    {
        public static class DataInterface
        {
            [Obfuscation(Feature = "virtualization", Exclude = false)]
            public static void Save<T>(string Name, T Data)
            {
                var Serial = JsonConvert.SerializeObject(Data);
                var Protected = ProtectedData.Protect(Encoding.UTF8.GetBytes(Serial),
                    Encoding.UTF8.GetBytes(Utils.Utils.Sha512(Environment.MachineName + Name)), DataProtectionScope.LocalMachine);
                File.WriteAllText("auth\\" + Name , Convert.ToBase64String(Protected));
            }

            [Obfuscation(Feature = "virtualization", Exclude = false)]
            public static T Read<T>(string Name)
            {
                var Unprotected = ProtectedData.Unprotect(Convert.FromBase64String(File.ReadAllText("auth\\" + Name + ".bin")),
                    Encoding.UTF8.GetBytes(Utils.Utils.Sha512(Environment.MachineName + Name)), DataProtectionScope.LocalMachine);
                return JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(Unprotected));
            }

            [Obfuscation(Feature = "virtualization", Exclude = false)]
            public static bool Exists(string Name)
            {
                return File.Exists("auth\\" + Name);
            }

            [Obfuscation(Feature = "virtualization", Exclude = false)]
            public static void Delete(string Name)
            {
                if (File.Exists("auth\\" + Name)) File.Delete("auth\\" + Name);
            }
        }
    }
}
