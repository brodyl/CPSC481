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
    
    public void restartOrder() {
        _items.Clear();
    }

    public void AddMenuItemToOrder() {
        _items.Add(new DropItem() {Quantity = 1, Customer = "Patron 1", menuItem = itemToCustomize});
    }    
    
    public void RemoveOrderItemByID()
    {
        _items.RemoveAll(item => item.menuItem.ID == 100);
    }


    public List<DropItem> _items = new()
    {
        new DropItem(){ 
            Quantity = 2, 
            Customer = "Patron 1", 
            menuItem = new MenuItem() {  
                ID = 100, 
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
                category = "combo", 
                side = new MenuItem() { 
                    ID = 3, 
                    category = "sides", 
                    name = "Poutine", 
                    price = 5.99m, 
                }, 
                drink = new MenuItem() { 
                    ID = 3, 
                    category = "drinks",
                    name = "Coke", 
                    price = 5.99m,   
                },
                price = 5.99m, 
            }
        },
    };





    public MenuItem itemToCustomize;
    public DropItem comboItemToCustomize = new DropItem();
    
    public void MakeItemIntoCombo() {
        itemToCustomize.side = new MenuItem();
        itemToCustomize.drink = new MenuItem();
        itemToCustomize.sauces = null;

        comboItemToCustomize = new DropItem() {Quantity = 1, Customer = "Patron 1", menuItem = itemToCustomize};
    }
    
    public bool DoesComboHaveSide()
    {
        return true;
    }
    public bool DoesComboHaveSauces()
    {
        return comboItemToCustomize.menuItem.sauces != null;
    }
    public bool DoesComboHaveDrink()
    {
        return comboItemToCustomize.menuItem.drink != null;
    }




    public event Action? OnChange;

    private void NotifyStateChanged() => OnChange?.Invoke();
}

