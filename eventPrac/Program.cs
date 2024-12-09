using consoletest;

Item item = new Item();

item.DisplayItem += DisplayMessage;


item.Add(new Item("Item 1", 23.1m, "Desc 1"));

item.Remove(1);

item.Add(new Item("Item 1", 23.1m, "Desc 1"));

item.Edit(2, new Item("Edited Item", 24.1m, "Desc for edited"));

void DisplayMessage(ItemEventArgs e)
{
    Console.WriteLine(e.Message);
    Console.ForegroundColor = ConsoleColor.Yellow;

    bool ItemFound = false;
    bool OperationDone = false;

    foreach (var i in item)
    {
        ItemFound = true;
        if (ItemFound == true && OperationDone == false)
        {
            Console.WriteLine("\nТекущий товар:");
            OperationDone = true;
        }
        Console.WriteLine($"Ид_товара: {i.Id} " +
                          $"\nНаименование товара: {i.Name} " +
                          $"\nЦена товара: {i.Price} " +
                          $"\nОписание товара: {i.Description}" +
                          $"\n");
    }

    Console.ForegroundColor = ConsoleColor.Gray;
}


