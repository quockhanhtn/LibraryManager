   M S B A M L   `   `   `  ����I  ELibraryManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:LibraryManagerLibraryManager  5   	   S.clr-namespace:LibraryManager.CustomUserControl LibraryManager.CustomUserControl  5	   	   (    "LibraryManager.StatisticBookWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:LibraryManager     5   	   =uc.clr-namespace:LibraryManager.CustomUserControl     5	   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   -   5          �Name$  statisticBookWindow��5   	    � Title$ Statistic Book Borrow��5   	      IconStatistic � Icon# [  5   	   $	��750��5   	   $
��1000��6    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�5   	   .��5      �� ���#007acc$��3q�6#   ._�5   
   �  � RowDefinitions 5      �� 5      $��60 �6    �� 5      .+�5      � $��0��6   ���#007acc.+�5      3   -LibraryManager.CustomUserControl.ControlBarUC  �� 5       
�������$��30(�5!   /   $��Center=�6=   $��Center=�6Z   ��5       �� *
BookName+ �� UpdateSourceTrigger$ PropertyChanged=�5!   Z   5"      � 5&      $��1��6   .+�5'      �� $
��Auto=�6   $
��Auto=�6B   .��5(      �� $��Stretch=�5)   /   $��Stretch=�5*   /   ��5(      �� *
ListBorrow+$ PropertyChanged=� �� Mode$ TwoWay=�	 �� View	 5+      �� 5,      .P�5-   "   �� $��Mã người mượn��61   
 �� DisplayMemberBinding
 6H   �� *
IdMember+�� 5.   "   $��Người mượn��61   
 6E   �� *Member+�� 5/   "   $��Mã người cho mượn��61   
 6L   �� *IdLibrarian+�� 50   "   $��Người cho mượn��61   
 6I   �� *	Librarian+�� 51   "   $��Ngày mượn��61   
 6D   ��  �� Path$ 
DateBorrow� �� StringFormat$ 
dd/MM/yyyy���� 52   "   $��Hạn trả��61   
 6B   �� $ 
DateReturn�$ 
dd/MM/yyyy��53      55      56      57      58      59      5:      