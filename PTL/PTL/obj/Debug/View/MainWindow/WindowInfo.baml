   M S B A M L   `   `   `  ����>  :PTL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:PTL.View.MainWindowPTL.View.MainWindow  5      $    PTL.View.MainWindow.WindowInfo   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:PTL.View.MainWindow     5      .��5
      �� .+�5      d� -   5          d�Name$  chb_info��5      ��5   
   �� *
l.chb_info+ �� FallbackValue$
 SIZE��6A   �� 5      ._�5      �� y�6   �� *	IsChecked+ �� ElementName$ chb_info��   b2v �� 	Converter# [  .+�5      ��  d� 	IsChecked 6   �� *
st.IsTitle+��5   
   �� *	l.IsTitle+$ Overlap title bar��6M   �� 5      ��6   �� *st.RESET_SIZE_TOP+y�5   	   �� *
st.IsTitle+# [  .��5      �� �� 5      $�Title Size: ��6
   6     �� 5      �6
   �� *st.Size_Top+$ 26�� �� 5      $�px��6
   6   5      �� 5       � Value 6   �� *st.Size_Top+$ 26��y�5   	   �� *
st.IsTitle+# [  6M   �� 5      ��6   �� *st.RESET_SIZE_APP_TOP+y�5   	   �� *
st.IsTitle+# [  .��5      �� �� 5      $�App Title Size: ��6
   6$    �� 5      �6
   �� *st.Size_App_Top+$ 31�� �� 5      $�px��6
   6   5       �� 5!      -   5         ��Name$ sl_Title��5#   	    � Maximum$ 50Q�5$   	    � Minimum$	 -50Q�5%   	    5!      �� *st.Size_App_Top+$ 31��y�5"   	   �� *
st.IsTitle+# [  5%      �� 5&       6   �� *st.IsBorder+��5'   
   �� *
l.IsBorder+$ Overlap border��6K   �� 5(       6   �� *st.IsHideFullScreenAppBorder+y�5)   
   �� *st.IsBorder+# [  ��5*   
   �� *l.IsHideFullScreenAppBorder+$! Hide border when fullscreen��6j   �� 5+      ��6   �� *st.RESET_SIZE_BORDER+y�5,   	   �� *st.IsBorder+# [  .��5-      �� �� 5.      $�Border Size: ��6
   6!    �� 5/      �6
   �� *st.Size_Border+$ 3�� �� 50      $�px��6
   6   51      �� 52       6   �� *st.Size_Border+$ 3��y�53   	   �� *st.IsBorder+# [   54   	   �� *	Maximum+$ sl_Title�� 55   	   �� *	Minimum+$ sl_Title��6=   ]� 56      y�6   �� *st.IsBorder+# [  .+�57      �� $��Reset  ��6   $��Right=�58   
   ��59   
   �� *st.BORDER_NORMAL+61   �� 5:      $��Minimize window's border��6   ��5;   
   �� *st.BORDER_THIN+6/   5<      ]� 5=      .+�5>      �� $��Reset  ��6   $��Right=�5?   
   ��5@   
   �� *st.SCROLLBAR_NORMAL+64   �� 5A      $��Minimize scroll bar width��6   ��5B   
   �� *st.SCROLLBAR_THIN+62   5C      �� 5D      $��	More info��6   $��Center=�5E   	   ��5F   	   �� *st.LAUNCH_URL+6-   �� 5G       6   �� *st.IsBottom+��5H   
   �� *
l.IsBottom+$ Overlap bottom��6K   �� 5I      ��6   �� *st.RESET_SIZE_BOTTOM+y�5J   	   �� *st.IsBottom+# [  .��5K      �� �� 5L      $�Bottom Size: ��6
   6!    �� 5M      �6
   �� *st.Size_Bottom+$ 0�� �� 5N      $�px��6
   6   5O      �� 5P       6   �� *st.Size_Bottom+$ 0��y�5Q   	   �� *st.IsBottom+# [   5R   	   �� *	Maximum+$ sl_Title�� 5S   	   �� *	Minimum+$ sl_Title��6=   5T      5U      5�      5�      