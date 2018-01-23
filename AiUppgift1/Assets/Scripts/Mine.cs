using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{

    private bool isMinable;
    private int goldNuggetCount;
    private int mineForGoldCounter;
    public bool releaseGold;
    public Vector3 minePos;
    

    public int MineForGoldCounter { get { return mineForGoldCounter; } set { mineForGoldCounter = value; } }
    public int GoldNuggetCount { get { return goldNuggetCount; } set { goldNuggetCount = value; } }

    public bool IsMinable{ get { return isMinable; } set { isMinable = value;  } }



    // Use this for initialization
    void Start(){

       
    }   
    //public void PossibleToMine()
    //{
    //    if(FindObjectOfType<Nugget>().IsOnGround == true)
    //    {
    //        IsMinable = false;
    //    }
    //    else
    //    {
    //        IsMinable = true;
    //    }
    //}
    // Update is called once per frame
    void Update()
    {
      
      
    }
}
