   M S B A M L   `   `   `  ����I  ELibraryManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:LibraryManagerLibraryManager  5   	   S.clr-namespace:LibraryManager.CustomUserControl LibraryManager.CustomUserControl  5	   	        LibraryManager.LoginWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:LibraryManager     5   	   =uc.clr-namespace:LibraryManager.CustomUserControl     5	   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   -   5          �Name$  loginWindow��5   	    � Title$ Library Hub��5   	      LoginWindowVM � DataContext# [  5   	     IconLibrary � Icon# [ 5   	   ���#fafafa  MaterialDesignFont#���  5   	   $	��420��5   	   $	��500��6    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�5   	   .��5      �� ���#007acc$��3q�6#   ._�5   
   �  � 	Resources 5      '  !MaterialDesignThemes.Wpf.PackIcon �� 
TargetType	 �� Property
 �� Value " MaterialDesignRaisedDarkButton �� BasedOn+  %MaterialDesignThemes.Wpf.ButtonAssist��%�  '        '	� �     '�� x    7  �� 5      "  6   .�5      �� 	 � ��
 63   Z� �� 5      	 � ��$
 Center=�6<   �� 5      	 � ��$
 Center=�6:   �� 5       	 � ��$
 40��6/   �� 5!      	 � ��$
 40��6.   5"      �� 5$      " 	�6   .�5%      �� 	 � ��$
 Center=�6<   �� 5&      	 � ��$
 Center=�6:   �� 5'      	 � ��$
 20(�61   5(      �� 5*      " ��6   8   .�5+      �� 	 �@ CornerRadius$
 10��6Q   �� 5,      	 � ��
 �#001e5163   �� 5-      	 � ��$
 Stretch=�6:   �� 5.      	 � ��$
 Stretch=�6<   �� 5/      	 � ��$
 60��6/   50      51       � RowDefinitions 53      �� 54      $��60 �6    �� 55      .+�59      � $��0��6   ���#007acc.  (System.Windows.Interactivity.Interaction   Triggers 5:      /  )System.Windows.Interactivity.EventTrigger  5;         	EventName$ 	MouseDown��6%   .  (System.Windows.Interactivity.TriggerBase   Actions. 5<      6  0System.Windows.Interactivity.InvokeCommandAction     Command 60   �� *MouseMoveWindowCommand+   CommandParameter 6[   ��  �� ElementName$ loginWindow��5=      .+�5@      �  � ColumnDefinitions 5A      �� 5B      $��60 �6+   �� 5C      �� 5D      $��60 �6+   .+�5G        -   5          Name$ packIcon��5G   .   �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ LoginVariant=�6@   
�������6T   �� 5I      $��ĐĂNG NHẬP��6    $��1��61   $��Center=�6A   $��Center=�6^   $��30(�5J      $��DemiBold"�6*   
�������6@   �� 5L       � ToolTip$ Close��6   $��2��6-   ��5M      �� *ExitCommand+��5N      �� $ loginWindow����5O      Z� ��60   Z� .��5P        $ WindowClose=�62   
�������6E   5Q      5R      5S      � 5V      $��1��6    5W      �� 5X      $
��auto �6$   �� 5Y      $
��auto �6$   �� 5Z      $
��auto �6$   �� 5[      $
��auto �6$   �� 5\      .+�5`      � $��0��6   $��
20 40 20 5q�6$    5a      �� 5b      $
��auto �6+   �� 5c      .+�5f        $��0��6.   $ Person=�6>   $��0 0 10 0q�6L   �� 5h      -   5         ��Name$ tbxUserName��5h   .   $��1��6   )  #MaterialDesignThemes.Wpf.HintAssist   
Foreground
 � � �.	  (MaterialDesignThemes.Wpf.TextFieldAssist 	  UnderlineBrush
 � � � % !MaterialDesignFloatingHintTextBox#��[ 5j      $��25(�5k      $��Center=�6,   $��Stretch=�6G   .��6e      Hint 5l      �� 5m      $��Tên đăng nhập��6(   $��0 -8 0 0q�6=   $��20(�6O   .��5n   :   5o      5p      � 5s      $��1��6   $��
20 20 20 0q�6$   $��Center=�68   $��Stretch=�6S    5t      �� 5u      $
��auto �6+   �� 5v      .+�5y        $��0��6.   $	 Key=�6>   $��0 0 10 0q�6I   �� 5|      -   5        $ tbxPassWordShow��5|   .   $��1��6   $y�Hidden=�6H   
 � � �
 � � �#��[ 5~      $��25(�5      $	��3 0q�6,   .��69    5�      �� 5�      $��Mật khẩu��6(   $��0 -8 0 0q�68   $��20(�6J   .��5�   :   5�      G� 5�      -   5         G�Name$ tbxPassWord��5�   2   $��1��6"    ) %MaterialDesignFloatingHintPasswordBox#��[ 5�   "   $y�Visible=�6a   
 � � �
 � � �$��25(�5�   "   $	��3 0q�60    5�      �� 5�      $��Mật khẩu��6(   $��0 -8 0 0q�68   $��20(�6J   5�      �� 5�      -   5         ��Name$ imgIconShowPassword��5�        IconShowPassword#��[ 69   $��2��6d   $��30��6t   $��30��6�   $��Right=�6�    5�        5�      $ 	MouseDown��6-   . 5�   "      68   �� *ShowPasswordCommand+ 6`   �� $ loginWindow��5�      5�      5�      � 5�      $��2��6   .+�5�      �� -   5         ��Name$ tblLoginFail��5�       $0��*Sai mật khẩu hoặc tên đăng nhập��66   
���  ��$��Center=�5�       $��Center=�6;   $y�Hidden=�6X   5�      � 5�      $��3��6   $��
20 25 20 5q�6$    5�      �� 5�      �� 5�      �� 5�      .+�5�      	� -   5         	�Name$ 
rbtnMember��5�   "   $��0��66    d� 	IsChecked$
 TrueY�6F   $
��Left=�5�       + 'MaterialDesignUserForegroundRadioButton#��[ 69   .��5�      � $��	0 -12 0 0q�6$     � Orientation$  Vertical=�67   .+�5�        $ Library=�66   $��20��6E   $��20��6Q   
���2�2�6\   �� 5�      $��Thành viên��6(   $��22(�6:   5�      5�      	� 5�      -	   5        $ rbtnLibrarian��5�   "   $��1��69   $��Center=�5�      #��[ 6;   .��5�      � $��	0 -12 0 0q�6$   $  Vertical=�67   .+�5�        $ Account=�66   $��20��6E   $��20��6Q   
��� ���6\   �� 5�      $��Nhân viên��6(   $��22(�69   5�      5�      	� 5�      -
   5        $ 	rbtnAdmin��5�   "   $��2��65   $��Right=�5�      #��[ 6:   .��5�      � $��	0 -12 0 0q�6$   $  Vertical=�67   .+�5�        $ SecurityAccount=�66   $��20��6M   $��20��6Y   
���  ��6d   �� 5�      $��Quản trị viên��6(   $��22(�6=   5�      5�      5�      � 5�      $��4��6   $��10 10q�6$    5�      �� 5�      �� 5�      .+�5�      �� $��0��6   $ Thoát��6-   ! �� IsCancel! . $��	10 5 5 10q�6M   ��5�      �� *ExitWithoutWarningCommand+��6K   �� $ loginWindow��.��5�      �� $��THOÁT��6$   $��22(�61   5�      �� 5�      $��1��6   $ Đăng nhập��6-   " �� 	IsDefault" . $��	5 5 10 10q�6R   ��5�      �� *LoginCommand+��6>   �� $ loginWindow��.��5�      �� $��ĐĂNG NHẬP��6$   $��22(�65   5�      5�      5�      5�      5�      5�      