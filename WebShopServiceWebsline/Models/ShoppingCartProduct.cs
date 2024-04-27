namespace WebShopServiceWebsline.Models;

public class ShoppingCartProduct
{
    public int ShoppingCartId { get; set; } // (FK)
    public int ProductId { get; set; } // (FK)
    public int Quantity { get; set; }
    
    // Navigation Properties
    public ShoppingCart ShoppingCart { get; set; }
    public Product Product { get; set; }
}