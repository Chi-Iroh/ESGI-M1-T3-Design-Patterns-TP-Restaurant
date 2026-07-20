namespace RestaurantApi
{
    class ReadyState : IOrderState
    {
        public OrderStatus Status()
        {
            return OrderStatus.Ready;
        }

        public IOrderState? Next()
        {
            return new ServedState();
        }

        public bool Finished()
        {
            return false;
        }
    }
}