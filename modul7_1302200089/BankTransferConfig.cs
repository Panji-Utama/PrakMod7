using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modul7_1302200089
{
    internal class BankTransferConfig
    {
        public dynamic ReadJson()
        {
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string jsonString = File.ReadAllText(path + "/bank_transfer_config.json");

            dynamic config = JsonConvert.DeserializeObject(jsonString);
            return config;
        }
    }
}


