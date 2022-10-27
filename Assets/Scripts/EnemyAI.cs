using UnityEngine;

//Summary -->> Class Responsible for managing the interaction of the enemy

public class EnemyAI : MonoBehaviour {
    [SerializeField]
    private float speed = 10f;

    private Transform target;
    private int wavePointIndex = 0;  //waypoint that we are pursuing

    private void Start() {
        target = Waypoints.points[0];

    }

    private void Update() {
        enemyMovement();

    }

    #region EnemyNavigationSystem
    private void enemyMovement() {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(target.position, transform.position) <= 0.4f)
            GetNextWayPoint();

    }

    private void GetNextWayPoint() {
        if (wavePointIndex >= Waypoints.points.Length - 1) {
            Destroy(gameObject);
            return;
        }


        wavePointIndex++;
        target = Waypoints.points[wavePointIndex];

    }
    #endregion

}//Class
