using _GAME_.Scripts.DataModels;
using UnityEngine;

namespace _GAME_.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Data", menuName = "InventoryData/InventoryData", order = 1)]
    public class InventorDataScriptable : ScriptableObject
    {
        public InventoryData InventorData;
    }
}