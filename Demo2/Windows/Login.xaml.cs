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
            var moder = DEMO4Entities.GetContext().Модераторы.FirstOrDefault(m => m.телефон == textboxlogin.Text);
            var moder2 = DEMO4Entities.GetContext().Модераторы.FirstOrDefault(m => m.пароль == textboxpass.Text);

            if (moder != null && moder2 != null)
            {
                Moderator moderator = new Moderator(moder as Demo2.Модераторы);
                moderator.Show();
                this.Close();
            }

            var org = DEMO4Entities.GetContext().Организаторы.FirstOrDefault(m => m.телефон == textboxlogin.Text);
            var org2 = DEMO4Entities.GetContext().Организаторы.FirstOrDefault(m => m.пароль == textboxpass.Text);

            if (org != null && org2 != null)
            {
                Organizer organizer = new Organizer();
                organizer.Show();
                this.Close();
            }
        }

        private void EnterWithout(object sender, RoutedEventArgs e)
        {

        }
    }
}
