using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookhandler : MonoBehaviour
{
    public Transform leftHand;
    public Transform rightHand;
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 vectorDirection = new Vector3(rightHand.position.x, rightHand.position.y, rightHand.position.z) - new Vector3(leftHand.position.x, leftHand.position.y, leftHand.position.z);
        vectorDirection /= 2;
        gameObject.transform.position = vectorDirection;
        gameObject.transform.position = new Vector3(leftHand.position.x, leftHand.position.y, leftHand.position.z)+vectorDirection;
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, 0, gameObject.transform.position.z);
    }
}
