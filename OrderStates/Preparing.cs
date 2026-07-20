namespace RestaurantApi
{
    class PreparingState : IOrderState
    {
        public OrderStatus Status()
        {
            return OrderStatus.Preparing;
        }

        public IOrderState? Next()
        {
            return new ReadyState();
        }

        public bool Finished()
        {
            return false;
        }
    }
}