using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterScript : MonoBehaviour
{
    // Variables for monster navigation
    
    public GameObject[] checkpoints;
    public bool randomPathing = true;
    public float stoppingDelaySeconds = 2;
    private bool startedCoroutine = false;

    private NavMeshAgent agent;

    // Variables for player detection
    public float mRaycastRadius = 2;                // width of our line of sight (x-axis and y-axis)
    private int currentDestination;
    public float mTargetDetectionDistance = 8;      // depth of our line of sight (z-axis)
    private RaycastHit _mHitInfo;               // allocating memory for the raycasthit to avoid Garbage
    private bool _bHasDetectedEnnemy = false;   // tracking whether the player is detected to change color in gizmos
    //[SerializeField] private LayerMask layerMask;
    void Start()
    {
        //mRaycastRadius = 2;
        //mTargetDetectionDistance = 8;
        this.agent = GetComponent<NavMeshAgent>();
        this.currentDestination = 0;
        agent.destination = checkpoints[currentDestination].transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        _bHasDetectedEnnemy = CheckForTargetInLineOfSight();
        if (_bHasDetectedEnnemy)
        {
            if (_mHitInfo.transform.CompareTag("Player"))
            {
                Debug.Log("Detected Player");
                agent.destination = _mHitInfo.transform.position;
            }
            else if (!agent.pathPending && agent.remainingDistance < 0.5f && !startedCoroutine)
            {
                StartCoroutine(goToNext());
                startedCoroutine = true;
            }
        }
        else
        {
            if (!agent.pathPending && agent.remainingDistance < 0.5f && !startedCoroutine)
            {
                StartCoroutine(goToNext());
                startedCoroutine = true;
            }
        }


    }

    IEnumerator goToNext()
    {
        yield return new WaitForSeconds(stoppingDelaySeconds);
       
        // go to next destination
        if (!randomPathing) currentDestination = (currentDestination + 1) % checkpoints.Length;
        // go to random destination
        else currentDestination = Random.Range(0, checkpoints.Length);

        agent.destination = checkpoints[currentDestination].transform.position;

        startedCoroutine = false;
    }
    // player detection
    public bool CheckForTargetInLineOfSight()
    {
        return Physics.SphereCast(transform.position, mRaycastRadius, transform.forward, out _mHitInfo, mTargetDetectionDistance);//, layerMask);

    }

    private void OnDrawGizmos()
    {
        if (_bHasDetectedEnnemy)
        {
            Gizmos.color = Color.red;
        }
        else
        {
            Gizmos.color = Color.green;
        }

        Gizmos.matrix = transform.localToWorldMatrix;

        Gizmos.DrawCube(new Vector3(0f, 0f, mTargetDetectionDistance / 2f), new Vector3(mRaycastRadius, mRaycastRadius, mTargetDetectionDistance));
    }
}
