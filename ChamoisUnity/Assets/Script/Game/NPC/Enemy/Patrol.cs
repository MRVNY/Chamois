using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

//Move between patrol points
public class Patrol : wolf
{

    [FormerlySerializedAs("path")] public Transform[] patrolPoints;
    public float roundingDistance;
    
    private int currentPoint = 0;
    private Transform currentGoal;
    
    bool patrolling = false;
    
    private Task<List<Vector3>> task;

    public override void CheckDistanceFuite()
    {
        checkTask();
        
        Vector3 pivot = transform.position - distToBottom;

        if (Vector3.Distance(target.position,
                               pivot) <= chaseRadius
               && Vector3.Distance(target.position,
                               pivot) > attackRadius)
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position + distToBottom, -moveSpeed * Time.deltaTime);


                ChangeAnim(temp - transform.position);
                myRigidbody.MovePosition(temp);
            }
        }
        else if (Vector3.Distance(target.position, pivot) > chaseRadius)
        {
            patrol();
        }
    }

    public override void CheckDistanceAttaque()
    {
        checkTask();
        
        //Enemy chases the target
        Vector3 pivot = transform.position - distToBottom;

        if (Vector3.Distance(target.position, pivot) <= chaseRadius
            && Vector3.Distance(target.position, pivot) > attackRadius)
        {
            if (patrolling)
            {
                //pathVectorList = GOPointer.Pathfinding.FindPath(pivot, target.position);
                checkTask();
                currentPathIndex = 0;

                if (pathVectorList != null && pathVectorList.Count > 1)
                {
                    pathVectorList.RemoveAt(0);
                }

                patrolling = false;
            }

            if (currentState == EnemyState.idle || currentState == EnemyState.walk)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position + distToBottom,
                    moveSpeed * Time.deltaTime);


                ChangeAnim(temp - transform.position);
                myRigidbody.MovePosition(temp);
            }
        }

        // Enemy patrols
        else if (Vector3.Distance(target.position, pivot) > chaseRadius)
        {
            patrol();
        }
    }

    void patrol()
    {
        if ((transform.position - lastPosition).magnitude < 0.01)
        {
            timeout++;
        }
        else
        {
            timeout = 0;
        }
        
        lastPosition = transform.position;
        
        Vector3 pivot = transform.position - distToBottom;
        if (patrolPoints == null 
            || (task!=null && task.IsCompleted && pathVectorList==null) 
            || (pathVectorList!=null && pathVectorList.Count == 0) 
            || !patrolling)
        {
            ChangeGoal();
            patrolling = true;
        }
        else
        {

            if (pathVectorList.Count > 0 &&
                pathVectorList[pathVectorList.Count - 1] != patrolPoints[currentPoint].position)
            {
                pathVectorList.Add(patrolPoints[currentPoint].position);
            }

            // Enemy is walking towards current patrol point
            if (Vector3.Distance(pivot, patrolPoints[currentPoint].position) > roundingDistance)
            {
                if (Vector3.Distance(pivot, pathVectorList[currentPathIndex]) <= 8.1)
                {
                    currentPathIndex++;
                    //timeout = 0;
                    //print("next point");
                }

                if (currentPathIndex >= pathVectorList.Count)
                {
                    ChangeGoal();
                    return;

                }
                
                Vector3 temp;
                if (pathVectorList == null || pathVectorList.Count == 0)
                {
                    //temp = transform.position;
                    temp = Vector3.MoveTowards(transform.position,
                        patrolPoints[currentPoint].position + distToBottom,
                        moveSpeed * 4 * Time.deltaTime);
                }
                else
                {
                    temp = Vector3.MoveTowards(transform.position,
                        pathVectorList[currentPathIndex] + distToBottom,
                        moveSpeed * 4 * Time.deltaTime);
                }

                ChangeAnim(temp - transform.position);
                myRigidbody.MovePosition(temp);

                // if (currentPathIndex > 1)
                // {
                //     print(name + " : " + Vector3.Distance(pivot, pathVectorList[currentPathIndex]) +" , "+
                //           Vector3.Distance(pivot, pathVectorList[currentPathIndex - 1]));
                // }

                // if (currentPathIndex > 1 && Vector3.Distance(pivot, pathVectorList[currentPathIndex]) >
                //     Vector3.Distance(pivot, pathVectorList[currentPathIndex - 1]))
                // {
                //     timeout++;
                // }
                // else{
                //     timeout = 0;
                // }
                //
                
                if (timeout > 100)
                {
                    timeout = 0;
                    ChangeGoal();
                }
                //currentPathIndex++;
                //print(Vector3.Distance(pivot, patrolPoints[currentPoint].position));

                //if (Vector3.Distance(temp, pivot) <= 1) currentPathIndex++;
            }
            // Enemy reaches the current patrol point, it changes his patrol point
            else
            {
                ChangeGoal();
            }
        }
    }

    void checkTask()
    {
        if (task!=null && task.IsCompleted && pathVectorList==null)
        {
            pathVectorList = task.GetAwaiter().GetResult();
            currentPathIndex = 0;

            if (pathVectorList is { Count: > 1 })
            {
                pathVectorList.RemoveAt(0);
            }


            if (pathVectorList != null)
            {
                for (int i = 0; i < pathVectorList.Count - 1; i++)
                {
                    Debug.DrawLine(pathVectorList[i], pathVectorList[i + 1], Color.red, 100f);
                }
            }
        }
    }

    private void ChangeGoal()
    {
        currentPathIndex = 0;
        pathVectorList = null;
        //Debug.Log("ChangeGoal "+ name);
        Vector3 pivot = transform.position - distToBottom;

        int nouveau = Random.Range(0, patrolPoints.Length);

        while (nouveau == currentPoint)
        {
            nouveau = Random.Range(0, patrolPoints.Length);
        }
        
        currentPoint = nouveau;
        currentGoal = patrolPoints[nouveau];
        
        task = Pathfinding.Instance.FindPath(pivot, currentGoal.position);
   
    }
}
