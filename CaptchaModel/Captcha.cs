using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;

namespace CaptchaModel
{
    public class Captcha
    {
        static private string captchaText;
        static private string captchaImage;

        public Captcha()
        {
            GenerateCaptcha();
        }

        static public void GenerateCaptcha()
        {
            // генерируем случайный текст
            captchaText = GenerateRandomText();

            // создаем изображение с текстом
            Bitmap bitmap = new Bitmap(150, 50);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.DrawString(captchaText, new Font("Arial", 20), new SolidBrush(Color.Black), new PointF(0, 0));
            graphics.Flush();

            // сохраняем изображение в поток
            MemoryStream stream = new MemoryStream();
            bitmap.Save(stream, ImageFormat.Png);

            // конвертируем изображение в массив байтов и возвращаем его в виде строки
            byte[] bytes = stream.ToArray();
            captchaImage = Convert.ToBase64String(bytes);
        }

        public string getText() { return captchaText; }
        public string getImage() { return captchaImage; }

        static public string GenerateRandomText()
        {
            // список символов, которые будут использоваться в капче
            string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            // генерируем случайную строку длиной 6 символов
            Random random = new Random();
            char[] captchaChars = new char[6];

            for (int i = 0; i < captchaChars.Length; i++)
            {
                captchaChars[i] = chars[random.Next(chars.Length)];
            }

            string captchaText = new string(captchaChars);

            return captchaText;
        }
    }
}
