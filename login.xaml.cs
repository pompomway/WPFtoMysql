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
    /// login.xaml 的互動邏輯
    /// </summary>
    public partial class login : Window
    {
        string id;
        string pass;
        public login()
        {
            InitializeComponent();
        }

        private void end_Click(object sender, RoutedEventArgs e) //關閉紐觸發
        {
            new MainWindow().Show();
            this.Close();
            
            
        }

        private void login1_Click(object sender, RoutedEventArgs e) //登入紐觸發
        {
            id = this.Id_input.Text;
            pass = this.Pw_input.Text;
            if (id.Length < 4 || pass.Length < 4) {
                Message.Text = "ID或密碼不正確";
                return;
            }
            ToDB toDB = new ToDB();
            int i = toDB.loginCheck(id, pass);
            if (i == 0) {
                id = "帳號或密碼錯誤";
            } else if (i == 1) {
                new EnSelect().Show();
                
                this.Close();
            }
            else {
                id = "權限不足";
            }
            Message.Text =id  ;
        }
    }
}
