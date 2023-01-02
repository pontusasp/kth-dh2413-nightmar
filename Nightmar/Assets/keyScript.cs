using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyScript : MonoBehaviour
{
    public GameObject keyObject;
    public GameObject playerBody;
    private float inityPos;
    void Start()
    {
        float inityPos = transform.position.y;
    }
    [SerializeField] [Range(0,1)] float speed = 0.15f;
    [SerializeField] [Range(0,100)] float range = 0.4f; 

    void Update()
    {
        
        loop();
        
    }

    void loop()
    {
        float yPos = Mathf.PingPong(Time.time * speed, 1) * range;
        keyObject.transform.position = new Vector3(keyObject.transform.position.x, yPos+0.5f, keyObject.transform.position.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == playerBody)
        {   
            Debug.Log("keycollected");
            //keychain.GetComponent<keyManager>().increment();
            keyObject.SetActive(false);
            
            
        }
    }
 }
