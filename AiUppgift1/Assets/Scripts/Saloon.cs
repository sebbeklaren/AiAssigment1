using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saloon : MonoBehaviour
{
    public Vector3 saloonPos;    
    private bool isOpen;


    public bool IsOpen { get { return isOpen; } set { isOpen = value; } }

    // Use this for initialization
    void Start()
    {
        saloonPos = gameObject.transform.position;
        //dayController = new DayAndNightControl();
    }

    // Update is called once per frame
    void Update()
    {
        //if (GameObject.FindObjectOfType<DayAndNightControl>().currentWorkerDaystate == DayAndNightControl.DaystateOut.Evening || GameObject.FindObjectOfType<DayAndNightControl>().currentWorkerDaystate == DayAndNightControl.DaystateOut.Night)
        //{
        //    IsOpen = true;
        //}
        //else
        //{
        //    IsOpen = true;
        //}
    }   
}
