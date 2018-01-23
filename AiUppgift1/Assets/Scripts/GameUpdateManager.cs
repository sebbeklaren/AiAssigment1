using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUpdateManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        FindObjectOfType<Worker>().WorkerUpdate();
        FindObjectOfType<Nugget>().ReleaseNugget();
        FindObjectOfType<BoolChecks>().CheckFatigue();
        FindObjectOfType<BoolChecks>().CheckThirst();
        FindObjectOfType<BoolChecks>().CheckPockets();
    }
}
