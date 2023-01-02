using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attachVel : MonoBehaviour
{

    Animator anim;
    Rigidbody rig;

    public float vx = 0;
    public float vy = 0;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("VelX", rig.velocity.x);
        anim.SetFloat("VelY", rig.velocity.z);
        vx = rig.velocity.x;
        vy = rig.velocity.z;
    }
}
