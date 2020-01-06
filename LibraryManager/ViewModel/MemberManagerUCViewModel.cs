using LibraryManager.Model;
using LibraryManager.Utility;
using MaterialDesignThemes.Wpf;
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
    public class MemberManagerUCViewModel : BaseViewModel
    {
        private ObservableCollection<Member> listMember;
        private Member memberSelected;
        private ObservableCollection<string> listSex;
        private ObservableCollection<string> listYearOfBirthFilter;
        private ObservableCollection<string> listIsBlockFilter;

        public ICommand FilterCommand { get; set; }
        public ICommand MemberSelectedChanged { get; set; }
        public ICommand ExportToExcelCommand { get; set; }
        public ICommand AddMemberCommand { get; set; }
        public ICommand UpdateInforCommand { get; set; }
        public ICommand BlockCommand { get; set; }

        public ObservableCollection<string> ListSex { get => listSex; set { listSex = value; OnPropertyChanged(); } }
        public ObservableCollection<string> ListIsBlockFilter { get => listIsBlockFilter; set { listIsBlockFilter = value; OnPropertyChanged(); } }
        public ObservableCollection<string> ListYearOfBirthFilter { get => listYearOfBirthFilter; set { listYearOfBirthFilter = value; OnPropertyChanged(); } }

        public ObservableCollection<Member> ListMember { get => listMember; set { listMember = value; OnPropertyChanged(); } }
        public Member MemberSelected { get => memberSelected; set { memberSelected = value; OnPropertyChanged(); } }
        
        public MemberManagerUCViewModel(string idLibrarian)
        {
            #region
            ListSex = new ObservableCollection<string>();
            ListSex.Add("Nam");
            ListSex.Add("Nữ");
            ListSex.Add("Khác");

            ListIsBlockFilter = new ObservableCollection<string>();
            ListIsBlockFilter.Add("Tất cả trạng thái");
            ListIsBlockFilter.Add("Khóa");
            ListIsBlockFilter.Add("Mở khóa");

            ListYearOfBirthFilter = new ObservableCollection<string>();
            ListYearOfBirthFilter.Add("Tất cả năm sinh");
            #endregion

            LoadList();

            FilterCommand = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                var cbxYearOfBirthFilter = p.FindName("cbxYearOfBirthFilter") as ComboBox;
                var cbxIsBlockFilter = p.FindName("cbxIsBlockFilter") as ComboBox;

                if (cbxIsBlockFilter.SelectedItem == null || cbxIsBlockFilter.SelectedItem.ToString() == "Tất cả trạng thái")
                {
                    ListMember = LibraryDatabase.Members();
                }
                else if (cbxIsBlockFilter.SelectedItem.ToString() == "Khóa")
                {
                    ListMember = LibraryDatabase.Members(true);
                }
                else if (cbxIsBlockFilter.SelectedItem.ToString() == "Mở khóa")
                {
                    ListMember = LibraryDatabase.Members(false);
                }

                if (cbxYearOfBirthFilter.SelectedItem == null || cbxYearOfBirthFilter.SelectedItem.ToString() == "Tất cả năm sinh") { return; }
                else
                {
                    int year = int.Parse(cbxYearOfBirthFilter.SelectedItem.ToString());

                    for (int i = 0; i < ListMember.Count(); i++)
                    {
                        if (ListMember[i].BirthDay.Year != year) { ListMember.Remove(ListMember[i]); i--; }
                    }
                }
            });

            ExportToExcelCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                string filePath = "";
                // tạo SaveFileDialog để lưu file excel
                SaveFileDialog dialog = new SaveFileDialog();

                dialog.Title = "Xuất danh sách nhân viên thư viện";

                // chỉ lọc ra các file có định dạng Excel
                dialog.Filter = "Excel | *.xlsx | Excel 2003 | *.xls";

                // Nếu mở file và chọn nơi lưu file thành công sẽ lưu đường dẫn lại dùng
                if (dialog.ShowDialog() == true)
                {
                    filePath = dialog.FileName;
                }

                // nếu đường dẫn null hoặc rỗng thì báo không hợp lệ và return hàm
                if (string.IsNullOrEmpty(filePath))
                {
                    //MessageBox.Show("Đường dẫn báo cáo không hợp lệ");
                    return;
                }

                try
                {
                    using (ExcelPackage package = new ExcelPackage())
                    {
                        // đặt tên người tạo file
                        package.Workbook.Properties.Author = "";

                        // đặt tiêu đề cho file
                        package.Workbook.Properties.Title = "Danh sách nhân viên thư viện";

                        //Tạo một sheet để làm việc trên đó
                        package.Workbook.Worksheets.Add("List Member Sheet");

                        // lấy sheet vừa add ra để thao tác
                        ExcelWorksheet worksheet = package.Workbook.Worksheets[1];

                        // đặt tên cho sheet
                        worksheet.Name = "List Member Sheet";
                        // fontsize mặc định cho cả sheet
                        worksheet.Cells.Style.Font.Size = 14;
                        // font family mặc định cho cả sheet
                        worksheet.Cells.Style.Font.Name = "Segoe UI";

                        // set column width
                        worksheet.Column(1).Width = 10;
                        worksheet.Column(2).Width = 20;
                        worksheet.Column(3).Width = 20;
                        worksheet.Column(4).Width = 10;
                        worksheet.Column(5).Width = 15;
                        worksheet.Column(6).Width = 40;
                        worksheet.Column(7).Width = 20;
                        worksheet.Column(8).Width = 15;

                        // Tạo danh sách các column header
                        string[] arrColumnHeader = {
                                "Mã số",
                                "Họ",
                                "Tên",
                                "Giới tính",
                                "Ngày sinh",
                                "Email",
                                "Số điện thooại",
                                "Ghi chú" };

                        // lấy ra số lượng cột cần dùng dựa vào số lượng header
                        var countColHeader = arrColumnHeader.Count();

                        // merge các column lại từ column 1 đến số column header
                        // gán giá trị cho cell vừa merge là Thống kê thông tni User Kteam
                        worksheet.Cells[1, 1].Value = "Thống kê danh thành viên thư viện".ToUpper();
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
                        foreach (var item in ListMember)
                        {
                            // bắt đầu ghi từ cột 1. Excel bắt đầu từ 1 không phải từ 0
                            colIndex = 1;

                            // rowIndex tương ứng từng dòng dữ liệu
                            rowIndex++;

                            //gán giá trị cho từng cell                      
                            ExcelFile.FormatCellBorder(worksheet, rowIndex, colIndex);
                            worksheet.Cells[rowIndex, colIndex++].Value = item.Id;

                            ExcelFile.FormatCellBorder(worksheet, rowIndex, colIndex);
                            worksheet.Cells[rowIndex, colIndex++].Value = item.LastName;

                            ExcelFile.FormatCellBorder(worksheet, rowIndex, colIndex);
                            worksheet.Cells[rowIndex, colIndex++].Value = item.FirstName;

                            ExcelFile.FormatCellBorder(worksheet, rowIndex, colIndex);
                            worksheet.Cells[rowIndex, colIndex++].Value = item.Sex;

                            // lưu ý phải .ToShortDateString để dữ liệu khi in ra Excel là ngày như ta vẫn thấy.Nếu không sẽ ra tổng số :v
                            ExcelFile.FormatCellBorder(worksheet, rowIndex, colIndex);
                            worksheet.Cells[rowIndex, colIndex++].Value = item.BirthDay.ToShortDateString();

                            ExcelFile.FormatCellBorder(worksheet, rowIndex, colIndex);
                            worksheet.Cells[rowIndex, colIndex++].Value = item.Email;

                            ExcelFile.FormatCellBorder(worksheet, rowIndex, colIndex);
                            worksheet.Cells[rowIndex, colIndex++].Value = item.Phone;

                            ExcelFile.FormatCellBorder(worksheet, rowIndex, colIndex);
                            worksheet.Cells[rowIndex, colIndex++].Value = item.Note;
                        }

                        //Lưu file lại
                        Byte[] bin = package.GetAsByteArray();
                        File.WriteAllBytes(filePath, bin);
                    }

                    if (KBox.KMessageBox.Show("Bạn có muốn mở file excel vừa xuất không ?", "Xuất file Excel thành công !", "Có", "Không", MessageBoxImage.Information))
                    {
                        ExcelFile.OpenFile(filePath);
                    }
                }

                catch (Exception)
                {
                    KBox.KMessageBox.Show("Có lỗi khi lưu file!", "Thông báo", "OK", "", MessageBoxImage.Error);
                }
            });

            AddMemberCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                AddPersonWindow addPersonWindow = new AddPersonWindow();
                addPersonWindow.DataContext = new AddPersonWindowViewModel(AccountType.MEMBER);
                addPersonWindow.ShowDialog();
                LoadList();
                /*
                AddLibrarianWindow addLibrarianWindow = new AddLibrarianWindow();
                addLibrarianWindow.ShowDialog();
                LoadList();
                */
            });

            UpdateInforCommand = new RelayCommand<UserControl>((p) => { return (p != null && MemberSelected != null); }, (p) =>
            {
                var tbxId = p.FindName("tbxId") as TextBox;
                var tbxLastName = p.FindName("tbxLastName") as TextBox;
                var tbxFirstName = p.FindName("tbxFirstName") as TextBox;
                var cbxSex = p.FindName("cbxSex") as ComboBox;
                var dtpkBirthday = p.FindName("dtpkBirthday") as DatePicker;
                var tbxEmail = p.FindName("tbxEmail") as TextBox;
                var tbxPhone = p.FindName("tbxPhone") as TextBox;

                var tblLastName = p.FindName("tblLastNameWarning") as TextBlock;
                var tblFirstName = p.FindName("tblFirstNameWarning") as TextBlock;
                var tblSex = p.FindName("tblSexWarning") as TextBlock;
                var tblBirthday = p.FindName("tblBirthdayWarning") as TextBlock;
                var tblEmail = p.FindName("tblEmailWarning") as TextBlock;
                var tblPhone = p.FindName("tblPhoneWarning") as TextBlock;

                if (tbxLastName.Text == "") { tblLastName.Visibility = Visibility.Visible; return; }
                else { tblLastName.Visibility = Visibility.Hidden; }

                if (tbxFirstName.Text == "") { tblFirstName.Visibility = Visibility.Visible; return; }
                else { tblFirstName.Visibility = Visibility.Hidden; }

                if (cbxSex.SelectedItem == null) { tblSex.Visibility = Visibility.Visible; return; }
                else { tblSex.Visibility = Visibility.Hidden; }

                if (dtpkBirthday.SelectedDate == null) { tblBirthday.Visibility = Visibility.Visible; return; }
                else { tblBirthday.Visibility = Visibility.Hidden; }

                if (tbxEmail.Text == "" || !FormatData.IsEmail(tbxEmail.Text)) { tblEmail.Visibility = Visibility.Visible; return; }
                else { tblEmail.Visibility = Visibility.Hidden; }

                if (tbxPhone.Text == "") { tblPhone.Visibility = Visibility.Visible; return; }
                else { tblPhone.Visibility = Visibility.Hidden; }

                this.MemberSelected.FirstName = tbxFirstName.Text;
                this.MemberSelected.LastName = tbxLastName.Text;
                this.MemberSelected.Sex = cbxSex.SelectedItem.ToString();
                this.MemberSelected.BirthDay = dtpkBirthday.SelectedDate.GetValueOrDefault();
                this.MemberSelected.Email = tbxEmail.Text;
                this.MemberSelected.Phone = tbxPhone.Text;

                this.MemberSelected.Update();
                LoadList();
            });

            BlockCommand = new RelayCommand<object>((p) => { return MemberSelected != null; } , (p) =>
            {
                if (this.MemberSelected.IsBlock)
                {
                    this.MemberSelected.Block(idLibrarian, "");
                }
                else
                {
                    string reson = KBox.KInputBox.Show("", "Lý do khóa", "OK", "Cancel");
                    if (reson == "") { return; }
                    this.MemberSelected.Block(idLibrarian, reson);
                }
                LoadList();
            });

            MemberSelectedChanged = new RelayCommand<UserControl>((p) => { return p != null; }, (p) =>
            {
                var btnBlock = p.FindName("btnBlock") as Button;
                var icoBlock = p.FindName("icoBlock") as PackIcon;
                var tblBlock = p.FindName("tblBlock") as TextBlock;

                try
                {
                    if (MemberSelected.IsBlock == true)
                    {
                        tblBlock.Text = "MỞ KHÓA";
                        icoBlock.Kind = PackIconKind.LockOpen;
                        btnBlock.ToolTip = "Mở khóa tài khoản " + MemberSelected.FullName;
                    }
                    else
                    {
                        tblBlock.Text = "KHÓA";
                        icoBlock.Kind = PackIconKind.Lock;
                        btnBlock.ToolTip = "Khóa tài khoản " + MemberSelected.FullName;
                    }
                }
                catch (Exception) { }
            });
        }

        void LoadList()
        {
            ListMember = LibraryDatabase.Members();
            foreach (var mem in ListMember)
            {
                if (ListYearOfBirthFilter.IndexOf(mem.BirthDay.Year.ToString()) < 0)
                {
                    ListYearOfBirthFilter.Add(mem.BirthDay.Year.ToString());
                }
            }
            for (int i = 0; i < ListYearOfBirthFilter.Count() - 1; i++)
            {
                for (int j = ListYearOfBirthFilter.Count() - 1; j > i; j--)
                {
                    int numj;
                    int numj_1;
                    if (int.TryParse(ListYearOfBirthFilter[j], out numj) && int.TryParse(ListYearOfBirthFilter[j - 1], out numj_1))
                    {
                        if (numj < numj_1)
                        {
                            string temp = ListYearOfBirthFilter[j];
                            ListYearOfBirthFilter[j] = ListYearOfBirthFilter[j - 1];
                            ListYearOfBirthFilter[j - 1] = temp;
                        }
                    }
                }
            }
        }
    }
}
