using RestaurantApi.Models;

namespace RestaurantApi
{
    public class HappyHourDiscount : IDiscountMethod
    {
        public decimal Discount(decimal price, Order order)
        {
            if (14 <= order.CreatedAt.Hour && order.CreatedAt.Hour < 18)
            {
                return 0.2m * price;
            }
            return 0;
        }
    }
}