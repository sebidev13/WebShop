using WebShopServiceWebsline.DTO;
using WebShopServiceWebsline.Models;

namespace WebShopServiceWebsline.Helper;

public class DummyData
{
    private static DummyData _instance;

    public static DummyData Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new DummyData();
            }

            return _instance;
        }
    }
    
    public List<DiscountCode> DiscountCodes { get; set; }
    public List<Product> Products { get; set; }
    public List<ProductGroup> ProductGroups { get; set; }
    public List<ShoppingCart> ShoppingCarts { get; set; }
    public List<ShoppingCartProduct> ShoppingCartProducts { get; set; }
    public List<Transaction> Transactions { get; set; }
    public List<User> Users { get; set; }


    private DummyData()
    {
        DiscountCodes = new List<DiscountCode>();
        Products = new List<Product>();
        ProductGroups = new List<ProductGroup>();
        ShoppingCarts = new List<ShoppingCart>();
        ShoppingCartProducts = new List<ShoppingCartProduct>();
        Transactions = new List<Transaction>();
        Users = new List<User>();
        
        DiscountCodes.Add(new DiscountCode() {
            DiscountCodeId = 1,
            Code = "1234",
            Discount = 10,
            IsUsed = false,
        });
        DiscountCodes.Add(new DiscountCode() {
                DiscountCodeId = 2,
                Code = "4321",
                Discount = 20,
                IsUsed = false,
            });
        DiscountCodes.Add(new DiscountCode() {
            DiscountCodeId = 3,
            Code = "asdf",
            Discount = 30,
            IsUsed = true,
        });

        Products.Add(new Product() {
            ProductId = 1,
            Name = "Schreibtisch-Stuhl",
            Description = "Das ist ein Scheibtisch-Stuhl",
            Price = 25,
            ProductGroupId = 1,
            ProductGroup = ProductGroups.FirstOrDefault(p => p.ProductGroupId == 1)
        });
        Products.Add(new Product() {
            ProductId = 2,
            Name = "Liege-Stuhl",
            Description = "Das ist ein Liege-Stuhl",
            Price = 30,
            ProductGroupId = 1,
            ProductGroup = ProductGroups.FirstOrDefault(p => p.ProductGroupId == 1)
        });   
        Products.Add(new Product() {
            ProductId = 3,
            Name = "Wohnzimmer-Tisch",
            Description = "Das ist ein Wohnzimmer-Stuhl",
            Price = 100,
            ProductGroupId = 2,
            ProductGroup = ProductGroups.FirstOrDefault(p => p.ProductGroupId == 2)
        });    
        Products.Add(new Product() {
            ProductId = 3,
            Name = "Schreib-Tisch",
            Description = "Das ist ein Schreib-Stuhl",
            Price = 120,
            ProductGroupId = 2,
            ProductGroup = ProductGroups.FirstOrDefault(p => p.ProductGroupId == 2)
        });   
        
        ProductGroups.Add(new ProductGroup() {
                ProductGroupId = 1,
                Name = "Stühle",
                Products = Products.Where(p => p.ProductGroupId == 1).ToList()
            });
        ProductGroups.Add(new ProductGroup() {
            ProductGroupId = 2,
            Name = "Tische",
            Products = Products.Where(p => p.ProductGroupId == 2).ToList()
        });
        
        ShoppingCarts.Add(new ShoppingCart() {
                ShoppingCartId = 1,
                UserId = 1,
                User = Users.FirstOrDefault(u => u.UserId == 1),
                ShoppingCartProducts = ShoppingCartProducts.Where(scp => scp.ShoppingCartId == 1).ToList()
            });
        ShoppingCarts.Add(new ShoppingCart() {
            ShoppingCartId = 2,
            UserId = 2,
            User = Users.FirstOrDefault(u => u.UserId == 2),
            ShoppingCartProducts = ShoppingCartProducts.Where(scp => scp.ShoppingCartId == 2).ToList()
        });
        
        ShoppingCartProducts.Add(new ShoppingCartProduct() {
                ShoppingCartId = 1,
                ProductId = 1,
                Quantity = 1,
                ShoppingCart = ShoppingCarts.FirstOrDefault(s => s.ShoppingCartId == 1),
                Product = Products.FirstOrDefault(p => p.ProductId == 1)
            });
        ShoppingCartProducts.Add(new ShoppingCartProduct() {
            ShoppingCartId = 2,
            ProductId = 2,
            Quantity = 1,
            ShoppingCart = ShoppingCarts.FirstOrDefault(s => s.ShoppingCartId == 2),
            Product = Products.FirstOrDefault(p => p.ProductId == 2)
        });
        
        Transactions.Add(new Transaction() {
                TransactionId = 1,
                UserId = 1,
                DiscountCodeId = 1,
                Date = new DateTime(),
                User = Users.FirstOrDefault(u => u.UserId == 1),
                DiscountCode = DiscountCodes.FirstOrDefault(d => d.DiscountCodeId == 1)
            });
        Transactions.Add(new Transaction() {
            TransactionId = 2,
            UserId = 2,
            DiscountCodeId = 2,
            Date = new DateTime(),
            User = Users.FirstOrDefault(u => u.UserId == 2),
            DiscountCode = DiscountCodes.FirstOrDefault(d => d.DiscountCodeId == 2)
        });
        
        Users.Add( new User() {
                UserId = 1,
                Username = "Sebi",
                Password = "1234",
                ShoppingCart = ShoppingCarts.FirstOrDefault(s => s.UserId == 1)
            });
        Users.Add(new User() {
            UserId = 2,
            Username = "Fabi",
            Password = "4321",
            ShoppingCart = ShoppingCarts.FirstOrDefault(s => s.UserId == 2)
        });
    }
}