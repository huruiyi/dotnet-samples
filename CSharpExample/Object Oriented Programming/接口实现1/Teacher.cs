namespace 接口实现1
{
    public class Teacher : Introduceable
    {
        public string Name { get; set; }
        public string Course { get; set; }

        public Teacher(string name, string course)
        {
            Name = name;
            Course = course;
        }

        public string detail()
        {
            return string.Format("本人是{0}教员,教授课程为{1}", Name, Course);
        }
    }
}