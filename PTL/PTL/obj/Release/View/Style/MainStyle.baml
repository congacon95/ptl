   M S B A M L   `   `   `  ���� b  ^PresentationFramework.Aero2, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35hKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2Microsoft.Windows.Themes  > :PTL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:PTL.View.SytlePTL.View.Sytle =#clr-namespace:PTL.ViewModel.UtilityPTL.ViewModel.Utility O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� MergedDictionaries �� Source   PTL.ViewModel.Utility.Add   Add/  )PTL.ViewModel.Utility.BooleanToVisibility  b2v$  PTL.ViewModel.Utility.Multiply  mul&   PTL.ViewModel.Utility.SubtractBy 	 subby%  PTL.ViewModel.Utility.NotNotNot  not$  PTL.ViewModel.Utility.Subtract  sub*  $PTL.ViewModel.Utility.DivideByFactor 	 divby0  *PTL.ViewModel.Utility.MultiMarginConverter  MultiMarginConverter"  PTL.ViewModel.Utility.AddAll 
 AddAll 	 animationTimeFast 
 animationTimeNormal  animationTimeSlow  	Rotate180 �� Angle  Rotate90  	Rotate270  Rotate45  	BaseStyle �� 
TargetType �� Property �� Value  DisableBackground  EnableBrush  DisableBrush  	dropBlack  
tb_content  bd_round �� BasedOn �� Triggers P� Property	 P� Value  EnableBackground  dropBlue 
 dark24  tb_ruleList  chb_nav  chb_cornerSetup
 �� 
TargetType ��Name �� Padding J� Opacity �� CornerRadius �� Triggers  tgb_menu 
 btn_Up J� RenderTransformOrigin �� ElementName �� Path N� EnterActions �� 
TargetName �� TargetProperty	 W� To g� DecelerationRatio g� Duration N� ExitActions 
 dark12   dropLime ! 
tt_default " 
dpn_slider # btn_trigger $ dropRed ]� 
Conditions �� Property �� Value % btn_demo_window ��Name & btn_demo_screen �� TextAlignment A� Rows  A� Columns ' ArrowBtn ( TriangleCheckbox! J� Effect" �� 
TargetName ) 
roundBlue2 * 	roundRed2 + 
roundBlue3 , 	roundRed3 - 
roundBlue1 . 	roundRed1 / btn_nav 0 ConfirmFormButton 1 	btn_Reset 2 ScrollViewerAnimationStyle# W� From 3 Slider_ListView_Rule 4 VerticalSlider$ �� 	Resources 5 Key% (�Name 6 CornerRadius1 7 Height1 8 Height2& (� Stretch' ]�Name( ]� DecreaseRepeatButton '9 #VerticalSlider_DecreaseRepeatButton) ]� IncreaseRepeatButton ': #VerticalSlider_IncreaseRepeatButton* ]� Thumb ; HorizontalSlider_Thumb < 
sl_default+ ��Name, n�Name = 
chb_switch- T� X. K� ZIndex > lv_Rules,	   &Microsoft.Windows.Themes.ListBoxChrome/ 	 Name0 	  BorderBrush1 	  BorderThickness2 	  
Background3 J� IsMouseOver4 	  RenderMouseOver5 J� IsKeyboardFocusWithin6 	  RenderFocused7 J� SnapsToDevicePixels8 � ColumnDefinitions9 � RowDefinitions: �� Columns; �� RelativeSource!< �� ColumnHeaderContainerStyle= �� ColumnHeaderTemplate#> �� ColumnHeaderTemplateSelector? �� AllowsColumnReorder@ �� ColumnHeaderContextMenuA �� ColumnHeaderToolTip-
  'System.Windows.Input.KeyboardNavigationB 
  DirectionalNavigationC �� CanContentScrollD �� CanHorizontallyScrollE �� CanVerticallyScrollF �� OrientationG �� ScrollableWidthH � MaximumI �� ViewportWidthJ �� ViewportSizeK �� HorizontalOffsetL � Value,M �� %ComputedHorizontalScrollBarVisibilityN �� ScrollableHeightO �� ViewportHeightP �� VerticalOffset*Q �� #ComputedVerticalScrollBarVisibility ? GridViewColumnHeaderGripper'  !System.Windows.VisualStateManagerR   VisualStateGroups%  System.Windows.VisualStateGroupS   States   System.Windows.VisualStateT ��Name @ ControlLightColorU �� ColorV �� 
StartPointW �� EndPoint A BorderLightColorX � ColorY � Offset B BorderDarkColor C DisabledBorderLightColorZ ��Name D MenuBackground[   
Storyboard E CheckBox_Round\ O� KeyTime] O� Value F CheckBox_RuleList^ g� AutoReverse G 	RoundBall_ �� From	` �� To H RoundCheckbox I CheckBox_ShowDetaila � ToolTipb ^� 	Placement J RoundCheckboxLeft K RoundCheckboxRight L Button_Color M ColorDropRight N RoundCheck2Rightc �� Orientation O Button_Command P TextBlockStyle1 Q OverlayIcon R viewBox_Style S ActiveStyle T 	MenuBrush U 	MenuColor V PrimaryColor�� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     VThemesKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2  &localclr-namespace:PTL.View.Sytle  2
converters#clr-namespace:PTL.ViewModel.Utility  .sys&clr-namespace:System;assembly=mscorlib    �� $, &/PTL;component/View/Style/Buttons.xaml?�%�s  &	        &	      &	 
     &	      &	      &	      &	      &	 #     &	 (     &		 -     &	
 >     &	 O     &	 `     &	 �     &	 �     &	 �     &	 �     7  7  7  7  &	 b    7  7  &	 2    7  '�� �    7  7  7  7  7  7  7  7  7  7  &	 �    7  7  7  7  7  7  &	 �    7  7  7  7  7  7  7  7  7  &	 �    7  7  7  7  7  7  7  &	 &	    7  7  7  7  7  7 	 7 	 7  7  7   7  7  7  &	! I    7  &	" �    7  &	# �    7  7  7  7 $ 7  &	% �    7  7  7  7  7  7  7  &	& k    7  7  7  7  7  7  7  &	' �    7  &	( �    7   7   7 ) 7 * 7 + 7   7 , 7 $ 7 - 7 . &	/ �    7  7   7  &	0 �    7  7 - 7   7  &	1 �    7  7  7  7  &	2 �    7 
 7 
 &	3 �     7  7  7 6 7 7 7 8 7 	 7 7 7 	 7 8 7 7 7 6 7 7 7 8 7 	 7 7 7 	 7 8 7 7 &	< _)    7  7  &	= �,    7  7  7  7  7 	 7 	 7  7  &	> 2/    7  7  (�� �1    *'%GridView.GridViewScrollViewerStyleKey+)&	? �5    '�� ^6    7  7  7 ? '�� e9    '�� ;    7 D 7 	 7 	 7  7  &	E Z=    7  7  7 D 7 ) 7   7 + 7 + 7  7  7 	 7  7  7 	 7   7   7  &	F D    7  7  7 	 7 	 7 	 7 	 7 ) 7  7  7  7 + 7   7  7  &	G 'J    7   7 	 7 	 7 	 7 	 7   7 $ 7  7 	 7 	 &	H �N    7 G &	I �O    7  7 D 7 D 7 ) 7 	 7 	 7 	 7 	 7 	 7 	 7 	 7 	 7  7   7  7  7  &	J �X    7 G &	K !Y    7   7   7 ) 7 * 7 + 7   7 , 7 $ 7 - 7 . &	L ]    7  7   7   7  7 $ &	M `    7 L 7   7  7  &	N �b    7 ) 7 ) 7   7 $ 7   7 + 7 - &	O Cf    7  7 D 7   7  7  7  7  7   7  &	P �h    7  &	Q �i    &	R ]j    7  &	S �j    7 T 7  7 U 7 	 7 	 7 V 7 	 7 	 7  7   7                     E�0:0:0.2D�E�0:0:0.3D�E�0:0:0.4D�V� .~��� �� �� $	 180Q�T� V� .~��� �� �� $ 90Q�T� V� .~��� �� �� $	 270Q�T� V� .~��� �� �� $ 45Q�T� �� " ��.���  � ��$ 32����  � ��8   ��  � ��8  ��  � ��8  ��  �@J�Effect8  ��  �@J�SnapsToDevicePixels . ��  �@_�	Placement$	 Top=���  �@^�InitialShowDelay$	 500����  � ��$ Segoe UI)���  � ��$ 18(���  � ��$	 1.5q���  � ��$
 Wrap=���  �@��TextAlignment$ Center=��� " ��.���  � ��$ WrapWithOverflow=���  � ��$ 18(���  � ��$ 60����  � ��$ 32����  �@��Padding$	 0,2q���  � ��$ Center=���  � ��8   ��  � ��8  �� " ��.���  � ��$ 0,0,0,0q���  �@��CornerRadius$ 0����  � ��8   �� chb_nav��" ��8    P�  �@d�	IsChecked$
	 TrueY�. ���  � ��8  ��  �@J�Effect8  P�  �@d�	IsChecked$	 FalseY�. ���  � ��8  ��  � ��8  ��  �@J�Effect8  P�  �@J�IsMouseOver	 . . ���  � ��8  ��  � ��8  P�  � ��	 . . ���  � ��8  ��  �@J�Effect8 	 �� " ��8   .���  � ��$ 50����  � ��8  ��  �@J�Effect8   P�  �@J�IsMouseOver	 . . ���  �@J�Effect8  ��  � ��8  ��  � ��8  �� " ��8   .���  � ��$ 50�� P�  �@d�	IsChecked$
	 TrueY�. ���  � ��8  ��  � ��8  P�  �@d�	IsChecked$	 FalseY�. ���  � ��8  ��  �@J�Effect8  P�  �@J�IsMouseOver	 . . ���  � ��8  ��  �@J�Effect8  ��  � ��8  P�  � ��	 . . ���  �@J�Effect8  �� " ��8   .���  � ��$ 0����  � ��8  ��  � �� �� "
 ��.R��� $ outerBorder��#��z��#��z��#��z��#��z��$ 3q�$��0q�$��1q�._��� #��z��# z $ 0�� P�  �@d�	IsChecked$	 FalseY�. ���  �@J�Opacity$	 0.8Q�P�  �@d�	IsChecked$
	 TrueY�. ���  �@J�Opacity$ 1Q��� 8   �@J�Effect�� 8   � ��P�  �@J�IsMouseOver	 . . ���  �@J�Opacity$ 1Q��� 8   �@J�Effect�� 8   � ��P�  � ��	 . . ��� 8   �@J�Effect��  �@J�Opacity$	 0.9Q��� " d�8   .���  �@d�	IsChecked$
 TrueY���  � ��$ 26(���  � ��$
 Bold)���  � �� �� "
 d�.R�� .+��� #��z��#��z��$��1q�$ 16���� #��z��$��0,1,0,-1q�$��Center=��� 8�� $ 0.5,0.5&�$��Right=�z�V� .~��� 	Angle���� 8�� $ 0.5,0.5&�$
