using RestaurantApi.Models;

namespace RestaurantApi
{
    public class GroupDiscount : IDiscountMethod
    {
        public decimal Discount(decimal price, Order order)
        {
            if (price > 50)
            {
                return price * 0.15m;
            }
            return 0;
        }
    }
}