using System;
using System.Collections;

namespace InventorySystem
{
    public class InventoryEnum : IEnumerator
    {
        private ItemStack[] stacks;
        private int position = -1;

        public InventoryEnum(ItemStack[] list)
        {
            stacks = list;
        }
        
        public bool MoveNext()
        {
            position++;
            return position < stacks.Length;
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current => Current;
        
        public ItemStack Current => stacks[position];
    }
}
