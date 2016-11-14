using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using WpfApplication2.service_sql;
//
using System.Xml;
using System.Data;
using System.Threading;
using System.Data.SqlClient;

//

namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            textBox.Foreground = Brushes.Gray;
            textBox.Text = "SQL Command goes here";
        }

        private void textBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (textBox.Foreground == Brushes.Gray)
            {
                textBox.Foreground = Brushes.Black;
                textBox.Text = "";
            }
        }

        private void textBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textBox.Text == "")
            {
                textBox.Foreground = Brushes.Gray;
                textBox.Text = "SQL Command goes here";
            }
        }

        private void button_Click(object sender, RoutedEventArgs e) //http://stackoverflow.com/questions/15865829/add-items-to-columns-in-a-wpf-listview
        {
            SqlCommand asd = new SqlCommand();
            if (textBox.Foreground == Brushes.Gray || textBox.Text == "")
                return;
            listView.Focus();
            Mouse.OverrideCursor = Cursors.Wait;
            Fel4Client fl = new Fel4Client();
            string xmlString = fl.Query(textBox.Text);
            if(xmlString=="")
            {
                MessageBox.Show("A tábla nem tartalmaz adatokat", "Empty", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                Mouse.OverrideCursor = null;
                return;
            }
            try
            {
                XmlDocument xml = new XmlDocument();
                XmlNodeReader xr = new XmlNodeReader(xml);
                xml.LoadXml(xmlString);
                DataSet ds = new DataSet();
                ds.ReadXml(xr);

                textBox.Foreground = Brushes.Gray;
                textBox.Text = "SQL Command goes here";
                //listView.Items.Clear();
                GridView gv = new GridView();
                listView.View = gv;
                listView.ItemsSource = ds.Tables[0].DefaultView;
                foreach (XmlAttribute item in xml.DocumentElement.FirstChild.Attributes)
                {
                    gv.Columns.Add(new GridViewColumn
                    {
                        Header = item.Name,
                        DisplayMemberBinding = new Binding(item.Name)
                    });
                }
            }
            catch (XmlException)
            {
                MessageBox.Show(xmlString, "SQL ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                Mouse.OverrideCursor = null;
                //richTextBox.Visibility = Visibility.Hidden;
                fl.Close();
            }
        }
    }
}
