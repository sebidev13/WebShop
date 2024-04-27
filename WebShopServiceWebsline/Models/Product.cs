namespace WebShopServiceWebsline.Models;

public class Product
{
    public int ProductId { get; set; } // (PK)
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int ProductGroupId { get; set; } // (FK)
    
    // Navigation Property
    public ProductGroup ProductGroup { get; set; }
}












