using RestaurantApi.Models;

namespace RestaurantApi
{
    public class StandardPrice : IPricingMethod
    {
        public decimal? Price(Order order)
        {
            decimal price = 0;
            foreach (MenuItem item in order.Items)
            {
                price += item.Price;
            }
            return price;
        }
    }
}