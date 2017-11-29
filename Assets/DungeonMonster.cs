using System.Collections;
using UnityEngine;

public class DungeonMonster : DungeonCharacter {

    [Header("Monster")]
    public Party party;
    public Transform waypointsContainer;
    [Range(0, 10)] public float minRestingTime = 1f;
    [Range(0, 10)] public float maxRestingTime = 2f;

    Transform[] waypoints;
    int waypointIndex;
    bool waiting;
    float minSqrDistToWaypoint = 0.5f;

    private Transform Waypoint { get { return waypoints[waypointIndex]; } }

    protected override void Awake() {
        base.Awake();

        if (DungeonManager.Instance.monstersToRemove.Contains(name)) {
            Destroy(gameObject);
            return;
        }

        waypoints = waypointsContainer.GetComponentsInChildren<Transform>();
        transform.position = waypoints[waypoints.Length - 1].position;
        //var wpPos = waypoints[waypoints.Length - 1].position;
        //transform.position = new Vector3(wpPos.x, transform.position.y, wpPos.z);
    }

    protected override Vector2 GetInput() {
        if (waiting)
            return Vector2.zero;

        var diff = Waypoint.position - transform.position;
        if (diff.sqrMagnitude < minSqrDistToWaypoint) {
            StartCoroutine(RestAndGoToNextWaypoint());
        }

        var direction = diff.normalized;
        return new Vector2(direction.x, direction.z);
    }

    private IEnumerator RestAndGoToNextWaypoint() {
        if (minRestingTime > 0) {
            waiting = true;
            yield return new WaitForSeconds(Random.Range(minRestingTime, maxRestingTime));
        }

        SelectNextWaypoint();
        waiting = false;
    }

    private void SelectNextWaypoint() {
        waypointIndex += 1;
        waypointIndex %= waypoints.Length;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            enabled = false;
            DungeonManager.Instance.StartBattleWith(this);
        }
    }
}
