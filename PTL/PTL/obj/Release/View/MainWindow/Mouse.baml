   M S B A M L   `   `   `  ���� >  :PTL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:PTL.View.MainWindowPTL.View.MainWindow      PTL.View.MainWindow.Mouse   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     3local!clr-namespace:PTL.View.MainWindow     .���� .+�d� -     d�Name$  chb_drag��$��MOUSE INPUT���� ._��� y��� *	IsChecked+ �� ElementName$ chb_drag��   b2v �� 	Converter# [  .+���  d� 	IsChecked �� *	st.IsDrag+���� *
l.IsDrag+ �� FallbackValue$" Drag anywhere to move window����  �� *st.IsDragPreview+���� *l.IsDragPreview+$# Preview window for mouse-drag����  �� *st.IsCorner+���� *
l.IsCorner+$) #Drag to corner to activate resizing����  �� *st.IsCornerPreview+���� *l.IsCornerPreview+$% Preview window for mouse-corner����  �� *st.IsXButton+���� *l.IsXButton+$" Use X1BUTTON to close window����  �� *st.IsXButton+���� *l.IsXButton+$" Use X2BUTTON to close window����  �� *st.IsMinimize+���� *l.IsMinimize+$% Minimize window instead closing����  �� *st.IsConfirm+���� *l.IsConfirm+$ Ask before closing window����  �� *st.IsScroll_SwitchScreen+���� *l.IsScroll_SwitchScreen+$* $Hold Shift + Scroll to switch screen����  �� *st.IsScroll_AddWidth+���� *l.IsScroll_AddWidth+$+ %Hold RButton + Scroll to change width����  �� *st.IsScroll_Volume+���� *l.IsScroll_Volume+$( "Scroll on taskbar to change volume���� ���� *st.RESET_VOLUME_STEP+y��� *st.IsScroll_Volume+# [  .���� �� $�Volume Step: �� �� ��� *st.Volume_Step+  mul# [  �� ConverterParameter$ 2��$ 2�� �� $�/ scroll����  � Maximum$ 5Q� � Minimum$ -5Q� � Value �� *st.Volume_Step+$ 1��y��� *st.IsScroll_Volume+# [  �� .���� �� $�Click count:�� �� ��� *
st.Counter+