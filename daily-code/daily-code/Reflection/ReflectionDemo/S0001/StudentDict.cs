using System.Collections.Generic;

namespace ReflectionDemo.S0001
{
    /// <summary>
    /// 学生小字典
    /// </summary>
    public class StudentDict
    {
        /// <summary>
        /// 教师名
        /// </summary>
        private string Teacher = "张老师";

        /// <summary>
        /// 类名称
        /// </summary>
        public string ClassName = "高三（1）班";

        /// <summary>
        /// 简单字典类型
        /// </summary>
        public Dictionary<string, string> AttributeDict = new Dictionary<string, string>();

        /// <summary>
        /// 教师名称
        /// </summary>
        public string TeacherName
        {
            get { return Teacher; }
            set { Teacher = value; }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public StudentDict()
        {
            AttributeDict.Add("01", "张三");
            AttributeDict.Add("02", "李四");
            AttributeDict.Add("03", "王五");
        }

        /// <summary>
        /// 根据序号查询姓名
        /// </summary>
        /// <param name="strCode"></param>
        /// <returns></returns>
        public string GetStuNameByCode(string strCode)
        {
            return AttributeDict[strCode];
        }
    }
}