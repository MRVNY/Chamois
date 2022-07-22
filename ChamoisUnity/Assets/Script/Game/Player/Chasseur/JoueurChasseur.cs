using UnityEngine;


public class JoueurChasseur : Joueur
{

    [Header("Tir du chasseur")]
    public GameObject crosshair;
    public GameObject bullet;
    public float bulletForce = 20f;
    public float vision;

    float basePositionX;
    float basePositionY;

    Vector2 center;

    /// angle de visée
    float _angle;
    float rotateSpeed = 5f;
    float radius = 0.1f;

    bool firemode = false;

    Renderer crossSprite;
    /// <summary>
    /// bouton qui permet le tir
    /// </summary>
    GameObject pew;
    Munitions munitions;

    public DataStorerChasseur dataStorer = new DataStorerChasseur();

    new void Start()
    {
        base.Start();
        munitions = gameObject.GetComponent<Munitions>();
        crossSprite = crosshair.GetComponent<Renderer>();
        crossSprite.enabled = false;
        pew = GOPointer.Pew;
        pew.SetActive(false);
    }

    new void Update()
    {
        base.Update();
        Aim();
    }

    /// <summary>
    /// fonction qui permet la visée du joueur
    /// </summary>
    void Aim()
    {
        if (v != Vector2.zero)
        {
            crosshair.transform.localPosition = new Vector2(v.y * 10, v.x * 10);
            center = crosshair.transform.localPosition;
        }
            _angle += rotateSpeed * Time.deltaTime;
            Vector2 offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * radius;
            crosshair.transform.localPosition = center + offset;
    }


    /// <summary>
    /// fonction qui permet le tir du joueur
    /// </summary>
    public void shoot()
    {
        Vector2 shootDirection = crosshair.transform.localPosition;
        shootDirection.Normalize();

        // création d'une balle
        GameObject b = Instantiate(bullet, transform.position, Quaternion.identity);
        // direction de la balle
        b.GetComponent<Rigidbody2D>().velocity = shootDirection * bulletForce;
        b.transform.Rotate(0,0, Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg);

        //camerascript.Shake(0.1f, 0.2f);
        camerascript.CameraRecoil(crosshair.transform.localPosition);
        munitions.perdUneBalle();

        if (!munitions.aDesMunitions())
        {
            PewPewMode();
            GameObject.Find("Boutons/ModePewPew").SetActive(false);
        }
        if (PlayerPrefs.GetInt("soundEffects") == 1)
        {
            GOPointer.Pew.GetComponent<AudioSource>().Play();
        }
    }

    /// <summary>
    /// active/ désactive le mode tir
    /// </summary>
    public void PewPewMode()
    {
        firemode = !firemode;

        lockPosition = !lockPosition;
        if (firemode)
        {
            crossSprite.enabled = true;
            pew.SetActive(true);
            camerascript.setZoom(zoomSize);
            camerascript.infrontOf = vision;
        }
        else
        {
            camerascript.setZoom(-zoomSize);
            camerascript.infrontOf = inFrontOf;
            Joystick_Link.Instance.setSpeed(vitesse);
            crossSprite.enabled = false;
            pew.SetActive(false);
        }
    }
}
