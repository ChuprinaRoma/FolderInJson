using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace FolderInJson.model
{
    public class Parser
    {
        public string GetStrJsonForDirectory(string directory)
        {
            string strJsonForDirectory = null;
            if (Directory.Exists(directory) || File.Exists(directory))
            {
                ModelFolder modelFolder = GetFullModelFolder(directory);
                strJsonForDirectory = JsonConvert.SerializeObject(modelFolder);
            }
            else
            {
                Console.WriteLine("Была введина не правильная директроия");
            }
            
            return strJsonForDirectory;
        }



        private ModelFolder GetFullModelFolder(string directry)
        {
            string nameFile = null;
            string fullNameFile = null;
            string createTimeFile = null;
            List<ModelFolder> subDyrectry = null;
            List<string> allDirectry = new List<string>();

            nameFile = directry.Replace(":\\", "");
            nameFile = nameFile.Remove(0, nameFile.LastIndexOf("\\")+1);
            fullNameFile = directry.Replace(":\\", "");
            createTimeFile = Directory.GetCreationTime(directry).ToString();
            if (Directory.Exists(directry))
            {
                try
                {
                    allDirectry.AddRange(Directory.GetFiles(directry));
                    allDirectry.AddRange(Directory.GetDirectories(directry));
                    subDyrectry = GetSubDirectiry(allDirectry);
                }
                catch(UnauthorizedAccessException)
                {
                    Console.WriteLine($"Не возможно парсить даную директорию ({directry}), из-за у приложения нету разрешений админа");
                }
            }

            return new ModelFolder(nameFile, fullNameFile, createTimeFile, subDyrectry);
        }

        private List<ModelFolder> GetSubDirectiry(List<string> allDirectry)
        {
            List<ModelFolder> listModelFolders = new List<ModelFolder>();
            foreach(var directory in allDirectry)
            {
                listModelFolders.Add(GetFullModelFolder(directory));
            }
            return listModelFolders;
        }
    }
}
