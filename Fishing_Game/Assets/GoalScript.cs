using UnityEngine;
using System.Collections;

public class GoalScript : MonoBehaviour {

    public GameObject[] CollectOrStill = new GameObject[2];
    public GameObject CollectAllText;
    public GameObject NotCollectedInTime;


    int fishCounter = 0;
    float timeLeft = 160f;

    // Use this for initialization
    void Start () {
        CollectAllText = CollectOrStill[0];
        NotCollectedInTime = CollectOrStill[1];
    }
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0)
        {
            NotCollectedInTime.SetActive(enabled);
        }

        if (fishCounter >= 15)
        {
            //covers everything, tells you to press "r" to restart scene
            CollectAllText.SetActive(enabled);
        }
    }

    void OnTriggerEnter(Collider otherCollider)
    {
        // the lure comes close enough to the fish so it starts following
        if (otherCollider.CompareTag("Fish"))
        {
            //add to counter and reset timer
            fishCounter += 1;
            timeLeft = 160f;
        }

    }

}
