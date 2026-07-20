using System.Text.Json.Serialization;

namespace RestaurantApi.Models
{
    public class Order
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int TableNumber { get; set; }
        public List<MenuItem> Items { get; set; } = new();
        public decimal TotalPrice => computePrice();
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [JsonIgnore]
        private StateManager stateManager = new();

        [JsonIgnore]
        private IPricingMethod[] pricingMethods = [
            new StandardPrice(),
            new MenuPrice()
        ];

        [JsonIgnore]
        private IDiscountMethod[] discountMethods = [
            new HappyHourDiscount(),
            new GroupDiscount()
        ];

        public void AddItem(MenuItem item)
        {
            Items.Add(item);
        }

        private decimal computePrice()
        {
            decimal price = 1e9m;

            foreach (IPricingMethod pricingMethod in this.pricingMethods)
            {
                decimal? basePrice_ = pricingMethod.Price(this);
                if (basePrice_ is not null)
                {
                    price = Math.Min(price, basePrice_.Value);
                }
            }

            decimal basePrice = price;

            foreach (IDiscountMethod discountMethod in this.discountMethods)
            {
                price -= discountMethod.Discount(basePrice, this);
            }
            return price;
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
