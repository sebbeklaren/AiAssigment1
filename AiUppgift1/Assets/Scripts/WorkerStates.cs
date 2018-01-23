using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerStates : MonoBehaviour {

   
   // public Transform targetPos;   
    public Vector3 movePos, currentPos;
    private int moveSpeed = 3;
    private int digCount;
    private int restCount;
    float dt, ft, st;
    
    public int DigCount { get { return digCount; } set { digCount = value; } }
    public int RestCount { get { return restCount; } set { restCount = value; } }

    // Use this for initialization
    void Start () {
        GameObject.FindObjectOfType<Mine>().MineForGoldCounter = 5;
        GameObject.FindObjectOfType<Mine>().GoldNuggetCount = 100;       
        dt = 0.0f;
        ft = 0.0f;
        st = 0.0f;
        DigCount = 0;
        RestCount = 0;
        FindObjectOfType<Worker>().IsThirsty = false;
        FindObjectOfType<Worker>().IsFatigue = false;

    }

    public void MoveTo(GameObject gObject, Vector3 targetPos)
    {
        movePos = Vector3.MoveTowards(gObject.transform.position, targetPos, moveSpeed * Time.deltaTime);
        gObject.transform.position = new Vector3(movePos.x, 0.4f, movePos.z);
    }

    public void MiningGold(GameObject gObject, Vector3 targetPos)
    {         
        if(gObject.transform.position.x - targetPos.x < 1)
        {          
            MineForGold(gObject, targetPos);            
        }        
    }
    public void PickUpGold(GameObject gObject, Vector3 targetPos)
    {
      //  Debug.Log(FindObjectOfType<Nugget>().CanPickUp);
        if (Vector3.Distance(FindObjectOfType<Nugget>().transform.position, gObject.transform.position) <= 1.0f && FindObjectOfType<Nugget>().CanPickUp == true)
        {
          //  Debug.Log("Distance0.5");
            
            FindObjectOfType<Nugget>().IsVisible = false;          
            FindObjectOfType<Nugget>().transform.position = new Vector3(-21.68f, 4.04f, 22.68f);
            FindObjectOfType<Nugget>().CanPickUp = false;
            FindObjectOfType<Nugget>().IsOnGround = false;
            FindObjectOfType<Worker>().GoldCounter++;
           // Debug.Log(FindObjectOfType<Worker>().GoldCounter);
            DigCount = 0;
        }        
    }
	
    public void GoToSaloon(GameObject gObject, Vector3 targetPos)
    {
        st += Time.deltaTime * 5;

        if (Vector3.Distance(gObject.transform.position, GameObject.FindGameObjectWithTag("saloonTargetpos").transform.position) < 0.5)
        {
            if (st >= 1)
            {
                if (FindObjectOfType<Worker>().Thirst != 100)
                {

                    FindObjectOfType<Worker>().Thirst++;
                }
                else if (FindObjectOfType<Worker>().Thirst == 100)
                {
                    FindObjectOfType<Worker>().IsThirsty = false;
                    FindObjectOfType<Worker>().GoldCounter = 0;
                }
                st = 0.0f;
            }
        }
        Debug.Log("saloonMove");
        DigCount = 0;
    }

    public void GoToBank(GameObject gObject, Vector3 targetPos)
    {
       
       // Debug.Log("bankMove");
        if (Vector3.Distance(gObject.transform.position, GameObject.FindGameObjectWithTag("bankTargetPos").transform.position) < 0.5)
        {
            FindObjectOfType<Worker>().BankAccount += FindObjectOfType<Worker>().GoldCounter;
            FindObjectOfType<Worker>().GoldCounter = 0;
            DigCount = 0;
        }

    }

    public void GoHome(GameObject gObject, Vector3 targetPos)
    {
        
       // Debug.Log("homeMove");
        DigCount = 0;
    }

    public void Rest(GameObject gObject, Vector3 targetPos)
    {
        ft += Time.deltaTime * 5;
        if (ft >= 1)
        {
            if (FindObjectOfType<Worker>().Fatigue != 100)
            {
                FindObjectOfType<Worker>().Fatigue++;
            }
            else if(FindObjectOfType<Worker>().Fatigue == 100)
            {
                FindObjectOfType<Worker>().IsFatigue = false;
            }
            ft = 0.0f;
        }
      //  Debug.Log("rest");
    }

    public void MineForGold(GameObject gObject, Vector3 targetPos)
    {   
        dt += Time.deltaTime * 5;
        if (DigCount <= 5)
        {        
            if (dt >= 3.0f)
            {
                movePos = Vector3.MoveTowards(gObject.transform.position, targetPos, moveSpeed * Time.deltaTime);
                // temporärt för att visualisera när ain arbetar
                if (dt % 2 == 0)
                {
                    gObject.transform.position = new Vector3(movePos.x, movePos.y + 1, movePos.z);
                }
                else
                {
                    gObject.transform.position = new Vector3(movePos.x, movePos.y - 1, movePos.z);
                }                
                dt = 0.0f;
                DigCount++;
                FindObjectOfType<Worker>().Fatigue--;
                FindObjectOfType<Worker>().Thirst--;
               // Debug.Log(FindObjectOfType<Worker>().Fatigue);
                if (DigCount == 5)
                {                   
                    FindObjectOfType<Nugget>().IsOnGround = true;
                   
                }
                //else if()
                //{
                //    FindObjectOfType<Nugget>().IsOnGround = false;
                //}
            }
            //Debug.Log(digCount);
        }      
    }
    void OnGUI()
    {
        //debug GUI on screen visuals
        GUI.Box(new Rect(15, 15, 130, 25), "Gold: " + FindObjectOfType<Worker>().GoldCounter);
        GUI.Box(new Rect(15, 40, 130, 25), "Fatigue: " + FindObjectOfType<Worker>().Fatigue);
        GUI.Box(new Rect(15, 65, 130, 25), "Thirst: " + FindObjectOfType<Worker>().Thirst);
        GUI.Box(new Rect(15, 90, 130, 25), "Bank account: " + FindObjectOfType<Worker>().BankAccount);
    }

}
