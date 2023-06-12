using System;
using UnityEngine;

namespace InventorySystem
{
    [CreateAssetMenu(fileName = "item", menuName = "ScriptableObjects/Equipment/Item")]
    public class Item : ScriptableObject
    {
        [Header("Properties")]
        [SerializeField] private ItemsData.Id id = ItemsData.Id.Nothing;
        [SerializeField] private string itemName = "Item";
        [SerializeField] private string description = "Description";
        [SerializeField] private ItemsData.Category category = ItemsData.Category.Misc;
        [SerializeField] private float weight;
        [SerializeField] private int value;
        [SerializeField] private Sprite sprite;

        public ItemsData.Id Id => id;
        public string Name => itemName;
        public string Description => description;
        public ItemsData.Category Category => category;
        public float Weight => weight;
        public int Value => value;
        public Sprite Sprite => sprite;
    }
}
