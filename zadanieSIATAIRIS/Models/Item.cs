namespace InventoryGame.Models;

/// <summary>Одиночный предмет: меч, зелье, кольцо.</summary>
public sealed class Item : IInventoryItem
{
    public string Name { get; }
    public decimal Weight { get; }
    public decimal Price { get; }

    public Item(string name, decimal weight, decimal price)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("У предмета должно быть имя", nameof(name));
        if (weight < 0)
            throw new ArgumentOutOfRangeException(nameof(weight), "Вес не может быть отрицательным");
        if (price < 0)
            throw new ArgumentOutOfRangeException(nameof(price), "Цена не может быть отрицательной");

        Name = name;
        Weight = weight;
        Price = price;
    }

    public void Display(int indent = 0)
        => Console.WriteLine($"{new string(' ', indent)}- {Name} ({Weight} кг, {Price:C})");

    /// <summary>Prototype: копия без знания конкретных полей снаружи.</summary>
    public IInventoryItem Clone() => new Item(Name, Weight, Price);

    public override string ToString() => $"{Name} ({Weight} кг, {Price:C})";
}