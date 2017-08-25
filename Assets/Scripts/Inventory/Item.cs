using UnityEngine;

public class Item : ScriptableObject {

    [SerializeField] private string _name = "Unarmed";
    [SerializeField] private Sprite _icon;

    public Sprite Icon { get { return _icon; } }
    public string Name { get { return _name; } }

}
