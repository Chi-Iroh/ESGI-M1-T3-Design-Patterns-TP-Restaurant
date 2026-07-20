using RestaurantApi.Models;

namespace RestaurantApi
{
    class RestaurantData
    {
        static private Menu makeMenu(string name, MenuItem[] menu)
        {
            Order order = new();
            order.Items = new List<MenuItem>(menu);
            return Menu.fromOrder(name, order);
        }

        public Menu[] Menus()
        {
            return [
                makeMenu("Menu découverte", [
                    new MenuItem("Salade César", 11),
                    new MenuItem("Gratin de ravioles à la truffe", 21),
                    new MenuItem("Coupe ardéchoise", 8)
                ]),
                makeMenu("Menu gourmand", [
                    new MenuItem("Pâté en croûte maison", 13),
                    new MenuItem("Suprême de volaille et gratin dauphinois", 25),
                    new MenuItem("Café gourmand", 10)
                ])
            ];
        }

        public Dictionary<string, string> WorkHours()
        {
            Dictionary<string, string> workHours = new();

            workHours.Add("Monday", "12PM - 7PM");
            workHours.Add("Tuesday", "12PM - 7PM");
            workHours.Add("Wednesday", "12PM - 7PM");
            workHours.Add("Thursday", "12PM - 7PM");
            workHours.Add("Friday", "12PM - 7PM");
            workHours.Add("Saturday", "12PM - 2PM");
            workHours.Add("Sunday", "Closed");

            return workHours;
        }
    }
}