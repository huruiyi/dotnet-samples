namespace ConApp.ReflectionDemo.Model
{
    public class OrderRequest
    {
        /// <summary>
        /// 订单号
        /// </summary>
        [Validate(ValidateType.IsEmpty)]
        public string OrderNo { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        [Validate(ValidateType.IsEmpty | ValidateType.MaxLength, MaxLength = 50)]
        public string CommodityName { get; set; }

        /// <summary>
        /// 商品数量
        /// </summary>
        [Validate(ValidateType.IsEmpty | ValidateType.IsNumber)]
        public string CommodityAmount { get; set; }

        /// <summary>
        /// 商品重量
        /// </summary>
        [Validate(ValidateType.IsEmpty | ValidateType.IsDecimal)]
        public string CommodityWeight { get; set; }

        /// <summary>
        /// 商品价格
        /// </summary>
        [Validate(ValidateType.IsEmpty | ValidateType.IsDecimal)]
        public string CommodityValue { get; set; }

        /// <summary>
        /// 希望到货时间
        /// </summary>
        [Validate(ValidateType.IsEmpty | ValidateType.IsDateTime)]
        public string HopeArriveTime { get; set; }

        /// <summary>
        /// 结算方式
        /// </summary>
        [Validate(ValidateType.IsEmpty | ValidateType.IsInCustomArray, CustomArray = new[] { "现结", "到付", "月结" })]
        public string PayMent { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Validate(ValidateType.MaxLength, MaxLength = 256)]
        public string Remark { get; set; }
    }
}