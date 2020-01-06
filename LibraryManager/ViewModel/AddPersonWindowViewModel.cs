using LibraryManager.Interface;
using LibraryManager.Model;
using LibraryManager.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace LibraryManager.ViewModel
{
    public class AddPersonWindowViewModel : BaseViewModel, IOKCancelCommand
    {
        private ObservableCollection<string> listSex;
        private string title;

        public ICommand OKCommand { get; set; }
        public ICommand RetypeCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand LostFocusNameTextBoxCommand { get; set; }

        public ObservableCollection<string> ListSex
        {
            get
            {
                if (listSex == null)
                {
                    listSex = new ObservableCollection<string>();
                    listSex.Add("Nam");
                    listSex.Add("Nữ");
                    listSex.Add("Khác");
                }
                return listSex;
            }
        }
        public string Title { get => title; set { title = value; OnPropertyChanged(); } }

        public AddPersonWindowViewModel(AccountType accountType)
        {
            switch (accountType)
            {
                case AccountType.LIBRARIAN:
                    Title = "THÊM NHÂN VIÊN MỚI";
                    break;
                case AccountType.MEMBER:
                    Title = "THÊM THÀNH VIÊN MỚI";
                    break;
            }

            OKCommand = new RelayCommand<Window>((p) => { return (p != null); }, (p) =>
            {
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

                if (accountType == AccountType.LIBRARIAN)
                {
                    Librarian newLibrarian = new Librarian(tbxFirstName.Text, tbxLastName.Text, cbxSex.SelectedItem.ToString(), dtpkBirthday.SelectedDate.GetValueOrDefault(), tbxEmail.Text, tbxPhone.Text);
                    newLibrarian.AddToData();
                }
                else if (accountType == AccountType.MEMBER)
                {
                    Member newMember = new Member(tbxFirstName.Text, tbxLastName.Text, cbxSex.SelectedItem.ToString(), dtpkBirthday.SelectedDate.GetValueOrDefault(), tbxEmail.Text, tbxPhone.Text);
                    newMember.AddToData();
                }
                p.Close();

            });

            CancelCommand = new RelayCommand<Window>((p) => { return (p != null); }, (p) => p.Close());

            LostFocusNameTextBoxCommand = new RelayCommand<TextBox>((p) => { return (p != null); }, (p) =>
            {
                p.Text = FormatData.CapitalizeEachWord(p.Text);
            });
        }
    }
}