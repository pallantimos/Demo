using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
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
using MaterialDesignThemes.Wpf;

namespace Demo2.Windows
{
    public class NotEmptyValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return string.IsNullOrWhiteSpace((value ?? "").ToString())
                ? new ValidationResult(false, "Поле обязательно") : ValidationResult.ValidResult;
        }
    }
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        private Модераторы _current = new Модераторы();
        public Registration()
        {
            InitializeComponent();
            DataContext = _current;
            comboboxcountry.ItemsSource = DEMO4Entities.GetContext().Страны.OrderBy(s => s.Название_страны).Select(s => s.Название_страны).ToList();
            comboboxactivity.ItemsSource = DEMO4Entities.GetContext().Активности.OrderBy(s => s.Активность).Select(s => s.Активность).ToList();
        }

        private void Main(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void Registrate(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if(_current.id == 0)
            {
                var activity = DEMO4Entities.GetContext().Активности.FirstOrDefault(act => act.Активность == comboboxactivity.Text);
                if(activity.id_Модератора != null)
                {
                    MessageBox.Show("Активность уже модерируется!");
                    return;
                }
                activity.id_Модератора = _current.id;
                _current.страна = DEMO4Entities.GetContext().Страны.FirstOrDefault(s => s.Название_страны == comboboxcountry.Text).Код2;
                DEMO4Entities.GetContext().Модераторы.Add(_current);
            }

            try
            {
                DEMO4Entities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);    
            }
        }

        private void isChecked(object sender, RoutedEventArgs e)
        {
            if (Check.IsChecked == true) comboboxactivity.IsEnabled = true;
            else {
                comboboxactivity.IsEnabled = false;
                comboboxactivity.Text = "";
            }
        }

        private void ShowPasswordClick(object sender, RoutedEventArgs e)
        {
            if (PasswordBoxAssist.GetIsPasswordRevealed(textboxpass) == true)
            {
                PasswordBoxAssist.SetIsPasswordRevealed(textboxpass, false);
                PasswordBoxAssist.SetIsPasswordRevealed(textboxpass2, false);
            }
            else
            {
                PasswordBoxAssist.SetIsPasswordRevealed(textboxpass2, true);
                PasswordBoxAssist.SetIsPasswordRevealed(textboxpass, true);
            }
        }
    }
}
