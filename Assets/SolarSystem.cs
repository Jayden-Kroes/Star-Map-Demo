using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystem : MonoBehaviour
{
    GalaxyGUI gui;
    public static SolarSystem hoveredSolarSystem = null;
    public static SolarSystem selectedSolarSystem = null;
    CameraController myCamera;

    // Start is called before the first frame update
    void Start()
    {
        gui = FindObjectOfType<GalaxyGUI>();
        myCamera = FindObjectOfType<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnMouseOver()
    {
        hoveredSolarSystem = this;
        gui.UpdateInfoText();
    }

    void OnMouseExit()
    {
        if (hoveredSolarSystem == this)
        {
            hoveredSolarSystem = null;
        }
        gui.UpdateInfoText();
    }

    void OnMouseDown()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            selectedSolarSystem = this;
            myCamera.SetCameraType(CameraController.MovementType.OrbitSystem);
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            selectedSolarSystem = this;
            myCamera.SetCameraType(CameraController.MovementType.SystemPerspective);
        }
    }
}
