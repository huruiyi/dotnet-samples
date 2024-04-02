using ReflectionDemo.Attr;

namespace ReflectionDemo.Model
{
    public class Teacher
    {
        [Required("教师姓名不能为空")]
        public string TeacherName { get; set; }

        public string Post { get; set; }
    }
}