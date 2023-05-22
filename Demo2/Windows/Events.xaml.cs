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
    /// Логика взаимодействия для Events.xaml
    /// </summary>
    public partial class Events : Window
    {
        public Events()
        {
            InitializeComponent();
            DatagridActivities.ItemsSource = DEMO4Entities.GetContext().Мероприятия.ToList();
        }

        private void ClickAddEvent(object sender, RoutedEventArgs e)
        {
            AddEvent addEvent = new AddEvent();
            addEvent.Show();

            this.Close();
        }

        private void ClickBack(object sender, RoutedEventArgs e)
        {
            Organizer org = new Organizer();
            org.Show();
            this.Close();
        }
    }
}
