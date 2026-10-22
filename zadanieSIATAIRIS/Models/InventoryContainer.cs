namespace InventoryGame.Models;

/// <summary>Контейнер: сумка, сундук. Содержит предметы и другие контейнеры.</summary>
public sealed class InventoryContainer : IInventoryItem
{
    private readonly List<IInventoryItem> _children = new();

    public string Name { get; }

    public InventoryContainer(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("У контейнера должно быть имя", nameof(name));
        Name = name;
    }

    public IReadOnlyList<IInventoryItem> Children => _children;

    // Composite: вес и цена — рекурсивная сумма детей.
    public decimal Weight => _children.Sum(c => c.Weight);
    public decimal Price => _children.Sum(c => c.Price);

    public void Add(IInventoryItem item)
    {
        ArgumentNullException.ThrowIfNull(item);
        _children.Add(item);
    }

    public void Remove(IInventoryItem item) => _children.Remove(item);

    public void Display(int indent = 0)
    {
        Console.WriteLine($"{new string(' ', indent)}+ {Name} [вес {Weight} кг, цена {Price:C}]");
        foreach (var child in _children)
            child.Display(indent + 2);
    }

    /// <summary>Prototype: глубокий клон — дети тоже копируются.</summary>
    public IInventoryItem Clone()
    {
        var copy = new InventoryContainer(Name);
        foreach (var child in _children)
            copy.Add(child.Clone());
        return copy;
    }
}