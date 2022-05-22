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
using MySql.Data.MySqlClient;
using RealEstate;

namespace RealEstateGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Seller> sellers = new List<Seller>();
        MySqlConnection conn = new MySqlConnection("server=localhost; user=root; database=ingatlan; port=3306");

        public MainWindow()
        {
            InitializeComponent();

            try
            {

                conn.Open();
                string sql = "SELECT * FROM sellers";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {

                    sellers.Add(new Seller() { 
                        
                        id = Convert.ToInt32(rdr["Id"].ToString()),
                        Name = rdr["Name"].ToString(),
                        Phone = rdr["Phone"].ToString()

                    });

                }

                rdr.Close();

            }catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }

            conn.Close();

            this.LB_Eladok.ItemsSource = sellers;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                conn.Open();
                string sql = "SELECT COUNT(id) AS darabSzam FROM realestates WHERE sellerId = @sellerid";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.Add(new MySqlParameter("@sellerId", (LB_Eladok.SelectedItem as Seller).id));

                MySqlDataReader rdr = cmd.ExecuteReader();

                rdr.Read();
                LBL_hirdetesekSzama.Content = rdr["darabszam"].ToString();
                rdr.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            conn.Close();
        }
    }
}
