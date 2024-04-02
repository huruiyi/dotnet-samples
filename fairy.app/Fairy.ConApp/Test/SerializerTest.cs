using Fairy.ConApp.Model;
using System;
using System.IO;
using System.Text;
using System.Web.Script.Serialization;
using Fairy.ConApp.Model.Serializer;
using System.Runtime.Serialization.Json;

namespace Fairy.ConApp.Test
{
    public class SerializerTest
    {

        public static void Test1()
        {
            Personnel personnel = new Personnel
            {
                Id = 1,
                Name = "小白"
            };
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            string personnelStr = jsonSerializer.Serialize(personnel);
            Console.WriteLine(personnelStr);

            Personnel personnel2 = jsonSerializer.Deserialize<Personnel>(personnelStr);
            Console.WriteLine(personnel2.ToString());
        }

        public static void Test2()
        {
            Person people = new Person
            {
                Id = 1,
                Name = "小白"
            };
            var json = new DataContractJsonSerializer(people.GetType());

            string personJsonStr = "";
            using (MemoryStream stream = new MemoryStream())
            {
                json.WriteObject(stream, people);
                personJsonStr = Encoding.UTF8.GetString(stream.ToArray());
                Console.WriteLine(personJsonStr);
            }
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(personJsonStr)))
            {
                var serializer = new DataContractJsonSerializer(typeof(Person));
                Person person = (Person)serializer.ReadObject(ms);
                Console.WriteLine(person);
            }
        }
    }
}
