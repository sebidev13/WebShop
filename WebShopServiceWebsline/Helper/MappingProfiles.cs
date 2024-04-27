using AutoMapper;
using WebShopServiceWebsline.DTO;
using WebShopServiceWebsline.Models;

namespace WebShopServiceWebsline.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<DiscountCode, DiscountCodeDTO>();
            CreateMap<DiscountCodeDTO, DiscountCode>();
            
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();

            CreateMap<ProductGroup, ProductGroupDTO>();
            CreateMap<ProductGroupDTO, ProductGroup>();
            
            CreateMap<ShoppingCart, ShoppingCardDTO>();
            CreateMap<ShoppingCardDTO, ShoppingCart>();
            
            CreateMap<Transaction, TransactionDTO>();
            CreateMap<TransactionDTO, Transaction>();

            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
        }
    }
}