using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ssd2
{
    internal static class HomePath
    {
        public static string HP { get; private set; }

        static HomePath()
        {
            // Используем папку "Документы" текущего пользователя
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var imagesDirectory = Path.Combine(documentsPath, "MyAppImages");

            // Создаем каталог, если он не существует
            if (!Directory.Exists(imagesDirectory))
            {
                Directory.CreateDirectory(imagesDirectory);
            }

            HP = imagesDirectory + Path.DirectorySeparatorChar;
        }
    }
}
