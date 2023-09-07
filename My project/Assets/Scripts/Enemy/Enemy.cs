using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent agent;

    GameObject player;

    GameObject target;

    public List<GameObject> patternTargets;
    public int patternNumber;

    public bool changePattern;
    // Start is called before the first frame update
    void Start()
    {
        patternNumber = 0;
        agent = this.GetComponent<NavMeshAgent>();
        target = patternTargets[patternNumber];
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.transform.position);
        if(agent.remainingDistance < 1f && !changePattern)
        {
            changePattern = true;
            patternNumber++;
            if (patternNumber >= patternTargets.Count)
            {
                patternNumber = 0;
            }
            target = patternTargets[patternNumber];
            
        }
        if(agent.remainingDistance < 2f && agent.remainingDistance > 1.5f)
        {
            changePattern = false;
        }

    }

}
