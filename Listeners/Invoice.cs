using RestaurantApi.Models;

namespace RestaurantApi
{
    class InvoiceListener : IListener
    {
        public void Update(Order order)
        {
            if (order.status == OrderStatus.Created)
            {
                Console.WriteLine($"[INVOICE] Created order {order.Id}: {order.TotalPrice}€ !");
            } else if (order.status == OrderStatus.Paid)
            {
                Console.WriteLine($"[INVOICE] Paying order {order.Id} !");
            }
        }
    }
}
