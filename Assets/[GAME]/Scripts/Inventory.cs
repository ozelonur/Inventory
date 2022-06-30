using _GAME_.Scripts.Buttons;
using _GAME_.Scripts.DataModels;
using _GAME_.Scripts.GlobalVariables;
using _GAME_.Scripts.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _GAME_.Scripts
{
    public class Inventory : MonoBehaviour
    {
        #region Public Variables

        [Header("Visual Elements")]
        [SerializeField]private Image icon;
        [SerializeField]private TMP_Text inventoryName;
        [SerializeField] private EquipButton equipButton;
        [SerializeField] private TMP_Text equipButtonText;
        
        #endregion

        #region Private Variables

        private InventoryData _inventoryData;
        private SlotCheckResult _slotCheckResult;

        #endregion

        #region MonoBehaviour Methods

        private void Awake()
        {
            equipButton.gameObject.SetActive(false);
        }

        #endregion
        

        #region Public Methods

        public void InitInventory(InventoryData inventoryData)
        {
            _inventoryData = inventoryData;
            equipButton.gameObject.SetActive(false);
            equipButtonText.text = GlobalStrings.Equip;
            icon.GetComponent<Image>().sprite = inventoryData.icon;
            inventoryName.text = inventoryData.name;
        }

        public void CheckSlotStatus()
        {
            equipButton.gameObject.SetActive(true);
            
            _slotCheckResult = SlotManager.Instance.CheckInventoryPlacement(_inventoryData);

            equipButton.ButtonActiveStatus(_slotCheckResult.isAvailable);
        }

        public void PlaceToTheSlot()
        {
            if (_slotCheckResult == null)
            {
                return;
            }

            foreach (Slot t in _slotCheckResult.availableSlots)
            {
                t.TakeInventory(_inventoryData, this);
            }

            InventoryDataManager.Instance.inventoryList.Remove(this);

            equipButtonText.text = GlobalStrings.Equipped;
            equipButton.ButtonActiveStatus(false);
        }

        public void UndoPlacement()
        {
            if (!InventoryDataManager.Instance.inventoryList.Contains(this))
            {
                InventoryDataManager.Instance.inventoryList.Add(this);
            }
            InitInventory(_inventoryData);
        }

        #endregion
    }
}