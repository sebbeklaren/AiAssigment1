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
            FindObjectOfType<BoolChecks>().Dehydrated &&
            FindObjectOfType<BoolChecks>().Semihydrated &&
            !FindObjectOfType<BoolChecks>().Hydrated &&
            FindObjectOfType<Worker>().PocketsFull)
        {
            worker.newTargetPos = GameObject.FindGameObjectWithTag("saloonTargetpos").transform.position;
            worker.currentWorkerState = Worker.WorkerState.VisitSaloon;
        }
        if (FindObjectOfType<DayAndNightControl>().currentWorkerDaystate == DayAndNightControl.DaystateOut.Evening ||
            FindObjectOfType<DayAndNightControl>().currentWorkerDaystate == DayAndNightControl.DaystateOut.Night && 
            !FindObjectOfType<Nugget>().CanPickUp  && 
            FindObjectOfType<Worker>().PocketsFull &&
            FindObjectOfType<BoolChecks>().Hydrated &&
            FindObjectOfType<BoolChecks>().Semihydrated &&
            !FindObjectOfType<BoolChecks>().Dehydrated)
        {
            worker.newTargetPos = GameObject.FindGameObjectWithTag("bankTargetPos").transform.position;
            worker.currentWorkerState = Worker.WorkerState.VisitBank;           
        }
        if (FindObjectOfType<DayAndNightControl>().currentWorkerDaystate != DayAndNightControl.DaystateOut.Day &&
            !FindObjectOfType<Worker>().PocketsFull)
        {
            worker.newTargetPos = GameObject.FindGameObjectWithTag("houseTargetPos").transform.position;
            worker.currentWorkerState = Worker.WorkerState.GoHome;           
        }
        if(FindObjectOfType<Nugget>().IsOnGround && FindObjectOfType<Nugget>().CanPickUp)
        {
            worker.newTargetPos = GameObject.FindGameObjectWithTag("nuggetTargetPos").transform.position;
            worker.currentWorkerState = Worker.WorkerState.PickUpGold;
        }
        if (FindObjectOfType<Worker>().IsFatigue)
        {           
            worker.currentWorkerState = Worker.WorkerState.Rest;
        }        
    }

    // Update is called once per frame
    void Update()
    {
        

    }
}
