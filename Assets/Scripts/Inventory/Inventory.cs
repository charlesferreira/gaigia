using System.Collections.Generic;
using UnityEngine;

public class Inventory : Singleton<Inventory> {

    [System.Serializable]
    public struct InventoryItem {
        public Item item;
        public int quantity;
    }

    [SerializeField] private IDictionary<Item, int> items;
    [SerializeField] private List<InventoryItem> itemList;

    protected Inventory() { }

    public void Add(Item item, int quantity) {
        if (!items.ContainsKey(item)) items[item] = 0;
        items[item] += quantity;
        UpdateItemList();
    }

    private void UpdateItemList() {
        itemList = new List<InventoryItem>();
        foreach (var tuple in items) {
            itemList.Add(new InventoryItem() {
                item = tuple.Key,
                quantity = tuple.Value
            });
        }
    }

    public void Remove(Item item, int quantity) {
        if (!items.ContainsKey(item)) items[item] = 0;
        items[item] = Mathf.Max(0, items[item] - quantity);
        UpdateItemList();
    }

    private void Awake() {
        items = new Dictionary<Item, int>();
        itemList = new List<InventoryItem>();
    }
}
