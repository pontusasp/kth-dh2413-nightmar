using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyPickup : MonoBehaviour
{

    public GameObject keyCountStorer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "key")
        {
            Debug.Log("Picked up key");
            collider.gameObject.SetActive(false);
            ParticleSystem particles = collider.gameObject.transform.parent.gameObject.GetComponentInChildren<ParticleSystem>();
            particles.Stop();
            keyCountStorer.transform.position += Vector3.forward;
        }
    }
}
