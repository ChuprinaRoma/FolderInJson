using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderInJson.model
{
    public class ModelFolder
    {
        public string NameFile { get; set; }
        public string Path { get; set; }
        public string CreateTimeFile { get; set; }
        public List<ModelFolder> SubDirectry { get; set; }

        public ModelFolder(string nameFile, string path, string createTimeFile, List<ModelFolder> subDirectry)
        {
            NameFile = nameFile;
            Path = path;
            CreateTimeFile = createTimeFile;
            SubDirectry = subDirectry;
        }
    }
}
