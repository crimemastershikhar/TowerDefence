using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Summary: This class is responsible to check and build on top of the node if its empty + It also handled the user interactions with the nodes environment

public class Node : MonoBehaviour {

    [SerializeField]
    private Color hoverColor;

    private Color startColor;
    private Renderer rend;

    private GameObject turret;
    private Vector3 positionOffset;

    private void Start() {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        positionOffset = new Vector3(0f, 0.5f, 0f);
    }

    private void OnMouseEnter() {
        rend.material.color = hoverColor;
    }

    private void OnMouseExit() {
        rend.material.color = startColor;
    }

    private void OnMouseDown() {
        if (turret != null)
            return;

        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);


    }

}//Class
