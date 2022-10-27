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

namespace ToDBC0419
{
    /// <summary>
    /// EnSelect.xaml 的互動邏輯
    /// </summary>
    public partial class EnSelect : Window
    {
        public EnSelect()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) //退出回主頁
        {
            new MainWindow().Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string ids = this.Id_Input.Text;
            if (ids.Length < 4) {
                Message.Text = "輸入資料有誤，請再確認。";
                return;
            }
            string[] id = ids.Split(',');
            ToDB toDB = new ToDB();
            Message.Text = toDB.showTestID(id);
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string pws = this.Pw_Input.Text;
            if (pws.Length < 4) {
                Message.Text = "輸入資料有誤，請再確認。";
                return;
            }
            string[] pass = pws.Split(',');
            ToDB toDB = new ToDB();
            Message.Text = toDB.showTestPass(pass);
        }
    }
}
