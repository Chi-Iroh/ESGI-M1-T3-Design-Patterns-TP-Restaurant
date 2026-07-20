namespace RestaurantApi
{
    class PaidState : IOrderState
    {
        public OrderStatus Status()
        {
            return OrderStatus.Paid;
        }

        public IOrderState? Next()
        {
            return null;
        }

        public bool Finished()
        {
            return true;
        }
    }
}