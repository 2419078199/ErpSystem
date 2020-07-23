namespace Model.Entitys
{
    public partial class SysConfigItem
    {
        public int Id { get; set; }
        public string Keyword { get; set; }
        public string TableName { get; set; }
        public string FieldName { get; set; }
        public int? OptionValue { get; set; }
        public string OptionText { get; set; }
        public int? Sorting { get; set; }
        public int? Status { get; set; }
    }
}