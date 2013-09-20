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

namespace 数据绑定
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

        //绑定数据到listbox中
        private void Grid_Loaded_1(object sender, RoutedEventArgs e)
        {
            List<Student> list = new List<Student>();
            list.Add(new Student { Name = "小红", Age = 3, Score = 90 });
            list.Add(new Student { Name = "雨昂分", Age = 23, Score = 50 });
            list.Add(new Student { Name = "袁芳", Age = 33, Score = 60 });
            list.Add(new Student { Name = "方圆", Age = 43, Score = 70 });
            list.Add(new Student { Name = "小黑", Age = 53, Score = 80 });
            listbox.ItemsSource = list;
        }

        //选择时弹出对应的消息框
        private void ListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            Student student = (Student)listbox.SelectedItem;
            MessageBox.Show(student.Name.ToString());
        }
    }
}
