namespace RestaurantApi
{
    class StateManager
    {
        private IOrderState state = new CreatedState();

        public void Next()
        {
            if (!this.state.Finished())
            {
                IOrderState? next = this.state.Next();
                if (next is not null)
                {
                    this.state = next!;
                }
            }
        }

        public bool Finished()
        {
            return this.state.Finished();
        }

        public OrderStatus CurrentState()
        {
            return this.state.Status();
        }
    }
}
