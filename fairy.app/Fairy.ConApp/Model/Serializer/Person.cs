using System.Runtime.Serialization;

namespace Fairy.ConApp.Model.Serializer
{
    [DataContract]
    public class Person
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [IgnoreDataMember]
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{this.Id} {this.Name}";
        }
    }
}