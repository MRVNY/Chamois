using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
 /// <summary>
/// classe de base pour controller un joueur
/// </summary>
public class Joueur : MonoBehaviour
{
    [Header("Vitesse de déplacement")]
    public float vitesse;

    [Header("Caméra du personnage")]

    [Header("Zoom Caméra si un évennement est appelé")]
    //zoom de la camera si et ssi un bouton est appuyé
    public float zoomSize;

    [Header("position de la caméra devant le joueur si cette valeur > 0")]
    public float inFrontOf;

    [Header("Champ de vision")]
    public float champ_de_vision;
    public CircleCollider2D champ_de_vision_collider;

    [Header("Animator")]
    public Animator animator;
    public Animator animatorOmbre;

    protected Rigidbody2D rb2d = new Rigidbody2D();
    protected GameObject playerManager;


    protected float time;
    protected Joystick_Link joystick;
    protected CameraControllerJoy camerascript;

    ///<summary>
    ///position x et y du joystick sur sa position locale
    ///</summary>
    protected Vector2 v;

    protected float currentSpeed;

    protected bool lockPosition = false;

    public static Joueur currentPlayer;

    private void OnEnable()
    {
        currentPlayer = this;
    }

    protected void Start()
    {
        GameEvents.Pause += Pause;

        camerascript = GOPointer.CameraReg.GetComponentInChildren<CameraControllerJoy>();
        joystick = gameObject.GetComponent<Joystick_Link>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();

        camerascript.infrontOf = inFrontOf;
        //champ_de_vision_collider.radius = champ_de_vision;
    }


    protected void Update()
    {
        v = joystick.getPosition();

        if (lockPosition)
        {
            currentSpeed = 0.0f;
        }
        else
            // calcul de la vitesse du joueur en fonction du joystick
            currentSpeed = Mathf.Clamp(v.magnitude, 0.0f, 1.0f);

        Animate();
        joystick.setSpeed(currentSpeed * vitesse);
    }

    /// <summary>
    /// mise en pause du script
    /// </summary>
    protected void Pause()
    {
        enabled = ! enabled;
    }


    /// <summary>
    /// Animations du joueur
    /// </summary>
    void Animate()
    {
        if (v != Vector2.zero)
        {
            animator.SetFloat("Horizontal", v.y);
            animator.SetFloat("Vertical", v.x);
        }
        animator.SetFloat("Speed", currentSpeed);
        
        if (Global.Personnage == "Chamois")
        {
            if (v != Vector2.zero)
            {
                animatorOmbre.SetFloat("Horizontal", v.y);
                animatorOmbre.SetFloat("Vertical", v.x);
            }
            animatorOmbre.SetFloat("Speed", currentSpeed);
        }
    }
}
