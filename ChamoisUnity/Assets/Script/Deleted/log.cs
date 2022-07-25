using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class log : ia_aggro
{

    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        currentState = EnemyState.idle;
        animator = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform; 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckDistance();
    }

    void CheckDistance()
    {
        if(Vector3.Distance(target.position, transform.position) <= chaseRadius)
        {
            if(currentState == EnemyState.idle || currentState == EnemyState.walk) {
                transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                ChangeState(EnemyState.walk);
            }   

        }
    }

    private void ChangeState(EnemyState newState)
    {
        if(currentState != newState)
        {
            currentState = newState;
        }
    }
}
