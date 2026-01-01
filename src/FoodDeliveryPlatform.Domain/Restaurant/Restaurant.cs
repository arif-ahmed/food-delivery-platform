using FoodDeliveryPlatform.SharedKernel;
using FoodDeliveryPlatform.SharedKernel.Abstractions;


namespace FoodDeliveryPlatform.Domain.Restaurant
{
    public class Restaurant : Entity<Guid>, IAggregateRoot
    {
        private readonly List<Menu> _menus = new();

        public string Name { get; set; }

        public IReadOnlyCollection<Menu> Menus => _menus.AsReadOnly();

        public Restaurant(Guid id, string name) : base(id)
        {
            Name = name;
        }

        public static Restaurant Create(string name)
        {
            return new Restaurant(Guid.NewGuid(), name);
        }

        public void AddMenu(Menu menu)
        {
            _menus.Add(menu);
        }

        public Menu? GetMenuById(Guid menuId)
        {
            return _menus.FirstOrDefault(m => m.Id == menuId);
        }

        public void RemoveMenu(Menu menu)
        {
            _menus.Remove(menu);
        }

        public void Rename(string newName)
        {
            // Implementation for renaming the restaurant
            Name = newName;
        }

        public void AddMenuItemToMenu(Menu menu, MenuItem menuItem)
        {
            // Implementation for adding a menu item to a specific menu
            // This is a placeholder; actual implementation would depend on Menu class details
        }
    }
}
