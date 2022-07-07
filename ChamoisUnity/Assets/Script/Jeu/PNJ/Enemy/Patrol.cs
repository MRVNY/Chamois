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
        //Enemy chases the target
        Vector3 pivot = transform.position - distToBottom;

        if (Vector3.Distance(target.position, pivot) <= chaseRadius
            && Vector3.Distance(target.position, pivot) > attackRadius)
        {
            if (patrolling)
            {
                pathVectorList = GOPointer.Pathfinding.FindPath(pivot, target.position);
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
        Vector3 pivot = transform.position - distToBottom;
        if (patrolPoints == null || pathVectorList == null || pathVectorList.Count == 0 || !patrolling)
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
                    //print("next point");
                }

                if (currentPathIndex >= pathVectorList.Count)
                {
                    ChangeGoal();
                }

                Vector3 temp;
                if (pathVectorList == null || pathVectorList.Count == 0)
                {
                    temp = transform.position;
                }
                else
                {
                    temp = Vector3.MoveTowards(transform.position,
                        pathVectorList[currentPathIndex] + distToBottom,
                        moveSpeed * 4 * Time.deltaTime);
                }

                ChangeAnim(temp - transform.position);
                myRigidbody.MovePosition(temp);
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


    private void ChangeGoal()
    {
        //Debug.Log("ChangeGoal "+ name);
        Vector3 pivot = transform.position - distToBottom;

        int nouveau = Random.Range(0, patrolPoints.Length);

        while (nouveau == currentPoint)
        {
            nouveau = Random.Range(0, patrolPoints.Length);
        }

        currentPoint = nouveau;
        currentGoal = patrolPoints[nouveau];
        
        pathVectorList = GOPointer.Pathfinding.FindPath(pivot, currentGoal.position);
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
