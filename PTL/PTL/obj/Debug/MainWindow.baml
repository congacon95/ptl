   M S B A M L   `   `   `  ����>  :PTL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:PTL.View.MainWindowPTL.View.MainWindow  5          PTL.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      3Views!clr-namespace:PTL.View.MainWindow     5      -   5          �Name$  Window_Main��5	       � Title$ 
MainWindow��5      $	��360��5
      $	��360��5       � Left$
 1560��5      
 � Top$ 30��5      $	��360��5      $
��5000��5       � AllowsTransparency .  � WindowStyle$
 None=�5       � Topmost . 
������  � Icon$0 */PTL;component/Resources/NotifyIcon_On.ico��5      .��5      �� -   5         ��Name$
 root��5      ��5      �� 5      	 �� Color$	 Black��6   
 �� Opacity
 5      �� *st.Opacity_Main+ �� FallbackValue$	 0.3��6F    � 	Resources 5         tgb_menu �� BasedOn �� 
TargetType  tb_ruleList  
tb_content  	btn_Reset  bd_round  
chb_switch  
sl_default  
tt_default��%�  'd�       7   '�� &     7  '�� L     7  '�� r     7  '�� �     7  '�� �     7  '�� �     7  '_� 
    7  �� 5      8   " d�5      6-   �� 5      8   " ��5      6(   �� 5       8   " ��5!      6*   �� 5"      8   " ��5#      6'   �� 5$      8   " ��5%      6'   �� 5&      8   " ��5'      6)   �� 5(      8   " ��5)      6'   �� 5*      8   " _�5+      6(   5,      .+�5-      ]� -   5         ]�Name$	 nav��5-      $��5q�5.   	   ��.  50        	BaseStyle �� Property 
	 dark24 �� Value 
 dropBlue��%�   '��       7  7 	 7 
 �� 51      " ��6   8   .�53      ��  � ��8  54   ,   �� 55       �@J�Effect8  56   .   57      58      .+�59      �� $��Right=�6    � ToolTip$
 EXIT��5:        dropRed J� Effect# [ 5<        btn_exit#��[ 5=      
���  ����5;      �� *	st.EXIT+5?      �� 5@      $��Right=�6   $ Normal/Wide��5A        btn_maximize#��[ 5C      ��5B      �� *	st.RESIZE+5C      �� 5D      $��Right=�6   $ Minimize��5E        
btn_Remove#��[ 5G      ��5F      �� *st.MINIMIZE+5G      �� 5H      -   5         ��Name$ 
label_main��5H      $��PTL 2017��5I      #��[ 5J      6-   �� 5K       d� 	IsChecked 6   �� *	st.IsOn+6.   5L      �� 5M      -   5        $
 menu��5M       �� Orientation$ 
Horizontal=�5N   	    K� ZIndex$ 1��5O   	   ��5Q   	   ��  �� ElementName$	 nav�� �� Path$ Margin� 5R        chb_nav��%4   '��       7  �� 5S      8   " ��5T   	   6*   5U      .+�5V      �� $ SETTING��6     btn_Settings#��[ 5W   	   64   �� 5X      $ MOUSE INPUT��6     btn_MouseEvent#��[ 5Y   	   66   �� 5Z      $ WINDOW  SIZE��6     btn_WindowInfo#��[ 5[   	   66   �� 5\      $ CORNER SETUP��6     btn_Display#��[ 5]   	   63   �� 5^      $ FILTER RULE��6     btn_RuleList#��[ 5_   	   64   �� 5`      $ KEYBOARD INPUT��6     btn_KeyEvent#��[ 5a   	   64   �� 5b      $ ABOUT AND CONTACT��6     	btn_About#��[ 5c   	   61   5d      �� 5q      -   5         ��Name$ 
sv_content��5q      $��Hidden=�5r   
   $��Hidden=�5s   
   ��5t   
   �� $	 nav��$ Margin�.��5u      �� -   5        $ content��5u      .+�5v      "   PTL.View.MainWindow.Settings  6      PTL.View.MainWindow.Mouse  5w      6   $   PTL.View.MainWindow.WindowInfo  5x      6   &    PTL.View.MainWindow.CornerSetups  5y      6      PTL.View.MainWindow.Rules  5z      6   "   PTL.View.MainWindow.Keyboard  5{      6      PTL.View.MainWindow.About  5|      6   5}      5~      5      5�      