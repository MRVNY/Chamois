using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe <c>wolf</c> du prédateur
/// Cette classe gère le mouvement du predateur
/// </summary>
public class wolf : ia_aggro
{
    public Rigidbody2D myRigidbody;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        currentState = EnemyState.idle;
        myRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        switch (Global.Personnage)
        {
            case "Chasseur":
                target = GOPointer.PlayerChasseur.transform;
                break;

            case "Randonneur":
                target = GOPointer.PlayerRandonneur.transform;
                break;

            case "Chamois":
                target = GOPointer.PlayerChamois.transform;
                break;
            
            default:
                break;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Global.Personnage == "Chamois")
        {
            CheckDistanceAttaque();
        }
        if (Global.Personnage == "Chasseur")
        {
            CheckDistanceFuite();
        }
        if (Global.Personnage == "Randonneur")
        {
            CheckDistanceFuite();
        }
        
    }

    /// <summary>
    /// Fonction permettant au prédateur de se rapprocher du joueur s'il est présent dans son rayon de chasse
    /// </summary>
    public virtual void CheckDistanceAttaque()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius)
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                
                
                //ChangeAnim(temp - transform.position);
                myRigidbody.MovePosition(temp);
                ChangeState(EnemyState.walk);
            }

        }
    }
    
    /// <summary>
    /// Fonction permettant au prédateur de s'éloigner du joueur s'il est présent dans son rayon de chasse
    /// </summary>
    public virtual void CheckDistanceFuite()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius)
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, -moveSpeed * Time.deltaTime);


                //ChangeAnim(temp - transform.position);
                myRigidbody.MovePosition(temp);
                ChangeState(EnemyState.walk);
            }

        }
    }

    private void SetAnimFloat(Vector2 setVector)
    {
        animator.SetFloat("moveX", setVector.x);
        animator.SetFloat("moveY", setVector.y);
    }

    /// <summary>
    /// Permet le changement de l'animation du prédateur
    /// </summary>
    /// <param name="direction">Direction du joueur</param>
    public void ChangeAnim(Vector2 direction)
    {
        if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if(direction.x > 0)
            {
                SetAnimFloat(Vector2.right);
            }else if(direction.x < 0)
            {
                SetAnimFloat(Vector2.left);
            }

        }else if(Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            if (direction.y > 0)
            {
                SetAnimFloat(Vector2.up);
            }
            else if (direction.y < 0)
            {
                SetAnimFloat(Vector2.down);
            }
        }
    }
    /// <summary>
    /// Change l'état du "loup"
    /// </summary>
    /// <param name="newState">L'état voulu</param>
    private void ChangeState(EnemyState newState)
    {
        if (currentState != newState)
        {
            currentState = newState;
        }
    }
}
