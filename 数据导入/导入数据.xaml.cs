using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
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

namespace 登录判断
{
    /// <summary>
    /// 导入数据.xaml 的交互逻辑
    /// </summary>
    public partial class 导入数据 : Window
    {
        public 导入数据()
        {
            InitializeComponent();
        }

        //导入“张三|123”文本格式数据
        private void btn_insert_Click(object sender, RoutedEventArgs e)
        {
            //打开文本
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "文本文件|*.txt";
            if (ofd.ShowDialog() != true)
            {
                return;
            }
            string filename = ofd.FileName;

            //把文件一次读取到string集合中
            IEnumerable<string> lines = File.ReadLines(filename, Encoding.Default);

            foreach (string line in lines)
            {
                string[] segs = line.Split('|', ' ');
                string name = segs[0];
                string age = segs[1];
                SqlHelper.ExecuteQuery("insert into custome(Name,Age)values(@Name,@Age)",
                    new SqlParameter("@Name", name),
                    new SqlParameter("@Age", Convert.ToInt32(age)));
            }
            MessageBox.Show("导入成功" + lines.Count() + "条数据!");
        }

        //导入“1300000	"北京市"	"联通"”文本格式数据
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "文本文件|*.txt";
            if (ofd.ShowDialog() == false)
            {
                return;
            }

            string[] lines = File.ReadLines(ofd.FileName, Encoding.Default).ToArray();

            for (int i = 1; i < lines.Count(); i++)
            {
                string line = lines[i];
                string[] str = line.Split('\t');
                string startTeLNum = str[0];
                string city = str[1];
                city = city.Trim('"');
                string telType = str[2];
                telType = telType.Trim('"');
                SqlHelper.ExecuteQuery(@"Insert into T_TelNum(StartTelNum,TelType,TelArea) 
                    values(@StartTelNum,@TelType,@TelArea)",
                    new SqlParameter("@StartTelNum", startTeLNum),
                new SqlParameter("@TelType", telType),
                new SqlParameter("@TelArea", city));
            }
            MessageBox.Show("导入成功！"+lines.Count()+"条数据");
        }
    }
}
