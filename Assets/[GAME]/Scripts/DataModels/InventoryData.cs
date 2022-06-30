using _GAME_.Scripts.Enums;
using UnityEngine;

namespace _GAME_.Scripts.DataModels
{
    [System.Serializable]
    public class InventoryData
    {
        [Header("Visuals")] public Sprite icon;
        public string name;

        [Space(30)] [Header("Rules")] public InventorType inventoryType;
        public InventoryHandType inventoryHandType;
        public InventoryPriority inventoryPriority;
    }
}