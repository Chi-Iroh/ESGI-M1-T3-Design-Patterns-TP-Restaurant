using System.Text.Json.Serialization;

namespace RestaurantApi.Models
{
    public class Order
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int TableNumber { get; set; }
        public List<MenuItem> Items { get; set; } = new();
        public decimal TotalPrice { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [JsonIgnore]
        private StateManager stateManager = new();

        public void AddItem(MenuItem item)
        {
            Items.Add(item);
        }

        public string? NextState()
        {
            if (this.stateManager.Finished())
            {
                return null;
            }
            this.stateManager.Next();
            return this.stateManager.CurrentState();
        }
    }
}
