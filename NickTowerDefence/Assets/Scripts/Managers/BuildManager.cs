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

    public GameObject buildFX;

    public bool canBuild
    {
        get
        {
            return turretToBuild != null;
        }
    }

    public bool hasMoney
    {
        get
        {
            return PlayerStats.Money >= turretToBuild.cost;
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
        if(PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not enough money");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;
        GameObject buildSFX = (GameObject)Instantiate(buildFX, node.GetBuildPosition(), Quaternion.identity);
        Destroy(buildSFX, 3f);

        Debug.Log("Turret is built! Money left is ..." + PlayerStats.Money);
    }



}
