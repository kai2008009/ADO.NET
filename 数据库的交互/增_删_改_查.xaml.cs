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

        //新增
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SqlHelper.ExecuteQuery("insert into custome(name,age)values('张三',19)");
            MessageBox.Show("插入成功！");
        }

        //删除
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SqlHelper.ExecuteQuery("delete from custome where name='a'");
            MessageBox.Show("删除成功！");
        }

        //修改
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            SqlHelper.ExecuteQuery("update custome set name='李四' where age=19");
            MessageBox.Show("修改成功！");
        }

        //推出
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Close();
        }

        //查询
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            DataTable table=SqlHelper.ExecuteDataTable("select * from custome");
            foreach (DataRow row in table.Rows)
            {
                string name = (string)row["Name"];
                int age = (int)row["Age"];
                txt.Text= name+age;

                MessageBox.Show(name+age);
            }
        }
    }
}
