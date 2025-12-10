using GamePrototype.Items.EconomicItems;

namespace GamePrototype.Units
{
    public sealed class Inventory
    {
        private readonly uint _capacity;
        private readonly List<Item> _items = new List<Item>();
        public IReadOnlyList<Item> Items => _items;

        public Inventory(uint capacity) => _capacity = capacity;

        public bool TryAdd(Item item)
        {
            if (_items.Count == _capacity)
            {
                return false;
            }

            _items.Add(item);
            return true;
        }

        public bool TryRemove(Item item)
        {
            if (_items.Count == 0 || !_items.Contains(item))
            {
                return false;
            }
            _items.Remove(item);
            return true;
        }



        public bool ReplaceItem(Item newItem)                                                          // Замена 
        {
            Console.WriteLine($"Инвентарь заполнен!");
            Console.WriteLine($"Ты нашел: {newItem.Name})");

            while (true)
            {
                Console.WriteLine("Выбери действие:");
                Console.WriteLine("1.Просмотреть инвентарь и заменить предмет");
                Console.WriteLine("2.Выбросить найденый предмет");
                Console.WriteLine("3.Отмена");

                Console.Write("Твой выбор: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        return ViewInventory(newItem);

                    case "2":
                        Console.WriteLine($"Ты выбросил {newItem.Name}");
                        return false;

                    case "3":
                        Console.WriteLine("Отмена");
                        return false;

                    default:
                        Console.WriteLine("Что-то пошло не ьак. Попробуйте снова.");
                        break;
                }
            }
        }
        private bool ViewInventory(Item newItem)                                                    // просмотр инвентаря
        {
            Console.WriteLine("Твой инвентарь:");
            for (int i = 0; i < _items.Count; i++)
            {
                var item = _items[i];
                Console.WriteLine($"{i + 1}. {item.Name}");
            }

            Console.WriteLine($"Какой предмет заменить на {newItem.Name}?");
            Console.Write("Введи номер предмета (0 для отмены): ");

            if (int.TryParse(Console.ReadLine(), out int select))
            {
                if (select == 0)
                {
                    Console.WriteLine("Отмена");
                    return false;
                }

                if (select >= 1 && select <= _items.Count)
                {
                    var oldItem = _items[select - 1];
                    _items[select - 1] = newItem;

                    Console.WriteLine($"{oldItem.Name} заменен на {newItem.Name}");
                    return true;
                }
            }

            Console.WriteLine("Неверный предмет");
            return false;
        }
                
    }
}

