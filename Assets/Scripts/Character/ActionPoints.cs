using UnityEngine;

public class ActionPoints: MonoBehaviour {

    //[Range(1, 9)]
    //[SerializeField]
    private int basePoints = 5;

    public int Total { get { return Base + Stored; } }
    public int Left { get { return Character.Movement.enabled ? Total - Character.Movement.Cost : Total; } }

    private int Base { get { return basePoints; } }
    private int Stored { get; set; }
    
    private Character Character { get; set; }

    public void Store(int points) {
        Stored = points;
    }

    private void Awake() {
        Character = GetComponent<Character>();
    }

}