using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitDoorPickup : MonoBehaviour
{

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "exitdoor")
        {
            Debug.Log("Game complete");
        }
    }
}