��Left=�z�V� .~���  �� $ Angle��$ Angle� P�  �@d�	IsChecked$
	 TrueY�. ��� 8   � ���� 8   � �� �� .���� .��W� $ Angle��$ Angle�$	 180X�$
 0.75Q�8   �� .���� .��W� $ Angle��$ Angle�$ 0X�$
 0.75Q�8  P�  �@d�	IsChecked$	 FalseY�. ��� 8   � ���� 8   � ��P�  �@J�IsMouseOver	 . . ��� 8 	  �@J�Effect�� 8 
  � ��P�  � ��	 . . ��� 8   �@J�Effect�� 8   � ���� " _�8   .���  � ��$	 350����  � ��
 ��  ���  � �� �� "
 _�.R�� .+��� #��z��#��z��$��1q�$ 16���� #��z��$��
36,-1,36,1q�$��Center=��� $
��Left=�#��z��#��z��$ 16��$��32��$��32��._��� ?�� $��Right=�#��z��#��z��$ 16��$��32��$��32��._��� ?�� " ]� P�  �@J�IsMouseOver	 . . ���  �@J�Effect8   �� " ��8   .���  � ��8   P�  �@J�IsMouseOver	 . . ���  �@J�Effect8  ��  � ��$ 3q�P�  � {�	 .  . ���  �@J�Effect8  ��  � ��
 �  ��]�  ��  � �� . ��  � {� . ./���  �@J�Effect8  ��  � ��$ 1q��� " ��8   .���  � ��$ 1q���  � ��$	 160����  � ��$ 90����  � ��8  ��  �@J�Effect8  ��  �@�ToolTip$&  Window position and size preview����  � �� �� "
 ��.R�� .+��� #��z��#��z��#��z��#��z��#��z��._��� $ ScreenDemo_Text��#��z��#��z��#��z��$��Center=�$��WrapWithOverflow=��� $��8��$	��Top=�#��z��._�]� ��.  .+�� $��Right=�$	��1,0q�$��8��$��8��.+��� $��2��$��8��
���   �$ 1��$ 0.5,0.5&�z�V� .~��� $ 45Q��� $��2��$��8��
���   �$ 1��$ 0.5,0.5&�z�V� .~��� $	 -45Q��� $��6��$��6��$��1q�$ 1��$��Right=�
���   �$��2q��� $��2��$��6��$	��2,0q�$ 1��$��Right=�
���   � P�  �@J�IsMouseOver	 . . ��� 8   � ���� 8   �@J�EffectP�  � ��	 . . ��� 8   � ���� 8   �@J�Effect�� " ��8   .���  � ��$ 1q���  � ��$ 14(���  � ��$
 Bold)���  � ��$	 360����  � ��$	 203����  � �� �� "
 ��.R�� .+��� #��z��#��z��#��z��#��z��#��z��._��� #��z��$
