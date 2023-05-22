using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CaptchaModel;
using Demo2.Windows;

namespace Demo2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Captcha captcha;
        private string captchaText;
        public MainWindow()
        {
            InitializeComponent();

             Login registration = new Login();
             registration.Show();
             this.Close();
            captcha = new Captcha();
            // генерируем и отображаем капчу
            captchaText = captcha.getImage();
            byte[] bytes = Convert.FromBase64String(captchaText);
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = new MemoryStream(bytes);
            bitmapImage.EndInit();
            captchaImage.Source = bitmapImage;
        }

        private void IsRobot(object sender, RoutedEventArgs e)
        {
            if (textboxCaptcha.Text.Equals(captcha.getText()))
            {
                Login login = new Login();
                login.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Некорректный ввод, попробуйте еще раз");
                captcha = new Captcha();
                captchaText = captcha.getImage();
                byte[] bytes = Convert.FromBase64String(captchaText);
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = new MemoryStream(bytes);
                bitmapImage.EndInit();
                captchaImage.Source = bitmapImage;
                textboxCaptcha.Clear();
            }
        }

        private void Refresh(object sender, RoutedEventArgs e)
        {
            captcha = new Captcha();
            captchaText = captcha.getImage();
            byte[] bytes = Convert.FromBase64String(captchaText);
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = new MemoryStream(bytes);
            bitmapImage.EndInit();
            captchaImage.Source = bitmapImage;
            textboxCaptcha.Clear();
        }
    }
}
