namespace WebShopServiceWebsline.DTO;

public class TransactionDTO
{
    public int TransactionId { get; set; } 
    public int UserId { get; set; } 
    public int? DiscountCodeId { get; set; } 
    public DateTime Date { get; set; }
}