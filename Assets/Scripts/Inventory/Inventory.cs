using System.Collections.Generic;
using UnityEngine;

public class Inventory : Singleton<Inventory> {

    [SerializeField]
    private List<Item> items = new List<Item>();

    protected Inventory() { }

    public void Add(Item item) {
        items.Add(item);
    }

    public void Remove(Item item) {
        items.Remove(item);
    }

}
