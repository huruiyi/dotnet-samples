using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using System;
using System.Threading.Tasks;

namespace ConApp.Samples.NoSql
{
    public class CosmosDb
    {
        private class Person
        {
            public String Uuid { get; set; }
            public String Name { get; set; }
            public String Hobby { get; set; }
            public short Age { get; set; }
        }

        public static void Demo1()
        {
            DocumentClient client = new DocumentClient(
                new Uri("https://localhost:8081"), "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==");
            Person person = new Person
            {
                Uuid = Guid.NewGuid().ToString(),

                Hobby = "Hobby",
                Age = 10
            };

            //var resourceResponse = client.CreateDatabaseAsync(new Database {Id = "MyList"}).Result;

            client.CreateDocumentCollectionAsync(UriFactory.CreateDatabaseUri("MyList"), new DocumentCollection { Id = "Person" }, new RequestOptions { OfferThroughput = 1000 });

            Task<ResourceResponse<Document>> task = client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri("MyList", "Person"), person);
            var resultActivityId = task.Result.ActivityId;
            Console.WriteLine(resultActivityId);
        }
    }
}