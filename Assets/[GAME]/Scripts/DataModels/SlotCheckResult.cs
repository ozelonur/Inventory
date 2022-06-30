using System.Collections.Generic;

namespace _GAME_.Scripts.DataModels
{
    [System.Serializable]
    public class SlotCheckResult
    {
        public bool isAvailable;
        public List<Slot> availableSlots;
    }
}