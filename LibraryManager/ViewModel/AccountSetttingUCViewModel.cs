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

namespace LibraryManager.ViewModel
{
    public class AccountSetttingUCViewModel : BaseViewModel, IOKCancelCommand
    {
        public ICommand OKCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand OKPasswordCommand { get; set; }
        public ICommand CancelPasswordCommand { get; set; }
        public ICommand LostFocusNameTextBoxCommand { get; set; }

        private Person personEdit;

        private ObservableCollection<string> listSex;

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

        public Person PersonEdit { get => personEdit; set { personEdit = value; OnPropertyChanged(); } }

        public AccountSetttingUCViewModel(string idPerson, AccountType accountType)
        {
            switch (accountType)
            {
                case AccountType.ADMIN:
                    break;
                case AccountType.LIBRARIAN:
                    PersonEdit = Librarian.FindLibrarianById(idPerson);
                    break;
                case AccountType.MEMBER:
                    PersonEdit = Member.FindMemberById(idPerson);
                    break;
                default:
                    return;
            }

            OKCommand = new RelayCommand<UserControl>((p) => { return (p != null); }, (p) =>
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

                //Update Infor
                PersonEdit.FirstName = tbxFirstName.Text;
                PersonEdit.LastName = tbxLastName.Text;
                PersonEdit.Sex = cbxSex.SelectedItem.ToString();
                PersonEdit.BirthDay = dtpkBirthday.SelectedDate.GetValueOrDefault();
                PersonEdit.Email = tbxEmail.Text;
                PersonEdit.Phone = tbxPhone.Text;

                PersonEdit.Update();

                KBox.KMessageBox.Show("Cập nhật thông tin thành công !", "Thông báo", "OK", "", MessageBoxImage.Information);
                //MessageBox.Show("Cập nhật thông tin thành công !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            });

            CancelCommand = new RelayCommand<UserControl>((p) => { return (p != null); }, (p) =>
            {
                (p.FindName("tbxLastName") as TextBox).Text = PersonEdit.LastName;
                (p.FindName("tbxFirstName") as TextBox).Text = PersonEdit.FirstName;
                (p.FindName("cbxSex") as ComboBox).SelectedItem = PersonEdit.Sex;
                (p.FindName("dtpkBirthday") as DatePicker).SelectedDate = PersonEdit.BirthDay;
                (p.FindName("tbxEmail") as TextBox).Text = PersonEdit.Email;
                (p.FindName("tbxPhone") as TextBox).Text = PersonEdit.Phone;
            });

            OKPasswordCommand = new RelayCommand<UserControl>((p) => { return (p != null); }, (p) =>
            {
                var pwxPassword = p.FindName("pwxPassword") as PasswordBox;
                var pwxPasswordNew = p.FindName("pwxPasswordNew") as PasswordBox;
                var pwxRetypePasswordNew = p.FindName("pwxRetypePasswordNew") as PasswordBox;

                var tblPasswordWarning = p.FindName("tblPasswordWarning") as TextBlock;
                var tblPasswordNewWarning = p.FindName("tblPasswordNewWarning") as TextBlock;
                var tblRetypePasswordNewWarning = p.FindName("tblRetypePasswordNewWarning") as TextBlock;

                if (pwxPassword.Password == "" || !LibraryDatabase.CheckPassword(idPerson, pwxPassword.Password, accountType))
                {
                    tblPasswordWarning.Visibility = Visibility.Visible;
                    return;
                }
                else { tblPasswordWarning.Visibility = Visibility.Hidden; }

                if (pwxPasswordNew.Password.Length < 5) { tblPasswordNewWarning.Visibility = Visibility.Visible; return; }
                else { tblPasswordNewWarning.Visibility = Visibility.Hidden; }

                if (pwxRetypePasswordNew.Password != pwxPasswordNew.Password) { tblRetypePasswordNewWarning.Visibility = Visibility.Visible; return; }
                else { tblRetypePasswordNewWarning.Visibility = Visibility.Hidden; }

                LibraryDatabase.SetNewPassword(idPerson, pwxPasswordNew.Password, accountType);

                //MessageBox.Show("Đổi mật khẩu thành công !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                KBox.KMessageBox.Show("Đổi mật khẩu thành công !", "Thông báo", "OK", "", MessageBoxImage.Information);
                pwxPassword.Password = pwxPasswordNew.Password = pwxRetypePasswordNew.Password = "";
            });

            CancelPasswordCommand = new RelayCommand<UserControl>((p) => { return (p != null); }, (p) =>
            {
                (p.FindName("pwxPassword") as PasswordBox).Password = "";
                (p.FindName("pwxPasswordNew") as PasswordBox).Password = "";
                (p.FindName("pwxRetypePasswordNew") as PasswordBox).Password = "";
            });

            LostFocusNameTextBoxCommand = new RelayCommand<TextBox>((p) => { return (p != null); }, (p) =>
            {
                p.Text = FormatData.CapitalizeEachWord(p.Text);
            });
        }
    }
}
