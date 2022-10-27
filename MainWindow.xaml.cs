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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ToDBC0419
{
  

    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        
            
    string message;
        int pk;
        string id;
        string pass;
        public MainWindow()
        {
            InitializeComponent();
        }
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
            
        }

        private void Button_toLogin(object sender, RoutedEventArgs e)//進入批量查詢紐
        {
            login l = new login();
            this.Close();
            l.Show();
        }

        private void BtnSet_Click(object sender, RoutedEventArgs e) //新增紐觸發
        {
            id=this.Id_Input.Text;
            pass = this.Pw_Input.Text;
            if (id.Length<4 || pass.Length<4) {
                Message.Text = "請再確認輸入資料，Pk指定無效，ID及密碼皆不得小於四位數。";
                return;
            }
            //Message.Text = "!!";
            ToDB toDB = new ToDB();
            toDB.setTest(id, pass);
            Message.Text = "資料已新增!";
            this.Pk_Input.Clear();
            this.Id_Input.Clear();
            this.Pw_Input.Clear();
        }

        private void BtnShow_Click(object sender, RoutedEventArgs e) //查詢紐觸發
        {
            bool toInt = int.TryParse(this.Pk_Input.Text, out pk);
            if (pk == 0) {
                Message.Text = "請再確認輸入資料,Pk不得為0，ID及PW查詢請登入批量查詢。";
                return;
            }
            ToDB toDB = new ToDB();
            Message.Text = toDB.showTest(pk); 
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)//修改紐觸發
        {
            bool toInt = int.TryParse(this.Pk_Input.Text, out pk);
            pass = this.Pw_Input.Text;
            if (pk==0 || pass.Length<4) {
                Message.Text = "請再確認輸入資料,Pk不得為0,修改密碼不得小於四位數。"+"\n"+"輸入修改對象之pk，並輸入新密碼，ID無法修改故指定亦無效。";
                return;
            }
            ToDB toDB = new ToDB();
            Message.Text = toDB.upTest(pk,pass);
            this.Pk_Input.Clear();
            this.Id_Input.Clear();
            this.Pw_Input.Clear();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)//刪除紐觸發
        {
            bool toInt = int.TryParse(this.Pk_Input.Text, out pk);
            if (pk==0) {
                Message.Text = "請再確認輸入資料,Pk不得為0。";
                return;
            }
            ToDB toDB = new ToDB();
            Message.Text = toDB.deTest(pk);
        }
    }
}
