using RestaurantApi.Models;

namespace RestaurantApi
{
    class KitchenListener : IListener
    {
        public void Update(Order order)
        {
            if (order.status == OrderStatus.Preparing)
            {
                Console.WriteLine($"[KITCHEN] Prepare order {order.Id} !");
            }
        }
    }
}
