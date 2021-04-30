using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private BuildManager buildManager;



    private void Start()
    {
        buildManager = BuildManager.instance;
    }


    public void PurchaseStandardTurret()
    {
        Debug.Log("Standard Turret Purchased");
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
    }

    public void PurchaseStandardTurretWithShields()
    {
        Debug.Log("Standard Turret With Shields Purchased");
        buildManager.SetTurretToBuild(buildManager.standardTurretWithShieldPrefab);
    }

    public void PurchaseMisselTurret()
    {
        Debug.Log("Missel Turret Purchased");
        buildManager.SetTurretToBuild(buildManager.misselTurretPrefab);
    }

    public void PurchaseLaserTurret()
    {
        Debug.Log("Laser Turret Purchased");
        buildManager.SetTurretToBuild(buildManager.laserLauncherPrefab);
    }


}
