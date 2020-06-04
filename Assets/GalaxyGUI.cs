using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class GalaxyGUI : MonoBehaviour
{
    public Text infoText;
    Camera myCamera;
    // Start is called before the first frame update
    void Start()
    {
        myCamera = FindObjectOfType<Camera>();
        UpdateInfoText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateInfoText()
	{
        if (SolarSystem.hoveredSolarSystem != null)
        {
            infoText.text =
                SolarSystem.hoveredSolarSystem.name + '\n' +
                "Distance to: " + (myCamera.transform.position - SolarSystem.hoveredSolarSystem.transform.position).magnitude + "ly";
        }
        else
		{
            infoText.text = "";
		}
	}
}
