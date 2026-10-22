using InventoryGame.Models;
using InventoryGame.Patterns;
using System.Text;
using System.ComponentModel;
using System.Globalization;

Console.OutputEncoding = System.Text.Encoding.UTF8;
CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("ru-RU");

// =============================================================
// ДЕМО 1. Composite — дерево предметов и контейнеров
// =============================================================
Console.WriteLine("=== Демо 1: Composite — дерево инвентаря ===");

var sword = new Item("Меч", 5.5m, 1500m);
var potion = new Item("Зелье лечения", 0.3m, 100m);
var ring = new Item("Кольцо силы", 0.1m, 2000m);
var bread = new Item("Хлеб", 0.2m, 5m);

var bag = new InventoryContainer("Сумка");
bag.Add(potion);
bag.Add(ring);

var chest = new InventoryContainer("Сундук");
chest.Add(sword);
chest.Add(bag);              // контейнер внутри контейнера

var inventory = new InventoryContainer("Инвентарь героя");
inventory.Add(chest);
inventory.Add(bread);

inventory.Display();
Console.WriteLine($"[итог] вес = {inventory.Weight} кг, стоимость = {inventory.Price:C}");

// =============================================================
// ДЕМО 2. Prototype — клонирование по образцу
// =============================================================
Console.WriteLine("\n=== Демо 2: Prototype — клонирование предметов ===");

var registry = new ItemRegistry();
registry.Register("меч", sword);
registry.Register("зелье", potion);
registry.Register("кольцо", ring);

var sword2 = registry.Create("меч");
var potion2 = registry.Create("зелье");

Console.WriteLine($"  оригинал меча:  {sword}");
Console.WriteLine($"  копия меча:     {sword2}");
Console.WriteLine($"  ReferenceEquals = {ReferenceEquals(sword, sword2)}");

Console.WriteLine($"  оригинал зелья: {potion}");
Console.WriteLine($"  копия зелья:    {potion2}");

// =============================================================
// ДЕМО 3. Prototype + Composite — глубокая копия инвентаря
// =============================================================
Console.WriteLine("\n=== Демо 3: глубокий клон инвентаря ===");

var inventoryCopy = (InventoryContainer)inventory.Clone();
inventoryCopy.Add(new Item("Факел", 0.5m, 10m));

Console.WriteLine("  Оригинал:");
inventory.Display();
Console.WriteLine("  Копия (добавлен факел):");
inventoryCopy.Display();
Console.WriteLine($"  [проверка] оригинал не изменился: {inventory.Price:C}, копия: {inventoryCopy.Price:C}");

Console.WriteLine("\nГотово. Нажмите Enter для выхода.");
Console.ReadLine();