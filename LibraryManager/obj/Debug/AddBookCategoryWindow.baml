   M S B A M L   `   `   `  ����I  ELibraryManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:LibraryManagerLibraryManager  5   	   S.clr-namespace:LibraryManager.CustomUserControl LibraryManager.CustomUserControl  5	   	   *    $LibraryManager.AddBookCategoryWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:LibraryManager     5   	   =uc.clr-namespace:LibraryManager.CustomUserControl     5	   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   -   5          �Name$  addBookCategoryWindow��5   	    � Title$ Add Book Category��5   	      IconAddBook � Icon# [  5   	   $	��450��5   	   $	��600��6    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�5   	   .��5      �� ���#007acc$��3q�6#   ._�5   
   �  � 	Resources 5       �� 
TargetType  MaterialDesignRaisedButton �� BasedOn+  %MaterialDesignThemes.Wpf.ButtonAssist	 �� Property
 �� Value��%z  '��       7  �� 5      " ��6   8   .�5      �� 	 �@ CornerRadius$
 7��6Q   �� 5      	 � ��$
 10 10q�6/   �� 5      	 � ��$
 Stretch=�6<   �� 5      	 � ��$
 Stretch=�6:   �� 5      	 � ��$

 auto��6/   �� 5      	 � ��$

 auto��6.   �� 5      	 � ��
 �#001e5163   �� 5       	 � ��
 64   Z� 5!      5"      .+�5#      �  � RowDefinitions 5$      �� 5%      $��60 �6$   �� 5&      �� 5'      $
��auto �6$   .+�5+      � $��0��6   ���#007acc.+�5,      �� #��[  6   $��50��6B   $
��Left=�6N   $��5q�6i   �� 5-      $��THÊM CHUYÊN MỤC SÁCH��6    
�������$��30(�6O   $��Center=�6]   $��Center=�6z   5.      � 51      $��1��6    52       % !MaterialDesignFloatingHintTextBox��%M  '��       7  '�� �     �� 53      " ��6    8   .�54      �� 	 � ��$
 Center=�6B   �� 55      	 � ��$
 20 10q�67   �� 56      	 � ��$
 18(�69   57      �� 59      " ��6    .�5:      �� 	 � ��$
 20 -2q�67   �� 5;      	 � ��

 �  ��6;   �� 5<      	 � y�$
 Hidden=�6;   5=      5>      .+�5@      �� $��0 50 0 0q�6!   .+�5B      �� -   5         ��Name$ tbxId��5B   Q   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Mã chuyên mục��6"   6Q   �� 5D      -   5         ��Name$ tblIdWarning��5D   C   $'��!Mã không được để trống��6$   6C   �� 5F      -   5        $ tbxName��5F   R   $ Tên chuyên mục��6"   6R   �� 5H      -   5        $ tblNameWarning��5H   C   $(��"Tên không được để trống��6$   6C   �� 5J      -   5        $ tbxBorrowTime��5J   U   $ Số ngày cho mượn��6#   6U   �� 5L      -   5        $ tblBorrowTimeWarning��5L   H   $,��&Vui lòng nhập số ngày hợp lệ��6$   6H   5N      5O      � 5R      $��2��6    5S      '  !MaterialDesignThemes.Wpf.PackIcon��%>  '��       '  �     �� 5T      " ��6    .�5U      �� 	 � ��$
 18(�69   �� 5V      	 � ��$
 Center=�6D   �� 5W      	 � ��$
 Center=�6B   5X      �� 5Z      "  6    .�5[      �� 	 � ��$
 36��67   �� 5\      	 � ��$
 36��66   �� 5]      	 � ��$

 10 0q�67   5^      5_       � ColumnDefinitions 5a      �� 5b      �� 5c      .+�5g      ��  � ToolTip$ Hoàn tất��6   $��0��60    �� 	IsDefault . ��5h      �� *	OKCommand+��5i      ��  �� ElementName$ addBookCategoryWindow��.��5j      ��  �� Orientation$ 
Horizontal=�6%   .+�5k        �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ TickAll=�66   $��0��6E   �� 5l      $��HOÀN TẤT��6(   $��1��68   6J   5m      5n      �� 5q      $ Hủy��6   $��2��6+    �� IsCancel . ��5r      �� *CancelCommand+��5s      �� $ addBookCategoryWindow��.��5t      �� $ 
Horizontal=�6%   .+�5u        $ Multiply=�66   $��0��6F   �� 5v      $��HỦY��6(   $��1��63   6E   5w      5x      5y      5z      5{      5|      5}      