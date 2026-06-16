using csharp.Challenges._05_cart_stock_validation.Models;

namespace csharp.Challenges._05_cart_stock_validation.Application.Interfaces;

public interface IOrderService
{
    CustomerCartStatus AddToCart(int productId, int quantity);
    double GetCartTotal();
}