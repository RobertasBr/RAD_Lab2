namespace RAD_Lab2
{
    public class Ad
    {
        public int Id { get; set; }
        public int SellerId { get; set; }
        public int CategoryId { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }

        public Ad(int id, int sellerId, int categoryId, string description, decimal price)
        {
            Id = id;
            SellerId = sellerId;
            CategoryId = categoryId;
            Description = description;
            Price = price;
        }

        public override string ToString()
        {
            return $"Ad ID: {Id}, Seller ID: {SellerId}, Category ID: {CategoryId}, Description: {Description}, Price: {Price:C}";
        }
    }
    public class Seller
    {
        public int Id { get; set; }
        public string SellerName { get; set; }

        public Seller(int id, string sellerName)
        {
            Id = id;
            SellerName = sellerName;
        }

        public override string ToString()
        {
            return $"Seller ID: {Id}, Name: {SellerName}";
        }
    }

    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public Category(int id, string categoryName)
        {
            Id = id;
            CategoryName = categoryName;
        }
        public override string ToString()
        {
            return $"Category ID: {Id}, Name: {CategoryName}";
        }
    }
}
