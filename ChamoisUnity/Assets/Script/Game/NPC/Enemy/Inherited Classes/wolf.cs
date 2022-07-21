using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// Classe <c>wolf</c> du prédateur
/// Cette classe gère le mouvement du predateur
/// </summary>
public class wolf : ia_aggro
{
    protected List<Vector3> pathVectorList;
    protected int currentPathIndex;
    
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;
    
    protected Rigidbody2D myRigidbody;
    protected Transform target;
    protected Animator animator;
    protected Vector3 distToBottom;

    protected int timeout = 0;
    protected Vector3 lastPosition;

    // Start is called before the first frame update
    async void Start()
    {
        if (Init.loading!=null) await Init.loading;

        currentState = EnemyState.idle;
        myRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        target = GOPointer.currentPlayer.transform;

        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if(sprite != null)
        {
            distToBottom = new Vector3(0,sprite.bounds.extents.y,0);
            //Debug.DrawLine(transform.position - new Vector3(0,distToBottom,0),transform.position,Color.blue,10f);
        }
        else
        {
            distToBottom = Vector3.zero;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.timeScale>0 && (target.position - transform.position).magnitude < 100)
        {
            switch (Global.Personnage)
            {
                case "Chamois":
                    CheckDistanceAttaque();
                    break;
                case "Chasseur":
                case "Randonneur":
                    CheckDistanceFuite();
                    break;
            }
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
                
                
                ChangeAnim(temp - transform.position);
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


                ChangeAnim(temp - transform.position);
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
        if(direction.x == 0 && direction.y == 0)
        {
            animator.SetBool("Moving", false);
        }
        else
        {
            animator.SetBool("Moving", true);
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
