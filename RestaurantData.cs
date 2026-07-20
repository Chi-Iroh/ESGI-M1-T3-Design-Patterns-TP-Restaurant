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
    }
}