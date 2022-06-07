using UnityEngine;

    /// <summary>
    /// CLasse pour controller la camera
    /// </summary>
public class CamMov : MonoBehaviour
{
    private Camera cam;
    
    //le joueur actuel
    GameObject player;
    GameObject[] players;

    //variable qui permet la décélération de la cam
    float decrease = 0.5f;

    //vitesse du momentum
    float speed = 0.1f;
    Vector3 momentum = Vector3.zero ;

    [Header("les limites du zoom de la caméra")]
    public float min = 3;
    public float max = 20; 

    [Header("les positions pour la bordure de la carte (à mettre quand la cam est zoom aux min")]
    public Vector2 minPos;
    public Vector2 maxPos;


    void Start()
    {
        cam = gameObject.GetComponent<Camera>();
        cam.enabled = false;

        enabled = false;    
        GameEvents.SwitchCamera += SwitchC;

        player = GameObject.Find("Players/Player" + Global.Personnage);
    }

    void Update()
    {

        // si le nombre de doigt posé sur l'écran est de deux on zoom
        if (Input.touchCount == 2)
        {
            Touch T0 = Input.GetTouch(0);
            Touch T1 = Input.GetTouch(1);

            zoom(T0, T1);
        }

        // si le nombre de doigt posé sur l'écran est supérieur à 0
        else if (Input.touchCount > 0)
        {
            touchMovement(Input.GetTouch(0));
        }

        // si il y a du momentum il faut décélérer
        if (momentum != Vector3.zero)
        {
            Vector3 pos = new Vector3(transform.position.x + momentum.x, transform.position.y + momentum.y, transform.position.z);

            //fonction à opti si possible
            pos = Boundaries(pos);

            transform.position = pos;
            momentum *= Mathf.Pow(decrease, Time.deltaTime);
        }

    }

    /// <summary>
    /// Zoom de la caméra avec la position des doigts
    /// </summary>
    /// <param name="T"> Touch qui est le doigt posé sur l'écran </param>
    void zoom(Touch T0, Touch T1)
    {
        Vector2 t0PreviousPos = T0.position - T0.deltaPosition;
        Vector2 t1PreviousPos = T1.position - T1.deltaPosition;

        float prevMagnitude = (t0PreviousPos - t1PreviousPos).magnitude;
        float currMagniture = (T0.position - T1.position).magnitude;

        float difference = (currMagniture - prevMagnitude) * 0.01f;

        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize - difference, min, max);
    }

    /// <summary>
    /// déplacement de la caméra avec le doigt
    /// </summary>
    /// <param name="T"> Touch qui est le doigt posé sur l'écran </param>
    void touchMovement(Touch T)
    {
        Vector2 vect = T.deltaPosition;
        transform.Translate(-vect.x * Time.deltaTime, -vect.y * Time.deltaTime, 0);
        momentum = -Input.GetTouch(0).deltaPosition * speed * (Time.deltaTime * 2);
    }

    /// <summary>
    /// vérifie si la caméra est aux bords de la carte, si oui, elle se bloque
    /// </summary>
    Vector3 Boundaries(Vector3 pos)
    {
        if (pos.x > maxPos.x)
        {
            pos.x = maxPos.x;
            momentum.x = 0;
        }
        if (pos.x < minPos.x)
        {
            pos.x = minPos.x;
            momentum.x = 0;
        }
        if (pos.y < maxPos.y)
        {
            pos.y = maxPos.y;
            momentum.y = 0;
        }
        if (pos.y > minPos.y)
        {
            pos.y = minPos.y;
            momentum.y = 0;
        }

        return pos;
    }

    /// <summary>
    /// switch de caméra et positionne le gameObject en fonction de la position du joueur
    /// </summary>
    void SwitchC()
    {
        enabled = !enabled;
        cam.enabled = !cam.enabled;
        transform.position = new Vector3(player.transform.position.x * 0.5f , player.transform.position.y * 0.5f ,-10);

        player.SetActive(!enabled);

        if (enabled == false)
        {
            momentum = new Vector3(0,0,0);
        }
    }

}
