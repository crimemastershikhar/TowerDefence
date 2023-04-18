using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// communicating with build manager and currency manager + Handle diff UI things 
/// Shop opening and closing times
/// </summary>

public class Shop : MonoBehaviour
{
    private GameObject standardTurretButton, missileLauncherButton, ultimateTurretButton;
    private BuildManager buildManager => BuildManager.instance;

    private void Start()
    {
        //ForButtons
        standardTurretButton = GameObject.FindGameObjectWithTag("StandardTurret");
        standardTurretButton.GetComponent<Button>().onClick.AddListener(PurchaseStandardTurret);

        missileLauncherButton = GameObject.Find(nameof(TowerType.MissileLauncher.ToString));
        missileLauncherButton.GetComponent<Button>().onClick.AddListener(PurchaseMissileLauncher);

/*        ultimateTurretButton = GameObject.Find(nameof(TowerType.UltimateTurret.ToString));
        ultimateTurretButton.GetComponent<Button>().onClick.AddListener(PurchaseUltimateTurret);*/

    }

    public void PurchaseStandardTurret()
    {
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
        Debug.Log("BUILT");

    }

    public void PurchaseMissileLauncher()
    {
        buildManager.SetTurretToBuild(buildManager.missileLauncher);

    }

    public void PurchaseUltimateTurret()
    {
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);

    }



}//Class

