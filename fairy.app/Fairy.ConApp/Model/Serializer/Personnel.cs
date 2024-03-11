using System.Web.Script.Serialization;

namespace Fairy.ConApp.Model.Serializer
{
    public class Personnel
    {
        public int Id { get; set; }


        [ScriptIgnore]
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{this.Id} {this.Name}";
        }
    }
}
