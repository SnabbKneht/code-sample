using System;
using UnityEngine;

namespace InventorySystem
{
    [Serializable]
    public class ItemStack
    {
        [SerializeField] private Item item;
        [SerializeField] private int count;

        public Item Item => item;
        public int Count => count;
        public float Weight => item.Weight * count;
        public float Value => item.Value * count;

        public ItemStack(Item item, int count)
        {
            if(item != null)
            {
                this.item = item;
            }
            else
            {
                throw new ArgumentException("Item cannot be null.");
            }

            if(count < 1)
            {
                throw new ArgumentException("Item count cannot be less than 1");
            }
            else
            {
                this.count = count;
            }
        }

        public void Add(int countToAdd)
        {
            count += countToAdd;
        }
        public ItemStack Split(int countToRemove)
        {
            if(countToRemove <= 0)
            {
                throw new ArgumentException("Non-positive number of items cannot be removed from stack.");
            }
            else if(countToRemove > Count)
            {
                throw new ArgumentException("Cannot remove more items than the stack contains.");
            }
            else
            {
                count -= countToRemove;
                return new ItemStack(Item, countToRemove);
            }
        }

        public bool Contains(ItemStack stack)
        {
            return Item == stack.Item && Count >= stack.Count;
        }
        public override string ToString()
        {
            return Count + "x " + Item.Name;
        }
        
        public static int CompareByName(ItemStack stack1, ItemStack stack2)
        {
            return String.Compare(stack1.Item.Name, stack2.Item.Name);
        }
        public static int CompareByWeight(ItemStack stack1, ItemStack stack2)
        {
            var difference = stack1.Weight - stack2.Weight;

            return difference switch
            {
                < 0f => -1,
                0f => 0,
                > 0f => 1,
                _ => throw new ArgumentOutOfRangeException($"Expected integer and received {difference}")
            };
        }
        public static int CompareByValue(ItemStack stack1, ItemStack stack2)
        {
            var difference = stack1.Value - stack2.Value;
            
            return difference switch
            {
                < 0f => -1,
                0f => 0,
                > 0f => 1,
                _ => throw new ArgumentOutOfRangeException($"Expected integer and received {difference}")
            };
        }
    }
}
