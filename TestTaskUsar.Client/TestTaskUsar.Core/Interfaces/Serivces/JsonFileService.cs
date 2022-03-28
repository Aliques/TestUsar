using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using TestTaskUsar.Core.Services;

namespace TestTaskUsar.Core.Interfaces.Serivces
{
    public class JsonFileService : IFileService
    {
        public List<Message> Open(string filename)
        {
            List<Message> phones = new List<Message>();
            DataContractJsonSerializer jsonFormatter =
                new DataContractJsonSerializer(typeof(List<Message>));
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                phones = jsonFormatter.ReadObject(fs) as List<Message>;
            }

            return phones;
        }

        public void Save(string filename, List<Message> phonesList)
        {
            DataContractJsonSerializer jsonFormatter =
                new DataContractJsonSerializer(typeof(List<Message>));
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                jsonFormatter.WriteObject(fs, phonesList);
            }
        }
    }
}
