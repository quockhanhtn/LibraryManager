using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using LibraryManager.Interface;
using LibraryManager.Model;
using LibraryManager.Utility;

namespace LibraryManager.ViewModel
{
    public class InputIdPerSonWindowViewModel : BaseViewModel, IOKCancelCommand
    {
        private Member memberBorrow;
        public string IdPerson { get; set; }

        public Member MemberBorrow { get => memberBorrow; set { memberBorrow = value; OnPropertyChanged(); } }
        public ICommand TextboxIdChangeCommand { get; set; }
        public ICommand OKCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public InputIdPerSonWindowViewModel()
        {
            IdPerson = "";

            TextboxIdChangeCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                var tbxId = p.FindName("tbxId") as TextBox;
                var tbxName = p.FindName("tbxName") as TextBox;
                var tbxIsBlock = p.FindName("tbxIsBlock") as TextBox;

                MemberBorrow = Member.FindMemberById(tbxId.Text);

                if (MemberBorrow != null)
                {
                    if (MemberBorrow.IsBlock) { tbxIsBlock.Foreground = Brushes.Red; }
                    else { tbxIsBlock.Foreground = Brushes.LimeGreen; }
                }
                else
                {
                    tbxIsBlock.Foreground = Brushes.Black;
                }
            });

            OKCommand = new RelayCommand<Window>((p) => { if (MemberBorrow == null || MemberBorrow.IsBlock) { return false; } return true; }, (p) =>
            {
                IdPerson = MemberBorrow.Id;
                p.Close();
            });

            CancelCommand = new RelayCommand<Window>((p) => { return (p != null); }, (p) => { p.Close(); });
        }
    }
}
