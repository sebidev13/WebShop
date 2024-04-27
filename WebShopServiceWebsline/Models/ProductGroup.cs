namespace WebShopServiceWebsline.Models;

public class ProductGroup
{
    public int ProductGroupId { get; set; } // (PK)
    public string Name { get; set; }
    
    // Navigation Property
    public ICollection<Product> Products { get; set; }
}