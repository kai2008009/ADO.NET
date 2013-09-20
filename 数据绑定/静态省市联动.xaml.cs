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
    /// 省市联动.xaml 的交互逻辑
    /// </summary>
    public partial class 省市联动 : Window
    {
        public 省市联动()
        {
            InitializeComponent();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            List<string> list = new List<string>();
            list.Add("山东");
            list.Add("湖南");
            list.Add("广东");
            list.Add("广西");
            listbox1.ItemsSource = list;
        }

        private void listbox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string prow = (string)listbox1.SelectedItem;
            if (prow == "山东")
            {
                List<string> city = new List<string>();
                city.Add("济南");
                city.Add("青岛");
                city.Add("烟台");
                city.Add("德州");
                listbox2.ItemsSource = city;
            }
            else if (prow == "湖南")
            {
                List<string> city =new List<string>();
                city.Add("永州");
                city.Add("长沙");
                city.Add("衡阳");
                city.Add("株洲");
                city.Add("湘潭");
                city.Add("岳阳");
                city.Add("常德");
                city.Add("郴州");
                city.Add("邵阳");
                listbox2.ItemsSource = city;
            }
            else if (prow == "广东")
            {
                List<string> city = new List<string>();
                city.Add("广州");
                city.Add("深圳");
                city.Add("佛山");
                city.Add("珠海");
                city.Add("茂名");
                city.Add("肇庆");
                listbox2.ItemsSource = city;
            }
            else if (prow == "广西")
            {
                List<string> city = new List<string>();
                city.Add("桂林");
                city.Add("南宁");
                city.Add("北海");
                city.Add("河池");
                listbox2.ItemsSource = city;
            }
            }

        private void listbox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string prod = (string)listbox2.SelectedItem;
            if (prod == "永州")
            {
                List<string> city = new List<string>();
                city.Add("祁阳");
                city.Add("祁东");
                listbox3.ItemsSource = city;
            }
            else if (prod == "长沙")
            {
                List<string> city = new List<string>();
                city.Add("宁乡");
                city.Add("浏阳");
                listbox3.ItemsSource = city;
            }
        }

    }
}
