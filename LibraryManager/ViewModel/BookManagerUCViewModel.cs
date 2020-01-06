using LibraryManager.CustomUserControl;
using LibraryManager.Model;
using LibraryManager.Utility;
using Microsoft.Win32;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LibraryManager.ViewModel
{

    public class BookManagerUCViewModel : BaseViewModel
    {
        private ObservableCollection<BookItem> listBookItem;
        private BookItem bookItemSelected;
        private BookCategory bookCategorySelected;
        private ObservableCollection<BookCategory> listBookCategory;
        public ICommand ChangeBookCategorySelectedCommand { get; set; }
        public ICommand TextboxSearchChangeCommand { get; set; }
        public ICommand BorrowBookButtonCommand { get; set; }
        public ICommand ReturnBookButtonCommand { get; set; }
        public ICommand ExportToExcelCommand { get; set; }
        public ICommand AddBookItemButtonCommand { get; set; }
        public ICommand UpdateBookItemButtonCommand { get; set; }
        public ICommand ExportBookItemButtonCommand { get; set; }
        public ICommand StatisticBookItemButtonCommand { get; set; }

        public ObservableCollection<BookItem> ListBookItem { get => listBookItem; set { listBookItem = value; OnPropertyChanged(); } }
        public BookItem BookItemSelected { get => bookItemSelected; set { bookItemSelected = value; OnPropertyChanged(); } }
        public BookCategory BookCategorySelected { get => bookCategorySelected; set { bookCategorySelected = value; OnPropertyChanged(); } }
        public ObservableCollection<BookCategory> ListBookCategory { get => listBookCategory; set { listBookCategory = value; OnPropertyChanged(); } }

        public BookManagerUCViewModel(string idLibrarian)
        {
            LoadList();

            ChangeBookCategorySelectedCommand = new RelayCommand<BookCategory>((p) => { return p != null; }, (p) =>
            {
                if (p.Id == "0")
                {
                    ListBookItem = LibraryDatabase.BookItems();
                }
                else
                {
                    ListBookItem = LibraryDatabase.BookItems(p);
                }
            });

            TextboxSearchChangeCommand = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                ListBookItem = LibraryDatabase.BookItems(this.bookCategorySelected);
                if (p.Text == "") { return; }
                if (p.Text == " ") { p.Text = ""; return; }
                var ListBookItemSearch = from item in ListBookItem
                                         where FormatData.StringConvertToUnSign(item.Book.Name).ToLower().Contains(FormatData.StringConvertToUnSign(p.Text).ToLower())
                                         select item;
                ListBookItem = new ObservableCollection<BookItem>(ListBookItemSearch);
            });

            BorrowBookButtonCommand = new RelayCommand<UserControl>((p) => { return true; }, (p) =>
            {
                var w = GetWindowParent(p) as Window;
                
                InputIdPerSonWindow inputIdPerSonWindow = new InputIdPerSonWindow();
                inputIdPerSonWindow.DataContext = new InputIdPerSonWindowViewModel();
                inputIdPerSonWindow.ShowDialog();

                var inputIdPerSonWindowVM = inputIdPerSonWindow.DataContext as InputIdPerSonWindowViewModel;

                if (inputIdPerSonWindowVM.IdPerson != "")
                {
                    var GridMain = w.FindName("GridMain") as Grid;
                    GridMain.Children.Clear();

                    UserControl borrowBookUC = new BorrowBookUC();
                    borrowBookUC.DataContext = new BorrowBookUCViewModel(inputIdPerSonWindowVM.IdPerson, idLibrarian);
                    GridMain.Children.Add(borrowBookUC);

                    /*
                    BorrowBookWindow borrowBookWindow = new BorrowBookWindow();
                    borrowBookWindow.DataContext = new BorrowBookWindowViewModel(inputIdPerSonWindowVM.IdPerson, idLibrarian);
                    borrowBookWindow.ShowDialog();
                    */
                }
            });

            ReturnBookButtonCommand = new RelayCommand<UserControl>((p) => { return true; }, (p) =>
            {
                var w = GetWindowParent(p) as Window;

                InputIdPerSonWindow inputIdPerSonWindow = new InputIdPerSonWindow();
                inputIdPerSonWindow.DataContext = new InputIdPerSonWindowViewModel();
                inputIdPerSonWindow.ShowDialog();

                var inputIdPerSonWindowVM = inputIdPerSonWindow.DataContext as InputIdPerSonWindowViewModel;

                if (inputIdPerSonWindowVM.IdPerson != "")
                {
                    var GridMain = w.FindName("GridMain") as Grid;
                    GridMain.Children.Clear();

                    UserControl returnBooKUC = new ReturnBookUC();
                    returnBooKUC.DataContext = new ReturnBookUCViewModel(inputIdPerSonWindowVM.IdPerson, idLibrarian);
                    GridMain.Children.Add(returnBooKUC);

                    LoadList();

                    /*
                    BorrowBookWindow borrowBookWindow = new BorrowBookWindow();
                    borrowBookWindow.DataContext = new BorrowBookWindowViewModel(inputIdPerSonWindowVM.IdPerson, idLibrarian);
                    borrowBookWindow.ShowDialog();
                    */
                }

                /*
                var inputIdPerSonWindowVM = inputIdPerSonWindow.DataContext as InputIdPerSonWindowViewModel;

                if (inputIdPerSonWindowVM.IdPerson != "")
                {
                    ReturnBookWindow returnBookWindow = new ReturnBookWindow();
                    returnBookWindow.DataContext = new ReturnBookWindowViewModel(inputIdPerSonWindowVM.IdPerson, IdLibrarian);
                    returnBookWindow.ShowDialog();
                    
                    LoadList();
                }
                */
            });

            ExportToExcelCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                string filePath = "";
                // tạo SaveFileDialog để lưu file excel
                SaveFileDialog dialog = new SaveFileDialog();

                dialog.Title = "Xuất danh sách sách trong thư viện";

                // chỉ lọc ra các file có định dạng Excel
                dialog.Filter = "Excel | *.xlsx | Excel 2003 | *.xls";

                // Nếu mở file và chọn nơi lưu file thành công sẽ lưu đường dẫn lại dùng
                if (dialog.ShowDialog() == true) { filePath = dialog.FileName; }

                // nếu đường dẫn null hoặc rỗng thì return
                if (string.IsNullOrEmpty(filePath)) { return; }

                try
                {
                    using (ExcelPackage package = new ExcelPackage())
                    {
                        // đặt tên người tạo file
                        package.Workbook.Properties.Author = "";

                        // đặt tiêu đề cho file
                        package.Workbook.Properties.Title = "Danh sách sách trong thư viện";

                        //Tạo một sheet để làm việc trên đó
                        package.Workbook.Worksheets.Add("List Book Sheet");

                        // lấy sheet vừa add ra để thao tác
                        ExcelWorksheet worksheet = package.Workbook.Worksheets[1];

                        // đặt tên cho sheet
                        worksheet.Name = "List Book Sheet";
                        // fontsize mặc định cho cả sheet
                        worksheet.Cells.Style.Font.Size = 14;
                        // font family mặc định cho cả sheet
                        worksheet.Cells.Style.Font.Name = "Segoe UI";

                        // set column width
                        worksheet.Column(1).Width = 12;
                        worksheet.Column(2).Width = 48;
                        worksheet.Column(3).Width = 25;
                        worksheet.Column(4).Width = 30;
                        worksheet.Column(5).Width = 35;
                        worksheet.Column(6).Width = 10;
                        worksheet.Column(7).Width = 10;
                        worksheet.Column(8).Width = 10;
                        worksheet.Column(9).Width = 10;

                        // Tạo danh sách các column header
                        string[] arrColumnHeader = { "Mã sách", "Tên sách", "Loại sách", "Tác giả", "Nhà xuất bản", "Năm XB", "Giá tiền", "Tổng số", "Còn lại"};

                        // lấy ra số lượng cột cần dùng dựa vào số lượng header
                        var countColHeader = arrColumnHeader.Count();

                        // merge các column lại từ column 1 đến số column header
                        // gán giá trị cho cell vừa merge là Thống kê thông tni User Kteam
                        worksheet.Cells[1, 1].Value = "Thống kê sách trong thư viện".ToUpper();
                        worksheet.Cells[1, 1, 1, countColHeader].Merge = true;
                        // in đậm
                        worksheet.Cells[1, 1, 1, countColHeader].Style.Font.Bold = true;
                        // căn giữa
                        worksheet.Cells[1, 1, 1, countColHeader].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        worksheet.Cells[2, 1].Value = "Ngày " + DateTime.Now.ToString();
                        worksheet.Cells[2, 1, 2, countColHeader].Merge = true;

                        // căn giữa
                        worksheet.Cells[2, 1, 2, countColHeader].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        int colIndex = 1;
                        int rowIndex = 3;

                        //tạo các header từ column header đã tạo từ bên trên
                        foreach (var item in arrColumnHeader)
                        {
                            var cell = worksheet.Cells[rowIndex, colIndex];

                            //set màu thành gray
                            var fill = cell.Style.Fill;
                            fill.PatternType = ExcelFillStyle.Solid;
                            fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);

                            //căn chỉnh các border
                            var border = cell.Style.Border;
                            border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                            //gán giá trị
                            cell.Value = item;

                            colIndex++;
                        }

                        // với mỗi item trong danh sách sẽ ghi trên 1 dòng
                        foreach (var item in ListBookItem)
                        {
                            // bắt đầu ghi từ cột 1. Excel bắt đầu từ 1 không phải từ 0
                            colIndex = 1;

                            // rowIndex tương ứng từng dòng dữ liệu
                            rowIndex++;

                            //gán giá trị cho từng cell                      
                            ExcelFile.FormatCellBorder(worksheet, rowIndex, colIndex);
                            worksheet.Cells[rowIndex, colIndex++].Value = item.IdBook;

                            ExcelFile.FormatCellBorder(worksheet, rowIndex, colIndex);
                            worksheet.Cells[rowIndex, colIndex++].Value = item.Book.Name;

                            ExcelFile.FormatCellBorder(worksheet, rowIndex, colIndex);
                            worksheet.Cells[rowIndex, colIndex++].Value = item.Book.BookCategory;

                            ExcelFile.FormatCellBorder(worksheet, rowIndex, colIndex);
                            worksheet.Cells[rowIndex, colIndex++].Value = item.Book.Author;

                            ExcelFile.FormatCellBorder(worksheet, rowIndex, colIndex);
                            worksheet.Cells[rowIndex, colIndex++].Value = item.Book.Publisher;

                            ExcelFile.FormatCellBorder(worksheet, rowIndex, colIndex);
                            worksheet.Cells[rowIndex, colIndex++].Value = item.Book.YearPublish.ToString();

                            ExcelFile.FormatCellBorder(worksheet, rowIndex, colIndex);
                            worksheet.Cells[rowIndex, colIndex++].Value = item.Book.Price.ToString();

                            ExcelFile.FormatCellBorder(worksheet, rowIndex, colIndex);
                            worksheet.Cells[rowIndex, colIndex++].Value = item.Number;

                            ExcelFile.FormatCellBorder(worksheet, rowIndex, colIndex);
                            worksheet.Cells[rowIndex, colIndex++].Value = item.Counter;
                        }

                        //Lưu file lại
                        Byte[] bin = package.GetAsByteArray();
                        File.WriteAllBytes(filePath, bin);
                    }

                    if (KBox.KMessageBox.Show("Bạn có muốn mở file excel vừa xuất không ?", "Xuất file Excel thành công !", "Có", "Không", MessageBoxImage.Information))
                    {
                        ExcelFile.OpenFile(filePath);
                    }
                    /*
                    MessageBoxResult messageBoxResult = MessageBox.Show("Xuất excel thành công!\nBạn có muốn mở file excel vừa xuất không ?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Asterisk);
                    if (messageBoxResult == MessageBoxResult.Yes) { ExcelFile.OpenFile(filePath); }
                    */
                }

                catch (Exception)
                {
                    KBox.KMessageBox.Show("Có lỗi khi lưu file!", "Thông báo", "OK", "", MessageBoxImage.Error);
                    //MessageBox.Show("Có lỗi khi lưu file!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });

            AddBookItemButtonCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                AddBookItemWindow addBookItemWindow = new AddBookItemWindow();
                addBookItemWindow.DataContext = new AddBookItemWindowViewModel();
                addBookItemWindow.ShowDialog();

                LoadList();
            });

            UpdateBookItemButtonCommand = new RelayCommand<object>((p) => { return !(BookItemSelected == null); }, (p) =>
            {
                UpdateBookItemWindow updateBookItemWindow = new UpdateBookItemWindow();
                var dataContext = new UpdateBookItemWindowViewModel(BookItemSelected);

                updateBookItemWindow.DataContext = dataContext;
                updateBookItemWindow.ShowDialog();
                LoadList();
            });

            ExportBookItemButtonCommand = new RelayCommand<object>((p) => { return (BookItemSelected != null && BookItemSelected.Counter > 0); }, (p) =>
            {
                int numberBookItemExport;
                string input = KBox.KInputBox.Show(BookItemSelected.Counter.ToString(), "NHẬP SỐ LƯỢNG XUẤT", "OK", "Cancel");

                if (input == "") { return; }

                if (!int.TryParse(input, out numberBookItemExport) || numberBookItemExport > BookItemSelected.Counter || numberBookItemExport < 1)
                {
                    KBox.KMessageBox.Show("Vui lòng nhập số nguyên dương bé hơn " + BookItemSelected.Counter.ToString(), "Thông báo", "OK", "", MessageBoxImage.Error);
                    return;
                }

                if (numberBookItemExport == BookItemSelected.Number)
                {
                    BookItemSelected.Remove();
                    LoadList();
                }
                else
                {
                    BookItemSelected.Export(numberBookItemExport);
                    LoadList();
                }
            });

            StatisticBookItemButtonCommand = new RelayCommand<object>((p) => { return !(BookItemSelected == null || BookItemSelected.Counter == BookItemSelected.Number); }, (p) =>
            {
                StatisticBookWindow statisticBookWindow = new StatisticBookWindow();
                statisticBookWindow.DataContext = new StatisticBookWindowViewModel(BookItemSelected.Book);
                statisticBookWindow.Show();
            });
        }

        public void LoadList()
        {
            ListBookItem = LibraryDatabase.BookItems();
            ListBookCategory = LibraryDatabase.BookCategories();
            ListBookCategory.Insert(0, BookCategory.AllBookCategory());
            BookCategorySelected = BookCategory.AllBookCategory();
        }
    }
}
