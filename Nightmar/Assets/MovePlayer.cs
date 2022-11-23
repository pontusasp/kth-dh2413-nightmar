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

    public float maxSpeed;
    public float sensitivity;
    public Rigidbody head;

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
        if (Input.GetKey(KeyCode.Escape))
        {
            Debug.Log("asd22");
            Application.Quit();
            Debug.Log("asd22");
        }
    }
}
