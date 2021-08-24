using System;
using System.Collections.Generic;
using System.Linq;
using WiredBrainCoffee.StorageApp.Entities;
using static System.Console;

namespace WiredBrainCoffee.StorageApp.Repositories
{
    public class ListRepository<T> : IRepository<T> where T: IEntity
    {
        private readonly List<T> _items = new();
        public void Add(T items)
        {
            items.Id = _items.Any() ? _items.Max(item => item.Id) + 1 : 1;
            _items.Add(items);
        }

        public void Save()
        {
            foreach (var item in _items)
            {
                WriteLine(item);
            }
        }

        public void Remove(T item)
        {
            _items.Remove(item);
        }

        public T GetById(int id)
        {
            return _items.Single(item => item.Id == id);
        }
    }
}
