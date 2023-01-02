using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class MovePlayer : MonoBehaviour
{
    public SteamVR_Action_Boolean moveValueNorth;
    public SteamVR_Action_Boolean moveValueWest;
    public SteamVR_Action_Boolean moveValueEast;
    public SteamVR_Action_Boolean moveValueSouth;

    public bool mvN;
    public bool mvW;
    public bool mvE;
    public bool mvS;

    public Animator anim;
    public Transform manTransform;
    public Transform lookHandler;

    public float maxSpeed;
    public float sensitivity;
    public Rigidbody head;

    private bool gameIsPaused = false;
    private float speed = 0.0f;

    // Update is called once per frame
    void Update()
    {
        mvN = moveValueNorth.lastState;
        mvW = moveValueWest.lastState;
        mvE = moveValueEast.lastState;
        mvS = moveValueSouth.lastState;


        if (mvN)
        {
            Vector3 dir = Player.instance.hmdTransform.TransformDirection(Vector3.forward);
            speed = sensitivity;
            transform.position += speed * Time.deltaTime * Vector3.ProjectOnPlane(dir, Vector3.up);
        }

        if (mvW)
        {
            Vector3 dir = Player.instance.hmdTransform.TransformDirection(Vector3.left);
            speed = sensitivity;
            transform.position += speed * Time.deltaTime * Vector3.ProjectOnPlane(dir, Vector3.up);
        }

        if (mvE)
        {
            Vector3 dir = Player.instance.hmdTransform.TransformDirection(Vector3.right);
            speed = sensitivity;
            transform.position += speed * Time.deltaTime * Vector3.ProjectOnPlane(dir, Vector3.up);
        }

        if (mvS)
        {
            Vector3 dir = Player.instance.hmdTransform.TransformDirection(Vector3.back);
            speed = sensitivity;
            transform.position += speed * Time.deltaTime * Vector3.ProjectOnPlane(dir, Vector3.up);
        }

        if (Input.GetKey(KeyCode.F))
        {
            Debug.Log("asd2");
            Application.Quit();
            Debug.Log("asd2");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // TODO: add UI when game is paused
            if (gameIsPaused)
            {
                
                Time.timeScale = 1;
                gameIsPaused = false;
                Debug.Log("Paused game");
            }
            else
            {
                Time.timeScale = 0;
                gameIsPaused = true;
                Debug.Log("Unpaused game");
            }
        }

        Vector3 dirA = Player.instance.hmdTransform.TransformDirection(Vector3.forward);
        //manTransform.LookAt(new Vector3(0,Mathf.Atan2(dirA.y, dirA.x), 0));
        //manTransform.LookAt(dirA);
        manTransform.LookAt(lookHandler);
        float dirX = 0, dirY = 0;
        if (mvN)
        {
            dirX = 1;
        }
        if (mvS)
        {
            dirX = -1;
        }
        if (mvW)
        {
            dirY = 1;
        }
        if (mvE)
        {
            dirY = -1;
        }

        if ((mvE || mvN || mvW || mvS))
        {
            anim.SetFloat("VelX", (dirY)*0.7f);
            anim.SetFloat("VelY", (dirX)*0.7f);
        }
        else
        {
            anim.SetFloat("VelX", 0);
            anim.SetFloat("VelY", 0);
        }
    }
    
    void OnGUI()
    {
        if ( gameIsPaused )
        {
            GUI.Label( new Rect( 10.0f, 10.0f, 600.0f, 400.0f ),
                "Game is paused");
        }
    }
}