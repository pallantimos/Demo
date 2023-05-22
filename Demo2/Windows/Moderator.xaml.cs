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
        public Moderator(Demo2.Модераторы moder)
        {   
            InitializeComponent();
            if (DateTime.Now.Hour > 10 && DateTime.Now.Hour < 18) time.Text = "Добрый день!";
            else if (DateTime.Now.Hour > 8 && DateTime.Now.Hour < 11) time.Text = "Доброе утро!";
            else if (DateTime.Now.Hour < 9) time.Text = "Доброй ночи!";
            else time.Text = "Добрый вечер!";

            if (moder.пол == "мужской") name.Text = "Mr " + moder.ФИО.Split(' ')[0];
            else name.Text = "Ms " + moder.ФИО.Split(' ')[0];

            DatagridActivities.ItemsSource = DEMO4Entities.GetContext().Активности.ToList();
        }

        private void FilterbyWay(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void FilterbyEvent(object sender, EventArgs e)
        {
            var merop = DEMO4Entities.GetContext().Мероприятия.FirstOrDefault(mer => mer.Название.ToString() == comboboxevent.Text);
            var activ = DEMO4Entities.GetContext().Активности.Where(act => act.id_Мероприятия == merop.id).ToList();

            DatagridActivities.ItemsSource = activ;
        }

        private void ClickRequest(object sender, RoutedEventArgs e)
        {

        }
    }
}
