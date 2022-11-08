using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick_Link : MonoBehaviour
{

    public float speed = 100f;

    protected Joystick joystick;
    protected Rigidbody2D rigidbody;
    public static Joystick_Link Instance;


    // Start is called before the first frame update
    async void OnEnable()
    {
        Instance = this;
        if (Init.loading!=null) await Init.loading;
        joystick = Joystick.Instance;
        GameEvents.Pause += Pause;
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Global.pause)
        {
            var hori = Input.GetAxis("Horizontal");
            var verti = Input.GetAxis("Vertical");

            if (Rocks.sliding)
                rigidbody.velocity = new Vector2(hori * 6, verti * 6)
                                     + Vector2.down * Global.difficulty;
            else
                rigidbody.velocity = new Vector2(hori * 6, verti * 6);


            if (joystick.Horizontal != 0 || joystick.Vertical != 0)
            {
                if (Rocks.sliding)
                    rigidbody.velocity = new Vector2(joystick.Horizontal * speed, joystick.Vertical * speed)
                                         + Vector2.down * Global.difficulty;
                else
                    rigidbody.velocity = new Vector2(joystick.Horizontal * speed, joystick.Vertical * speed);
            }

            if (hori == 0 && verti == 0 && joystick.Horizontal == 0 && joystick.Vertical == 0 && Rocks.sliding)
                rigidbody.velocity = Vector2.down * Global.difficulty;
        }
    }

    /// <summary>
    /// met la vitesse du joueur
    /// </summary>
    public void setSpeed(float speed)
    {
        this.speed = speed;
    }

    /// <summary>
    /// récupère la position locale du joystick
    /// </summary>
    public Vector2 getPosition()
    {
        if (!Global.pause)
        {
            if (joystick.Horizontal != 0 || joystick.Vertical != 0)
                return new Vector2(joystick.Vertical, joystick.Horizontal);

            else
            {
                var hori = Input.GetAxis("Horizontal");
                var verti = Input.GetAxis("Vertical");

                return new Vector2(verti, hori);
            }
        }
        else return new Vector2(0, 0);
    }

    void Pause()
    {
        enabled = !enabled;
    }
}
