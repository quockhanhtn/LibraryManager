   M S B A M L   `   `   `  ����I  ELibraryManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:LibraryManager.KBoxLibraryManager.KBox  5   	   %    LibraryManager.KBox.KMessageBox   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:LibraryManager.KBox     5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   -   5          �Name$  kMessageBox��5
   	      MaterialDesignPaper#���   5   	     MaterialDesignFont#���  5   	   $	��250��5   	   $	��500��6    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�5   	    � 	Resources 5       �� 
TargetType " MaterialDesignRaisedDarkButton �� BasedOn+  %MaterialDesignThemes.Wpf.ButtonAssist �� Property �� Value % !MaterialDesignFloatingHintTextBox��%"  '��       7  '�� j    7  �� 5   
   " ��6   8   .�5      ��  �@ CornerRadius$ 10��6I   �� 5       � �� �#001e516+   �� 5       � ��$ Stretch=�62   �� 5       � ��$ Stretch=�64   �� 5       � ��$ 40��6'   �� 5       � ��$	 200��6&   �� 5       � ��$ 20(�6)   �� 5       � ��$ 10 10q�6'   5      �� 5   
   " ��6   8   .�5       ��  � ��$ Center=�62   �� 5!       � ��$ 20 10q�6'   �� 5"       � ��$ 25(�6)   5#      5%      .��5'      �� ���#007acc$��3q�6#   ._�5(   
   � 	 � RowDefinitions	 5)      �� 5*      $��40 �6    �� 5+      .+�5/      � -   5        $��0��5/      ���#007acc.+�50      �� -   5        
 ��Name$
 tblTitle��50      $��TITLE��6.   
�������$��30(�6N   $��Center=�6\   $��Center=�6y   �� 51      -   5         � ToolTip$ Close��51      
�������$��Right=�6<   .��52      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ WindowClose=�6.   ��53      �� 54      " ��6    .�55      ��  � �� 6;   Z� �� 56       � �� 6<   Z� �� 57       � ��$ 30��67   �� 58       � ��$ 30��66   �� 59       � ��$ Center=�6D   �� 5:       � ��$ Center=�6B   �� 5;       � ��
 �����6;   �� 5<       � �� 5=   "   �� 5>   &    �� 
TargetType" ��66   .R�5?   *   ��  ��Name$ Border��61   
������ ._�5@   .   �� $��Center=�6?   $��Center=�6\   5A   +    �� Triggers 5B   *   P� 5C   .    P� Property �@J�IsMouseOver P� Value . . �5D   2   ��  �� 
TargetName$ Border��6[    � ��
 �  ��5E   /   5G   '   5I      5J      5L      5M      � 5P      $��1��6   	 5Q      �� 5R      �� 5S      $
��auto �6$   .+�5V      � -   5         �Name$ gridContent��5V   $   $��0��6    � ColumnDefinitions 5W      �� 5X      $��60 �6+   �� 5Y      .+�5\      � $��0��6   .+�5]        -   5          Name$ icoBox��5]   2   $	 Abc=�6B   $��60��6M   $��60��6X   $��Center=�5^   2   $��Center=�6O   5_      � 5a      $��1��6   .+�5b      �� $
��Auto=�6'   .��5c      �� -   5        $
 
tblContent��5c   4   $��20q�6(   $��Nội dung gì nè��6H   $��WrapWithOverflow=�6^   $��25(�6~   5d      5e      5f      � 5i      $��1��6   $��Bottom=�6$    5j      �� 5k      �� 5l      .+�5p      �� -   5         ��Name$
 btn1��5p   -   $��0��6    �� 	IsDefault . $��Right=�5q   .   .��5r      �� -	   5        $
 
tblButton1��5r   $   $��OK��68   
�������6B   5s      �� 5v      -
   5        $
 btn2��5v   -   $��1��6    �� IsCancel . $
��Left=�5w   -   .��5x      �� -   5        $
 
tblButton2��5x   $   $��Cancel��68   
�������6F   5y      5z      5{      5|      5}      5~      