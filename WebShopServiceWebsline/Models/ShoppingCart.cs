namespace WebShopServiceWebsline.Models;


public class ShoppingCart
{
    public int ShoppingCartId { get; set; } // (PK)
    public int UserId { get; set; } // (FK)
    
    // Navigation Property
    public User User { get; set; }
    public ICollection<ShoppingCartProduct> ShoppingCartProducts { get; set; }
}