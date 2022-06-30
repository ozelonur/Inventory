using _GAME_.Scripts.Structs;
using UnityEngine;

namespace _GAME_.Scripts.Scriptables
{
    [CreateAssetMenu(fileName = "Data", menuName = "InventoryData/InventoryData", order = 1)]
    public class InventorDataScriptable : ScriptableObject
    {
        public InventorData InventorData;
    }
}