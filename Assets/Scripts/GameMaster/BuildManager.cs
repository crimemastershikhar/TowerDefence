using UnityEngine;

//Summary: Using Singleton for a single refrence for all nodes 

public class BuildManager : MonoBehaviour {

    [SerializeField]
    private GameObject standardTurretPrefab;


    private GameObject turretToBuild;

    public static BuildManager instance;

    private void Awake() {
        if (instance != null)
            return;

        instance = this;
    }

    private void Start() {
        turretToBuild = standardTurretPrefab;

    }

    public GameObject GetTurretToBuild() {
        return turretToBuild;
    }

}
