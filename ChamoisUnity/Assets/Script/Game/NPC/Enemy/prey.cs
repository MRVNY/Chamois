using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe <c>prey</c> du prédateur
/// Cette classe gère le mouvement d'uen proie
/// </summary>
public class prey : ia_aggro
{
    private Rigidbody2D myRigidbody;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;
    private Animator animator;

    // Start is called before the first frame update
    async void Start()
    {
        if (Init.loading!=null) await Init.loading;
        currentState = EnemyState.idle;
        myRigidbody = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
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
        if (Global.Personnage == "Chasseur" || Global.Personnage == "Randonneur") 
        {
            CheckDistance();
        }
    }

    /// <summary>
    /// Fonction permettant à la proie de fuir le joueur s'il est présent dans son rayon de fuite
    /// </summary>
    void CheckDistance()
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


    /// <summary>
    /// Change l'état de la proie
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
