using WebShopServiceWebsline.Models;

namespace WebShopServiceWebsline.Interfaces;

public interface IDiscountCodeRepository
{
    ICollection<DiscountCode> GetDiscountCodes(); 
    DiscountCode GetDiscountCodeById(int discountCodeId);
    DiscountCode GetDiscountCodeByName(string discountCodeName);
    bool DiscountCodeExists(int discountCodeId);
    bool CreateDiscountCode(DiscountCode discountCode);
    bool UpdateDiscountCode(DiscountCode discountCode);
    bool DeleteDiscountCode(DiscountCode discountCode);
}