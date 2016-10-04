using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    public static float speed = 0f;
    public static float idleSpeed = 0f;
    public static float moveSpeed = 6f;


    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) ||
            Input.GetKey(KeyCode.A))
        {
            MoveLure(Vector3.left);
            //transform.position += new Vector3.left.normalized * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow) ||
            Input.GetKey(KeyCode.D))
        {
            MoveLure(Vector3.right);
            //transform.position += new Vector3.right.normalized * speed * Time.deltaTime;

        }
        if (Input.GetKey(KeyCode.UpArrow) ||
            Input.GetKey(KeyCode.W))
        {
             MoveLure(Vector3.up);
             //transform.position += new Vector3.up.normalized * speed * Time.deltaTime;

        }
         if (Input.GetKey(KeyCode.DownArrow) ||
                Input.GetKey(KeyCode.S))
            {
                MoveLure(Vector3.down);
                //transform.position += new Vector3.down.normalized * speed * Time.deltaTime;
            }

        if (Input.GetKeyUp(KeyCode.R))
        {
            SceneManager.LoadScene("Phil");
        }

        //If no longer moving
        if (Input.GetKeyUp(KeyCode.UpArrow) ||
              Input.GetKeyUp(KeyCode.DownArrow) ||
              Input.GetKeyUp(KeyCode.LeftArrow) ||
              Input.GetKeyUp(KeyCode.RightArrow) ||
              Input.GetKeyUp(KeyCode.W) ||
              Input.GetKeyUp(KeyCode.A) ||
              Input.GetKeyUp(KeyCode.S) ||
              Input.GetKeyUp(KeyCode.D))
        {
            speed = idleSpeed;
        }

    }

        void MoveLure(Vector3 dir){
            speed = moveSpeed;
            transform.position += dir.normalized * speed * Time.deltaTime;
            //transform.position += new Vector3.u
            
            //transform.position = transform.position + new Vector3.dir.normalized * speed * Time.deltaTime;
        }
}