using System;

namespace ConApp.Model
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class, Inherited = true)]
    public class EnitityMappingAttribute : Attribute
    {
        /// <summary>
        /// 实体实际对应的表名
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// 中文列名
        /// </summary>
        public string ColumnName { get; set; }
    }

}
