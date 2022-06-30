using System.Collections.Generic;
using _GAME_.Scripts;
using _GAME_.Scripts.DataModels;
using UnityEngine;

public class InventoryDataManager : MonoBehaviour
{
    #region Singleton

    public static InventoryDataManager Instance;

    #endregion

    #region SerializeFields

    [Header("Data List")] [SerializeField] private List<InventoryData> inventoryDataList;

    [Space(30)] [Header("Grid Parent")] [SerializeField]
    private Transform gridParent;

    [Space(30)] [Header("Inventory Holder Prefab")] [SerializeField]
    private Inventory inventoryPrefab;

    #endregion

    #region Public Variables

    public List<Inventory> inventoryList;

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

        inventoryList = new List<Inventory>();
    }

    private void Start()
    {
        GenerateInventories();
    }

    #endregion

    #region Private Methods

    private void GenerateInventories()
    {
        inventoryList.Clear();

        for (int i = 0; i < 9; i++)
        {
            Inventory inventory = Instantiate(inventoryPrefab, gridParent);

            inventory.InitInventory(inventoryDataList[i]);

            inventoryList.Add(inventory);
        }
    }

    #endregion

    #region Public Methods

    public void ResetAllInventories()
    {
        foreach (Inventory t in inventoryList)
        {
            t.UndoPlacement();
        }
    }

    #endregion
}