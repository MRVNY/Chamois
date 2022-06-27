using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

//Move between patrol points
public class Patrol : wolf
{

    [FormerlySerializedAs("path")] public Transform[] patrolPoints;
    public float roundingDistance;
    
    private int currentPoint = 0;
    private Transform currentGoal;
    
    bool patrolling = false;

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
            if (Vector3.Distance(transform.position, patrolPoints[currentPoint].position) > roundingDistance)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, patrolPoints[currentPoint].position, moveSpeed / 2 * Time.deltaTime);
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
        //Enemy chases the target
            if (Vector3.Distance(target.position,
                            transform.position) <= chaseRadius
            && Vector3.Distance(target.position,
                            transform.position) > attackRadius)
            {
                if (patrolling)
                {
                    pathVectorList = Pathfinding.Instance.FindPath(transform.position, target.position);
                    currentPathIndex = 0;
                    
                    if (pathVectorList != null && pathVectorList.Count > 1) {
                        pathVectorList.RemoveAt(0);
                    }
                    patrolling = false;
                }
                
                if (currentState == EnemyState.idle || currentState == EnemyState.walk)
                {
                    Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);


                    ChangeAnim(temp - transform.position);
                    myRigidbody.MovePosition(temp);
                }

            }
            // Enemy patrols
            else if (Vector3.Distance(target.position, transform.position) > chaseRadius)
            {   
                if (patrolPoints == null || pathVectorList==null || !patrolling)
                {
                    ChangeGoal();
                    patrolling = true;
                }
                
                if(pathVectorList[pathVectorList.Count-1]!=patrolPoints[currentPoint].position)
                {
                    pathVectorList.Add(patrolPoints[currentPoint].position);
                }
                
                // Enemy is walking towards current patrol point
                if (Vector3.Distance(transform.position, patrolPoints[currentPoint].position) > roundingDistance)
                {
                    if (Vector3.Distance(transform.position, pathVectorList[currentPathIndex]) <= 10)
                    {
                        currentPathIndex++;
                        //print("next point");
                    }
                    
                    if(currentPathIndex >= pathVectorList.Count)
                    {
                        ChangeGoal();
                    }

                    Vector3 temp = Vector3.MoveTowards(transform.position, pathVectorList[currentPathIndex], moveSpeed * Time.deltaTime);
                    
                    ChangeAnim(temp - transform.position);
                    myRigidbody.MovePosition(temp);
                    //currentPathIndex++;
                    //print(Vector3.Distance(transform.position, patrolPoints[currentPoint].position));

                    //if (Vector3.Distance(temp, transform.position) <= 1) currentPathIndex++;
                }
                // Enemy reaches the current patrol point, it changes his patrol point
                else
                {
                    ChangeGoal();
                }
            }        
    }

    private void ChangeGoal()
    {
        int nouveau = Random.Range(0, patrolPoints.Length);

        while (nouveau == currentPoint)
        {
            nouveau = Random.Range(0, patrolPoints.Length);
        }

        currentPoint = nouveau;
        currentGoal = patrolPoints[nouveau];
        
        pathVectorList = Pathfinding.Instance.FindPath(transform.position, currentGoal.position);
        currentPathIndex = 0;

        if (pathVectorList is { Count: > 1 }) {
            pathVectorList.RemoveAt(0);
        }


        if (pathVectorList != null) {
            for (int i=0; i<pathVectorList.Count - 1; i++) {
                Debug.DrawLine(pathVectorList[i], pathVectorList[i+1], Color.red, 100f);
            }
        }
        
    }
}
