using UnityEngine;
using System.Collections;

public class FishMoves : MonoBehaviour {

    //declare state constants 
    //const tells the comp that values wont change
    private const int WAITING_ON_LURE = 0;
    private const int FOLLOWING_LURE = 1;
    private const int CAUGHT_ON_LURE = 2;
    

    //state variable to determine behavior
    private int state = WAITING_ON_LURE;

    private float fishLureSpeed = 5;
    private float fishRegSpeed = 5;

    private Transform lurePosition;
    int randomGen1;
    int randomGen2;

    public GameObject[] comps = new GameObject[1];

    // Use this for initialization
    void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {

        if (state == WAITING_ON_LURE)
        {
            //default state will swim around
            randomGen1 = Random.Range(-1, 2);
            randomGen2 = Random.Range(-1, 2);
            this.transform.position = Vector3.Lerp(this.transform.position, (this.transform.position + new Vector3(randomGen1 *fishRegSpeed, randomGen2 * fishRegSpeed, 0)), Time.deltaTime);


        } else if (state == FOLLOWING_LURE)
        {
            //a lure is within range, swim towards it

            this.transform.LookAt( lurePosition );
            this.transform.position += transform.forward * Time.deltaTime * fishLureSpeed;

        }else if (state == CAUGHT_ON_LURE)
        {

            //the fish caught on the lure, and is parented to it
            transform.position = lurePosition.position;
        }
	
	}

    //Trigger checks to see if lure is close enough to follow
    void OnTriggerEnter( Collider otherCollider) {
        // the lure comes close enough to the fish so it starts following
        if (otherCollider.CompareTag("Lure"))
        {
            //follow player

            state = FOLLOWING_LURE;
            lurePosition = otherCollider.transform;
            Debug.Log("fish being Lured");
        }

        if (otherCollider.CompareTag("Goal"))
        {
            this.comps[0].SetActive(enabled);
            Destroy(this.gameObject);
        }



    }

    void OnTriggerStay(Collider otherCollider)
    {
        // the lure comes close enough to the fish so it starts following
        if (otherCollider.CompareTag("Lure"))
        {
            //follow player

            state = FOLLOWING_LURE;
            lurePosition = otherCollider.transform;
            Debug.Log("fish being Lured");
        }


    }

    void OnTriggerExit ()
    {
        state = WAITING_ON_LURE;
    }

    void OnCollisionEnter( Collision collisionData) {
        if (collisionData.gameObject.name == "Lure")
        {
            state = CAUGHT_ON_LURE;
            lurePosition = collisionData.transform;
            //this.gameObject.transform.position = lurePosition.position;
            

        }
       

    }
}
