using System.Collections.Generic;
using UnityEngine;

public class LootCollector : MonoBehaviour {

    private IList<Loot> LootNearby { get; set; }

    private void OnTriggerEnter(Collider other) {
        var loot = other.GetComponent<Loot>();
        if (!loot) return;

        loot.OnApproach();
        LootNearby.Add(loot);
    }

    private void OnTriggerExit(Collider other) {
        var loot = other.GetComponent<Loot>();
        if (!loot) return;

        loot.OnLeave();
        LootNearby.Remove(loot);
    }

    private void Awake() {
        LootNearby = new List<Loot>();
    }

    private void Update() {
        if (PlayerInput.Confirm && LootNearby.Count > 0) {
            LootNearby[0].Collect();
            LootNearby.RemoveAt(0);
        }
    }
}
