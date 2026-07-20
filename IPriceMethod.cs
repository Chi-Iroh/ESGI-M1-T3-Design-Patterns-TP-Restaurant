using RestaurantApi.Models;

namespace RestaurantApi
{
    public interface IPricingMethod
    {
        public decimal? Price(Order order);
    }

    public interface IDiscountMethod
    {
        public decimal Discount(decimal price, Order order);
    }
}