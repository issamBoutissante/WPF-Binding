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
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
namespace Wpf_Binding
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        static string ConnectionString = ConfigurationManager.ConnectionStrings["banqueConnection"].ConnectionString;
        SqlConnection connection;
        SqlDataAdapter ComptesAdapter;
        SqlDataAdapter ClientAdapter;
        DataSet dataSet;
        public UserControl1()
        {
            InitializeComponent();
            connection = new SqlConnection(ConnectionString);
            dataSet = new DataSet();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ComptesAdapter = new SqlDataAdapter("select * from compte", connection);
            ComptesAdapter.Fill(dataSet, "compte");

            ClientAdapter = new SqlDataAdapter("select * from client", connection);
            ClientAdapter.Fill(dataSet, "client");

            DataView compteView = dataSet.Tables["compte"].DefaultView;
            ComptesGrid.ItemsSource = compteView;
            numClient.ItemsSource = dataSet.Tables["client"].DefaultView;
            this.DataContext = compteView;
        }
    }
}
