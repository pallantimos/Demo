using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class Item
    {
        public string Name { get; set; }
        public int Day { get; set; }
        public TimeSpan time { get; set; }


        // Дополнительные свойства, если необходимо
    }

    public partial class AddEvent : Window
    {
        private Мероприятия _current = new Мероприятия();
        public ObservableCollection<Активности> ActivtiyCollection = new ObservableCollection<Активности>();

        public AddEvent()
        {
            InitializeComponent();
            DataContext = _current;

            Активности act1 = new Активности();
            Активности act2 = new Активности();
            Активности act3 = new Активности();

            ActivtiyCollection.Add(act1);
            ActivtiyCollection.Add(act2);
            ActivtiyCollection.Add(act3);

            DatagridActivities.ItemsSource = ActivtiyCollection;

            comboboxcity.ItemsSource = DEMO4Entities.GetContext().Город.OrderBy(g => g.Название).Select(g => g.Название).ToList();

            DatagridActivities.ItemsSource = ActivtiyCollection;
        }

        private void CreateEvent(object sender, RoutedEventArgs e)
        {
            _current.Город = DEMO4Entities.GetContext().Город.FirstOrDefault(g => g.Название == comboboxcity.Text).Номер;
            _current.C_ = 22;

            if (_current.id == 0)
            {
                DEMO4Entities.GetContext().Мероприятия.Add(_current);


                ActivtiyCollection[0].id_Мероприятия = _current.id;
                ActivtiyCollection[1].id_Мероприятия = _current.id;
                ActivtiyCollection[2].id_Мероприятия = _current.id;
                DEMO4Entities.GetContext().Активности.Add(ActivtiyCollection[0]);
                DEMO4Entities.GetContext().Активности.Add(ActivtiyCollection[1]);
                DEMO4Entities.GetContext().Активности.Add(ActivtiyCollection[2]);
            }

            try
            {
                DEMO4Entities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            Events ev = new Events();
            ev.Show();
            this.Close();
        }
    }
}
