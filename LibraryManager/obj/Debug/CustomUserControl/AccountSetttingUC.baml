   M S B A M L   `   `   `  ����I  ELibraryManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:LibraryManager.CustomUserControl LibraryManager.CustomUserControl  5      S.clr-namespace:LibraryManager.CustomUserControl LibraryManager.CustomUserControl  5
      8    2LibraryManager.CustomUserControl.AccountSetttingUC   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      @local.clr-namespace:LibraryManager.CustomUserControl     5      =uc.clr-namespace:LibraryManager.CustomUserControl     5
      U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      -   5          >�Name$  accountSetttingUC��5      ���#fafafa � 	Resources 5       �� 
TargetType "  MaterialDesignRaisedDarkButton �� BasedOn+  %MaterialDesignThemes.Wpf.ButtonAssist �� Property �� Value'  !MaterialDesignThemes.Wpf.PackIcon#  MaterialDesignThemes.Wpf.Card+  %MaterialDesignThemes.Wpf.ShadowAssist % !MaterialDesignFloatingHintTextBox ) %MaterialDesignFloatingHintPasswordBox)  #MaterialDesignThemes.Wpf.HintAssist.  (MaterialDesignThemes.Wpf.TextFieldAssist��%�  '��       7   '  l    '  (    '�� �    7  'G� �    7  '�� �    �� 5   
   " ��6   8   .�5      ��  �@ CornerRadius$ 10��6I   �� 5       � �� �#001e516+   �� 5       � ��$ Stretch=�62   �� 5       � ��$ Stretch=�64   �� 5       � ��$
 auto��6'   �� 5       � ��$
 auto��6&   �� 5       � ��$ 25(�6)   �� 5       � ��$
 10 0q�6'   5      �� 5   
   "  6   .�5      ��  � ��$ 48��6'   �� 5       � ��$ 48��6&   �� 5       � ��$ Center=�64   �� 5       � ��$ Center=�62   5       �� 5"   
   "  6   .�5#      ��  � ��$ 0q�6(   �� 5$       � ��$ Stretch=�64   �� 5%       � ��$ Stretch=�62   �� 5&       �@ ShadowDepth$ Depth3=�6H   5'      �� 5)   
   " ��6   8   .�5*      ��  � ��$ Center=�62   �� 5+       � ��$ 20 10q�6'   �� 5,       � ��$ 18(�6)   5-      �� 5/   
   " G�6   8   .�50      ��  � ��$ 20(�6)   �� 51       � ��$ Center=�62   �� 52       � ��$ Stretch=�64   �� 53       �@ 
Foreground
 � � �6E   �� 54       �@ UnderlineBrush
 � � �6N   �� 55       � ��$ 20 10q�6'   56      �� 58   
   " ��6   .�59      ��  � ��
 �  ��6+   �� 5:       � y�$ Hidden=�6+   �� 5;       � ��$ 1��6)   �� 5<       � ��$ 20 -2q�6'   5=      5?      .��5A      �  � RowDefinitions 5B   
   �� 5C      $��8* �6   �� 5D      $��5* �6    � ColumnDefinitions 5G   
   �� 5H      �� 5I      .+�5M   
     $��
10 10 5 10q�6   $��0��62   $��2��6B   .��5N      � $��Stretch=�6   $��Center=�61    5P      �� 5Q      $��8* �6$   �� 5R      $��2* �6$   .+�5U      ��  �� Orientation$ Vertical=�6   .+�5V      �� $��THÔNG TIN CÁ NHÂN��6    $��10 30 10 10q�69   $��Center=�5W       $��Center=�6;   $��30(�5X       $��DemiBold"�6.   ���#001e51$y�Visible=�6Y   �� 5[      -   5        	 ��Name$	 tbxLastName��5[   M   
   Hint$
 Họ và tên đệm��6   ��5\      �� *PersonEdit.LastName+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ OneWay=�.��6u   .  (System.Windows.Interactivity.Interaction   Triggers 5]      /  )System.Windows.Interactivity.EventTrigger  5^         	EventName$ 	LostFocus��6-   .	  (System.Windows.Interactivity.TriggerBase 	  Actions. 5_   "   6
  0System.Windows.Interactivity.InvokeCommandAction
   
  Command 68   �� *LostFocusNameTextBoxCommand+ 
  CommandParameter 5`   8   ��  �� ElementName$ tbxLastName��5a      .��5b   2   5c      �� 5e      -   5         ��Name$ tblLastNameWarning��5e   >   $(��"Họ không được để trống��6    6>   �� 5h      -   5        $	 tbxFirstName��5h   D   $

 Tên��6   ��5i   #   �� *PersonEdit.FirstName+$ PropertyChanged=�$ OneWay=�.��6{    5j        5k      $ 	LostFocus��6-   . 5l   "   
   68   �� *LostFocusNameTextBoxCommand+ 5m   8   �� $ tbxFirstName��5n      .��5o   2   5p      �� 5r      -   5        $ tblFirstNameWarning��5r   ?   $(��"Tên không được để trống��6    6?   � 5u       5v      �� 5w      �� 5x      .+�5{      � $��0��6    5|      �� 5}   "   �� 5~   "   $
��auto �60   .+�5�      �� -   5         ��Name$ cbxSex��5�   R   $
 Giới tính��6'   $��20 10q�5�   '   $��18(�66      HintOpacity$	 .26Q�6D   ��5�   '   �� *	ListSex+ �� SelectedItem 5�   '   �� *PersonEdit.Sex+$ PropertyChanged=�$ OneWay=�5�   D   �� 5�      -   5        $ tblSexWarning��5�   >   $��Chọn giới tính��6(   6>   5�      � 5�      $��1��6    5�      �� 5�   "   �� 5�   "   $
��auto �60   .+�5�      (  "System.Windows.Controls.DatePicker  -   5          Name$ dtpkBirthday��5�   U   $
 
Ngày sinh��6)   $��20 10q�5�   )   $��18(�68    ( $MaterialDesignFloatingHintDatePicker#��[ 5�   )      SelectedDate 5�   )   �� *PersonEdit.BirthDay+$ PropertyChanged=�$ OneWay=�5�   )   �� 5�      -	   5        $ tblBirthdayWarning��5�   M   $.��(Ngày sinh không được để trống��6(   6M   5�      5�      �� 5�      -
   5        $	 tbxEmail��5�   E   $
 Email��6   ��5�      �� *PersonEdit.Email+$ PropertyChanged=�$ OneWay=��� 5�      -   5        $ tblEmailWarning��5�   ;   $��Email sai định dạng��6    6;   �� 5�      -   5        $	 tbxPhone��5�   J   $
 Điện thoại��6   ��5�      �� *PersonEdit.Phone+$ PropertyChanged=�$ OneWay=��� 5�      -   5        $ tblPhoneWarning��5�   9   $��Số điện thoại sai��6    69   5�      � 5�      $��1��6   $��20q�6$    5�      �� 5�      �� 5�      .+�5�      ��  � ToolTip$ Hoàn tất��6   $��0��5�       �� 	IsDefault . ��5�      �� *	OKCommand+��5�      �� $ accountSetttingUC��.��5�      �� $ 
Horizontal=�6%   .+�5�        �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ TickAll=�66   $��0��6E   �� 5�      $��HOÀN TẤT��6(   
�������$��Center=�6K   $��Center=�6h   $y�Visible=�6�   6�   5�      5�      �� 5�      $ Hoàn tất��6   $��1��5�       �� IsCancel . ��5�      �� *CancelCommand+��5�      �� $ accountSetttingUC��.��5�      �� $ 
Horizontal=�6%   .+�5�        $ Multiply=�66   �� 5�      $��HỦY��6(   
�������$��Center=�6F   $��Center=�6c   $y�Visible=�6~   6�   5�      5�      5�      5�      5�        5�   
   $��	5 10 10 5q�6   $��1��61   $��0��6A   .��5�      �  5�      �� 5�      �� 5�      $
��auto �6$   .+�5�      �� $ Vertical=�6   $��0��64   .+�5�      �� $��ĐỔI MẬT KHẨU��6    $��
10 30 10 0q�64   $��Center=�5�       $��Center=�6;   $��30(�5�       $��DemiBold"�6.   ���#001e51$y�Visible=�6Y   G� 5�      -   5         G�Name$ pwxPassword��5�   U   $
 Mật khẩu hiện tại��6"   6U   �� 5�      -   5        $ tblPasswordWarning��5�   4   $��Mật khẩu sai��6    64   G� 5�      -   5        $ pwxPasswordNew��5�   P   $
 Mật khẩu mới��6"   6P   �� 5�      -   5        $ tblPasswordNewWarning��5�   J   $7��1Mật khẩu có độ dài ít nhất 5 ký tự��6    6J   G� 5�      -   5        $ pwxRetypePasswordNew��5�   Y   $%
 Nhập lại mật khẩu mới��6"   6Y   �� 5�      -   5        $! tblRetypePasswordNewWarning��5�   :   $��Mật khẩu không kớp��6    6:   5�      � 5�      $��1��6   $��20q�6$    5�      �� 5�      �� 5�      .+�5�      �� $ Hoàn tất��6   $��0��5�       . ��5�      �� *OKPasswordCommand+��5�      �� $ accountSetttingUC��.��5�      �� $ 
Horizontal=�6%   .+�5�        $ TickAll=�66   $��0��6E   �� 5�      $��HOÀN TẤT��6(   
�������$��Center=�6K   $��Center=�6h   $y�Visible=�6�   6�   5�      5�      �� 5�      $ Hoàn tất��6   $��1��5�       . ��5�      �� *CancelPasswordCommand+��5�      �� $ accountSetttingUC��.��5�      �� $ 
Horizontal=�6%   .+�5�        $ Multiply=�66   �� 5�      $��HỦY��6(   
�������$��Center=�6F   $��Center=�6c   $y�Visible=�6~   6�   5�      5�      5�      5�      5�        5�   
   $��	5 5 10 10q�6   $��1��61   $��1��6>   .��5�      �  5�      �� 5�      $
��auto �6$   �� 5�      �� 5      $
��auto �6$   .+�5     �� $��ẢNH ĐẠI DIỆN��6   $��10 30 10 10q�60   $y�Visible=�6F   $��0��6[   $��Center=�5     $��Center=�67   $��30(�5     $��DemiBold"�6*   ���#001e516@     5     $ About=�6*   $��Stretch=�67   $��90��6U   $��90��6a   $��1��6l   6{   �� 5	     $��10q�6   $��2��6%   .��5
     �� $ 
Horizontal=�6!   .+�5       $ Update=�62   $
��10 0q�6@   �� 5     $��ĐỔI ẢNH��6$   
�������$��Center=�6F   $��Center=�6c   $y�Visible=�6~   6�   5     5     5     5     5     5     