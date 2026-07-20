using RestaurantApi.Models;

namespace RestaurantApi
{
    public interface IListener
    {
        public void Update(Order order);
    }
}