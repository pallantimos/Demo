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
        }

        private void Main(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void Registrate(object sender, RoutedEventArgs e)
        {
            string connString = @"Data Source = DBSRV\mam2022; Initial Catalog = DEMO4; Integrated Security = True;";
            SqlConnection sqlConnection = new SqlConnection(connString);
            sqlConnection.Open();

            string hashpass = CaptchaModel.Captcha.GetHashString(textboxpass.Text);
            string command = "insert into Жюри values (@login, 'мужской',@email, @data, 82, @phone, @direction, @pass, 12)";
            SqlCommand cmd = new SqlCommand(command, sqlConnection);
            cmd.Parameters.Add("@login", SqlDbType.VarChar, 255).Value = textboxlogin.Text;
            cmd.Parameters.Add("@data", SqlDbType.VarChar, 255).Value = textboxbirth.Text;
            cmd.Parameters.Add("@email", SqlDbType.VarChar, 255).Value = textboxemail.Text;
            cmd.Parameters.Add("@phone", SqlDbType.VarChar, 255).Value = textboxnumber.Text;
            cmd.Parameters.Add("@direction", SqlDbType.VarChar, 255).Value = comboboxway.SelectedValue.ToString();
            cmd.Parameters.Add("@pass", SqlDbType.VarChar, 255).Value = hashpass;
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
            //SqlCommand sqlCommand = new SqlCommand("INSERT INTO Жюри VALUES('" + textboxlogin.Text + "', '" + textboxsex.Text + "', '"
            //            + textboxemail.Text + "', '" + textboxbirth.Text + "', " + textboxcountry.Text + ", '" +
            //             textboxnumber.Text + "', '" + comboboxway.SelectedValue.ToString() + "', '" + hashpass + "' + '1')", sqlConnection);
        }
    }
}
