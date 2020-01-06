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
    /// Interaction logic for KInputBox.xaml
    /// </summary>
    public partial class KInputBox : Window
    {
        /// <summary>
        /// Result != "" , button 1 được nhấn
        /// </summary>
        public string Result { get; set; }
        public KInputBox(string inputTextExam, string caption, string btn1_Text, string btn2_Text)
        {
            InitializeComponent();
            Result = "";
            tbxInput.Text = inputTextExam;
            tblTitle.Text = caption.ToUpper();
            tblButton1.Text = btn1_Text;
            tblButton2.Text = btn2_Text;

            tbxInput.Focus();
            tbxInput.CaretIndex = tbxInput.Text.Length;

            if (btn2_Text == "")
            {
                Grid.SetColumnSpan(btn1, 2);
                this.btn2.Visibility = Visibility.Hidden;
            }
        }

        public static string Show(string inputTextExam, string caption, string btn1_Text, string btn2_Text)
        {
            KInputBox kInputBox = new KInputBox(inputTextExam, caption, btn1_Text, btn2_Text);
            kInputBox.ShowDialog();
            return kInputBox.Result;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            Result = tbxInput.Text.Trim();
            this.Close();
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            Result = "";
            this.Close();
        }
    }
}
