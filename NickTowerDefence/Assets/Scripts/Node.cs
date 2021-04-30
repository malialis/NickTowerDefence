using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    [SerializeField] private Color hoverColor;
    [SerializeField] private Color occupiedColor;
    [SerializeField] private Color originalColor;
    [SerializeField] private Renderer rendr;
    [SerializeField] private Vector3 positionOffset;

    private GameObject turret;
    private BuildManager buildManager;


    // Start is called before the first frame update
    void Start()
    {
        rendr = GetComponent<Renderer>();
        originalColor = rendr.material.color;
        buildManager = BuildManager.instance;
    }

   


    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (buildManager.GetTurretToBuild() == null)
            return;

        if (turret == null)
        {
            rendr.material.color = hoverColor;
        }
        else if(turret != null)
        {
            rendr.material.color = occupiedColor;
        }
        
    }

    private void OnMouseExit()
    {
        rendr.material.color = originalColor;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (buildManager.GetTurretToBuild() == null)
            return;

        if(turret != null)
        {
            Debug.Log("Can not build, a turret is here " + gameObject.name);
            return;
        }

        //else build a turret
        GameObject turretToBuild = buildManager.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);


    }



}
