using UnityEngine;

public class TitleWave : MonoBehaviour {

    public float length;
    public float speed;
    [Range(0f, 360f)]
    public float phase;

    private Vector3 startingPosition;
    private Vector3 offset;

    void Start () {
        startingPosition = transform.position;
	}
	
	void LateUpdate () {
        offset.y = Mathf.Cos(Time.time * speed + phase) * length;

		transform.position = startingPosition + offset;
	}
}
