

//INT, PARSONS D12, DAY
//TWO GAME DESIGNERS SIT AT A CRAMPED TABLE
//ROHIL: HOW TO FUCK AM I GOING TO MAKE A FISHING GAME???
//EDGAR: LIKE THIS.
//SWEET CHILD O MINE GUNS N' ROSES BEGINS TO PLAY
//BOTH EDGAR AND ROHIL PUT ON THEIR SUNGLASSES
//THEY CREATE THIS SCRIPT.

using UnityEngine;
using System.Collections;

public class FishSticks : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //EDGAR: FIRST THINGS FIRST, WE NEED TO ADD A NEW FUNCTION BELOW
    void FishStickToRod()
    {
        GameObject Rod = GameObject.Find("Rod").gameObject;
        this.gameObject.transform.parent = Rod.transform;
       
    }

    //EDGAR: THERES... ... *DRAMATIC PAUSE*... AN ERROR...
    //ROHIL: Fixed it. 
    //EDGAR: Yep!

    void OnCollisionEnter(Collision hit)
    {

        if (hit.gameObject.GetComponent<Rigidbody>() != null)
        {
            gameObject.AddComponent<FixedJoint>();
            gameObject.GetComponent<FixedJoint>().connectedBody = hit.gameObject.GetComponent<Rigidbody>();
        }
        Debug.Log("Touching Rod");



        //ROHIL: THIS IS MAD DOPE DUDE, BUT I'M SUPER FUCKING CONFUSED??? 

        //EDGAR:
        //Okay, so what we're doing is, if the fish touched the Rod, which is detected in OnTrigger, 
        //then it runs code to stick to the rod. We couldve written it inside Ontrigger 
        //where we call the FishStickToRod function but to organize and re-use it for future reference, we made a function

        // ROHIL: GOT IT.
    }

}