��Left=�$��Center=�$��5q�$
 Left=�$
��Wrap=�#��z��#��z��� $��Bottom=�#��z��.+��� $ border��#��z��$��14��$��Bottom=�#��z��#��z���� $��32��$��8��$
��13,0q�$
��Left=�#��z���� $
��Left=����� *Height+$ border������ *Height+$ border��._�A� $ 2��$  2��$��3q�.+��� 
���  ���� 
��� � ��� 
����� ��� 
��� ��� P�  �@J�IsMouseOver	 . . ��� 8   � ���� 8   �@J�EffectP�  �@d�	IsChecked$
	 TrueY�. ��� 8   � ���� 8   �@J�EffectP�  � ��	 . . ��� 8   � ���� 8   �@J�Effect�� " ��.���  � ��8   ��  � ��$ 50����  � ��$ 50����  � ��$ 16����  �@J�RenderTransformOrigin$ 0.5, 0.5&���  � �� �� "
 ��.R�� #��z��#��z��.+��� $��15��$	��1.5��$ 1��$��0,0,-2,2q�$��Right=�$��Bottom=�#��z��$ 0.5,0.5&�z�V� .~��� �� �� $	 -45Q�T� �� $��15��$	��1.5��$ 1��$��0,2,-2,0q�$��Right=�$	��Top=�#��z��$ 0.5,0.5&�z�V� .~��� �� �� $ 45Q�T� �� #��z��$	��1.5��$ 1��#��z���� " ��.���  �@d�	IsChecked$
 TrueY���  �@J�SnapsToDevicePixels . ��  � �� �� "
 ��.R�(� .���� $ outerBorder��
��� � �$��20��$��20��$��1q�$ 10,00,10,00��8!    P�  �@J�IsMouseOver	 . . ��� $" outerBorder�� � ��
 � � ��� $" outerBorder��8   �@J�EffectP�  �@d�	IsChecked$
	 TrueY�. ��� $" outerBorder��8   � ��P�  �@d�	IsChecked$	 FalseY�. ��� $" outerBorder��8   � ��]�  ��  �@d�	IsChecked$
 TrueY���  �@J�IsMouseOver . ./��� $" outerBorder��8   � ���� $" outerBorder��8   �@J�Effect]�  ��  �@d�	IsChecked$ FalseY���  �@J�IsMouseOver . ./��� $" outerBorder��8   � ���� $" outerBorder��8   �@J�Effect]�  ��  �@d�	IsChecked$
 TrueY���  � �� . ./��� $" outerBorder��8   � ��]�  ��  �@d�	IsChecked$ FalseY���  � �� . ./��� $" outerBorder��8 	  � ���� " ��8   .���  � ��$ 40����  � �� �� "
 ��.R�(� .���� $
 elip��$��20��$��20��#��z��$ 0��#��z��#��z��._��� #��z��$ Center=�#��z��$��20(�$��
0,-7.5,0,0q� P�  �@J�IsMouseOver	 . . ��� 8   �@J�EffectP�  � ��	 . . ��� 8   �@J�Effect�� " ��.���  �@J�SnapsToDevicePixels . ��  � ��$ 2q���  � ��$ 50����  � ��$ 0q���  � ��$ 50����  � ��8   ��  � ��8  ��  � �� �� "
 ��.R�(� .���� $
 elip��#��z��#��z��#��z��$ 25��#��z��#��z��._��� #��z��$ Center=�#��z��$��20(�$��0,0,0,5q�$��Center=� P�  �@J�IsMouseOver	 . . ��� 8   �@J�Effect��  � ��
 � � �P�  � ��	 . . ���  � ��
 �2͚��� 8   �@J�Effect�� " ��8   .���  � ��8  ��  � ��$ 0q���  � �� �� "
 ��.R�� .+��� #��z��#��z��#��z��#! z! $ 16���� #��z��$��
10,1,10,-2q� P�  �@J�IsMouseOver	 . . ��� 8   �@J�EffectP�  � ��	 . . ��� 8   �@J�Effect�� " ��.���  � �� .  ��  � ��$	 Top=���  � ��$
 Left=���  � ��$ Hidden=� P�  �@J�	IsVisible	 .  �� .���� .��W� $ Opacity�$ 1X�$	# 0.5X�8    �� .���� .��W� $ Opacity�$ 0X�8  �� " ��.���  �@�OverridesDefaultStyle . ��  � ��8   ��  �@��TickFrequency$ 1Q���  � ��$ 1q���  � ��$ 20����  �@��Orientation$ Vertical=���  �@J�Opacity$ 1Q���  �@J�SnapsToDevicePixels . ��  �@��IsSnapToTickEnabled . ��  � ��8  ��  � ��# � 4 $ ����CornerRadius25 6����CornerRadius15 6��X�Height15 12Q�X�Height25 12Q��� HorizontalSlider_Thumb5 " n�.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  �@�OverridesDefaultStyle . ��  � �� �� "
 n�.R�(� $% Ellipse��#��z��.���� $��20��$��4��#��z���� '#VerticalSlider_DecreaseRepeatButton5 " ��.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  � �� �� "
 ��.R��� ���	#00000000._��� $ 
background��
���  ��#��z��#��z��8  8�� $ 0Q� P�  �@J�IsMouseOver	 .  �� .���� .��W� $ 
background��$ Width�8  8   �� .���� .��W� $ 
background��$ Width�8  8  . ��� $" 
background�� � ��
 � � ��� $" 
background��8   � ��P�  � ��	 . . ��� $" 
background�� � ��
 �2͚��� $" 
background��8 	  � ���� '#VerticalSlider_IncreaseRepeatButton5 " ��.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  � �� �� "
 ��.R��� ���	#00000000._��� $ 
background��
���  ��
����  �#��z��8 
 8�� $ 0Q� P�  �@J�IsMouseOver	 .  �� .���� .��W� $ 
background��$ Width�8  8   �� .���� .��W� $ 
background��$ Width�8  8  . ��� $" 
background�� � ��
 � � ��� $" 
background��8   � ��P�  � ��	 . . ��� $" 
background�� � ��
 �2͚��� $" 
background��8   � ���� VerticalSlider5 "
 ��.R�(� $& Uniform=�.��� #��z��#��z��.+�]� $' 
PART_Track��( �� #��� 9 #��z��$y�	Collapsed=�$��Slider.DecreaseLarge��) �� #��� : #��z��$y�	Collapsed=�#��z��$��Slider.IncreaseLarge��* n� #��� ; #��z��#��z��$ 0.5,0.5&��� " ��8   .���  � ��$ 1q���  � ��
 �   ���  �@�Value$ 24Q���  �@�Maximum$ 48Q���  �@�Minimum$ 0Q���  �@��TickFrequency$ 1Q���  � �� �� "
 ��.R�]� $' 
PART_Track��( �� $+ DecreaseRepeatButton��#��z��#��z��#��z��#��z��$��	0,0,-16,0q�$��Slider.DecreaseLarge������ "
 ��.R�� #��z��#��z��.+��� #��z��#��z��#��z��$ 2��$��4��$��5,0,14,0q�) �� $+ IncreaseRepeatButton��#��z��#��z��#��z��#��z��$��	-16,0,0,0q�$��Slider.IncreaseLarge��! Z� ���� "
 ��.R�� #��z��#��z��.+��� #��z��#��z��8�� $ 2��$��4��$��14,0,5,0q�* n� $, Thumb��#��z��#��z��#��z��#��z������ "
 n�.R�� .+��� $��30��$��30��$ 20��#��z��$	��1.5q�#��z���� $��24��$��24��$ 20��#��z�� �� " ��8   .���  � ��8  ��  � �� �� "
 d�.R�� #��z��#��z��.+��� #��z��$
��Left=�$��Center=�#! z! #��z��#��z��#��z��� $��Right=�.+��� $ Bullet��$��24��$��24��$ 12��#��z��z�V� .~�T� 	MoveX��$	- -10Q��� $��50��$��30��$ 15��#��z��#��z��$	��1.5q�$. -1�� P�  �@d�	IsChecked$	 FalseY�. ��� 8   � ��P�  �@J�IsMouseOver	 . . ��� 8   �@J�EffectP�  �@d�	IsChecked$
	 TrueY� �� .���� .��W� $ MoveX��$ X�$ 10X�8   �� .���� .��W� $ MoveX��$ X�$	 -10X�8  . ��� 8   � ��P�  � ��	 . . ��� 8   �@J�Effect�� " ��.���  � �� �	#01000000��  � ��8   ��  � ��8  ��  � ��$ 1q���  � ��$ 14(���  � ��$	 Top=���  � ��$ Hidden=���  � ��$ Hidden=���  � �� . ��  �@��PanningMode$
 Both=���  �@��IsFlicksEnabled .  ��  � ��$ Center=���  � �� �� "
 ��.R�	  $/ Bd��#0 z��#1 z��#2 z��#4 z3 #6 z5 7 . ._��� #��� $�.���� #7 z7  P�  � {�	 .  . ��� $" Bd��# � �� �@	 
BackgroundP�  �@��
IsSelected	 . . ��� $" Bd�� �@	 
Background �#242424]�  ��  �@��
IsGrouping . �� " �@%�IsVirtualizingWhenGrouping .  ./���  � �� .  �� " ��.���  � �� �� "
 ��.R�� #��z��8 �� $��* ��� $
��Auto �9 �� $��* ��� $
��Auto �.+�]� $��0q�.+��� $	��Top=�$��Hidden=�$��Hidden=�|�.  .���� #7 z7 : �� *TemplatedParent.View.Columns+; �� *TemplatedParent+< �� $5 /TemplatedParent.View.ColumnHeaderContainerStyle�; �� *TemplatedParent+= �� $/ )TemplatedParent.View.ColumnHeaderTemplate�; �� *TemplatedParent+> �� $7 1TemplatedParent.View.ColumnHeaderTemplateSelector�; �� *TemplatedParent+? �� $. (TemplatedParent.View.AllowsColumnReorder�; �� *TemplatedParent+@ �� $2 ,TemplatedParent.View.ColumnHeaderContextMenu�; �� *TemplatedParent+A �� $. (TemplatedParent.View.ColumnHeaderToolTip�; �� *TemplatedParent+�� $!��PART_ScrollContentPresenter��$B Local=�C . D .  E . �� $��PART_HorizontalScrollBar��$F 
Horizontal=�$��1��#H zG #J zI #L zK #y�zM �� $��PART_VerticalScrollBar��$��1��#H zN #J zO #L zP #y�zQ �� " n�.���  � �� �� "
 n�.R��� # z��$��2��$ 0��$��20��$��0,-2,0,0q�#��z��$ 1Q��� " ��.���  � ��$ Center=���  � ��$ Center=���  � ��8   ��  � �� �� "
 ��.R�� R   CommonStates��.S   
Normal��  	MouseOver��  Pressed��  Disabled��.+��� $ HeaderBorder��$��0,0,0,1q�#��z��8�� ._��� $T HeaderContent��$��14(�$��0,-4,0,0q�#��z����. #��z��#��z��#7 z7 n� $, PART_HeaderGripper��$��Right=�#��z��8��  P�  �@��Role$	 Floating=�. ���  �@J�Opacity$ 1Q���  � �� �� "
 ��.R��� $��PART_FloatingHeaderCanvas��.+��� 
����  �#��z��#��z��P�  �@��Role$	 Padding=�. ���  � �� �� "
 ��.R��� $��HeaderBorder��$��0q����� #U � @ ���� $	V 0,0&�$	W 0,1&���� � #X � A $	Y 0.0Q�� #X � B $	Y 1.0Q��� " ��.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  � ��$
 Auto=���  � ��$
 Auto=���  � �� . ��  � ��$ Center=���  � �� �� "
 ��.R��� $��Border��$��0q�
���  ��
��� � �._��� #��� $�.����  P�  �@��
IsGrouping	 . . ���  � �� .  P�  � {�	 .  . ��� $" Border�� � �� �� #U � C �� " ��.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  � ��$ Center=���  � �� �� "
 ��.R�� 7 . .+��� $Z 
background��8��  $ 0Q��� #��z��$��Center=�$ Center=�#��z��R   CommonStates��.S   
Normal��  	MouseOver��.[ �� .��W� $ 
background��$ Opacity�$ 1X�8    Disabled��  SelectionStates��.S   
Unselected��  Selected��.[ �� .��W� $ 
background��$ Opacity�$ 1X�8   P�  � {�	 . . ��� 8   � ��P�  � {�	 .  . ��� 8   � ���� " ��.���  � ��$
 Left=���  � ��8   ��  � ��8  ��  � ��$ 24(���  � ��$ Light"���  � ��$ Stretch=���  � ��$ 0,2,0,2q���  � ��$	 1.5q���  � �� �� "
 ��.R�� $��mainGrid��$��36��8 �� $��36 ��� $��* �.+��� $ 	backround��$��2��8�� $
 0.25Q�$ 20���� $ 
outterBall��$��18��$��18��#��z�����	#01000000#��z��$ 30���� $��circle��$��0��$��0��#��z��8�� #��z��8!  $ 20���� $T content��$��1��$��	-0,0,15,0q�7 . $
��Left=�#��z��#��z��#��z�� ]�  ��  �@d�	IsChecked$
 TrueY���  �@J�IsMouseOver . ./��� $" circle��8   � ��]�  ��  �@d�	IsChecked$
 TrueY���  �@J�IsMouseOver . ./��� $" circle��8   � ��P�  �@d�	IsChecked$
	 TrueY� �� .���� .��U� $ circle��$ Width�8  .\��� $\ 0:0:0.25��] 36�� $\ 0:0:0.4��] 24U� $ circle��$ Height�8  .\��� $\ 0:0:0.25��] 36�� $\ 0:0:0.4��] 24W� $ 	backround��$ Opacity�$	 0.8X�8 	  �� .���� .��U� $ circle��$ Width�8 
 .\��� $\ 0:0:0.15��] 36�� $\ 0:0:0.4��] 0U� $ circle��$ Height�8  .\��� $\ 0:0:0.15��] 36�� $\ 0:0:0.4��] 0W� $ 	backround��$ Opacity�$
 0.25X�8  ]�  ��  �@J�IsMouseOver . ./��� $" 	backround�� � ��
 � � ��� $" 
outterBall��8   �@J�Effect�� 8   �@J�EffectP�  � ��$
	 Left=�. ��� $" circle�� � ��$ 0���� $" content�� � ��$ 1��P�  � ��$	 Right=�. ��� $" circle�� � ��$ 1���� $" content�� � ��$ 0��P�  � ��	 . . ��� 8   �@J�Effect�� " ��.���  � ��$
 Left=���  � ��8   ��  �@d�	IsChecked$ FalseY���  � ��$ 32����  � ��$	 120����  � ��$
 auto����  � ��$ Light"���  � �� �	#01000000��  � �� �� "
 ��.R��� #��z��._�� $��mainGrid��#��z��8 �� $��50 ��� $��* �.+��� $ Ellipse��$��16��$��16��$ 16��8�� #��z��#! z! $��2q��� $ content��$��1��$��20(�$��0,1,0,0q�7 . #��z��#��z�� P�  �@d�	IsChecked$
	 TrueY� �� .���� .��W� $ Ellipse��$ Width�$ 22X�8  ^ .  W� $ Ellipse��$ Height�$ 22X�8  ^ .   �� .���� .��W� $ Ellipse��$ Width�$ 16X�8  ^ .  W� $ Ellipse��$ Height�$ 16X�8  ^ .  . ��� $" Ellipse��8   � ���� 8   � ���� 8   �@J�EffectP�  �@d�	IsChecked$	 FalseY�. ��� $" Ellipse�� � �� �	#01000000�� 8 	  � ��P�  � {�	 .  . ��� $" Ellipse�� � �� �	#01000000��  � ��
 �  ��]�  ��  �@d�	IsChecked$
 TrueY���  �@J�IsMouseOver . ./��� $" Ellipse��8 
  � ����  � ��
 � � ��� 8   �@J�Effect]�  ��  �@d�	IsChecked$ FalseY���  �@J�IsMouseOver . ./���  � ��
 � � ��� 8   �@J�EffectP�  � ��$
	 Left=�. ��� $" Ellipse�� � ��$ 0���� $" content�� � ��$ 1��P�  � ��$	 Right=�. ��� $" Ellipse�� � ��$ 1���� $" content�� � ��$ 0��P�  � ��	 . . ��� 8   �@J�Effect�� "
 ��.R��� $
 Ball��
