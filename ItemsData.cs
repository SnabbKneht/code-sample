using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    [CreateAssetMenu(fileName = "ItemsData", menuName = "ScriptableObjects/Equipment/ItemsData")]
    public class ItemsData : ScriptableObject
    {
        public enum Id
        {
            Nothing,
            EmptyBottle,
            HealthPotion,
            StaminaPotion,
            ManaPotion,
            Key,
            Sword,
            Ruby,
            Diamond,
            Bow,
            Shield,
            SilverRing,
            GoldRing,
            Helmet,
            Boots,
            Gloves,
            CopperIngot,
            SilverIngot,
            GoldIngot,
            Amulet,
            Scroll,
            Apple
        }

        public enum Category
        {
            Equipment,
            Usable,
            Ingredients,
            Readable,
            Keys,
            Misc
        }

        public enum SortingCriterion
        {
            ByName,
            ByWeight,
            ByValue
        }
    }
}
