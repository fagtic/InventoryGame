namespace InventoryGame.Patterns;

using InventoryGame.Models;

/// <summary>
/// Реестр предметов-образцов. Создаёт копию по ключу,
/// не зная конкретного класса предмета.
/// </summary>
public sealed class ItemRegistry
{
    private readonly Dictionary<string, IInventoryItem> _prototypes = new();

    public void Register(string key, IInventoryItem prototype)
    {
        ArgumentNullException.ThrowIfNull(prototype);
        if (string.IsNullOrWhiteSpace(key))
            throw new ArgumentException("Нужен ключ образца", nameof(key));
        _prototypes[key] = prototype;
    }

    public IInventoryItem Create(string key)
    {
        if (!_prototypes.TryGetValue(key, out var prototype))
            throw new KeyNotFoundException($"Образец «{key}» не зарегистрирован");

        var copy = prototype.Clone();
        Console.WriteLine($"  [реестр] создана копия образца «{key}» → {copy}");
        return copy;
    }
}