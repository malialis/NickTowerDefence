using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private GameObject turretToBuild;

    public GameObject standardTurretPrefab;
    public GameObject standardTurretWithShieldPrefab;
    public GameObject misselTurretPrefab;
    public GameObject laserLauncherPrefab;


    // Start is called before the first frame update
    void Awake()
    {
        if(instance != null)
        {
            Debug.Log("More than exists, there can only be one");
            return;
        }

        instance = this;
    }

    
    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }


}
