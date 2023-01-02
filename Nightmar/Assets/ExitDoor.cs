using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{

    public GameObject keyCountStorer;
    public GameObject particles;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (keyCountStorer.transform.position.z >= 4)
        {
            Debug.Log("Door opened");
            MeshRenderer mesh = gameObject.GetComponentInChildren<MeshRenderer>();
            mesh.enabled = false;
            particles.SetActive(true);
        }
    }
}
