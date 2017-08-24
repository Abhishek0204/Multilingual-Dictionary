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
using System.Data.SqlClient;

namespace WDictionary
{
    /// <summary>
    /// Interaction logic for EnglishToHindi.xaml
    /// </summary>
    public partial class EnglishToHindi : Window
    {
        String label;
        public EnglishToHindi()
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
            SqlCommand sd = new SqlCommand(@"SELECT Hindi_word FROM EnglishToHindi WHERE English_word= '" + textBox1.Text + "'", con);
            con.Open();
            SqlDataReader dr = sd.ExecuteReader();
            if (dr.Read())
            {
                label = dr.IsDBNull(dr.GetOrdinal("Hindi_word"))
                  ? String.Empty
                  : dr.GetString(dr.GetOrdinal("Hindi_word"));
            }
            dr.Close();
            label1.Content = label;

        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListBox.Items.Add(textBox1.Text);
        }

        
    }
}
