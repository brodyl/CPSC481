public class StateContainer
{   
    public List<Customer> _customers = new()
    {
        new Customer { Name = "Patron 1", InitiallyExpanded = true },
    };

    public IReadOnlyList<Customer> Customers => _customers.AsReadOnly();

    public void AddCustomer(Customer customer)
    {
        _customers.Add(customer);
        NotifyStateChanged();
    }

    public void UpdateCustomer(int index, Customer updatedCustomer)
    {
        if (index >= 0 && index < _customers.Count)
        {
            _customers[index] = updatedCustomer;
            NotifyStateChanged();
        }
    }

    public void RemoveCustomer(int index)
    {
        if (index >= 0 && index < _customers.Count)
        {
            _customers.RemoveAt(index);
            NotifyStateChanged();
        }
    }
    
    public List<DropItem> _items = new()
    {
        new DropItem(){ 
            Quantity = 2, 
            Customer = "Patron 1", 
            menuItem = new MenuItem() {  
                ID = 1, 
                category = "burger", 
                name = "Schooper Burger", 
                price = 10.00m, 
                size = null, 
                image = "/resources/whopper.png", 
                imageSm = "/resources/whopper.png", 
                imageLg = "/resources/whopper.png", 
                tags = "popular",
                Ingredients = new List<Ingredient>
                {
                    new Ingredient { Name = "Lettuce", Quantity = "Regular" },
                    new Ingredient { Name = "Bacon", Quantity = "Regular" },
                    new Ingredient { Name = "Cheese", Quantity = "Regular" },
                    new Ingredient { Name = "Ketchup", Quantity = "Regular" },
                    new Ingredient { Name = "Onion", Quantity = "Regular" },
                }
            }
        },

        new DropItem(){ 
            Quantity = 2, 
            Customer = "Patron 1", 
            menuItem = new MenuItem() {  
                ID = 2, 
                category = "sides", 
                name = "Poutine", 
                price = 5.99m, 
                size = "Medium", 
                image = "/resources/poutine.png", 
                imageSm = "/resources/poutine.png", 
                imageLg = "/resources/poutine.png", 
                tags = "popular",
                Ingredients = new List<Ingredient> {}
            }
        },

        new DropItem(){ 
            Quantity = 2, 
            Customer = "Patron 1", 
            menuItem = new MenuItem() {  
                ID = 3, 
                category = "sides", 
                name = "Coke", 
                price = 2.99m, 
                size = "Medium", 
                image = "/resources/Coke.png", 
                imageSm = "/resources/Coke.png", 
                imageLg = "/resources/Coke.png", 
                tags = "popular",
                Ingredients = new List<Ingredient> {}
            }
        },
    };





    public MenuItem itemToCustomize;




    public event Action? OnChange;

    private void NotifyStateChanged() => OnChange?.Invoke();
}

