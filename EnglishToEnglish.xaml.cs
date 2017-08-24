using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
using System.Data.SqlClient;

namespace WDictionary
{
    /// <summary>
    /// Interaction logic for EnglishToEnglish.xaml
    /// </summary>
    public partial class EnglishToEnglish : Window
    {
        String label;
        public EnglishToEnglish()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-1EN6S3H;Initial Catalog=dictionary;Integrated Security=True");
            SqlCommand sd = new SqlCommand(@"SELECT definition FROM EnglishToEnglish WHERE word= '" + searchBox.Text + "'", con);
            con.Open();
            SqlDataReader dr = sd.ExecuteReader();
            if (dr.Read())
            {
                label = dr.IsDBNull(dr.GetOrdinal("definition"))
                  ? String.Empty
                  : dr.GetString(dr.GetOrdinal("definition"));
            }
            dr.Close();
            result.Text = label;
        }

        private void searchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            {
                ListBox.Items.Add(searchBox.Text);
            }
           
        }
    }
}