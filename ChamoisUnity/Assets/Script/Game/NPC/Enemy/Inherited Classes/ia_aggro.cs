using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enumère tous les états que peut prendre le loup
/// </summary>
public enum EnemyState
{
    idle,
    walk,
    attack,
    stagger,
}

/// <summary>
/// Classe <c>ia_aggro</c> du prédateur
/// Cette classe gère les paramètres de base d'un type "ia_aggro"
/// </summary>
public class ia_aggro : MonoBehaviour
{
    /// <summary>
    /// Etat courant du PnJ
    /// </summary>
    public EnemyState currentState;
    public int health;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;


}
