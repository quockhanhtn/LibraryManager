   M S B A M L   `   `   `  ����I  ELibraryManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:LibraryManager.CustomUserControl LibraryManager.CustomUserControl  5      S.clr-namespace:LibraryManager.CustomUserControl LibraryManager.CustomUserControl  5
      6    0LibraryManager.CustomUserControl.MemberManagerUC   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      @local.clr-namespace:LibraryManager.CustomUserControl     5      =uc.clr-namespace:LibraryManager.CustomUserControl     5
      U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      -   5          >�Name$  memberManagerUC��5      ���#fafafa J� InputBindings 5      �� 5   
    �� Gesture$ CTRL+N��5       �� Command 5      �� *AddLibrarianCommand+ �� CommandParameter 5      ��  �� ElementName$ 
mainWindow��5      .��5      �  � 	Resources 5   
    �� 
TargetType "  MaterialDesignRaisedDarkButton �� BasedOn+  %MaterialDesignThemes.Wpf.ButtonAssist	 �� Property
 �� Value'  !MaterialDesignThemes.Wpf.PackIcon��%e  '��       7   '  k    �� 5      " ��6   8   .�5      �� 	 �@ CornerRadius$
 10��6M   �� 5      	 � ��
 �#001e516/   �� 5      	 � ��$
 Stretch=�66   �� 5      	 � ��$
 Stretch=�68   �� 5      	 � ��$

 auto��6+   �� 5       	 � ��$

 auto��6*   �� 5!      	 � ��$
 25(�6-   �� 5"      	 � ��$	
 5 5q�6+   5#      �� 5%      "  6   .�5&      �� 	 � ��$
 30��6+   �� 5'      	 � ��$
 30��6*   �� 5(      	 � ��$

 10 0q�6+   �� 5)      	 � ��$
 Center=�68   �� 5*      	 � ��$
 Center=�66   5+      5,       � ColumnDefinitions 5.   
   �� 5/      $��7* �6   �� 50      $��3* �6   .+�55   
   � $��0��6   .+�56      #  MaterialDesignThemes.Wpf.Card  +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth3=�6"   $��0q�6S   $��
10 10 5 10q�6`   $��Stretch=�6t   $��Stretch=�6�   .��57      �  � RowDefinitions 58      �� 59      $
��auto �6(   �� 5:      $
��auto �6(   �� 5;      .+�5?      � $��0��6   .+�5@      � $��0��6   .+�5A      �� $��DANH SÁCH THÀNH VIÊN��6(   $��Center=�5B   (   $��Center=�6E   $��30(�5C   (   $��DemiBold"�66   ���#001e51$��10 30 10 10q�5D   (   5E      5F      � 5I      -   5         �Name$ 	gridFiler��5I   (   $��1��6    5J      �� 5K      �� 5L      �� 5M      $
��auto �6/   .+�5Q      � $��0��6   .+�5R      �� -   5         ��Name$ cbxYearOfBirthFilter��5T   '   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 	Năm sinh��5R   '   $��20 10q�5S   '   $��18(�66      HintOpacity$	 .26Q�5V   '   ��5U   '   �� *ListYearOfBirthFilter+.  (System.Windows.Interactivity.Interaction   Triggers 5W   "   /  )System.Windows.Interactivity.EventTrigger  5X   &      	EventName$ SelectionChanged��65   .  (System.Windows.Interactivity.TriggerBase   Actions. 5Y   *   6	  0System.Windows.Interactivity.InvokeCommandAction	   	  Command 6@   �� *FilterCommand+ 	  CommandParameter 6b   �� $ 	gridFiler��5Z   '   5\      5]      � 5`      $��1��6   .+�5a      �� -   5        $ cbxIsBlockFilter��5b   '   $ Trạng thái��5a   '   $��20 10q�5c   '   $��18(�66   $	 .26Q�5e   '   ��5d   '   �� *ListIsBlockFilter+ 5f   "     5g   &   $ SelectionChanged��65   . 5h   *   	   6@   �� *FilterCommand+ 6b   �� $ 	gridFiler��5i   '   5k      5l      � 5o      $��2��6   .+�5p      �� $��XUẤT FILE EXCEL��5q   %    � ToolTip$> 8Xuất danh sách thành viên thư viện ra file Excel��5r   %   $��18(�5s   %   $��5q�63   ��5p   %   �� *ExportToExcelCommand+5s   3   5t      5u      � 5x      $��2��6   .+�5y      �� $
��Auto=�6'   $
��Auto=�6J   .��5z      �� $��Stretch=�5{   '   $��Stretch=�6C   
���   ���5z   '   �� *
ListMember+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=� �� SelectedItem 5|   '   �� *MemberSelected+$ PropertyChanged=�$ TwoWay=� 5}   "     5~   &   $ SelectionChanged��65   . 5   *   	   6@   �� *MemberSelectedChanged+ 6j   �� $ memberManagerUC��5�   '    �� View 5�   "   �� 5�   &   .P�5�   *   �� $	��Mã��69    �� CellTemplate 5�   .   �� 5�   2   .R�5�   6   �� 
���   ���6S   �� *Id+6i   5�   3   5�   +   �� 5�   *   $
��Họ��69    �� Width$	 200��6E    5�   .   �� 5�   2   .R�5�   6   �� 
���   ���6S   �� *
LastName+6o   5�   3   5�   +   �� 5�   *   $
��Tên��69   $	 100��6F    5�   .   �� 5�   2   .R�5�   6   �� 
���   ���6S   �� *	FirstName+6p   5�   3   5�   +   �� 5�   *   $��Giới tính��69    5�   .   �� 5�   2   .R�5�   6   �� 
���   ���6S   �� *Sex+6j   5�   3   5�   +   �� 5�   *   $��
Ngày sinh��69    5�   .   �� 5�   2   .R�5�   6   �� 
���   ���6S   ��  �� Path$ BirthDay� �� StringFormat$ 
dd/MM/yyyy��6�   5�   3   5�   +   �� 5�   *   $��Email��69    5�   .   �� 5�   2   .R�5�   6   �� 
���   ���6S   �� *Email+6l   5�   3   5�   +   �� 5�   *   $��Điện thoại��69    5�   .   �� 5�   2   .R�5�   6   �� 
���   ���6S   �� *Phone+6l   5�   3   5�   +   �� 5�   *   $��Trạng thái��69   $	 100��6M    5�   .   �� 5�   2   .R�5�   6   �� 
���   ���6S   �� *Note+6k   5�   3   5�   +   5�   '   5�      5�      5�      5�      5�      5�      � 5�   
   $��1��6   .+�5�        $ Depth3=�6"   $��0q�6S   $��
5 10 10 10q�6`   $��Stretch=�6t   $��Stretch=�6�   .��5�      �  5�      �� 5�      $
��auto �6)   �� 5�      .+�5�      � $��0��6   .+�5�      ��  5�       % !MaterialDesignFloatingHintTextBox��%�   '��       7  �� 5�   "   " ��6(   8   .�5�   &   �� 	 � ��$
 Center=�6J   �� 5�   &   	 � ��$
 20 10q�6?   �� 5�   &   	 � ��$
 18(�6A   5�   #   5�      .+�5�      �� $��THÔNG TIN THÀNH VIÊN��6(   $��Center=�5�   (   $��Center=�6E   $��30(�5�   (   $��DemiBold"�66   ���#001e51$��10 30 10 10q�5�   (   �� 5�      -   5          ��Name$  tbxId��5�   &   $	 Mã��5�   &   ! �� 
IsReadOnly! . ��5�   &   �� *MemberSelected.Id+$ PropertyChanged=�$ OneWay=�� 5�       5�   "   �� 5�   &   �� 5�   &   $
��auto �64   .+�5�   "   �� -   5        $  tbxLastName��5�   Y   $ Họ và tên đệm��6*   $��0��6n   ��5�   *   �� *MemberSelected.LastName+$ PropertyChanged=�$ OneWay=�.��6�    5�   &     5�   *   $ LostKeyboardFocus��69   . 5�   .   	   6E   �� *LostFocusNameTextBoxCommand+ 5�   E   �� $ tbxLastName��5�   +   .��5�   >   5�   #   �� 5�   "   -   5        " ��Name$" tblLastNameWarning��5�   J   $(��"Họ không được để trống��6,   
���  ��$��2��5�   =   $��20 -2q�6J   $y�Hidden=�6Y   5�      � 5      5  "   �� 5  &   �� 5  &   $
��auto �64   .+�5  "   �� -   5        $  tbxFirstName��5  O   $
 Tên��6*   $��0��6e   ��5  *   �� *MemberSelected.FirstName+$ PropertyChanged=�$ OneWay=�.��6�    5
  &     5  *   $ LostKeyboardFocus��69   . 5  .   	   6E   �� *LostFocusNameTextBoxCommand+ 5  E   �� $ tbxFirstName��5  +   .��5  >   5  #   �� 5  "   -	   5        $" tblFirstNameWarning��5  K   $(��"Tên không được để trống��6,   
���  ��$��2��5  =   $��20 -2q�6J   $y�Hidden=�6Y   5     � 5      5  "   �� 5  &   �� 5  &   .+�5  "   � $��0��6'    5  &   �� 5   *   �� 5!  *   $
��auto �68   .+�5$  &   �� -
   5        $ cbxSex��5$  Z   $ Giới tính��6/   $��20 10q�5%  /   $��18(�6>   $��0��6L   $	 .26Q�5(  /   ��5&  /   �� *	ListSex+ 5'  /   �� *MemberSelected.Sex+$ OneWay=�$ PropertyChanged=�5(  /   �� 5*  &   -   5        $" tblSexWarning��5*  F   $��Chọn giới tính��60   
���  ��$��2��5+  A   $��20 -2q�6N   $y�Hidden=�6]   5,  #   � 5/  "   $��1��6'    50  &   �� 51  *   �� 52  *   $
��auto �68   .+�55  &   (
  "System.Windows.Controls.DatePicker
  -   5        # 
 Name$# dtpkBirthday��55  \   $ 
Ngày sinh��61   $��20 10q�56  1   $��18(�6@   $��0��6N    ( $MaterialDesignFloatingHintDatePicker#��[ 58  1   $ 
  SelectedDate$ 57  1   �� *MemberSelected.BirthDay+$ PropertyChanged=�58  1   �� 5:  &   -   5        $" tblBirthdayWarning��5:  F   $��Chọn ngày sinh��60   
���  ��$��2��5;  A   $��20 -2q�6N   $y�Hidden=�6]   5<  #   5=     � 5@      5A  "   �� 5B  &   �� 5C  &   $
��auto �64   .+�5F  "   �� -   5        $  tbxEmail��5F  Q   $ Email��6*   $��0��6c   ��5G  *   �� *MemberSelected.Email+$ PropertyChanged=�$ OneWay=��� 5I  "   -   5        $" tblEmailWarning��5I  G   $��Email sai định dạng��6,   $��1��5J  ,   
���  ��$��20 -2q�6J   $y�Hidden=�6Y   5K     � 5N      5O  "   �� 5P  &   �� 5Q  &   $
��auto �64   .+�5T  "   �� -   5        $  tbxPhone��5T  V   $ Điện thoại��6*   $��0��6h   ��5U  *   �� *MemberSelected.Phone+$ PropertyChanged=�$ OneWay=��� 5W  "   -   5        $" tblPhoneWarning��5W  E   $��Số điện thoại sai��6,   
���  ��$��1��5X  =   $��20 -2q�6J   $y�Hidden=�6Y   5Y     5[     5\     � 5_     $��1��6    5`     �� 5a     �� 5b      5e     �� 5f     $��2* �6,   �� 5g     $��1* �6,   .+�5k     � $��0��6   .+�5l     �� $ Cập nhật��6%   ��5m  %   �� *UpdateInforCommand+��5n  %   �� $ memberManagerUC��.��5p  "   �� % �� Orientation$% Vertical=�6-   .+�5q  &     �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]&   Kind$& AccountEdit=�6>   $��Center=�6Q   �� 5r  &   $��CẬP NHẬT��60   6B   5s  #   5t     5u     � 5x     $��1��6   .+�5y     �� -   5        ' ��Name$' btnBlock��5y  >   $ Khóa tài khoản��6%   ��5z  %   �� *BlockCommand+��5{  %   �� $ btnBlock��.��5|  "   �� $% Vertical=�6-   .+�5}  &     -   5        (  Name$( icoBlock��5}  g   $
& Lock=�6>   $��Center=�6J   6g   �� 5~  &   -   5        $" tblBlock��5~  <   $��KHÓA��60   6P   5  #   5�     5�     �� 5�     $ Thêm thành viên mới��6!   $��1��5�  !   $��2��5�  !   ��5�  !   �� *AddMemberCommand+.��5�     �� $% 
Horizontal=�6)   .+�5�  "     $& 
AccountAdd=�6:   $
��Left=�6L   �� 5�  "   $��THÊM THÀNH VIÊN��6,   6E   5�     5�     5�     5�     5�     5�     5�     5�     