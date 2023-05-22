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

namespace Demo2.Windows
{
    /// <summary>
    /// Логика взаимодействия для Organizer.xaml
    /// </summary>
    public partial class Organizer : Window
    {
        public Organizer()
        {
            InitializeComponent();
        }

        private void EventsClick(object sender, RoutedEventArgs e)
        {
            Events events = new Events();
            events.Show();
            Close();
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            Login log = new Login();
            log.Show();

            this.Close();
        }

        private void Profileclick(object sender, RoutedEventArgs e)
        {
            MyProfile mp = new MyProfile();
            mp.Show();
            this.Close();
        }
    }
}
