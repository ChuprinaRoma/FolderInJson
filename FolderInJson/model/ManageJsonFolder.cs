using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FolderInJson.model
{
    public class ManageJsonFolder
    {
        private Parser parser = null;

        public ManageJsonFolder()
        {
            Task.Run(() => Work()).GetAwaiter().GetResult();
        }

        private void Work()
        {
            parser = new Parser();
            string strJson = null;
            while(true)
            {
                Console.WriteLine("Введите путь директори которой хотите парсить!!\n" +
                    @"Пример: С:\\fOLDER\FOLDER");
                string selectDirectori = Console.ReadLine();
                strJson = parser.GetStrJsonForDirectory(selectDirectori);
                WriteToFile(strJson);
            }
        }

        private void WriteToFile(string strJson)
        {
            if(strJson != null)
            {
                File.WriteAllText("../../Write/FolderJsonDirictory.json", strJson);
                Console.WriteLine($"Json = {strJson}");
                Console.WriteLine();
                Console.WriteLine($"Ваша json строка записаны в файл FolderJsonDirictory(в папке Write)");
                Console.WriteLine();
            }
        }
    }
}
