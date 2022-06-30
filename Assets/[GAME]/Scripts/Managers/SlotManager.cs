using System.Collections.Generic;
using _GAME_.Scripts.DataModels;
using _GAME_.Scripts.Enums;
using UnityEngine;

namespace _GAME_.Scripts.Managers
{
    public class SlotManager : MonoBehaviour
    {
        #region Singleton

        public static SlotManager Instance;

        #endregion

        #region SerializeFields

        [Header("Slots")] [SerializeField] private Slot rightHandSlot;
        [SerializeField] private Slot leftHandSlot;

        #endregion

        #region Public Variables

        public bool isAcceptable;
        public List<Slot> availableSlots;

        #endregion

        #region MonoBehaviour Methods

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(this);
            }

            availableSlots = new List<Slot>();

        }

        #endregion

        #region Public Methods

        public SlotCheckResult CheckInventoryPlacement(InventoryData inventoryData)
        {
            availableSlots.Clear();
            switch (inventoryData.inventoryType)
            {
                case InventorType.OneHanded:
                    switch (inventoryData.inventoryHandType)
                    {
                        case InventoryHandType.LeftHand:
                            if (leftHandSlot.isEmpty)
                            {
                                isAcceptable = true;
                                availableSlots.Add(leftHandSlot);
                            }

                            else
                            {
                                isAcceptable = false;
                            }

                            break;
                        case InventoryHandType.RightHand:
                            if (rightHandSlot.isEmpty)
                            {
                                isAcceptable = true;
                                availableSlots.Add(rightHandSlot);
                            }

                            else
                            {
                                isAcceptable = false;
                            }

                            break;
                        case InventoryHandType.Both:
                            switch (inventoryData.inventoryPriority)
                            {
                                case InventoryPriority.LeftHand:
                                    if (leftHandSlot.isEmpty)
                                    {
                                        isAcceptable = true;
                                        availableSlots.Add(leftHandSlot);
                                    }

                                    else if (rightHandSlot.isEmpty)
                                    {
                                        isAcceptable = true;
                                        availableSlots.Add(rightHandSlot);
                                    }

                                    else
                                    {
                                        isAcceptable = false;
                                    }

                                    break;
                                case InventoryPriority.RightHand:
                                    if (rightHandSlot.isEmpty)
                                    {
                                        isAcceptable = true;
                                        availableSlots.Add(rightHandSlot);
                                    }

                                    else if (leftHandSlot.isEmpty)
                                    {
                                        isAcceptable = true;
                                        availableSlots.Add(leftHandSlot);
                                    }

                                    else
                                    {
                                        isAcceptable = false;
                                    }

                                    break;
                                default:
                                    Debug.Log("This type is not implemented!");
                                    break;
                            }

                            break;
                        default:
                            Debug.Log("This type is not implemented!");
                            break;
                    }

                    break;
                case InventorType.TwoHanded:
                    if (leftHandSlot.isEmpty && rightHandSlot.isEmpty)
                    {
                        isAcceptable = true;
                        availableSlots.Add(rightHandSlot);
                        availableSlots.Add(leftHandSlot);
                    }

                    else
                    {
                        isAcceptable = false;
                    }

                    break;
                default:
                    Debug.Log("This type is not implemented!");
                    break;
            }

            SlotCheckResult slotCheckResult = new SlotCheckResult()
            {
                isAvailable = isAcceptable,
                availableSlots = availableSlots
            };
            
            return slotCheckResult;
        }

        public void RemoveAllSlots()
        {
            leftHandSlot.EmptySlot();
            rightHandSlot.EmptySlot();
        }

        #endregion
    }
}