using System.Diagnostics;
using System.Text;

namespace Net.Tools
{
    public enum SqlAuthor
    {
        用户1,
        用户2,
        用户3,
        用户4,
    }

    public class LogHelper
    {
        public const string ProjectName = "项目名称";

        /// <summary>
        /// 增加Sql注释(保存作者,方法明,文件路径,以及用途)
        /// </summary>
        /// <param name="author">作者，即开发人的姓名</param>
        /// <param name="desc">功能描述</param>
        /// <returns></returns>
        public static string AddNotes(SqlAuthor author, string desc)
        {
            try
            {
                StackFrame stackFrame = new StackTrace(true).GetFrame(1);
                StringBuilder commetBuilder = new StringBuilder();
                commetBuilder.AppendFormat("/*{0}/Author:{1}/For:{2}/File:///{3}/Fun:{4}*/", ProjectName, author, desc, stackFrame.GetFileName(), stackFrame.GetMethod().Name);
                return commetBuilder.ToString();
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}