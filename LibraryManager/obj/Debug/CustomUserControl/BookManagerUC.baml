   M S B A M L   `   `   `  ����I  ELibraryManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:LibraryManager.CustomUserControl LibraryManager.CustomUserControl  5      S.clr-namespace:LibraryManager.CustomUserControl LibraryManager.CustomUserControl  5
      4    .LibraryManager.CustomUserControl.BookManagerUC   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      @local.clr-namespace:LibraryManager.CustomUserControl     5      =uc.clr-namespace:LibraryManager.CustomUserControl     5
      U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      -   5          >�Name$  bookManagerUC��5      ���#fafafa J� InputBindings 5      �� 5   
    �� Gesture$ CTRL+B��5       �� Command 5      �� *BorrowBookButtonCommand+ �� CommandParameter 5      ��  �� ElementName$ librarianWindow��5      �� 5   
   $ CTRL+R��5       5      �� *ReturnBookButtonCommand+ 5      �� $ librarianWindow��5      �� 5   
   $ CTRL+E��5       5      �� *ExitCommand+ 5      �� $ librarianWindow��5       � 	Resources 5       �� 
TargetType "  MaterialDesignRaisedDarkButton �� BasedOn+  %MaterialDesignThemes.Wpf.ButtonAssist	 �� Property
 �� Value'  !MaterialDesignThemes.Wpf.PackIcon��%�  '��       7   '  l    '�� (    �� 5    
   " ��6   8   .�5!      �� 	 �@ CornerRadius$
 10��6I   �� 5"      	 � ��
 �#001e516+   �� 5#      	 � ��$
 Stretch=�62   �� 5$      	 � ��$
 Stretch=�64   �� 5%      	 � ��$

 auto��6'   �� 5&      	 � ��$

 auto��6&   �� 5'      	 � ��$
 25(�6)   �� 5(      	 � ��$

 10 0q�6'   5)      �� 5*   
   "  6   .�5+      �� 	 � ��$
 48��6'   �� 5,      	 � ��$
 48��6&   �� 5-      	 � ��$
 Center=�64   �� 5.      	 � ��$
 Center=�62   5/      �� 50   
   " ��6   .�51      �� 	 � ��$
 Center=�64   �� 52      	 � ��$
 Center=�62   �� 53      	 � ��$
 30(�6)   54      55      .��57      #  MaterialDesignThemes.Wpf.Card  +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth3=�6   $��0q�6K   $��
10 10 5 10q�6X   $��Stretch=�6l   $��Stretch=�6�   .��58   
   �  � RowDefinitions 59      �� 5:      $
��auto �6    �� 5;      $
��auto �6    �� 5<      �� 5=      $
��auto �6    .+�5A      � $��0��6    � ColumnDefinitions 5B      �� 5C      �� 5D      .+�5G      ��  � ToolTip$% Thực hiện cho mượn sách��5I      $��10q�5J      $��0��6%   ��5G      �� *BorrowBookButtonCommand+��5H      �� $ bookManagerUC��.��5K      ��  �� Orientation$ 
Horizontal=�6!   .+�5L        �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ ArrowLeftBoldCircle=�62   �� 5M      $��MƯỢN SÁCH��6$   $
��20 0q�65   5N      5O      �� 5Q      $  Thực hiện nhận sách��6   $��10q�5T      $��1��6%   ��5R      �� *ReturnBookButtonCommand+��5S      �� $ bookManagerUC��.��5U      �� $ 
Horizontal=�6!   .+�5V        $ ArrowRightBoldCircle=�62   �� 5W      $��TRẢ SÁCH��6$   $
��20 0q�64   5X      5Y      5[      � 5^      $��1��6   $��10 20q�6     5_      �� 5`      �� 5a      �� 5b      $
��auto �6'   .+�5e      � $��0��6    5f      �� 5g      $
��auto �6+   �� 5h      .+�5k        $ 
BookSearch=�6.   $��36��6@   $��36��6L   $��Bottom=�6W   $��0��6r   �� 5m      -   5         ��Name$ tbxSearchBook��5n      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Tên sách��5m       % !MaterialDesignFloatingHintTextBox#��[ 5o      $��Center=�5p      $��18(�5q      $��1��5r      .��6.   .  (System.Windows.Interactivity.Interaction   Triggers 5s      /  )System.Windows.Interactivity.EventTrigger  5t         	EventName$ TextChanged��6-   .	  (System.Windows.Interactivity.TriggerBase 	  Actions. 5u   "   6
  0System.Windows.Interactivity.InvokeCommandAction
   
  Command 68   �� *TextboxSearchChangeCommand+ 
  CommandParameter 6g   �� $ tbxSearchBook��6�   5v      .��5w   2   5x      5y      � 5z      $��1��6   .+�5{      �� -   5         ��Name$ cbxBookCategory��5|      $ Loại sách��5{      $��72��5}      $
��20 0q�5~      $��Bottom=�5       �� DisplayMemberPath$
 Name��5�      $��14(�5�      ��5�      �� *ListBookCategory+ �� SelectedValue 5�      �� *BookCategorySelected+ 5�        5�      $ SelectionChanged��6-   . 5�   "   
   68   �� *#!ChangeBookCategorySelectedCommand+ 6n   �� $ cbxBookCategory�� �� Path$ SelectedValue�5�      5�      5�      � 5�      $��2��6   .+�5�      �� $��XUẤT FILE EXCEL��5�      $= 7Xuất danh sách sách trong thư viện ra file Excel��5�      $��18(�5�      ��5�      �� *ExportToExcelCommand+5�      5�      5�      � 5�      $��2��6   .+�5�      �� $
��Auto=�6   $
��Auto=�6B   .��5�      �� $��Stretch=�5�      $��Stretch=�6;   ��5�      �� *ListBookItem+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=� �� SelectedItem 5�      �� *BookItemSelected+$ PropertyChanged=� �� View 5�      �� 5�      .P�5�   "   �� $	��Mã��61     �� Width$
  auto��6=   ! �� CellTemplate! 5�   &   �� 5�   *   .R�5�   .   �� 
���   ���6K   �� *IdBook+5�   +   5�   #   �� 5�   "   $��
Tên sách��61   $	  300��6C   ! 5�   &   �� 5�   *   .R�5�   .   �� 
���   ���6K   �� *	Book.Name+5�   +   5�   #   �� 5�   "   $��Loại��61   $	  200��6?   ! 5�   &   �� 5�   *   .R�5�   .   �� 
���   ���6K   �� *Book.BookCategory+5�   +   5�   #   �� 5�   "   $��
Tác giả��61   $	  150��6B   ! 5�   &   �� 5�   *   .R�5�   .   �� 
���   ���6K   �� *Book.Author+5�   +   5�   #   �� 5�   "   $��Nhà xuất bản��61   $	  200��6G   ! 5�   &   �� 5�   *   .R�5�   .   �� 
���   ���6K   �� *Book.Publisher+5�   +   5�   #   �� 5�   "   $��Năm XB��61   $	  100��6A   ! 5�   &   �� 5�   *   .R�5�   .   �� 
���   ���6K   �� *Book.YearPublish+5�   +   5�   #   �� 5�   "   $
��Giá��61   $  75��6?   ! 5�   &   �� 5�   *   .R�5�   .   �� 
���   ���6K   �� *
Book.Price+5�   +   5�   #   �� 5�   "   $��Tổng số��61   $  80��6B   ! 5�   &   �� 5�   *   .R�5�   .   �� 
���   ���6K   �� *Number+5�   +   5�   #   �� 5�   "   $��
Còn lại��61   $  80��6B   ! 5�   &   �� 5�   *   .R�5�   .   �� 
���   ���6K   �� *	Counter+5�   +   5�   #   5�      5�      5�      5�      � 5�      $��3��6    5�      �� 5�      �� 5�      �� 5�      �� 5�      .+�5�      �� $) #Nhập sách mới vào thư viện��5�      $��10q�5�      $��0��6%   ��5�      �� *AddBookItemButtonCommand+.��5�      �� $ 
Horizontal=�6!   .+�5�        $ ArrowTopBoldCircle=�62   �� 5�      $��NHẬP SÁCH��6$   $
��10 0q�65   5�      5�      �� 5�      $) #Cập nhật lại thông tin sách��6   $��10q�5�      $��1��6%   ��5�      �� *UpdateBookItemButtonCommand+.��5�      �� $ 
Horizontal=�6!   .+�5�        $ NewReleases=�62   �� 5      $��CẬP NHẬT��6$   $
��10 0q�64   5     5     �� 5     $  Thực hiện xuất sách��6   $��10q�5     $��2��6%   ��5     �� *ExportBookItemButtonCommand+��5     �� $ bookManagerUC��.��5     �� $ 
Horizontal=�6!   .+�5	       $ ArrowBottomBoldCircle=�62   �� 5
     $��XUẤT SÁCH��6$   $
��10 0q�65   5     5     �� 5     $0 *Thống kê những người mượn sách��6   $��10q�5     $��3��6%   ��5     �� * StatisticBookItemButtonCommand+��5     �� $ bookManagerUC��.��5     �� $ 
Horizontal=�6!   .+�5       $ 
FileReport=�62   �� 5     $��THỐNG KÊ��6$   $
��10 0q�64   5     5     5     5     5     5     