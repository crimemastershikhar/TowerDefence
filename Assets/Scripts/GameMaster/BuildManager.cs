using UnityEngine;

/// <summary>
/// Using Singleton for a single refrence for all nodes 
/// </summary>

public class BuildManager : MonoBehaviour {

    /// <summary>
    /// Introduce enums/SO here later for diff types of weapons
    /// </summary>
    public GameObject standardTurretPrefab;
    public GameObject missileLauncher;

    private GameObject turretToBuild;
    public static BuildManager instance;

    private void Awake() {
        if (instance != null)
            return;

        instance = this;
    }

    public GameObject GetTurretToBuild() {
        return turretToBuild;

    }

    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;

    }











}//Class
