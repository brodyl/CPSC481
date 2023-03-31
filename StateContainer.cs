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
        new DropItem(){ Name = "Item 1", Price = 12.99m, Quantity = 2, Customer = "Patron 1" },
        new DropItem(){ Name = "Item 2", Price = 8.50m, Quantity = 1, Customer = "Patron 1" },
        new DropItem(){ Name = "Item 3", Price = 3.99m, Quantity = 4, Customer = "Patron 1" },
        new DropItem(){ Name = "Item 4", Price = 15.99m, Quantity = 2, Customer = "Patron 1" },
        new DropItem(){ Name = "Item 5", Price = 25.00m, Quantity = 1, Customer = "Patron 1" },
        new DropItem(){ Name = "Item 6", Price = 5.99m, Quantity = 3, Customer = "Patron 1" },
    };







    public event Action? OnChange;

    private void NotifyStateChanged() => OnChange?.Invoke();
}