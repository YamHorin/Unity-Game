using UnityEngine;
using UnityEngine.AI;
public class carBehavior : MonoBehaviour
{
    public GameObject target;
    NavMeshAgent agent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.transform.position);


    }
}
