   M S B A M L   `   `   `  ����I  ELibraryManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:LibraryManagerLibraryManager  5   	   S.clr-namespace:LibraryManager.CustomUserControl LibraryManager.CustomUserControl  5   	       LibraryManager.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:LibraryManager     5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5
   	   7uc.clr-namespace:LibraryManager.CustomUserControl  5   	   -   5          �Name$  
mainWindow��5   	      MainWindowVM � DataContext# [  5   	     IconLibrary � Icon# [ 5   	    � Title$ Library Hub��5   	   $	��768��5   	   $
��1366��6    � WindowStartupLocation$ CenterScreen=�6#    � 
ResizeMode$ NoResize=�6H    � WindowStyle$
 None=�6^   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase	   Actions.	 5      6  0System.Windows.Interactivity.InvokeCommandAction  
   Command
 6$   �� *LoadLoginWindowCommand+   CommandParameter 5   $   ��  �� ElementName$ 
mainWindow��5       J� InputBindings 5      �� 5   
    �� Gesture$ CTRL+N��5        �� Command 5      �� *AddLibrarianCommand+ �� CommandParameter 5      �� $ 
mainWindow��5       �� 5"   
   $ CTRL+E��5$       5"      �� *ExitCommand+ 5#      �� $ 
mainWindow��5$      �� 5&   
   $ ALT+E��5'       5&      �� *ExportToExcelCommand+5'      �� 5)   
   $ CTRL+B��5+       5)      �� *BookManagerCommand+ 5*      �� $ 
mainWindow��5+      �� 5-   
   $ CTRL+M��5/       5-      �� *MemberManagerCommand+ 5.      �� $ 
mainWindow��5/      �� 51   
   $ ALT+N��52       51      �� *ChangeLibraryNameCommand+52       � 	Resources 55        OpenMenu �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value  	CloseMenu��%�  &	       &	 �     �� 56   
   .��57      U� $ (FrameworkElement.Width)�6,   $ GridMenu��6a   .\�58        $ 0��6'   $ 60Q�63     59      $ 0:0:0.5��6'   $	 300Q�69   5:      5;      �� 5<   
   .��5=      U� $ (FrameworkElement.Width)�6,   $ GridMenu��6a   .\�5>        $ 0��6'   $	 200Q�63     5?      $ 0:0:0.5��6'   $ 70Q�69   5@      5A      5B       � Triggers 5D      :� 5E   
    :� RoutedEvent$ ButtonBase.Click��6    :� 
SourceName$ ButtonOpenMenu��66   .[�5F      �� #��[ 6   5G      :� 5H   
   $ ButtonBase.Click��6   $ ButtonCloseMenu��66   .[�5I      �� #��[ 6   5J      .��5M      �� ���#007acc$��3q�6#   ._�5N   
   �  5O       �� 
TargetType �� Property �� Value'  !MaterialDesignThemes.Wpf.PackIcon��%�  '��       '  �     �� 5P      " ��6   .�5Q      ��  � ��
 �����63   �� 5R       � ��$ Center=�6:   �� 5S       � ��$ Center=�6<   5T      �� 5V      "  6   .�5W      ��  � ��$ 40��6/   �� 5X       � ��$ 40��6.   �� 5Y       � ��$ Center=�6<   �� 5Z       � ��$ Center=�6:   �� 5[       � ��
 �����63   5\      5]       � RowDefinitions 5_      �� 5`      $
