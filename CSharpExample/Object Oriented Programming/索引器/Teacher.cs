namespace 索引器
{
    internal class Teacher
    {
        private Student[] students = new Student[3];

        public Student this[int index]
        {
            get { return students[index]; }
            set { students[index] = value; }
        }

        public void Show()
        {
            foreach (Student student in students)
            {
                student.Say();
            }
        }
    }
}