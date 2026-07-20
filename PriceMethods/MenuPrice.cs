using RestaurantApi.Models;

namespace RestaurantApi
{
    public class MenuPrice : IPricingMethod
    {
        public decimal? Price(Order order)
        {
            if (order.Items.Count != 3)
            {
                return null;
            }
            foreach (string category in new List<string>(["entrée", "plat", "dessert"]))
            {
                if (order.Items.Find(item => item.Category == category) is null)
                {
                    return null;
                }
            }
            return 25;
        }
    }
}