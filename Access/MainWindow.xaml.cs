using System;
using System.Collections.Generic;
using System.Data.OleDb;
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

namespace Access
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OleDbConnection cn;
        public MainWindow()
        {
            InitializeComponent();
            cn = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = |DataDirectory|Classwork 6.accdb");
            cn.Open();
        }

        private void SeeAssets_Click(object sender, RoutedEventArgs e)
        {
            string AssetID = "select * from Assets";
            OleDbCommand cmd = new OleDbCommand(AssetID, cn);
            OleDbDataReader read = cmd.ExecuteReader();
            string data = "";
            while (read.Read())
            {
                data += "EmployeeID: " + read[0].ToString() + "  AssestID: " + read[1].ToString() + "  Description: " + read[2].ToString() + "\n";
            }
            Text1.Text = data;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string EmployeeID = "select * from Employees";
            OleDbCommand cmd = new OleDbCommand(EmployeeID, cn);
            OleDbDataReader read = cmd.ExecuteReader();
            string data = "";
            while (read.Read())
            {
                data += "EmployeeID: " + read[0].ToString() + "  FirstName: " + read[1].ToString() + "  LastName: " + read[2].ToString() + "\n";
            }
            Text2.Text = data;
        }
    }
}