��� � �$��30��$��30��#��z��8!   $ 25��$ 0.5,0.5&���
� .��� $X Black��$Y -1Q�� $X 	LightBlue��$	Y 0.0Q�� $
X Blue��$Y 1Q�._��� #��z��$��Center=�$��Center=�$��0,-4,0,0q�#��z�� P�  �@J�IsMouseOver	 . . ��� $
" Ball�� � ��
 � � �P�  �@d�	IsChecked$
	 TrueY� �� .���� .���� $
 Ball��$N H(Background).(RadialGradientBrush.GradientStops)[1].(GradientStop.Color)�$_ WhiteX�$` 	LightBlueX�8  �� $
 Ball��$N H(Background).(RadialGradientBrush.GradientStops)[2].(GradientStop.Color)�$	_ RedX�$
` BlueX�8   �� .���� .���� $
 Ball��$N H(Background).(RadialGradientBrush.GradientStops)[1].(GradientStop.Color)�$_ 	LightBlueX�$` WhiteX�8  �� $
 Ball��$N H(Background).(RadialGradientBrush.GradientStops)[2].(GradientStop.Color)�$
_ BlueX�$	` RedX�8  . ��� $
" Ball��8   �@J�EffectP�  �@d�	IsChecked$	 FalseY�. ��� $
" Ball��8   �@J�Effect�� $
" Ball��8   � z�P�  � ��	 .  �� .���� .��W� $
 Ball��$ Width�$# 30X�$ 25X�8  ^ . W� $
 Ball��$ Height�$# 30X�$ 25X�8 	 ^ . �� " ��.���  �@d�	IsChecked$
 TrueY���  �@J�SnapsToDevicePixels . ��  � ��$ 2q���  � ��8   ��  �@^�	Placement$
 Left=���  �@^�InitialShowDelay$	 100���� " ��.���  �@J�SnapsToDevicePixels . ��  � ��$ 0q���  � ��8   ��  � ��
 �  ����  �@d�	IsChecked$ FalseY���  � ��$ 50����  � �� �� "
 ��.R��� #��z��#��z��#��z��._�� #��z��#��z��.+��� $ 
