using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;
using Microsoft.ServiceFabric.Actors.Runtime;
using Actor1.Interfaces;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Measurements;

namespace Actor1
{
    public class Met : Actor, IMet
    {

        private readonly string storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=testefred;AccountKey=DC9kaiIvwmn+TNjj439cplWiOTidai/uFTV1fPT3gD2HEw08dGD/kkUxJ4XXVC8HdJ4vyDP6I3zGFt+fkWPp+g==;EndpointSuffix=core.windows.net";

        public Met(ActorService actorService, ActorId actorId) : base(actorService, actorId)
        {
        }


        public Task EnviaMedicoes(Medicoes medicoes)
        {


            CloudTable medidasTable;
            CloudTable ipTable;
            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(storageConnectionString);
            var cloudTableClient = cloudStorageAccount.CreateCloudTableClient();
            medidasTable = cloudTableClient.GetTableReference("Medicoes");
            medidasTable.CreateIfNotExistsAsync();
            ipTable = cloudTableClient.GetTableReference("EnderecoIP");
            ipTable.CreateIfNotExistsAsync();

            var medidas = new MedEntity(medicoes.REGIAO)
            {
                MAC_Adress = medicoes.MAC,
                Temperatura = medicoes.TEMP,
                Umidade = medicoes.UMIDADE,
                Status_Chuva = medicoes.CHUVAS,
                Intensidade_Chuva = medicoes.CHUVAI,
            };

            TableOperation insertOperation = TableOperation.InsertOrReplace(medidas);
            medidasTable.ExecuteAsync(insertOperation);



            var ip = new IPEntity(medicoes.REGIAO, medicoes.MAC)
            {
                IP_Adress = medicoes.IP,
            };


            TableOperation insertOperation2 = TableOperation.InsertOrReplace(ip);
            ipTable.ExecuteAsync(insertOperation2);

            return Task.FromResult(true);
        }
    }
}
