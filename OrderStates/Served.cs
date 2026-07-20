namespace RestaurantApi
{
    class ServedState : IOrderState
    {
        public OrderStatus Status()
        {
            return OrderStatus.Served;
        }

        public IOrderState? Next()
        {
            return new PaidState();
        }

        public bool Finished()
        {
            return false;
        }
    }
}