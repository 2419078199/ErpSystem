namespace Model.Params
{
    public class SlOrderParams : BaseParams
    {
        public string CustomerName { get; set; }
        public int Status { get; set; } = -1;
    }
}