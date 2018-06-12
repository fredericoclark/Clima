using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace Measurements
{
    public class MedEntity : TableEntity
    {
        public MedEntity(string regiao)
        {
            PartitionKey = regiao;
            RowKey = RowKey = Guid.NewGuid().ToString();
        }

        public MedEntity() { }


        public string MAC_Adress { get; set; }
        public float Temperatura { get; set; }
        public float Umidade { get; set; }
        public string Status_Chuva { get; set; }
        public string Intensidade_Chuva { get; set; }
    }
}
