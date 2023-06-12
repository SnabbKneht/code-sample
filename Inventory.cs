using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Events;

namespace InventorySystem
{
    public class Inventory : IEnumerable
    {
        private Dictionary<ItemsData.Id, ItemStack> items;

        public float Weight => items.Values.Sum(stack => stack.Weight);
        public int Size => items.Count;

        public Inventory()
        {
            items = new Dictionary<ItemsData.Id, ItemStack>();
        }
        
        public Inventory(IEnumerable<ItemStack> stacks)
        {
            items = new Dictionary<ItemsData.Id, ItemStack>();
            AddAll(stacks);
        }
        
        public Inventory GetByCategory(ItemsData.Category category)
        {
            return new Inventory( 
                items.Values.Where(stack => stack.Item.Category == category));
        }
        
        public Inventory SortBy(ItemsData.SortingCriterion criterion, bool ascending = true)
        {
            var sortedItems = items.Values.ToList();
            switch(criterion)
            {
                case ItemsData.SortingCriterion.ByName:
                    sortedItems.Sort(ItemStack.CompareByName);
                    break;
                
                case ItemsData.SortingCriterion.ByWeight:
                    sortedItems.Sort(ItemStack.CompareByWeight);
                    break;
                
                case ItemsData.SortingCriterion.ByValue:
                    sortedItems.Sort(ItemStack.CompareByValue);
                    break;
                
                default:
                    throw new ArgumentOutOfRangeException($"{criterion} is not a valid sorting criterion");
            }
            return new Inventory(sortedItems);
        }
        
        public void Add(ItemStack stack)
        {
            if(Contains(stack.Item))
            {
                items[stack.Item.Id].Add(stack.Count);
            }
            else
            {
                items.Add(stack.Item.Id, stack);
            }
            EventManager.Instance.RaiseOnInventoryModified();
        }

        public void AddAll(IEnumerable<ItemStack> stacks)
        {
            foreach(var stack in stacks)
            {
                Add(stack);
            }
        }
        
        public void Remove(ItemStack stack)
        {
            if(Contains(stack))
            {
                items[stack.Item.Id].Split(stack.Count);
                if(items[stack.Item.Id].Count <= 0)
                {
                    items.Remove(stack.Item.Id);
                }
            }
            else
            {
                throw new ArgumentException($"Cannot remove {stack} from inventory");
            }
            EventManager.Instance.RaiseOnInventoryModified();
        }
        
        public bool Contains(Item item)
        {
            return items.Keys.Contains(item.Id);
        }
        
        public bool Contains(ItemStack stack)
        {
            try
            {
                return items[stack.Item.Id].Contains(stack);
            }
            catch(KeyNotFoundException)
            {
                return false;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public InventoryEnum GetEnumerator()
        {
            return new InventoryEnum(items.Values.ToArray());
        }
    }
}
