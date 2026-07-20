namespace RestaurantApi
{
    class CreatedState : IOrderState
    {
        public OrderStatus Status()
        {
            return OrderStatus.Created;
        }

        public IOrderState? Next()
        {
            return new PreparingState();
        }

        public bool Finished()
        {
            return false;
        }
    }
}