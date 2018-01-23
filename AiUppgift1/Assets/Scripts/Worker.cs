using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : WorkerEntity
{   
       
    public Vector3 newTargetPos;
    public enum WorkerState
    {
        MineGold,
        PickUpGold,
        VisitSaloon,
        GoHome,
        VisitBank,
        Rest
    }
    public WorkerState currentWorkerState;

    // Use this for initialization
    void Start()
    {
        Fatigue = 100;
        Health = 100;
        Thirst = 100;
        BankAccount = 0;
        GoldCounter = 0;
    }   

    public void WorkerUpdate()
    {
        GameObject.FindObjectOfType<SwitchStates>().StateChanger(this, GameObject.FindObjectOfType<Bank>(), GameObject.FindObjectOfType<Nugget>());
        switch (currentWorkerState)
        {
            case WorkerState.MineGold:
                FindObjectOfType<WorkerStates>().MoveTo(gameObject, newTargetPos);
                FindObjectOfType<WorkerStates>().MiningGold(gameObject, newTargetPos);
                break;
            case WorkerState.PickUpGold:
                FindObjectOfType<WorkerStates>().MoveTo(gameObject, newTargetPos);
                FindObjectOfType<WorkerStates>().PickUpGold(gameObject, newTargetPos);
                break;
            case WorkerState.VisitSaloon:
                FindObjectOfType<WorkerStates>().MoveTo(gameObject, newTargetPos);
                FindObjectOfType<WorkerStates>().GoToSaloon(gameObject, newTargetPos);
                break;
            case WorkerState.GoHome:
                FindObjectOfType<WorkerStates>().MoveTo(gameObject, newTargetPos);
                break;
            case WorkerState.VisitBank:
                FindObjectOfType<WorkerStates>().MoveTo(gameObject, newTargetPos);
                FindObjectOfType<WorkerStates>().GoToBank(gameObject, newTargetPos);
                break;
            case WorkerState.Rest:
                FindObjectOfType<WorkerStates>().Rest(gameObject, newTargetPos);
                break;
            default:
                break;
        }
    }
    
}
