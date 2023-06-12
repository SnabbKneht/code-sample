using System;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    public class InventoryComponent : MonoBehaviour
    {
        // config parameters
        [SerializeField] private List<ItemStack> initialItems;

        public Inventory Items { get; private set; }

        private string InventoryName => $"{gameObject.name}'s inventory";

        private void Awake()
        {
            Items = new Inventory();
        }

        private void Start()
        {
            Items.AddAll(initialItems);
        }

        public override string ToString()
        {
            var result = InventoryName + "\n";
            foreach(var item in Items)
            {
                result += $"\t{item}\n";
            }
            return result;
        }
    }
}
