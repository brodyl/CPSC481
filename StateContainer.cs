public class StateContainer
{   
    private static Ingredient lettuce = new Ingredient { Name = "Lettuce", Quantity = "Regular" };
    private static Ingredient tomato = new Ingredient { Name = "Tomato", Quantity = "Regular" };
    private static Ingredient pickles = new Ingredient { Name = "Pickles", Quantity = "Regular" };
    private static Ingredient onion = new Ingredient { Name = "Onion", Quantity = "Regular" };
    private static Ingredient houseSauce = new Ingredient { Name = "House Sauce", Quantity = "Regular" };
    private static Ingredient mayo = new Ingredient { Name = "Mayonnaise", Quantity = "Regular" };
    private static Ingredient ketchup = new Ingredient { Name = "Ketchup", Quantity = "Regular" };
    private static Ingredient jalapenos = new Ingredient { Name = "Jalapenos", Quantity = "Regular" };
    private static Ingredient pepperJackCheese = new Ingredient { Name = "Pepper Jack Cheese", Quantity = "Regular" };
    private static Ingredient spicyMayo = new Ingredient { Name = "Spicy Mayo", Quantity = "Regular" };
    private static Ingredient swissCheese = new  Ingredient { Name = "Swiss Cheese", Quantity = "Regular" };
    private static Ingredient mushrooms = new Ingredient { Name = "Mushrooms", Quantity = "Regular" };
    private static Ingredient garlicAioli = new Ingredient { Name = "Garlic Aioli", Quantity = "Regular" };
    private static Ingredient bacon = new Ingredient { Name = "Bacon", Quantity = "Regular" };
    private static Ingredient cheddarCheese = new Ingredient { Name = "Cheddar Cheese", Quantity = "Regular" };
    private static Ingredient bbqSauce = new Ingredient { Name = "BBQ Sauce", Quantity = "Regular" };
    private static Ingredient chiliSauce = new Ingredient { Name = "Chili Sauce", Quantity = "Regular" };
    private static Ingredient redOnion = new Ingredient { Name = "Red Onion", Quantity = "Regular" };
    private static Ingredient ranchSauce = new Ingredient { Name = "Ranch Sauce", Quantity = "Regular" };
    private static Ingredient pickle = new Ingredient { Name = "Pickle", Quantity = "Regular" };
    private static Ingredient veganMayo = new Ingredient { Name = "Vegan Mayo", Quantity = "Regular" };
    private static Ingredient avocado = new Ingredient { Name = "Avocado", Quantity = "Regular" };
    private static Ingredient veganChipotleMayo = new Ingredient { Name = "Vegan Chipotle Mayo", Quantity = "Regular" };


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
        _customers.Clear();
        _customers = new()
            {
                new Customer { Name = "Patron 1", InitiallyExpanded = true },
            };
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
                category = "burgers", 
                name = "Schooper Burger", 
                price = 10.00m, 
                size = null, 
                image = "/resources/whopper.png", 
                imageSm = "/resources/whopper3.png", 
                imageLg = "/resources/whopper3.png", 
                tags = "popular",
                Ingredients = new List<Ingredient> {lettuce,tomato,pickles,onion,houseSauce},
                description = "Our signature Schooper Burger is a mouthwatering treat loaded with fresh lettuce, juicy tomatoes, crunchy pickles, flavorful onions, and our secret house sauce. This classic burger is sure to satisfy your cravings and keep you coming back for more.",
                Calories = 550
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
                imageSm = "/resources/poutineLg.png", 
                imageLg = "/resources/poutineLg.png", 
                tags = "popular",
                Ingredients = new List<Ingredient> {},
                description = "Our world famous contains cheese curds imported directly from Quebec, hand churned to perfections. The gravy is an in house blend, with a secret recipe to wake up your taste buds",
                Calories = 450
            }
        },

        new DropItem(){ 
            Quantity = 2, 
            Customer = "Patron 1", 
            menuItem = new MenuItem() {  
                ID = 3, 
                category = "combo", 
                name = "Schooper Burger",
                side = new MenuItem() { 
                    ID = 3, 
                    category = "sides", 
                    name = "Poutine", 
                    price = 5.99m, 
                    image = "/resources/frenchfries.png", 
                    imageSm = "/resources/frenchfries.png", 
                    imageLg = "/resources/frenchfries.png", 
                }, 
                drink = new MenuItem() { 
                    ID = 3, 
                    category = "drinks",
                    name = "Coke", 
                    price = 5.99m,   
                    image = "/resources/Coke.png", 
                    imageSm = "/resources/Coke.png", 
                    imageLg = "/resources/Coke.png", 
                },
                price = 12.49m, 
                image = "/resources/combo.png",  
                imageSm = "/resources/combo.png", 
                imageLg = "/resources/combo.png", 
                Ingredients = new List<Ingredient> {},
                description = "Our world famous contains cheese curds imported directly from Quebec, hand churned to perfections. The gravy is an in house blend, with a secret recipe to wake up your taste buds",
                Calories = 450
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

