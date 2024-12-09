
using consoletest;
using System.Collections;

public class Item : IEnumerable
{
    private static int NEXT_ID = 0;
    public int Id { get; }
    public string Name { get; }
    public decimal Price { get; }
    public string Description { get; }

    public delegate void ShowItemHandler(ItemEventArgs e);
    public event ShowItemHandler DisplayItem;
    public Item()
    {
    }
    public Item(string name, decimal price, string description)
    {
        this.Id = ++NEXT_ID;
        this.Name = name;
        this.Price = price;
        this.Description = description;
    }
    List<Item> Items { get; set; } = new List<Item>();

    public void Add(Item item)
    {
        Items.Add(item);

        DisplayItem?.Invoke(new ItemEventArgs(item, $"\nПоступил товар с параметрами: " +
            $"\nИД: {item.Id} " +
            $"\nНаименование: {item.Name}" +
            $"\nЦена:{item.Price}" +
            $"\nОписание: {item.Description}"));
    }
    public void Remove(int id)
    {
        var RemovingItem = Items.FirstOrDefault(x => x.Id == id);

        if (RemovingItem == null)
        {
            Console.WriteLine($"Item with ID {id} not found.");
            return;
        }
        Items.Remove(RemovingItem);
        DisplayItem?.Invoke(new ItemEventArgs(RemovingItem, $"\nУдален товар с параметрами: " +
            $"\nИД: {RemovingItem.Id}" +
            $"\nНаименование: {RemovingItem.Name}" +
            $"\nЦена: {RemovingItem.Price}" +
            $"\nОписание: {RemovingItem.Description}"));
    }
    public void Edit(int editedItemId, Item newitem)
    {
        var SelectedItem = Items.FirstOrDefault(x => x.Id == editedItemId);

        if (SelectedItem == null)
        {
            Console.WriteLine($"Item with ID {editedItemId} not found.");
            return;
        }

        DisplayItem?.Invoke(new ItemEventArgs(SelectedItem, $"\nИзменен товар с параметрами: " +
            $"\nИД: {SelectedItem.Id}" +
            $"\nНаименование: {SelectedItem.Name}" +
            $"\nЦена: {SelectedItem.Price}" +
            $"\nОписание: {SelectedItem.Description}" +
            $"\n\nНа товар с параметрами: " +
            $"\nИД: {newitem.Id}" +
            $"\nНаименование: {newitem.Name}" +
            $"\nЦена:{newitem.Price}" +
            $"\nОписание: {newitem.Description}"));
        SelectedItem = newitem;
    }

    public IEnumerator<Item> GetEnumerator() => Items.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
