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

namespace 数据绑定
{
    /// <summary>
    /// Bingding.xaml 的交互逻辑
    /// </summary>
    public partial class Bingding : Window
    {
        private Student stu = new Student();
        public Bingding()
        {
            InitializeComponent();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            //绑定数据到文本框
            stu.Name = "张三";
            stu.Height = 190;
            stu.Age = 19;
            this.DataContext = stu;

            Student st = new Student();
            st.Score = 123456;
            txt.DataContext = st;

            //绑定数据到ComboBox
            List<string> li = new List<string>();
            li.Add("123");
            li.Add("1223");
            li.Add("1323");
            li.Add("1423");
            li.Add("1253");
            combobox.ItemsSource = li;

            //绑定数据到DataGrid
            List<Student> lis = new List<Student>();
            lis.Add(new Student { Name = "张三", Age = 19 });
            lis.Add(new Student { Name = "李四", Age = 29 });
            lis.Add(new Student { Name = "王五", Age = 39 });
            lis.Add(new Student { Name = "招六", Age = 49 });
            lis.Add(new Student { Name = "马奇", Age = 59 });
            dg.ItemsSource = lis;

            
        }
    }
}