background��#��z��#��z��8��  �� *MenuOpacity+�� $ 	mouseover��$ 0Q�#��z��#��z��$ 0.5,0.5&�8�� z��� $	 180Q�� #��z��#��z��$
��Left=�.+��� $
 ball��$ 0.5,0.5&�$��38��$��38��$a Click To Show��$	b Top=�8�� #��z��$	��1.5q�$ 25��._�� ���	#01000000.+��� $��14��$��3��$	 1.5��$��	-9,-3,0,0q�$��Center=�#��z��$ 0.5,0.5&�z�V� .~��� �� �� $ 45Q�T� �� $��14��$��3��$	 1.5��$��9,-3,0,0q�$��Center=�#��z��$ 0.5,0.5&�z�V� .~��� �� �� $	 -45Q�T� z�V� .~��� rotateTransform��$	 180Q��� $��0��$��	55,-3,0,5q�$
��Left=�$��Center=�#��z��#��z��$��34(�$��Light"�$
 Left=� P�  �@d�	IsChecked$	 FalseY�. ���  � ��
 �   �P�  �@d�	IsChecked$	 FalseY� �� .���� .��W� $ 	mouseover��$ Opacity�$ 0X�8  W� $ rotateTransform��$ Angle�$ 90X�8  U� $
 ball��$ Width�8  .\��� $\ 0:0:0.05��] 50�� $\ 0:0:0.1��] 38U� $
 ball��$ Height�8  .\��� $\ 0:0:0.05��] 50�� $\ 0:0:0.1��] 38 �� .���� .��W� $ 	mouseover��$ Opacity�$ 1X�8  W� $ rotateTransform��$ Angle�$	 180X�8 	 U� $
 ball��$ Width�8 
 .\��� $\ 0:0:0.05��] 30�� $\ 0:0:0.1��] 38U� $
 ball��$ Height�8  .\��� $\ 0:0:0.05��] 30�� $\ 0:0:0.1��] 38]�  ��  �@J�IsMouseOver .  �� .���� .��W� $ 	mouseover��$ Opacity�$ 1X�$ 0D� �� .���� .��W� $ 	mouseover��$ Opacity�$ 0X�$ 0D�./��� 8   � ���� $
