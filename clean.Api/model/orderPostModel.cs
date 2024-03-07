namespace clean.Api.model

{
    public class orderPostModel
    {
        public int orderNum { get; set; }
        public string Status { get; set; }
        public int orderSum { get; set; }
        public DateTime orderDate { get; set; }
        public int customerId { get; set; }
    }
}
