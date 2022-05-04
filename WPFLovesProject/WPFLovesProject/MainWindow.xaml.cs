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

namespace WPFLovesProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
   
        public MainWindow()
        {
            InitializeComponent();

            cbostore.Items.Add("1");
            cbostore.Items.Add("2");
            cbostore.Items.Add("3");
            cbostore.Items.Add("4");


        }

        //private void MainWindow_Load(object sender, EventArgs e)
        //{
        //    command = new SqlCommand();
        //    command.CommandText = "SELECT * FROM SalesPrice";
        //    dr = command.ExecuteReader();

        //    while (dr.Read())
        //    {
        //        cbostore.Items.Add(dr["StoreNumber"]);
        //    }
           
        //}
    }
}
