using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Demo2.Windows
{
    /// <summary>
    /// Логика взаимодействия для Moderator.xaml
    /// </summary>
    public partial class Moderator : Window
    {
        private SqlConnection sqlconnection;
        public Moderator(int id, string sex, string fio, SqlConnection sqlConnection, SqlDataReader sqlDataReader)
        {
            sqlDataReader.Close();
            this.sqlconnection = sqlConnection;
            InitializeComponent();
            if (DateTime.Now.Hour > 10 && DateTime.Now.Hour < 18) time.Text = "Добрый день!";
            else if (DateTime.Now.Hour > 8 && DateTime.Now.Hour < 11) time.Text = "Доброе утро!";
            else if (DateTime.Now.Hour < 9) time.Text = "Доброй ночи!";
            else time.Text = "Добрый вечер!";

            if (sex == "мужской") name.Text = "Mr " + fio.Split(' ')[1];
            else name.Text = "Mrs " + fio.Split(' ')[1];

            SqlCommand cmd = new SqlCommand("Select Название, Дата, Время_начала from Активности", sqlConnection);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "Активности");
            DatagridActivities.ItemsSource = dataSet.Tables["Активности"].DefaultView;
            
            sqlConnection.Close();
        }

        private void FilterbyWay(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void FilterbyEvent(object sender, EventArgs e)
        {
            sqlconnection.Open(); ;
            SqlCommand cmd2 = new SqlCommand("Select id from Мероприятия Where Название = '" + comboboxevent.Text + "'", sqlconnection);
            SqlDataReader sqlDataReader = cmd2.ExecuteReader();
            sqlDataReader.Read();
            SqlCommand cmd = new SqlCommand
           ("SELECT Название, Дата, Время_начала FROM Активности WHERE ID_мероприятия = " + sqlDataReader[0], sqlconnection);
            sqlDataReader.Close();

            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "Активности");
            DatagridActivities.ItemsSource = dataSet.Tables["Активности"].DefaultView;
            sqlconnection.Close();
        }

        private void ClickRequest(object sender, RoutedEventArgs e)
        {

        }
    }
}