��auto �6    �� 5a       � ColumnDefinitions 5d      �� 5e      $
��auto �6#   �� 5f      .+�5j      � -   5         �Name$ 	GridTitle��5j      $��80��6&   ���#007acc$	��Top=�6G   $��0��6_   $��2��6l    5l      �� 5m      �� 5n      .+�5q      ��  �� Orientation$ 
Horizontal=�6   $��Right=�66   $��1��6R   .+�5s      #  MaterialDesignThemes.Wpf.Chip  $��Quản trị viên��6*   $��20(�6B   ���#001e51  �� 	ClickMode$  Press=�6e   !   Icon$! Q��5t   &   
�������"   IconForeground" �#001e51#   IconBackground
# �������5u   &   �� *AccountInfoCommand+��5v   &   �� $ memberWindow��'  !MaterialDesignThemes.Wpf.PopupBox  5x      $   PlacementMode$$ BottomAndAlignRightEdges=�6.   %   	StaysOpen% .  $��0q�6i   
�������&   PopupContent.& 5y      �� $
��auto��6%   .+�5z      �� $��Đổi tên thư viện��6%   ��5{   !   �� *ChangeLibraryNameCommand+�� 5|      $��Đổi mật khẩu��6%   ��5}   !   �� *ChangePasswordCommand+�� 5~      �� 5      $��Đăng xuất��6%   ��5�   !   �� *LogoutCommand+��5�   !   �� $ 
mainWindow��5�      5�      5�      3	   -LibraryManager.CustomUserControl.ControlBarUC	  5�      $��0��6"   61   �� 5�        LibraryName#���  6   $��30(�6M   $��2��6[   5�      � 5�      -   5        $ GridMain��5�      
�������$��Stretch=�6;   $��Stretch=�6Y   $��1��6u   $��1��6�   � 5�      -   5        $ GridMenu��5�      $��60��6%   $
��Left=�60   ���#001e51$��2��6`   $��0��6q   .+�5�      �� .+�5�      � $��79��6   ���#001e51' J� RenderTransformOrigin$' 0.5,0.5&�6<   z�5�      V� 5�      .~�5�   "   �� �� 5�   "   �� 5�   "   T� 5�   "   5�      .+�5�      �� -   5        ( ��Name$( ButtonOpenMenu��5�   !   $��60��69   $��60��6E   $��5q�6P   $��Center=�6[   $��Center=�6x    0 ,MaterialDesignFloatingActionMiniAccentButton#��[ 6�   ���	#FF31577E��6�   Z� ��6�   Z� .��5�        �
  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]) 
  Kind$
) Menu=�66   
�������6B   5�      �� 5�      -   5        $( ButtonCloseMenu��5�   !   $y�	Collapsed=�6:   $��60��6Q   $��60��6]   $��5q�6h   $��Center=�6s   $	��Top=�6�   #��[ 6�   ���	#FF31577E��6�   Z� ��6  Z� .��5�        $) 	ArrowLeft=�66   5�      5�      �� 5�      $��1q�6   ���#007acc* �� Padding$* 0q�6G   �� 5�      -   5        + ��Name$+ ListViewMenu��5�      ���	#FF5C99D6$��Disabled=�6L    5�      ��%�   '��       �� 5�      " ��6$   .�5�   "   ��  � ��$ 20(�6=   �� 5�   "    � ��$
 Thin"�6?   �� 5�   "    � ��$ Center=�6F   �� 5�   "    � ��$ 1��6@   �� 5�   "    � ��
 �����6?   5�      5�       5�        5�      $ SelectionChanged��6-   .	 5�   "     
 68   �� *MenuSelectionChangedCommand+ 6h   �� $ 
mainWindow��5�      .@�5�      �� -   5        , ��Name$, LibrarianManager��5�   '   $��60��6A   .��5�      �  5�   "   �� 5�   &   $��60 �67   �� 5�   &   .+�5�   "     $) Library=�6:   $��0,0,15,0q�6I   �� 5�   "   $��Quản lý nhân viên��6,   5�      5�      �� 5�      -	   5        $, BookManager��5�   '   $��60��6<   .��5�      �  5�   "   �� 5�   &   $��60 �67   �� 5�   &   .+�5�   "     $
) Book=�6:   $��0,0,15,0q�6F   �� 5�   "   $��Quản lý sách��6,   5�      5�      �� 5�      -
   5        $, BookCategoryManager��5�   '   $��60��6D   .��5�      �  5�   "   �� 5�   &   $��60 �67   �� 5�   &   .+�5�   "     $) Category=�6:   $��0,0,15,0q�6J   �� 5�   "   $$��Quản lý chuyên mục sách��6,   5�      5�      �� 5�      -   5        $, MemberManager��5�   '   $��60��6>   .��5�      �  5�   "   �� 5�   &   $��60 �67   �� 5�   &   .+�5�   "     $) CardMembership=�6:   $��0,0,15,0q�6P   �� 5�   "   $��Quản lý thành viên��6,   5�      5�      5�      5�      5�      5�      5�      5�      