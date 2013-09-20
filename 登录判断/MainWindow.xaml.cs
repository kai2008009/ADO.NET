using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using 登录判断;

namespace 登录判断
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_logo_Click(object sender, RoutedEventArgs e)
        {
            if (txt_name.Text.Length <= 0)
            {
                MessageBox.Show("请输入用户名!");
                return;
            }
            if (password.Password.Length <= 0)
            {
                MessageBox.Show("请输入密码!");
                return;
            }

            DataTable da = SqlHelper.ExecuteDataTable("select * from custome where name=@name,pwd=@pwd",
                new SqlParameter("@name",txt_name.Text));

            if (da.Rows.Count <= 1)
            {
                MessageBox.Show("用户名不存在");
                return;
            }

            if (da.Rows.Count > 1)
            {
                throw new Exception("用户名存在相同的了");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("确定退出","哈哈哈", MessageBoxButton.OK);
            this.Close();
        }
    }
}
