using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerEntity : MonoBehaviour {


    private int fatigue, health, thirst, goldCounter, bankAccount;
    private bool isFatigue, pocketsFull, isThirsty;

    public int BankAccount { get { return bankAccount; } set { bankAccount = value; } }
    public int GoldCounter { get { return goldCounter; } set { goldCounter = value; } }
    public int Fatigue { get { return fatigue; } set { fatigue = value; } }
    public int Health { get { return health; } set { health = value; } }
    public int Thirst { get { return thirst; } set { thirst = value; } }

    public bool IsFatigue { get { return isFatigue; } set { isFatigue = value; } }
    public bool PocketsFull { get { return pocketsFull; } set { pocketsFull = value; } }
    public bool IsThirsty { get { return isThirsty; } set { isThirsty = value; } }

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
