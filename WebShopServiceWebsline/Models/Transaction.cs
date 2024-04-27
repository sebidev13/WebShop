namespace WebShopServiceWebsline.Models;

public class Transaction
{
    public int TransactionId { get; set; } // (PK)
    public int UserId { get; set; } // (FK)
    public int? DiscountCodeId { get; set; } // (FK)
    public DateTime Date { get; set; }
    
    // Navigation Properties
    public User User { get; set; }
    public DiscountCode DiscountCode { get; set; }
}