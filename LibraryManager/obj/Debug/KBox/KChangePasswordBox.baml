   M S B A M L   `   `   `  ����I  ELibraryManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:LibraryManager.KBoxLibraryManager.KBox  5   	   ,    &LibraryManager.KBox.KChangePasswordBox   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:LibraryManager.KBox     5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   -   5          �Name$  kChangePasswordBox��5
   	      	IconInput � Icon# [  5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	   $	��350��5   	   $	��500��6    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�5   	    � 	Resources 5       �� 
TargetType " MaterialDesignRaisedDarkButton �� BasedOn+  %MaterialDesignThemes.Wpf.ButtonAssist �� Property	 �� Value ) %MaterialDesignFloatingHintPasswordBox)  #MaterialDesignThemes.Wpf.HintAssist.  (MaterialDesignThemes.Wpf.TextFieldAssist��%O  '��       7  'G� j    7  '�� �    �� 5   
   " ��6   8   .�5      ��  �@ CornerRadius$	 10��6I   �� 5       � ��	 �#001e516+   �� 5       � ��$	 Stretch=�62   �� 5       � ��$	 Stretch=�64   �� 5       � ��$	 40��6'   �� 5       � ��$		 200��6&   �� 5       � ��$	 20(�6)   �� 5       � ��$	 10 10q�6'   5      �� 5!   
   " G�6   8   .�5"      ��  � ��$	 20(�6)   �� 5#       � ��$	 Center=�62   �� 5$       � ��$	 Stretch=�64   �� 5%       �@ 
Foreground
	 � � �6E   �� 5&       �@ UnderlineBrush
	 � � �6N   �� 5'       � ��$	 20 10q�6'   5(      �� 5*   
   " ��6   .�5+      ��  � ��
	 �  ��6+   �� 5,       � ��$	 1��6)   �� 5-       � ��$	 20 -2q�6'   5.      50      .��52      �� ���#007acc$��3q�6#   ._�53   
   � 
 � RowDefinitions
 54      �� 55      $��40 �6    �� 56      �� 57      $
��auto �6    .+�5;      � -   5        $��0��5;      ���#007acc.+�5<      �� #��[  6   $��30��6<   $
��Left=�6H   $��5q�6c   �� 5=      -   5         ��Name$ tblTitle��5=      $��ĐỔI MẬT KHẨU��6.   
�������$��30(�6U   $��Center=�6c   $��Center=�6�   �� 5?      -   5         � ToolTip$ Close��5?      
�������$��Right=�6<   .��5@      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ WindowClose=�6.   ��5A      �� 5B      " ��6    .�5C      ��  � ��	 6;   Z� �� 5D       � ��	 6<   Z� �� 5E       � ��$	 30��67   �� 5F       � ��$	 30��66   �� 5G       � ��$	 Center=�6D   �� 5H       � ��$	 Center=�6B   �� 5I       � ��
	 �����6;   �� 5J       � ��	 5K   "   �� 5L   &    �� 
TargetType" ��66   .R�5M   *   ��  ��Name$ Border��61   
������ ._�5N   .   �� $��Center=�6?   $��Center=�6\   5O   +    �� Triggers 5P   *   P� 5Q   .    P� Property �@J�IsMouseOver P� Value . . �5R   2   ��  �� 
TargetName$ Border��6[    � ��
	 �  ��5S   /   5U   '   5W      5X      5Z      5[      � 5]      $��1��6   .+�5^      ��  �� Orientation$ Vertical=�6   $
��0 10q�64   .+�5a      G� -   5         G�Name$ pwxPassword��5a   U      Hint$ Mật khẩu hiện tại��6"   6U   �� 5b      -   5        $ tblPasswordWarning��5b   4   $��Mật khẩu sai��6    $y�Hidden=�6P   G� 5e      -   5        $ pwxPasswordNew��5e   P   $ Mật khẩu mới��6"   6P   �� 5f      -   5        $ tblPasswordNewWarning��5f   J   $7��1Mật khẩu có độ dài ít nhất 5 ký tự��6    $y�Hidden=�6i   G� 5i      -	   5        $ pwxRetypePasswordNew��5i   Y   $% Nhập lại mật khẩu mới��6"   6Y   �� 5j      -
   5        $! tblRetypePasswordNewWarning��5j   :   $��Mật khẩu không kớp��6    $y�Hidden=�6_   5l      5m      � 5o      $��2��6   $��Bottom=�6     � ColumnDefinitions 5p      �� 5q      �� 5r      .+�5v      �� -   5         ��Name$ btnOK��5v   )   $��0��6    �� 	IsDefault . $��Right=�5w   .   .��5x      �� -   5        $ 
tblButton1��5x       $��OK��64   
�������6>   5y      �� 5|      -   5        $ 	btnCancel��5|   )   $��1��6    �� IsCancel . $
��Left=�5}   -   .��5~      �� -   5        $ 
tblButton2��5~       $��Cancel��64   
�������6B   5      5�      5�      5�      5�      