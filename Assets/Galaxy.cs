using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Galaxy : MonoBehaviour
{
    public GameObject solarSystemObj;

    // Start is called before the first frame update
    void Start()
    {
        AddSolarSystem("Sun", 0, 0, 0);
        AddSolarSystem("Alpha Centauri", 4.5f, 315, 0);
        AddSolarSystem("Groombridge 34", 11, 140, -3.5f);
        AddSolarSystem("Ross 248", 10, 130, -2.75f);
        AddSolarSystem("Barnard's Star", 7.5f, 85, 2);
        AddSolarSystem("Struve 2398", 11, 90, 4.75f);
        AddSolarSystem("61 Cygni", 12, 80, -1);
        AddSolarSystem("Ross 154", 10, 10, -1.75f);
        AddSolarSystem("L789.6", 6, 45, -9.25f);
        AddSolarSystem("Lacaile 9352", 5, 0, -9.25f);
        AddSolarSystem("εIndi", 8, 340, -8.5f);
        AddSolarSystem("L725.32", 2, 155, -11.75f);
        AddSolarSystem("L726.8", 2, 180, -8.5f);
        AddSolarSystem("τCeti", 3, 175, -11.5f);
        AddSolarSystem("εEridari", 7, 195, -7.75f);
        AddSolarSystem("L372.58", 7.5f, 250, -9.5f);
        AddSolarSystem("Sirius", 8.5f, 225, -1.25f);
        AddSolarSystem("Luyten's Star", 12, 215, 2.25f);
        AddSolarSystem("Procyon", 11, 215, 2.5f);
        AddSolarSystem("G51.15", 10, 200, 6.25f);
        AddSolarSystem("Wolf 359", 4, 245, 6.5f);
        AddSolarSystem("Ross 128", 6, 270, 9.25f);
        AddSolarSystem("Lalande21185", 3.5f, 185, 7.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void AddSolarSystem(string name, float distance, float angle, float depth)
	{
        float radAngle = angle * Mathf.PI / 180.0f;
        GameObject solarSystem = Instantiate(solarSystemObj, new Vector3(-Mathf.Sin(radAngle) * distance, depth, Mathf.Cos(radAngle) * distance), Quaternion.identity);
        solarSystem.name = name;
    }
}
