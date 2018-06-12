using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace Measurements
{
    public class IPEntity : TableEntity
    {
        public IPEntity(string regiao, string mac)
        {
            PartitionKey = regiao;
            RowKey = mac;
        }

        public IPEntity() { }

        public string IP_Adress { get; set; }
    }
}
