namespace InventoryGame.Models;

/// <summary>
/// Общий компонент дерева инвентаря: одиночный предмет и контейнер
/// обрабатываются одинаково (Composite). Clone() объявлен здесь, а не
/// через ICloneable, чтобы вернуть конкретный тип (Prototype).
/// </summary>
public interface IInventoryItem
{
    string Name { get; }
    decimal Weight { get; }
    decimal Price { get; }

    void Display(int indent = 0);

    /// <summary>Копия элемента (Prototype).</summary>
    IInventoryItem Clone();
}