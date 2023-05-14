using System;
using System.Collections.Generic;
using System.Configuration;
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
using System.Windows.Shapes;

namespace Demo2.Windows
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
            comboboxway.IsEnabled = false;
        }

        private void Main(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void Registrate(object sender, RoutedEventArgs e)
        {
            string connString = @ConfigurationManager.AppSettings.Get("connString"); ;
            SqlConnection sqlConnection = new SqlConnection(connString);
            sqlConnection.Open();

            string command;

            if (comboboxrole.SelectedIndex == 1)
            {
                command = "insert into Жюри values (@id, @FIO, @sex , @email, @data, @country, @phone, @direction, @pass, 12)";

            }else
            {
                command = "insert into Модераторы values (@id, @FIO, @sex , @email, @birth, @country, @phone, @way, @pass, @event)";
            }

            string hashpass = CaptchaModel.Captcha.GetHashString(textboxpass.Text);
            SqlCommand cmd = new SqlCommand(command, sqlConnection);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = textboxnumber.Text;
            cmd.Parameters.Add("@FIO", SqlDbType.VarChar, 255).Value = textboxfio.Text;
            cmd.Parameters.Add("@sex", SqlDbType.VarChar, 255).Value = comboboxsex.Text;
            SqlCommand cmd2 = new SqlCommand(command, sqlConnection);
            cmd2 = new SqlCommand("Select id from Мероприятия Where Название = '" + comboboxway.Text + "'", sqlConnection);
            SqlDataReader sqlDataReader = cmd2.ExecuteReader();
            if(sqlDataReader.Read()) cmd.Parameters.Add("@event", SqlDbType.Int).Value = sqlDataReader[0];
            else cmd.Parameters.Add("@event", SqlDbType.Int).Value = "";
            cmd.Parameters.Add("@way", SqlDbType.VarChar, 255).Value = textboxway.Text;   
            cmd.Parameters.Add("@birth", SqlDbType.VarChar, 255).Value = textboxbirth.Text;
            cmd.Parameters.Add("@country", SqlDbType.VarChar, 255).Value = textboxcountry.Text;
            cmd.Parameters.Add("@email", SqlDbType.VarChar, 255).Value = textboxemail.Text;
            cmd.Parameters.Add("@phone", SqlDbType.VarChar, 255).Value = textboxphone.Text;
            sqlDataReader.Close();
            cmd.Parameters.Add("@pass", SqlDbType.VarChar, 255).Value = hashpass;
            cmd.ExecuteNonQuery();

            //cmd = new SqlCommand("Update мероприятия set Модератор = " + textboxnumber + " Where Название = " + comboboxway.Text, sqlConnection);
            //cmd.ExecuteNonQuery();
            sqlConnection.Close();
            //SqlCommand sqlCommand = new SqlCommand("INSERT INTO Жюри VALUES('" + textboxlogin.Text + "', '" + textboxsex.Text + "', '"
            //            + textboxemail.Text + "', '" + textboxbirth.Text + "', " + textboxcountry.Text + ", '" +
            //             textboxnumber.Text + "', '" + comboboxway.SelectedValue.ToString() + "', '" + hashpass + "' + '1')", sqlConnection);
        }

        private void isChecked(object sender, RoutedEventArgs e)
        {
            if (Check.IsChecked == true) comboboxway.IsEnabled = true;
            else {
                comboboxway.IsEnabled = false;
                comboboxway.Text = "";
            }
        }
    }
}
