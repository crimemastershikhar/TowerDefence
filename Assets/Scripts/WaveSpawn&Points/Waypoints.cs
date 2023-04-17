using UnityEngine;

//Summary --> Class is responsible for calculating and storing the wave points on the map

public class Waypoints : MonoBehaviour {

    public static Transform[] points;

    private void Awake() {
        points = new Transform[transform.childCount];
        for (int i = 0; i < points.Length; i++) {
            points[i] = transform.GetChild(i);
        }

    }

}
