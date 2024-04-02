using System.Collections.Generic;

namespace ReflectionDemo.S0002
{
    /// <summary>
    /// 学生小字典
    /// </summary>
    public class StudentDict
    {
        /// <summary>
        /// 教师名
        /// </summary>
        private string Teacher = "曹老师";

        /// <summary>
        /// 类名称
        /// </summary>
        public string ClassName = "高三（2）班";

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

        public string OtherP1;
        public string OtherP2;
        public string OtherP3;

        /// <summary>
        /// 构造函数
        /// </summary>
        public StudentDict()
        {
            AttributeDict.Add("01", "赵六");
            AttributeDict.Add("02", "钱七");
            AttributeDict.Add("03", "周八");
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