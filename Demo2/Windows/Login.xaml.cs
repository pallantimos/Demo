using System;
using System.Collections.Generic;
using System.Data;
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
using System.Configuration;
using System.Collections.Specialized;

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
            string connString = @ConfigurationManager.AppSettings.Get("connString");
            SqlConnection sqlConnection = new SqlConnection(connString);
            sqlConnection.Open();

            string hashpass = CaptchaModel.Captcha.GetHashString(textboxpass.Text);
            string command = "Select * from Модераторы Where телефон = @login AND пароль = @pass";
            SqlCommand cmd = new SqlCommand(command, sqlConnection);
            cmd.Parameters.Add("@login", SqlDbType.VarChar, 255).Value = textboxlogin.Text;
            cmd.Parameters.Add("@pass", SqlDbType.VarChar, 255).Value = hashpass;
            //SqlCommand sqlCommand = new SqlCommand("SELECT * from Жюри Where почта ='" + textboxlogin.Text + "' AND Пароль = '" + hashpass + "'", sqlConnection);
            SqlDataReader sqlDataReader = cmd.ExecuteReader();

            if (sqlDataReader.Read())
            {
                Moderator moderator = new Moderator((int)sqlDataReader["id"], (string)sqlDataReader["пол"], (string)sqlDataReader["ФИО"], sqlConnection, sqlDataReader);
                moderator.Show();
                this.Close();
            }
            sqlDataReader.Close();
            sqlConnection.Close();
        }

        private void EnterWithout(object sender, RoutedEventArgs e)
        {

        }
    }
}
