using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.IO;

namespace TaskLibrary.Manager.LocalMemory
{
    public  class LocalMemoryBaseClass<T>
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
            FileStream myStream = File.Open($@"{dbPath}\{Name}.txt", FileMode.Open);
            StreamWriter writer = new StreamWriter(myStream);
            string serialize = JsonConvert.SerializeObject(collectionClasses);
            writer.WriteLine(serialize);
            writer.Close();
            myStream.Close();
        }
    }
}
