namespace OnlineshopAPI.Controllers.entities
{
    public class product
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string imageURL { get; set; }
        public decimal price { get; set; }
        public int qty { get; set; }
        public int categoryID { get; set; }

    }
}
