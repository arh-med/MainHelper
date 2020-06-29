using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Manager.LocalMemory.LocalMemoryBase
{
    public class LocalMemoryBaseClass<T>
    {
        string dbPath = $@"{new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName}";
        public ObservableCollection<T> collectionClasses = new ObservableCollection<T>();
        public string Name;
        public LocalMemoryBaseClass(string Name)
        {
            this.Name = Name;
            if (File.Exists($@"{dbPath}\{Name}.txt"))
            {
                FileStream myStream = File.OpenRead($@"{dbPath}\{Name}.txt");
                StreamReader streamReader = new StreamReader(myStream);
                string deserialze1 = streamReader.ReadToEnd();
                collectionClasses = JsonConvert.DeserializeObject<ObservableCollection<T>>(deserialze1);
                streamReader.Close();
                myStream.Close();

            }
            else
            {
                FileStream myStream = File.Create($@"{dbPath}\{Name}.txt");
                string json = "[]";
                StreamWriter writer = new StreamWriter(myStream);
                writer.WriteLine(json);
                writer.Close();
                myStream.Close();
            }
        }
        public void Serialize()
        {
            string serialize = JsonConvert.SerializeObject(collectionClasses);
            File.WriteAllText($@"{dbPath}\{Name}.txt", serialize);
        }
    }
}
