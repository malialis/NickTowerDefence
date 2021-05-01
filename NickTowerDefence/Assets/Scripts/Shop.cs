using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private BuildManager buildManager;

    [Header("Turret Prefabs")]
    public TurretBlueprint standardTurret;
    public TurretBlueprint standardWithShieldTurret;
    public TurretBlueprint missleTurret;
    public TurretBlueprint laserTurret;



    private void Start()
    {
        buildManager = BuildManager.instance;
    }


    public void SelectStandardTurret()
    {
        Debug.Log("Standard Turret Purchased");
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectStandardTurretWithShield()
    {
        Debug.Log("Standard Turret With Shields Purchased");
        buildManager.SelectTurretToBuild(standardWithShieldTurret);
    }

    public void SelectMissleLauncherTurret()
    {
        Debug.Log("Missel Turret Purchased");
        buildManager.SelectTurretToBuild(missleTurret);
    }

    public void SelectLaserTurret()
    {
        Debug.Log("Laser Turret Purchased");
        buildManager.SelectTurretToBuild(laserTurret);
    }


}
