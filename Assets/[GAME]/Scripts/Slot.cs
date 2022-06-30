using _GAME_.Scripts.Buttons;
using _GAME_.Scripts.DataModels;
using _GAME_.Scripts.Enums;
using _GAME_.Scripts.GlobalVariables;
using _GAME_.Scripts.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _GAME_.Scripts
{
    public class Slot : MonoBehaviour
    {
        #region SerializeFields

        [Header("Visual Elements")] [SerializeField]
        private Image icon;

        [SerializeField] private TMP_Text inventoryName;
        [SerializeField] private TMP_Text emptyText;

        #endregion

        #region Public Variables

        public SlotType slotType;
        [HideInInspector] public bool isEmpty;

        #endregion

        #region Private Variables

        private SlotButton _slotButton;
        private Inventory _inventory;
        private InventoryData _inventoryData;

        #endregion

        #region MonoBehaviour Methods

        private void Awake()
        {
            isEmpty = true;
            
            _slotButton = GetComponent<SlotButton>();
            _slotButton.ButtonActiveStatus(false);

            emptyText.text = GlobalStrings.Empty;
            icon.gameObject.SetActive(false);
            inventoryName.gameObject.SetActive(false);
        }

        #endregion

        #region Public Methods

        public void TakeInventory(InventoryData inventoryData, Inventory inventory)
        {
            _inventory = inventory;
            _inventoryData = inventoryData;
            emptyText.text = $"";
            icon.GetComponent<Image>().sprite = inventoryData.icon;
            inventoryName.text = inventoryData.name;
            ObjectStatus(true);

            isEmpty = false;

            _slotButton.ButtonActiveStatus(true);
        }

        public void OnClickSlot()
        {
            if (_inventoryData.inventoryType == InventorType.TwoHanded)
            {
                SlotManager.Instance.RemoveAllSlots();
            }

            else
            {
                EmptySlot();
            }
        }
        public void EmptySlot()
        {
            if (isEmpty) return;
            
            _inventory.UndoPlacement();
            InventoryDataManager.Instance.ResetAllInventories();
            isEmpty = true;
            emptyText.text = GlobalStrings.Empty;
            ObjectStatus(false);

            _slotButton.ButtonActiveStatus(false);
        }

        #endregion

        #region Private Methods

        private void ObjectStatus(bool status)
        {
            icon.gameObject.SetActive(status);
            inventoryName.gameObject.SetActive(status);
        }

        #endregion
    }
}