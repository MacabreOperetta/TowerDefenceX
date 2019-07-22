using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour {

    public static ArrayList array = new ArrayList();
    public static Transform[] points;

    // Use this for initialization
    void Awake()
    {
        points = new Transform[transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
            points[i]=transform.GetChild(i);
            if(i>0)
            {
                if (points[i].transform.position.z > points[i - 1].transform.position.z)
                    array.Add("U");
                if (points[i].transform.position.z < points[i - 1].transform.position.z)
                    array.Add("D");
                if (points[i].transform.position.x > points[i - 1].transform.position.x)
                    array.Add("R");
                if (points[i].transform.position.x < points[i - 1].transform.position.x)
                    array.Add("L");
            }
            
            
        }
    }
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
