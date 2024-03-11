namespace ConApp.Model
{
    /// <summary>
    /// 会员 ，实际的表名叫MemberInfo，并不是和实体名一致
    /// </summary>
    [EnitityMapping(TableName = "MemberInfo")]
    public class Member
    {
        [EnitityMapping(ColumnName = "关键字")]
        public int Id { get; set; }

        [EnitityMapping(ColumnName = "会员注册名")]
        public string UserName { get; set; }

        [EnitityMapping(ColumnName = "会员真实名")]
        public string RealName { get; set; }

        /// <summary>
        /// 是否活跃  没有附加自定义属性
        /// </summary>
        public bool IsActive { get; set; }
    }
}