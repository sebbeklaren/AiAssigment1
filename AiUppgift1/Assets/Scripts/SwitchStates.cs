using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchStates : MonoBehaviour
{
    int minFatigue = 0;
    int rich = 100;
    int poor = 0;
    int thirsty = 50;
   
    // Use this for initialization
    void Start()
    {
       
    }

    public void StateChanger(Worker worker, Bank bank, Nugget nugget)
    {
       
        if (FindObjectOfType<DayAndNightControl>().currentWorkerDaystate == DayAndNightControl.DaystateOut.Morning ||
            FindObjectOfType<DayAndNightControl>().currentWorkerDaystate == DayAndNightControl.DaystateOut.Evening ||            
            FindObjectOfType<DayAndNightControl>().currentWorkerDaystate == DayAndNightControl.DaystateOut.Day && 
            !FindObjectOfType<Nugget>().IsOnGround && !FindObjectOfType<Worker>().IsFatigue)
        {          
            worker.newTargetPos = GameObject.FindGameObjectWithTag("mineTargetPos").transform.position;
            worker.currentWorkerState = Worker.WorkerState.MineGold;
        }
        if (FindObjectOfType<DayAndNightControl>().currentWorkerDaystate != DayAndNightControl.DaystateOut.Day &&
            !FindObjectOfType<Nugget>().CanPickUp && 
            FindObjectOfType<Worker>().IsThirsty && 
            FindObjectOfType<Worker>().PocketsFull)
        {
           // Debug.Log("VisitSaloonState");

            worker.newTargetPos = GameObject.FindGameObjectWithTag("saloonTargetpos").transform.position;
            worker.currentWorkerState = Worker.WorkerState.VisitSaloon;
        }
        if (FindObjectOfType<DayAndNightControl>().currentWorkerDaystate == DayAndNightControl.DaystateOut.Evening ||
            FindObjectOfType<DayAndNightControl>().currentWorkerDaystate == DayAndNightControl.DaystateOut.Night && 
            !FindObjectOfType<Nugget>().CanPickUp  && 
            FindObjectOfType<Worker>().PocketsFull && 
            !FindObjectOfType<Worker>().IsThirsty)
        {
          //  Debug.Log("VisitBankState");

            worker.newTargetPos = GameObject.FindGameObjectWithTag("bankTargetPos").transform.position;
            worker.currentWorkerState = Worker.WorkerState.VisitBank;           
        }
        if (FindObjectOfType<DayAndNightControl>().currentWorkerDaystate != DayAndNightControl.DaystateOut.Day &&
            !FindObjectOfType<Worker>().PocketsFull)
        {
           // Debug.Log("GoHomeState");

            worker.newTargetPos = GameObject.FindGameObjectWithTag("houseTargetPos").transform.position;
            worker.currentWorkerState = Worker.WorkerState.GoHome;           
        }
        if(FindObjectOfType<Nugget>().IsOnGround && FindObjectOfType<Nugget>().CanPickUp)
        {
           // Debug.Log("pickUpNuggetState");
            worker.newTargetPos = GameObject.FindGameObjectWithTag("nuggetTargetPos").transform.position;
            worker.currentWorkerState = Worker.WorkerState.PickUpGold;
        }
        if (FindObjectOfType<Worker>().IsFatigue)
        {
           // Debug.Log("restState");
            worker.currentWorkerState = Worker.WorkerState.Rest;

        }        
    }

    // Update is called once per frame
    void Update()
    {
        

    }
}
