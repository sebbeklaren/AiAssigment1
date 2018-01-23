using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolChecks : MonoBehaviour {


   public void CheckThirst()
    {
        if(FindObjectOfType<Worker>().Thirst <= 50)
        {
            FindObjectOfType<Worker>().IsThirsty = true;
        }
   
        
    }

    public void CheckFatigue()
    {
        if (FindObjectOfType<Worker>().Fatigue <= 50)
        {
            FindObjectOfType<Worker>().IsFatigue = true;
        }
        
       
    }

    public void CheckPockets()
    {
        if(FindObjectOfType<Worker>().GoldCounter != 0)
        {
            FindObjectOfType<Worker>().PocketsFull = true;
        }
        else
        {
            FindObjectOfType<Worker>().PocketsFull = false;
        }
       // Debug.Log(FindObjectOfType<Worker>().PocketsFull);
    }



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
