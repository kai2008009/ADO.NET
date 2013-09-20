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
using 登录判断;
using System.Data;
using System.Data.SqlClient;


namespace 省市联动
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            DataTable datable = SqlHelper.ExecuteDataTable("select * from AreaFull where AreaPid=0");

            List<Area> listProv = new List<Area>();

            foreach (DataRow row in datable.Rows)
            {
                Area area = new Area();
                area.AreaID = (int)row["AreaId"];
                area.AreaName = (string)row["AreaName"];
                listProv.Add(area);
            }
            listbox1.ItemsSource = listProv;
        }

        private void listbox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //获得选择的省的Area对象
            Area area = (Area)listbox1.SelectedItem;

            DataTable dtCity = SqlHelper.ExecuteDataTable("select * from AreaFull where AreaPid=@pid",
                new SqlParameter("@Pid", area.AreaID));

            List<Area> listCity = new List<Area>();

            foreach (DataRow row in dtCity.Rows)
            {
                Area areaCtiry = new Area();
                areaCtiry.AreaID = (int)row["AreaId"];
                areaCtiry.AreaName = (string)row["AreaName"];
                listCity.Add(areaCtiry);
            }
            listbox2.ItemsSource = listCity;
        }

        private void listbox2_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            Area area = (Area)listbox2.SelectedItem;

            DataTable dtCity = SqlHelper.ExecuteDataTable("select * from AreaFull where AreaPid=@pid",
                new SqlParameter("@Pid", area.AreaID));

            List<Area> listCity = new List<Area>();

            foreach (DataRow row in dtCity.Rows)
            {
                Area areaCtiry = new Area();
                areaCtiry.AreaID = (int)row["AreaId"];
                areaCtiry.AreaName = (string)row["AreaName"];
                listCity.Add(areaCtiry);

            }
            listbox3.ItemsSource = listCity;
        }
    }
}
