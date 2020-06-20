using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskLibrary.Entityes;

namespace TaskLibrary.Manager.LocalMemory
{
    class LocalMemoryClass
    {
        string dbPath = $@"{new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName}";
        public ObservableCollection<CategoryClass>  categoryClasses = new ObservableCollection<CategoryClass>();
        public LocalMemoryClass()
        {

            if (File.Exists($@"{dbPath}\Category.txt"))
            {
                string deserialze = File.ReadAllText($@"{dbPath}\Category.txt");
                categoryClasses = JsonConvert.DeserializeObject<ObservableCollection<CategoryClass>>(deserialze);
            }
            else
            {
                FileStream myStream = File.Create($@"{dbPath}\Category.txt");
                string json = "[]";
                StreamWriter writer = new StreamWriter(myStream);
                writer.WriteLine(json);
                writer.Close();
            }
        }
        public void Serialize()
        {
            string serialize = JsonConvert.SerializeObject(categoryClasses);
            File.WriteAllText($@"{dbPath}\Category.txt", serialize);
        }
    }
}
