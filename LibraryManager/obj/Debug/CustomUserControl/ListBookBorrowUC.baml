   M S B A M L   `   `   `  ����I  ELibraryManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:LibraryManager.CustomUserControl LibraryManager.CustomUserControl  5      S.clr-namespace:LibraryManager.CustomUserControl LibraryManager.CustomUserControl  5
      7    1LibraryManager.CustomUserControl.ListBookBorrowUC   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      @local.clr-namespace:LibraryManager.CustomUserControl     5      =uc.clr-namespace:LibraryManager.CustomUserControl     5
      U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      -   5          >�Name$  listBookBorrowUC��5      ���#fafafa.��5      #  MaterialDesignThemes.Wpf.Card  $��10 5 5 5q�6   $��1��6,   .��5   
   �  � RowDefinitions 5      �� 5      $
��auto �6    �� 5      .+�5      �� $��CÁC SÁCH ĐÃ MƯỢN��6   $��0��60   $��Center=�5       $��Center=�6=   $��30(�5       $��DemiBold"�6.   ���#001e51$��10 30 10 10q�6Y   �� 5       $
��Auto=�6   $
��Auto=�6>   $��1��6c   .��5!      �� $��Stretch=�5"   #   $��Stretch=�6?   ��5!      �� *ListBookBorrow+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=� �� View 5#      �� 5$      .P�5%      �� $	��Mã��6-    �� CellTemplate 5&   "   �� 5'   &   .R�5(   *   �� 
���   ���6G   �� *IdBook+6a   5)   '   5+      �� 5-      $��
Tên sách��6-    5.   "   �� 5/   &   .R�50   *   �� 
���   ���6G   �� *	Book.Name+6d   51   '   53      �� 55      $��
Tác giả��6-    56   "   �� 57   &   .R�58   *   �� 
���   ���6G   �� *Book.Author+6f   59   '   5;      �� 5=      $��Nhà xuất bản��6-    5>   "   �� 5?   &   .R�5@   *   �� 
���   ���6G   �� *Book.Publisher+6i   5A   '   5C      �� 5E      $��Người cho mượn��6-    5F   "   �� 5G   &   .R�5H   *   �� 
���   ���6G   �� *	Librarian+6d   5I   '   5K      �� 5M      $��Ngày mượn��6-    5N   "   �� 5O   &   .R�5P   *   �� 
���   ���6G   ��  �� Path$ 
DateBorrow� �� StringFormat$ 
dd/MM/yyyy��6�   5Q   '   5S      �� 5U      $��Hạn trả��6-    5V   "   �� 5W   &   .R�5X   *   �� 
���   ���6G   �� $ 
DateReturn�$ 
dd/MM/yyyy��6�   5Y   '   5[      5\      5^      5_      5`      5a      5b      