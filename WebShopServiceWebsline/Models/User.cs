namespace WebShopServiceWebsline.Models;

public class User
{
    public int UserId { get; set; } // (PK)
    public string Username { get; set; }
    public string Password { get; set; }
    
    // Navigation Property
    public ShoppingCart ShoppingCart { get; set; }
}