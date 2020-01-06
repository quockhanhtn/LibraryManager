using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LibraryManager.KBox
{
    /// <summary>
    /// Interaction logic for KMessageBox.xaml
    /// </summary>
    public partial class KMessageBox : Window
    {
        /// <summary>
        /// Result = true -> Button 1 được nhấn // Result = false -> Button 2 được nhấn
        /// </summary>
        public bool Result { get; set; }

        /// <summary>
        /// Hiện ra một MessageBox tùy chỉnh
        /// </summary>
        /// <param name="kMessageBoxText">Nội dung hiển thị</param>
        /// <param name="caption">Tiêu đề</param>
        /// <param name="btn1_Text">Nội dung của nút bấm thứ 1 - nút Default</param>
        /// <param name="btn2_Text">Nội dung của nút bấm thứ 2 - nút Cancel</param>
        /// <param name="messageBoxImage">Icon</param>
        public KMessageBox(string kMessageBoxText, string caption, string btn1_Text, string btn2_Text, MessageBoxImage messageBoxImage)
        {
            InitializeComponent();
            Result = false;
            tblContent.Text = kMessageBoxText;
            tblTitle.Text = caption.ToUpper();
            tblButton1.Text = btn1_Text;
            tblButton2.Text = btn2_Text;
            switch (messageBoxImage)
            {
                case MessageBoxImage.None:
                    icoBox.Visibility = Visibility.Hidden;
                    break;
                case MessageBoxImage.Question:
                    icoBox.Kind = MaterialDesignThemes.Wpf.PackIconKind.QuestionMarkRhombus;
                    icoBox.Foreground = (Brush)(new BrushConverter()).ConvertFrom("#007acc");
                    break;
                case MessageBoxImage.Error:
                    icoBox.Kind = MaterialDesignThemes.Wpf.PackIconKind.MultiplyBox;
                    icoBox.Foreground = (Brush)(new BrushConverter()).ConvertFrom("#f38b76");
                    break;
                case MessageBoxImage.Warning:
                    icoBox.Kind = MaterialDesignThemes.Wpf.PackIconKind.WarningBox;
                    icoBox.Foreground = (Brush)(new BrushConverter()).ConvertFrom("#d9b172");
                    break;
                case MessageBoxImage.Information:
                    icoBox.Kind = MaterialDesignThemes.Wpf.PackIconKind.InformationOutline;
                    icoBox.Foreground = (Brush)(new BrushConverter()).ConvertFrom("#66b158");
                    break;
                default:
                    break;
            }
            if (btn2_Text == "")
            {
                Grid.SetColumnSpan(btn1, 2);
                this.btn2.Visibility = Visibility.Hidden;
            }
        }

        public static bool Show(string kMessageBoxText, string caption, string btn1_Text, string btn2_Text, MessageBoxImage messageBoxImage)
        {
            KMessageBox kMessageBox = new KMessageBox(kMessageBoxText, caption, btn1_Text, btn2_Text, messageBoxImage);
            kMessageBox.ShowDialog();
            return kMessageBox.Result;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            Result = true;
            this.Close();
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            Result = false;
            this.Close();
        }
    }
}
