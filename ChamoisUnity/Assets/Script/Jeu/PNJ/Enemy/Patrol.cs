using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Move between patrol points
public class Patrol : wolf
{
    public Transform[] path;
    public float roundingDistance;
    
    private int currentPoint = 0;
    private Transform currentGoal;

    public override void CheckDistanceFuite()
    {
        if (Vector3.Distance(target.position,
                               transform.position) <= chaseRadius
               && Vector3.Distance(target.position,
                               transform.position) > attackRadius)
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, -moveSpeed * Time.deltaTime);


                ChangeAnim(temp - transform.position);
                myRigidbody.MovePosition(temp);
            }

        }
        else if (Vector3.Distance(target.position, transform.position) > chaseRadius)
        {
            if (Vector3.Distance(transform.position, path[currentPoint].position) > roundingDistance)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, path[currentPoint].position, moveSpeed / 2 * Time.deltaTime);
                ChangeAnim(temp - transform.position);
                myRigidbody.MovePosition(temp);
            }
            else
            {
                ChangeGoal();
            }
        }
    }

    public override void CheckDistanceAttaque()
    {
            if (Vector3.Distance(target.position,
                            transform.position) <= chaseRadius
            && Vector3.Distance(target.position,
                            transform.position) > attackRadius)
            {
                if (currentState == EnemyState.idle || currentState == EnemyState.walk)
                {
                    Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);


                    ChangeAnim(temp - transform.position);
                    myRigidbody.MovePosition(temp);
                }

            }
            else if (Vector3.Distance(target.position, transform.position) > chaseRadius)
            {
                if (Vector3.Distance(transform.position, path[currentPoint].position) > roundingDistance)
                {
                    Vector3 temp = Vector3.MoveTowards(transform.position, path[currentPoint].position, moveSpeed / 2 * Time.deltaTime);
                    ChangeAnim(temp - transform.position);
                    myRigidbody.MovePosition(temp);
                }
                else
                {
                    ChangeGoal();
                }
            }        
    }

    private void ChangeGoal()
    {
        int nouveau = Random.Range(0, path.Length);

        while (nouveau == currentPoint)
        {
            nouveau = Random.Range(0, path.Length);
        }

        currentPoint = nouveau;
        currentGoal = path[nouveau];
    }
}
