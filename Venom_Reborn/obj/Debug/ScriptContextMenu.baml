   M S B A M L   `   `   `  ����@  <Venom, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:DiscordXDiscordX  5   $       DiscordX.ScriptContextMenu   6   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    6'   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     6i   @d2http://schemas.microsoft.com/expression/blend/2008     6�   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6�   (localclr-namespace:DiscordX     6$  ���	#00FFFFFF  � AllowsTransparency  .  � WindowStyle$
 None=�5       � 
ResizeMode$ NoResize=�5       � Title$ ScriptContextMenu��5       � SizeToContent$ WidthAndHeight=�5       � ShowInTaskbar .  .��5
      � .+�5      �� $��10q�5       �� Padding$ 2q�5       �� CornerRadius$ 8��5      ���	#FF181818 J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      	   
BlurRadius$	 10Q�5      
   	Direction$	
 -90Q�5         ShadowDepth$ 2Q�5      ._�5      �� $ 8��5      ���#181818._�5      �  J� OpacityMask 5      !� 5       j� Stretch$
 None=�5       !� Visual 5      ��  �� ElementName$
 Mask��.+�5      �� -   5        $
��Mask��5       $ 6��5!      ���#1818185"      �� 5#       � 	Resources 5$         RoundButton �� BasedOn �� 
TargetType �� Property �� Value�� 5%   	   %�   '��       7   �� 5&   
   8   " ��5(   
   .�5*      ��  � ��$ 20��5,      �� 5-       � ��$ 60��5/      50      51   
   .+�53      �� -   5        $��0,0,0,3q�54      .��55      	Execute6'   �� 56      -   5        .��57      Load6!   58      59      5:      5;      5<      5=      