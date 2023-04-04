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
        new DropItem(){ Name = "Schooper Combo",    Price = 12.99m, Quantity = 2, Customer = "Patron 1", ImgPath = "/resources/number1.png"},
        new DropItem(){ Name = "Large Poutine",     Price = 8.50m,  Quantity = 1, Customer = "Patron 1", ImgPath = "/resources/poutine.png"},
        new DropItem(){ Name = "Fries Sm",          Price = 3.99m,  Quantity = 4, Customer = "Patron 1", ImgPath = "/resources/fries.png"},
        new DropItem(){ Name = "Fries Lg",          Price = 15.99m, Quantity = 2, Customer = "Patron 1", ImgPath = "/resources/fries.png"},
        new DropItem(){ Name = "Coke Lg",           Price = 25.00m, Quantity = 1, Customer = "Patron 1", ImgPath = "/resources/Coke.png"},
        new DropItem(){ Name = "Coffee 2c1S",       Price = 5.99m,  Quantity = 3, Customer = "Patron 1", ImgPath = "/resources/coffee.png"},
    };




    public customizeItem





    public event Action? OnChange;

    private void NotifyStateChanged() => OnChange?.Invoke();
}