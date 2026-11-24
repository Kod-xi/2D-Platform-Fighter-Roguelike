using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelContext : MonoBehaviour
{
    public static List<GameObject> fighters = new List<GameObject>();

    void Awake()
    {

        foreach(GameObject f in GameObject.FindGameObjectsWithTag("Fighter"))
        {
            fighters.Add(f);
            Debug.Log(fighters.ToString());
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
