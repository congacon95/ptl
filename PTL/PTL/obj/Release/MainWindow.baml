   M S B A M L   `   `   `  ���� >  :PTL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:PTL.View.MainWindowPTL.View.MainWindow      PTL.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     3Views!clr-namespace:PTL.View.MainWindow     -     �Name$  Window_Main�� � Title$ 
MainWindow��$	��360��$	��360�� � Left$
 1560��
 � Top$ 30��$	��360��$
��5000�� � AllowsTransparency .  � WindowStyle$
 None=� � Topmost . 
������  � Icon$0 */PTL;component/Resources/NotifyIcon_On.ico��.���� -    ��Name$
 root������ 	 �� Color$	 Black��
 �� Opacity
 �� *st.Opacity_Main+ �� FallbackValue$	 0.3�� � 	Resources    tgb_menu �� BasedOn �� 
TargetType  tb_ruleList  
tb_content  	btn_Reset  bd_round  
chb_switch  
sl_default  
tt_default��%�   'd�       7   '��      7  '��      7  '�� -     7  '�� <     7  '�� K     7  '�� Z     7  '_� i     7  �� 8   " d��� 8   " ���� 8   " ���� 8   " ���� 8   " ���� 8   " ���� 8   " ���� 8   " _�.+�]� -    ]�Name$	 nav��$��5q���.    	BaseStyle �� Property 
	 dark24 �� Value 
 dropBlue��%S   '��       7  7 	 7 
 �� " ��8   .���  � ��8  ��  �@J�Effect8  .+��� $��Right=� � ToolTip$
 EXIT��  dropRed J� Effect# [   btn_exit#��[ 
���  ������ *	st.EXIT+�� $��Right=�$ Normal/Wide��  btn_maximize#��[ ���� *	st.RESIZE+�� $��Right=�$ Minimize��  
btn_Remove#��[ ���� *st.MINIMIZE+�� -    ��Name$ 
label_main��$��PTL 2017��#��[ ��  d� 	IsChecked �� *	st.IsOn+�� -   $
 menu�� �� Orientation$ 
Horizontal=� K� ZIndex$ 1������  �� ElementName$	 nav�� �� Path$ Margin�   chb_nav��%   '��       7  �� 8   " ��.+��� $ SETTING��  btn_Settings#��[ �� $ MOUSE INPUT��  btn_MouseEvent#��[ �� $ WINDOW  SIZE��  btn_WindowInfo#��[ �� $ CORNER SETUP��  btn_Display#��[ �� $ FILTER RULE��  btn_RuleList#��[ �� $ KEYBOARD INPUT��  btn_KeyEvent#��[ �� $ ABOUT AND CONTACT��  	btn_About#��[ �� -    ��Name$ 
sv_content��$��Hidden=�$��Hidden=����� $	 nav��$ Margin�.���� -   $ content��.+�"   PTL.View.MainWindow.Settings     PTL.View.MainWindow.Mouse  $   PTL.View.MainWindow.WindowInfo  &    PTL.View.MainWindow.CornerSetups     PTL.View.MainWindow.Rules  "   PTL.View.MainWindow.Keyboard     PTL.View.MainWindow.About  