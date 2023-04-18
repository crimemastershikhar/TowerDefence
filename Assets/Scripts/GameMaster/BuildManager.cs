using UnityEngine;

/// <summary>
/// Using Singleton for a single refrence for all nodes 
/// </summary>


public class BuildManager : MonoBehaviour {
     
    public GameObject standardTurretPrefab;

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

    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;

    }











}//Class
