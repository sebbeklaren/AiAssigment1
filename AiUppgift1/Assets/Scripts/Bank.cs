using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : MonoBehaviour
{
    private int richNow;
   
   

    public int RichNow { get { return richNow; } set { richNow = value; } }

    // Use this for initialization
    void Start()
    {       
        RichNow = 100;        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
