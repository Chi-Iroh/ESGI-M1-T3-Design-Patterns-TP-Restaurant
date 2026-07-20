using RestaurantApi.Models;

namespace RestaurantApi
{
    class RoomListener : IListener
    {
        public void Update(Order order)
        {
            if (order.status == OrderStatus.Served)
            {
                Console.WriteLine($"[ROOM] Serving order {order.Id} !");
            }
        }
    }
}
