namespace RestaurantApi
{
    public enum OrderStatus
    {
        Created,
        Preparing,
        Ready,
        Served,
        Paid
    };

    public interface IOrderState
    {
        public OrderStatus Status();

        public IOrderState? Next();

        public bool Finished();
    }
}
