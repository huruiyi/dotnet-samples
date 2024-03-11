namespace HuUtils.Model
{
    public class Department
    {
        public int Id { get; set; }

        public int ParentId { get; set; }

        public string Name { get; set; }

        public bool IfDel { get; set; }

        public Department(int id, int parentId, string name, bool ifDel)
        {
            this.Id = id;
            this.Name = name;
            this.ParentId = parentId;
            this.IfDel = ifDel;
        }

        public override string ToString()
        {
            return string.Format("Id :{0} , ParentId : {1} , Name :{2} , IfDel :{3}" , this.Id, this.ParentId, this.Name, this.IfDel);
        }
    }
}