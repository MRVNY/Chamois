using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick_Link : MonoBehaviour
{

    public float speed = 100f;

    public GameObject gm;
    protected Joystick joystick;
    // Start is called before the first frame update
    void Start()
    {
        joystick = gm.GetComponent<Joystick>();
        GameEvents.Pause += Pause;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Global.pause)
        {
            var rigidbody = GetComponent<Rigidbody2D>();

            var hori = 0;
            var verti = 0;
            if (Input.GetKey("up")) verti = 1;
            if (Input.GetKey("down")) verti = -1;
            if (Input.GetKey("left")) hori = -1;
            if (Input.GetKey("right")) hori = 1;

            if (Global.sliding)
                rigidbody.velocity = new Vector2(hori * 6, verti * 6)
                                     + Vector2.down * Global.difficulty;
            else
                rigidbody.velocity = new Vector2(hori * 6, verti * 6);


            if (joystick.Horizontal != 0 || joystick.Vertical != 0)
            {
                if (Global.sliding)
                    rigidbody.velocity = new Vector2(joystick.Horizontal * speed, joystick.Vertical * speed)
                                         + Vector2.down * Global.difficulty;
                else
                    rigidbody.velocity = new Vector2(joystick.Horizontal * speed, joystick.Vertical * speed);
            }

            if (hori == 0 && verti == 0 && joystick.Horizontal == 0 && joystick.Vertical == 0 && Global.sliding)
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
                var hori = 0;
                var verti = 0;
                if (Input.GetKey("up")) verti = 1;
                if (Input.GetKey("down")) verti = -1;
                if (Input.GetKey("left")) hori = -1;
                if (Input.GetKey("right")) hori = 1;

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
