   M S B A M L   `   `   `  ����>  :PTL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:PTL.View.MainWindowPTL.View.MainWindow  5      "    PTL.View.MainWindow.Keyboard   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:PTL.View.MainWindow     5      .��5
      �� .+�5      d� -   5          d�Name$  
chb_Numpad��5      ��5   
   �� *
l.Numpad+ �� FallbackValue$ NUMPAD��6A   �� 5      ._�5      �� y�6   �� *	IsChecked+ �� ElementName$ 
chb_Numpad��   b2v �� 	Converter# [  .+�5      �� $#��Use numpad to move and resize��6    d� 	IsChecked 5   
   �� *st.IsNumpad+�� 5      $ ��Move window across screens��6    5   
   �� *st.IsNumpadSwitchScreen+�� 5      $��Block numpad text input��6    5   
   �� *st.IsNumpadBlockInput+�� 5      $��Disable when Ctrl is down��6    5   
   �� *st.IsNumpadCtrlToDisable+�� 5      $#��Enable only when Ctrl is down��6    5   
   �� *st.IsNumpadCtrlToEnable+�� 5      ��6   �� *st.RESET_INTERVAL_NUMPAD+.��5      �� �� 5      $#�Accept keyboard input every: ��6
    �� 5      �6
   �� *st.Interval_Numpad+ �� ConverterParameter$ 10��  mul# [ $	 100�� �� 5      $�ms��6
   6   5      �� 5       � Maximum$	 100Q�5    	    � Value 5      �� *st.Interval_Numpad+$ 10��5    	   �� 5!      .��5"      �� �� 5#      $�/* key additional width: ��6
    �� 5$      �6
   �� *st.AddedWidth+$ 1�� �� 5%      $�	column(s)��6
   6   5&      �� 5'      $ 5Q�5(   	    � Minimum$ -5Q�5)   	    5'      �� *st.AddedWidth+$ 1��5)   	   �� 5*      .��5+      �� �� 6   $ �+- key additional height: ��6    �� 5,      �6
   �� *st.AddedHeight+$ 1�� �� 5-      $�row(s)��6
   6   5.      �� 5/      $ 5Q�50   	   $ -5Q�51   	    5/      �� *st.AddedHeight+$ 1��51   	   52      53      d� 54      -   5        $  	chb_Arrow��54      ��55   
   �� *	l.Arrow+$ ARROW��6?   �� 56      ._�57      �� y�6   �� *	IsChecked+$ 	chb_Arrow��# [  .+�58      �� $"��Use arrow key to move window��6    59   
   �� *st.IsArrowKey+�� 5:      $��Block Key input��6    5;   
   �� *st.IsArrowBlockInput+�� 5<      $��Disable when Ctrl is down��6    5=   
   �� *st.IsArrowCtrlToDisable+�� 5>      $#��Enable only when Ctrl is down��6    5?   
   �� *st.IsArrowCtrlToEnable+�� 5@      .��5A      �� �� 5B      $�Horizontal Step:��6
    �� 5C      �6
   �� *	st.AddedX+$ 1�� �� 5D      $�	column(s)��6
   6   5E      �� 5F      $ 5Q�6   $ -5Q�5G   	    5H   	   �� *	st.AddedX+�� 5I      .��5J      �� �� 6   $�Vertical Step:��6    �� 5K      �6
   �� *	st.AddedY+$ 1�� �� 5L      $�row(s)��6
   6   5M      �� 5N      $ 5Q�6   $ -5Q�5O   	    5P   	   �� *	st.AddedY+5Q      5R      5S      5T      