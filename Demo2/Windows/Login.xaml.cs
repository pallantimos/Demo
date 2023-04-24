using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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

namespace Demo2.Windows
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Registration(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Close();
        }

        private void Enter(object sender, RoutedEventArgs e)
        {
            string connString = @"Data Source = DBSRV\mam2022; Initial Catalog = DEMO4 Integrated Security = True;";
            SqlConnection sqlConnection = new SqlConnection(connString);
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand("SELECT * from Жюри Where почта ='" + textboxlogin.Text + "' AND Пароль = '" + textboxpass.Text + "'", sqlConnection);
            SqlDataReader sqlDataReader3 = sqlCommand.ExecuteReader();

            if (sqlDataReader3.Read())
            {
                Jury jury = new Jury();
                jury.Show();
                this.Close();
            }
            sqlDataReader3.Close();

            //SqlCommand sqlCommand2 = new SqlCommand("SELECT * from Сотрудники Where Логин ='" + textboxlogin.Text + "' AND Пароль = '" + textboxpass.Password + "'", sqlConnection);
            //sqlDataReader3 = sqlCommand2.ExecuteReader();

            //if (sqlDataReader3.Read())
            //{
            //    Librarian librarian = new Librarian();
            //    librarian.Show();
            //    this.Close();
            //}

            //sqlDataReader3.Close();
            sqlConnection.Close();
        }

        private void EnterWithout(object sender, RoutedEventArgs e)
        {

        }
    }
}
