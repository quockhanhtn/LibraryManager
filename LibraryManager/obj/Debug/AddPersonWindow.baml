   M S B A M L   `   `   `  ����I  ELibraryManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:LibraryManagerLibraryManager  5   	   S.clr-namespace:LibraryManager.CustomUserControl LibraryManager.CustomUserControl  5	   	   $    LibraryManager.AddPersonWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:LibraryManager     5   	   =uc.clr-namespace:LibraryManager.CustomUserControl     5	   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   -   5          �Name$  addPersonWindow��5   	    � Title$	 New��5   	      IconAddPerson � Icon# [  5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	   $	��550��5   	   $	��500��6    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�5   	    � 	Resources 5       �� 
TargetType " MaterialDesignRaisedDarkButton �� BasedOn+  %MaterialDesignThemes.Wpf.ButtonAssist	 �� Property
 �� Value % !MaterialDesignFloatingHintTextBox��%%  '��       7  '�� m    7  �� 5   
   " ��6   8   .�5      �� 	 �@ CornerRadius$
 10��6I   �� 5      	 � ��
 �#001e516+   �� 5      	 � ��$
 Stretch=�62   �� 5      	 � ��$
 Stretch=�64   �� 5      	 � ��$

 auto��6'   �� 5      	 � ��$

 auto��6&   �� 5      	 � ��$
 25(�6)   �� 5       	 � ��$
 10 10q�6'   5!      �� 5#   
   " ��6   8   .�5$      �� 	 � ��$
 Center=�62   �� 5%      	 � ��$
 20 10q�6'   �� 5&      	 � ��$
 18(�6)   5'      5)      .��5+      �� ���#007acc$��3q�6#   ._�5,   
   �  � RowDefinitions 5-      �� 5.      $��50 �6    �� 5/      �� 50      $��70 �6    .+�54      � $��0��6   ���#007acc.+�55      �� #��[  6   $��50��6@   $
��Left=�6L   $��5q�6g   �� 56      
�������$��30(�6F   $��Center=�6T   $��Center=�6q   ��6   �� *Title+6q   57      � 5:      $��1��6   $
��0 20q�6    .+�5;      ��  5<      ��%M  '��       7  '�� �     �� 5=      " ��6    8   .�5>      �� 	 � ��$
 Center=�6B   �� 5?      	 � ��$
 20 10q�67   �� 5@      	 � ��$
 18(�69   5A      �� 5B      " ��6    .�5C      �� 	 � y�$
 Hidden=�6;   �� 5D      	 � ��

 �  ��6;   �� 5E      	 � ��$
 20 -2q�67   5F      5G      .+�5J      �� -   5         ��Name$ tbxLastName��5J   M   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Họ và tên đệm��6   ��5K      �� *LibrarianSelected.LastName+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ OneWay=�.��6|   .  (System.Windows.Interactivity.Interaction   Triggers 5L      /  )System.Windows.Interactivity.EventTrigger  5M         	EventName$ 	LostFocus��6-   .  (System.Windows.Interactivity.TriggerBase   Actions. 5N   "   6  0System.Windows.Interactivity.InvokeCommandAction     Command 68   �� *LostFocusNameTextBoxCommand+   CommandParameter 5O   $   ��  �� ElementName$ tbxLastName��5P      .��5Q   2   5R      �� 5T      -   5         ��Name$ tblLastNameWarning��5T   >   $(��"Họ không được để trống��6    6>   �� 5W      -   5        $ tbxFirstName��5W   C   $
 Tên��6   ��5X      �� *LibrarianSelected.FirstName+$ PropertyChanged=�$ OneWay=�.��6}    5Y        5Z      $ 	LostFocus��6-   . 5[   "      68   �� *LostFocusNameTextBoxCommand+ 5\   $   �� $ tbxFirstName��5]      .��5^   2   5_      �� 5a      -   5        $ tblFirstNameWarning��5a   ?   $(��"Tên không được để trống��6    6?   � 5d       � ColumnDefinitions 5e      �� 5f      �� 5g      .+�5k      � $��0��6    5l      �� 5m   "   �� 5n   "   $
��auto �60   .+�5q      �� -   5         ��Name$ cbxSex��5q   R   $ Giới tính��6'   $��20 10q�5r   /   $��18(�6>   $��0��6L      HintOpacity$	 .26Q�5u   /   ��5s   /   �� *	ListSex+ �� SelectedItem 5t   /   �� *LibrarianSelected.Sex+$ OneWay=�$ PropertyChanged=�5u   /   �� 5w      -   5        $ tblSexWarning��5w   >   $��Chọn giới tính��6(   $��1��6U   5x      � 5{      $��1��6    5|      �� 5}   "   �� 5~   "   $
��auto �60   .+�5�      (  "System.Windows.Controls.DatePicker  -   5          Name$ dtpkBirthday��5�   T   $ 
Ngày sinh��6)   $��20 10q�5�   1   $��18(�6@   $��0��6N    ( $MaterialDesignFloatingHintDatePicker#��[ 5�   1      SelectedDate 5�   1   �� *LibrarianSelected.BirthDay+$ PropertyChanged=�5�   1   �� 5�      -	   5        $ tblBirthdayWarning��5�   >   $��Chọn ngày sinh��6(   $��1��6Z   5�      5�      �� 5�      -
   5        $ tbxEmail��5�   E   $ Email��6   ��5�   *   �� *LibrarianSelected.Email+$ PropertyChanged=�$ OneWay=��� 5�      -   5        $ tblEmailWarning��5�   ;   $��Email sai định dạng��6    6;   �� 5�      -   5        $ tbxPhone��5�   J   $ Điện thoại��6   ��5�   *   �� *LibrarianSelected.Phone+$ PropertyChanged=�$ OneWay=��� 5�      -   5        $ tblPhoneWarning��5�   9   $��Số điện thoại sai��6    69   5�      5�      � 5�      $��2��6    5�      �� 5�      �� 5�      .+�5�      �� $��0��67    � ToolTip$ Hoành thành��5�       �� 	IsDefault . ��5�      �� *	OKCommand+��5�      �� $ addPersonWindow��.��5�      �� $
��Xong��6    
�������6,   5�      �� 5�      $��1��6;   $ Hủy��5�       �� IsCancel . ��5�      �� *CancelCommand+��5�      �� $ addPersonWindow��.��5�      �� $��Hủy��6    
�������6+   5�      5�      5�      5�      5�      