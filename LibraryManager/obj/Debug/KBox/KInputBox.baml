   M S B A M L   `   `   `  ����I  ELibraryManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:LibraryManager.KBoxLibraryManager.KBox  5   	   #    LibraryManager.KBox.KInputBox   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:LibraryManager.KBox     5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   -   5          �Name$  	kInputBox��5
   	      	IconInput � Icon# [  5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	   $	��250��5   	   $	��500��6    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�5   	    � 	Resources 5       �� 
TargetType " MaterialDesignRaisedDarkButton �� BasedOn+  %MaterialDesignThemes.Wpf.ButtonAssist �� Property	 �� Value % !MaterialDesignFloatingHintTextBox��%"  '��       7  '�� j    7  �� 5   
   " ��6   8   .�5      ��  �@ CornerRadius$	 10��6I   �� 5       � ��	 �#001e516+   �� 5       � ��$	 Stretch=�62   �� 5       � ��$	 Stretch=�64   �� 5       � ��$	 40��6'   �� 5       � ��$		 200��6&   �� 5       � ��$	 20(�6)   �� 5       � ��$	 10 10q�6'   5      �� 5!   
   " ��6   8   .�5"      ��  � ��$	 Center=�62   �� 5#       � ��$	 20 10q�6'   �� 5$       � ��$	 25(�6)   5%      5'      .��5)      �� ���#007acc$��3q�6#   ._�5*   
   � 
 � RowDefinitions
 5+      �� 5,      $��40 �6    �� 5-      .+�51      � -   5        $��0��51      ���#007acc.+�52      �� #��[  6   $��30��6<   $
��Left=�6H   $��5q�6c   �� 53      -   5         ��Name$ tblTitle��53      $��TITLE��6.   
�������$��30(�6N   $��Center=�6\   $��Center=�6y   �� 55      -   5         � ToolTip$ Close��55      
�������$��Right=�6<   .��56      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ WindowClose=�6.   ��57      �� 58      " ��6    .�59      ��  � ��	 6;   Z� �� 5:       � ��	 6<   Z� �� 5;       � ��$	 30��67   �� 5<       � ��$	 30��66   �� 5=       � ��$	 Center=�6D   �� 5>       � ��$	 Center=�6B   �� 5?       � ��
	 �����6;   �� 5@       � ��	 5A   "   �� 5B   &    �� 
TargetType" ��66   .R�5C   *   ��  ��Name$ Border��61   
������ ._�5D   .   �� $��Center=�6?   $��Center=�6\   5E   +    �� Triggers 5F   *   P� 5G   .    P� Property �@J�IsMouseOver P� Value . . �5H   2   ��  �� 
TargetName$ Border��6[    � ��
	 �  ��5I   /   5K   '   5M      5N      5P      5Q      � 5T      $��1��6   
 5U      �� 5V      �� 5W      $
��auto �6$   .+�5Z      � $��0��6   .+�5[      �� -   5         ��Name$ tbxInput��5[   *   $��20q�6   $��Nội dung gì nè��6<    �� TextWrapping$ WrapWithOverflow=�6R   $��25(�6r   5\      � 5_      -   5         �Name$ 
gridButton��5_   ?   $��1��6   $��Bottom=�6$    � ColumnDefinitions 5`      �� 5a      �� 5b      .+�5f      �� -   5         ��Name$
 btn1��5f   -   $��0��6    �� 	IsDefault . $��Right=�5g   .   .��5h      �� -   5        $ 
tblButton1��5h   $   $��OK��68   
�������6B   5i      �� 5l      -	   5        $
 btn2��5l   -   $��1��6    �� IsCancel . $
��Left=�5m   -   .��5n      �� -
   5        $ 
tblButton2��5n   $   $��Cancel��68   
�������6F   5o      5p      5q      5r      5s      5t      