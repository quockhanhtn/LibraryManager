   M S B A M L   `   `   `  ����I  ELibraryManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:LibraryManager.CustomUserControl LibraryManager.CustomUserControl  5      S.clr-namespace:LibraryManager.CustomUserControl LibraryManager.CustomUserControl  5
      9    3LibraryManager.CustomUserControl.LibrarianManagerUC   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      @local.clr-namespace:LibraryManager.CustomUserControl     5      =uc.clr-namespace:LibraryManager.CustomUserControl     5
      U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      -   5          >�Name$  librarianManagerUC��5      ���#fafafa.  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *LoadLoginWindowCommand+   CommandParameter 5   $   ��  �� ElementName$ 
mainWindow��5       J� InputBindings 5      �� 5   
    �� Gesture$ CTRL+N��5      	 �� Command	 5      �� *AddLibrarianCommand+
 �� CommandParameter
 5      �� $ 
mainWindow��5      �� 5   
   $ CTRL+E��5!      	 5      �� *ExitCommand+
 5       �� $ 
mainWindow��5!      �� 5#   
   $ ALT+E��5$      	 5#      �� *ExportToExcelCommand+5$      �� 5&   
   $ CTRL+B��5(      	 5&      �� *BookManagerCommand+
 5'      �� $ 
mainWindow��5(      �� 5*   
   $ CTRL+M��5,      	 5*      �� *MemberManagerCommand+
 5+      �� $ 
mainWindow��5,      �� 5.   
   $ ALT+N��5/      	 5.      �� *ChangeLibraryNameCommand+5/      .��53      �  � 	Resources 54   
    �� 
TargetType "  MaterialDesignRaisedDarkButton �� BasedOn+  %MaterialDesignThemes.Wpf.ButtonAssist �� Property �� Value'  !MaterialDesignThemes.Wpf.PackIcon��%e  '��       7   '  k    �� 55      " ��6   8   .�56      ��  �@ CornerRadius$ 10��6M   �� 57       � �� �#001e516/   �� 58       � ��$ Stretch=�66   �� 59       � ��$ Stretch=�68   �� 5:       � ��$
 auto��6+   �� 5;       � ��$
 auto��6*   �� 5<       � ��$ 25(�6-   �� 5=       � ��$	 5 5q�6+   5>      �� 5@      "  6   .�5A      ��  � ��$ 30��6+   �� 5B       � ��$ 30��6*   �� 5C       � ��$
 10 0q�6+   �� 5D       � ��$ Center=�68   �� 5E       � ��$ Center=�66   5F      5G       � ColumnDefinitions 5I   
   �� 5J      $��7* �6#   �� 5K      $��3* �6#   .+�5P   
   � $��0��6   .+�5Q      #  MaterialDesignThemes.Wpf.Card  +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth3=�6"   $��0q�6S   $��
10 10 5 10q�6`   $��Stretch=�6t   $��Stretch=�6�   .��5R      �  � RowDefinitions 5S      �� 5T      $
��auto �6(   �� 5U      $
��auto �6(   �� 5V      .+�5Z      � $��0��6   .+�5[      � $��0��6   .+�5\      �� $��DANH SÁCH NHÂN VIÊN��6(   $��Center=�5]   (   $��Center=�6E   $��30(�5^   (   $��DemiBold"�66   ���#001e51$��10 30 10 10q�5_   (   5`      5a      � 5d      $��1��6    5e      �� 5f      �� 5g      $
��auto �6/   .+�5k      � $��0��6   .+�5l      �� -   5         ��Name$ cbxSeLectLibrarian��5m   '   )	  #MaterialDesignThemes.Wpf.HintAssist 	  Hint$ 
Tất cả��5l   '   $��20 10q�5n   '   $��18(�66    	  HintOpacity$	 .26Q�5p   '   ��5o   '   �� *ListIsActiveFilter+ 5q   "     5r   &   $ SelectionChanged��65   . 5s   *      6@   �� *IsActiveFilterCommand+ 6j   �� $ cbxSeLectLibrarian�� �� Path$ SelectedValue�5t   '   5v      5w      � 5z      $��1��6   .+�5{      �� $��XUẤT FILE EXCEL��5|   %    � ToolTip$= 7Xuất danh sách nhân viên thư viện ra file Excel��5}   %   $��18(�5~   %   $��5q�63   ��5{   %   �� *ExportToExcelCommand+5~   3   5      5�      � 5�      $��2��6   .+�5�      �� $
��Auto=�6'   $
��Auto=�6J   .��5�      �� $��Stretch=�5�   '   $��Stretch=�5�   '   
���   ���5�   '   �� *ListLibrarian+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=� �� SelectedItem 5�   '   �� *LibrarianSelected+$ PropertyChanged=�$ TwoWay=� 5�   "     5�   &   $ SelectionChanged��65   . 5�   *      6@   �� *LibrarianSelectedChanged+ 6m   �� $ librarianManagerUC��5�   '    �� View 5�   "   �� 5�   &   .P�5�   *   �� $	��Mã��69    �� CellTemplate 5�   .   �� 5�   2   .R�5�   6   �� 
���   ���6S   �� *Id+6i   5�   3   5�   +   �� 5�   *   $
��Họ��69    5�   .   �� 5�   2   .R�5�   6   �� 
���   ���6S   �� *
LastName+6o   5�   3   5�   +   �� 5�   *   $
��Tên��69    5�   .   �� 5�   2   .R�5�   6   �� 
���   ���6S   �� *	FirstName+6p   5�   3   5�   +   �� 5�   *   $��Giới tính��69    5�   .   �� 5�   2   .R�5�   6   �� 
���   ���6S   �� *Sex+6j   5�   3   5�   +   �� 5�   *   $��
Ngày sinh��69    5�   .   �� 5�   2   .R�5�   6   �� 
���   ���6S   �� $ BirthDay� �� StringFormat$ 
dd/MM/yyyy��6�   5�   3   5�   +   �� 5�   *   $��Email��69    5�   .   �� 5�   2   .R�5�   6   �� 
���   ���6S   �� *Email+6l   5�   3   5�   +   �� 5�   *   $��Điện thoại��69    5�   .   �� 5�   2   .R�5�   6   �� 
���   ���6S   �� *Phone+6l   5�   3   5�   +   �� 5�   *   $��Ghi chú��69    5�   .   �� 5�   2   .R�5�   6   �� 
���   ���6S   �� *Note+6k   5�   3   5�   +   5�   '   5�      5�      5�      5�      5�      5�      � 5�   
   $��1��6   .+�5�        $ Depth3=�6"   $��0q�6S   $��
5 10 10 10q�6`   $��Stretch=�6t   $��Stretch=�6�   .��5�      �  5�      �� 5�      $
��auto �6)   �� 5�      .+�5�      � $��0��6   .+�5�      ��  5�       % !MaterialDesignFloatingHintTextBox��%M  '��       7  '�� �     �� 5�   "   " ��6(   8   .�5�   &   ��  � ��$ Center=�6J   �� 5�   &    � ��$ 20 10q�6?   �� 5�   &    � ��$ 18(�6A   5�   #   �� 5�   "   " ��6(   .�5�   &   ��  � y�$ Hidden=�6C   �� 5�   &    � ��
 �  ��6C   �� 5�   &    � ��$ 20 -2q�6?   5�   #   5�      .+�5�      �� $��THÔNG TIN NHÂN VIÊN��6(   $y�Visible=�6C   $��Center=�5�   (   $��Center=�6E   $��30(�5�   (   $��DemiBold"�66   ���#001e51$��10 30 10 10q�5�   (   �� 5�      -   5         ��Name$ tbxId��5�   &   $	 Mã��5�   &    �� 
IsReadOnly . ��5�   &   �� *LibrarianSelected.Id+$ PropertyChanged=�$ OneWay=��� 5�      -   5        $ tbxLastName��5�   U   $ Họ và tên đệm��6&   ��5�   &   �� *LibrarianSelected.LastName+$ PropertyChanged=�$ OneWay=��� 5      -   5          ��Name$  tblLastNameWarning��5   F   $(��"Họ không được để trống��6(   6F   �� 5     -   5        $ tbxFirstName��5  K   $
 Tên��6&   ��5  &   �� *LibrarianSelected.FirstName+$ PropertyChanged=�$ OneWay=��� 5     -   5        $  tblFirstNameWarning��5  G   $(��"Tên không được để trống��6(   6G   � 5	      5
  "   �� 5  &   �� 5  &   .+�5  "   � $��0��6'    5  &   �� 5  *   �� 5  *   $
��auto �68   .+�5  &   �� -   5        $ cbxSex��5  Z   $ Giới tính��6/   $��20 10q�5  /   $��18(�6>   $��0��6L   $	 .26Q�5  /   ��5  /   �� *	ListSex+ 5  /   �� *LibrarianSelected.Sex+$ OneWay=�$ PropertyChanged=�5  /   �� 5  &   -	   5        $  tblSexWarning��5  F   $��Chọn giới tính��60   $��1��6]   5  #   � 5   "   $��1��6'    5!  &   �� 5"  *   �� 5#  *   $
��auto �68   .+�5&  &   (
  "System.Windows.Controls.DatePicker
  -
   5        ! 
 Name$! dtpkBirthday��5&  \   $ 
Ngày sinh��61   $��20 10q�5'  1   $��18(�6@   $��0��6N    ( $MaterialDesignFloatingHintDatePicker#��[ 5)  1   " 
  SelectedDate" 5(  1   �� *LibrarianSelected.BirthDay+$ PropertyChanged=�5)  1   �� 5+  &   -   5        $  tblBirthdayWarning��5+  F   $��Chọn ngày sinh��60   $��1��6b   5,  #   5-     �� 50     -   5        $ tbxEmail��50  M   $ Email��6&   ��51  *   �� *LibrarianSelected.Email+$ PropertyChanged=�$ OneWay=��� 53     -   5        $  tblEmailWarning��53  C   $��Email sai định dạng��6(   6C   �� 55     -   5        $ tbxPhone��55  R   $ Điện thoại��6&   ��56  *   �� *LibrarianSelected.Phone+$ PropertyChanged=�$ OneWay=��� 58     -   5        $  tblPhoneWarning��58  A   $��Số điện thoại sai��6(   6A   5:     5;     � 5>     $��1��6    5?     �� 5@     �� 5A      5D     �� 5E     $��2* �6,   �� 5F     $��1* �6,   .+�5J     � $��0��6   .+�5K     �� $ Cập nhật��6%   ��5L  %   �� *UpdateInforCommand+��5M  %   �� $ librarianManagerUC��.��5O  "   �� # �� Orientation$# Vertical=�6-   .+�5P  &     �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]$   Kind$$ AccountEdit=�6>   $��Center=�6Q   �� 5Q  &   $��CẬP NHẬT��60   6B   5R  #   5S     5T     � 5W     $��1��6   .+�5X     �� -   5        % ��Name$% btnBlock��5X  9   $ Thôi việc��6%   ��5Y  %   �� *StopWorkCommand+.��5Z  "   �� $# Vertical=�6-   .+�5[  &     -   5        &  Name$& icoBlock��5[  Q   $$ BlockHelper=�6>   $��Center=�6c   �� 5\  &   -   5        $  tblBlock��5\  A   $��THÔI VIỆC��60   6U   5]  #   5^     5_     �� 5b     $ Thêm nhân viên mới��6!   $��1��5c  !   $��2��5d  !   ��5e  !   �� *AddLibrarianCommand+.��5f     �� $# 
Horizontal=�6)   .+�5g  "     $$ 
AccountAdd=�6:   $
��Left=�6L   �� 5h  "   $��THÊM NHÂN VIÊN��6,   6D   5i     5j     5k     5m     5n     5o     5p     5q     