" ball��8   �@J�Effect]�  ��  �@J�IsMouseOver .  ��  �@d�	IsChecked$ FalseY� �� .���� .��W� $ 	mouseover��$ Opacity�$ 0X�$ 0D� �� .���� .��W� $ 	mouseover��$ Opacity�$ 1X�$ 0D�./��� 8   � ��P�  � {�	 .  . ��� 8   � ��P�  �@d�	IsChecked$
	 TrueY�. ��� 8   � ����  �@^�	Placement$
 Left=���  �@^�InitialShowDelay$	 100���� " ��.���  �@d�	IsChecked$
 TrueY���  �@J�SnapsToDevicePixels . ��  � ��$ 3q���  � ��8   �� " ��.���  �@d�	IsChecked$
 TrueY���  �@J�SnapsToDevicePixels . ��  � ��$ 1q���  � �� �� "
 ��.R�(� .���� $ outerBorder��
��� � �$��20��$��20��#��z��8!   $ 10,00,10,10�� P�  �@J�IsMouseOver	 . . ��� $" outerBorder�� � ��
 � � ��� $" outerBorder��8   �@J�EffectP�  �@d�	IsChecked$
	 TrueY�. ��� $" outerBorder��8   � ��P�  �@d�	IsChecked$	 FalseY�. ��� $" outerBorder��8   � ��]�  ��  �@d�	IsChecked$
 TrueY���  �@J�IsMouseOver . ./��� $" outerBorder��8   � ���� $" outerBorder��8   �@J�Effect]�  ��  �@d�	IsChecked$ FalseY���  �@J�IsMouseOver . ./��� $" outerBorder��8   � ���� $" outerBorder��8   �@J�Effect]�  ��  �@d�	IsChecked$
 TrueY���  � �� . ./��� $" outerBorder��8   � ��]�  ��  �@d�	IsChecked$ FalseY���  � �� . ./��� $" outerBorder��8 	  � ���� " ��.���  � ��$ 69����  � ��$ Stretch=���  � ��$ Stretch=���  � ��$	 1.6q���  � ��$ 3q���  � ��
 � � ���  � ��8   ��  � �� �� "
 ��.R��� $ outerBorder��#��z��#��z��#��z��$ 20��#��z��#��z�� P�  �@J�IsMouseOver	 . . ���  � ��
 � � ���  � ��$ 2q��� 8   �@J�Effect��  � ��$ 3q�P�  � ��$	 1��. ���  � ��
 � � ���  � ��$ 2q��� 8   �@J�Effect�� $" outerBorder�� �@��CornerRadius$ 35��P�  � ��	 . . ���  � ��
 � � ��� 8   �@J�Effect�� $" outerBorder�� �@��CornerRadius$ 35��P�  � {�	 .  . ���  � ��
 �  ���� 8   �@J�Effect�� " ��8   .���  � �� �� "
 ��.R�(� .���� $ outerBorder��#��z��#��z��$��80��$ 
40,0,40,40��#��z��#��z��._��� $ Conntent��#��z��$��0,6,0,0q�$ Center=� P�  �@J�IsMouseOver	 . . ��� $" outerBorder�� � ��
 � � ��� $" outerBorder�� � ��$ 3q��� $" Conntent�� � ��
 � � ��� $" outerBorder��8   �@J�EffectP�  � ��	 . . ��� $" outerBorder�� � ��
 �2͚��� $" Conntent�� � ��
 �2͚��� $" outerBorder��8   �@J�EffectP�  � {�	 .  . ��� $" outerBorder�� � ��
 �  ���� $" Conntent�� � ��
 �  ���� $" outerBorder��8   �@J�Effect�� " ��.���  � ��$ 40����  � ��$
 Left=���  � ��$
 0,10q���  � �� �� "
 ��.R�(� #��z��.���� ���	#01000000._��� $��40��$
��Left=�$c 
Horizontal=�.+��� $ content��$��1��$��34(�$��0,0,10,0q�#��z��#��z���� $ circle��$��40��$��40��#��z��8��  $��3q�$ 20�� P�  �@d�	IsChecked$
	 TrueY�. ��� $" circle��8   � ���� $" circle��8   �@J�EffectP�  �@d�	IsChecked$	 FalseY�. ��� $" circle�� � �� �	#01000000�� $" circle��8   �@J�EffectP�  �@J�IsMouseOver	 . . ��� $" circle�� � ��
 � � ��� $" content�� � ��
 � � ��� $" circle��8   �@J�Effect]�  ��  �@d�	IsChecked$
 TrueY���  �@J�IsMouseOver . ./��� $" circle��8   � ��]�  ��  �@d�	IsChecked$
 TrueY���  � �� . ./��� $" circle��8   � ���� " ��.���  � ��$ 20(���  � ��$
 auto����  � ��$ 50����  � ��$ Light"���  � ��8   ��  � ��8  ��  � �� �� "
 ��.R�(� .���� $ outerBorder��$ 0q�$��5q�#��z��#��z��$��1q�$ 14��$ 1Q�#��z��._��� $ Conntent��$��
12,-2,12,2q�#��z��#��z��$ Center=� P�  �@J�IsMouseOver	 . . ��� 8   �@J�EffectP�  � ��	 . . ��� 8   �@J�Effect P�  � {�	 . . ���  �@J�Effect8  P�  � {�	 .  . ���  �@J�Effect8  ��  � ��8  P�  �@J�IsMouseOver	 . . ���  �@J�Opacity$ 1Q���  �@J�Effect8  P�  � ��	 . . ���  �@J�Effect8  �� " ��.���  � ��$ NoWrap=���  � ��$
 None=���  � ��8   ��  � ��$ 32(���  � ��$	 165�� P�  �@J�IsMouseOver	 . . ���  � ��
 �   ��� .R�� $��16��$��16��.+�A� 
���  ��
�������$��.5���� $ Center=�
�������$
��Bold"�$��16��$��Center=�$��10(����� *	Counter+�� " � P�  �@J�	IsVisible	 .  �� .���� .��W� $ Width�8   $# 0X��� " ��.���  � �� �	#01000000��  � ��$ 40����  � ��$ 40����  �@d�	IsChecked$ FalseY���  � ��8   ��  �@J�Effect8  ��  �@^�	Placement$ Bottom=� P�  �@d�	IsChecked$	 FalseY� �� .���� .���� $ Foreground.Color�8`  8  W� $ Background.Opacity�$
 0.01X�8   �� .���� .���� $ Foreground.Color�8`  8  W� $ Background.Opacity�$ 1X�8  P�  �@J�IsMouseOver	 . . ���  �@J�Effect8  ]�  ��  �@J�IsMouseOver . ��  �@d�	IsChecked$
 TrueY�./���  �@J�Effect8 	 P�  � ��	 . . ���  �@J�Effect8 
 