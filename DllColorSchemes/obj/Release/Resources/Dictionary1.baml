   M S B A M L   `   `   `  ���� J  FDllColorSchemes, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:DllColorSchemes.ExtensionsDllColorSchemes.Extensions  W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 
  Freeze  	radBrush1  � Offset � Color  	radBrush2  	linBrush1  MouseOverColorKey �� Color  Background1  Background2  Foreground1  ExtButtonStyle �� 
TargetType*    $DllColorSchemes.Extensions.ExtButton �� BasedOn �� Property �� Value �� 
TargetType �� CornerRadius	 � 	Resources
 �� Triggers P� Property P� Value �� 
TargetName �� Path �� RelativeSource �� Mode �� AncestorType �� AncestorLevel 	 NormalButton �� Triggers :� RoutedEvent g� AutoReverse g� RepeatBehavior �� TargetProperty W� From	 W� To g� Duration 

 Label1  ToolTipStyle J� Effect3  -System.Windows.Media.Effects.DropShadowEffect   
BlurRadius   Color   	Direction   Opacity    ShadowDepth�� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    /ex(clr-namespace:DllColorSchemes.Extensions  :x,http://schemas.microsoft.com/winfx/2006/xaml     NPOptionsAhttp://schemas.microsoft.com/winfx/2006/xaml/presentation/options  %
  &	       &	 F     &	 �     &	 �     &	     &	 )    &	 F    &	 `    7��&		 A    7��7  &	
 �    &	 �    7_�7  7  
� 4True  .��� $  0Q�$ 	AliceBlue��� $  1Q�$
 Blue��
� 4True  .��� $  0Q�$ 	AliceBlue��� $  1Q�$ 
LightGreen���� 4True  .��� $  0Q�$ 	#FF007711��� $	  0.5Q�$
 Blue��� $  1Q�$ 	#FF007711���� 4True  $	 Red���� 4True  $ Black���� 4True  $ DarkGray���� 4True  $ Black���� "   8   ���  � �� �� "   .R��� $��	BtnBorder��
���   �#��z��$ 0��#��z��._��� #��z��.���� $��Center=�$��Center=���. 	 ��
 P�  �@J�IsMouseOver . . ���  �@�Cursor$
 Hand���� $ 	BtnBorder�� � �� �� $ MouseOverBackground� �� $ FindAncestor=�" ��$ 1��P�  �@J�	IsFocused . . ��� $ 	BtnBorder�� � �� �� $ MouseOverBackground� �� $ FindAncestor=�" ��$ 1���� " ��8    P�  �@J�IsMouseOver . . ���  � ��$ Italic$���  � ��$
 Bold"����  �@J�RenderTransformOrigin$ .5, .5&���  � z� �� ��  � �� �#7777FF��  �@�Cursor$
 Hand����  �@�OverridesDefaultStyle . ��  � �� . ��  �@J�SnapsToDevicePixels . ��  � �� �� " ��.R��� $��	BtnBorder��
���   �$��2q�$ 6��$��
0, 0, 0, 0q�#��z��._��� $��Content1��$��
1, 1, 1, 1q���.  #��z��.���� #��z��#��z��#��z��#��z��#��z����. 
 P�  � {� .  . ��� $ 	BtnBorder�� � ��
 ������� $ Content1�� � ��
 �   �P�  �@J�IsKeyboardFocused .  . ��� $ 	BtnBorder�� � ��
 �   ���  � ��$ Normal"���  � ��$ Normal$�P�  �@J�IsKeyboardFocused . . ���  � ��$
 Bold"���  � ��$ Italic$�P�  �@J�IsMouseOver . . ��� 8  $ 	BtnBorder�� � ��:� $  PreviewMouseLeftButtonDown��.[��� .����  . $ 1x��.��W� $6 0(Button.RenderTransform).(ScaleTransform.ScaleX)�$ 1X�$ .6X�$ 0:0:0.1D�W� $6 0(Button.RenderTransform).(ScaleTransform.ScaleY)�$ 1X�$ .6X�$ 0:0:0.1D��� " �����  � ��
 �   ���  � ��
 �������  � ��$
 Left=���  � ��$ 18����  � ��$ 5 0 5 0q���  � ��$ Center=��� " _�8   .���  � ��
 ���� ��  � ��
 ���� ��  � �� �� " _�.R��� 8�� $ 10��$��4q�   $ 10Q�$ Black��$	 180Q�$	 0.5Q�$  20Q�._��� 8�� $
��Bold"�.���� $��Center=�$��Center=