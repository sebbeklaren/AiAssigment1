using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolChecks : MonoBehaviour {

    private bool dehydrated;
    private bool semihydrated;
    private bool hydrated;

    public bool Dehydrated
    {
        get
        {
            return dehydrated;
        }

        set
        {
            dehydrated = value;
        }
    }

    public bool Semihydrated
    {
        get
        {
            return semihydrated;
        }

        set
        {
            semihydrated = value;
        }
    }

    public bool Hydrated
    {
        get
        {
            return hydrated;
        }

        set
        {
            hydrated = value;
        }
    }

    //public void CheckThirst()
    // {
    //     if(FindObjectOfType<Worker>().Thirst <= 50)
    //     {
    //         FindObjectOfType<Worker>().IsThirsty = true;
    //     }       
    // }

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
    }

    public void ThirstState()
    {
        if (FindObjectOfType<Worker>().Thirst <= 100 && FindObjectOfType<Worker>().Thirst >= 75)
        {
            Hydrated = true;
        }
        else if (FindObjectOfType<Worker>().Thirst <= 80 && FindObjectOfType<Worker>().Thirst >= 25)
        {
            Semihydrated = true; ;
        }
        else if (FindObjectOfType<Worker>().Thirst <= 30 && FindObjectOfType<Worker>().Thirst >= 0)
        {
            Dehydrated = true;
        }
        else
        {
            Hydrated = false;
            Dehydrated = false;
            Semihydrated = false;
        }
        
           
    }
}
