using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FakeAi : MonoBehaviour
{
    //AI
    NavMeshAgent agent = null;
    public GameObject TargetPoint = null;


    //Raycast
    public float dist = 10;
    public LayerMask mask = 0;

    GameObject hitTarget = null;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        hitTarget = TargetPoint;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(TargetPoint.transform.position);
    }
}
