namespace WebShopServiceWebsline.DTO;

public class DiscountCodeDTO
{
    public int DiscountCodeId { get; set; } // (PK)
    public string Code { get; set; }
    public decimal Discount { get; set; }
    public bool IsUsed { get; set; }
}