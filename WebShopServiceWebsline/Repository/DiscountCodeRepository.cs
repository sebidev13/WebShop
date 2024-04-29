using WebShopServiceWebsline.Helper;
using WebShopServiceWebsline.Interfaces;
using WebShopServiceWebsline.Models;

namespace WebShopServiceWebsline.Repository;

public class DiscountCodeRepository: IDiscountCodeRepository
{
    private readonly DummyData _context;
    
    public DiscountCodeRepository() 
    {
        _context = DummyData.Instance; 
    }
    
    public ICollection<DiscountCode> GetDiscountCodes()
    {
        return _context.DiscountCodes.ToList();
    }

    public DiscountCode GetDiscountCodeById(int discountCodeId)
    {
        return _context.DiscountCodes.FirstOrDefault(d => d.DiscountCodeId.Equals(discountCodeId));   
    }

    public DiscountCode GetDiscountCodeByName(string discountCode)
    {
        return _context.DiscountCodes.Where(c => c.Code.Equals(discountCode)).FirstOrDefault();
    }

    public bool DiscountCodeExists(int discountCodeId)
    {
        return _context.DiscountCodes.Any(d => d.DiscountCodeId.Equals(discountCodeId));
    }

    public bool CreateDiscountCode(DiscountCode discountCode)
    {
        discountCode.DiscountCodeId = _context.DiscountCodes.Count() + 1;
        _context.DiscountCodes.Add(discountCode);

        if (_context.DiscountCodes.Contains(discountCode))
            return true;

        return false;    
    }

    public bool UpdateDiscountCode(DiscountCode discountCode)
    {
        var item = _context.DiscountCodes.Find(c => c.DiscountCodeId.Equals(discountCode.DiscountCodeId));

        if(item != null)
        {
            item.Code = discountCode.Code;
            item.Discount = discountCode.Discount;
            item.IsUsed = discountCode.IsUsed;
                
            return true;    
        }
        return false;
    }

    public bool DeleteDiscountCode(DiscountCode discountCode)
    {
        var item = _context.DiscountCodes.Find(d => d.DiscountCodeId.Equals(discountCode.DiscountCodeId));

        if(item != null)
        {
            _context.DiscountCodes.Remove(item);
                
            if(_context.DiscountCodes.Contains(item))
                return false;

            return true;
        }
        return false;    
    }
}