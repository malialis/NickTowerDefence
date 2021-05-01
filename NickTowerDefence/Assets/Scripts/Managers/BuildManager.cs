using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private TurretBlueprint turretToBuild;

    public GameObject standardTurretPrefab;
    public GameObject standardTurretWithShieldPrefab;
    public GameObject misselTurretPrefab;
    public GameObject laserLauncherPrefab;

    public bool canBuild
    {
        get
        {
            return turretToBuild != null;
        }
    }


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

   
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
        

    public void BuildTurretOn(Node node)
    {
        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;
    }
   

}
