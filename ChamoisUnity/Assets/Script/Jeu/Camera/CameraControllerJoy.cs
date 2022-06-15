using UnityEngine;


    /// <summary>
    /// classe pour controller la caméra du joueur
    /// </summary>
    public class CameraControllerJoy : MonoBehaviour
    {
        [Header("transform of player gameobject")]
        private Transform focus = null;

        public float smoothTime = 2;

        //public BoxCollider2D boundBox;
        private Vector3 minBounds;
        private Vector3 maxBounds;

        [Header("Joystick du joueur")]
        public GameObject gm;

        /// <summary>
        ///position de la caméra devant le joueur si cette valeur > 0
        /// </summary>
        public float infrontOf { private get; set;}

        Joystick joystick;
        Vector3 offset;

        // la nouvelle position de la caméra
        Vector3 position;
        private Camera cam;
        private float halfHeight;
        private float halfWidth;

        private float minX;
        private float maxX;
        private float minY;
        private float maxY;

        public Vector2 maxPosition;
        public Vector2 minPosition;


        // void Awake()
        // {
        //     if(Global.Personnage=="Chamois") focus = GOPointer.PlayerChamois.transform;
        //     else if(Global.Personnage=="Chasseur") focus = GOPointer.PlayerChasseur.transform;
        //     else if(Global.Personnage=="Randonndeur") focus = GOPointer.PlayerRandonneur.transform;
        //     
        //     transform.position = new Vector3(focus.position.x, focus.position.y, -10);
        //     //offset = focus.position - transform.position;
        // }

        void Start()
        {
            if(Global.Personnage=="Chamois") focus = GOPointer.PlayerChamois.transform;
            else if(Global.Personnage=="Chasseur") focus = GOPointer.PlayerChasseur.transform;
            else if(Global.Personnage=="Randonneur") focus = GOPointer.PlayerRandonneur.transform;
            
            transform.position = new Vector3(focus.position.x, focus.position.y, -10);
            offset = focus.position - transform.position;
            
            cam = gameObject.GetComponent<Camera>();
            joystick = gm.GetComponent<Joystick>();

            /*minX = GameObject.Find("TopLeft").GetComponent<Transform>().position.x;
            maxX = GameObject.Find("BotRight").GetComponent<Transform>().position.x;
            minY = GameObject.Find("BotRight").GetComponent<Transform>().position.y;
            maxY = GameObject.Find("TopLeft").GetComponent<Transform>().position.y;*/

    // mise en place de la fonction dans le gameEvent
    GameEvents.SwitchCamera += SwitchC;

            //minBounds = boundBox.bounds.min;
            //maxBounds = boundBox.bounds.max;
            //halfHeight = cam.orthographicSize;
            //halfWidth = halfHeight * Screen.width / Screen.height;
        }

        /*
            suite de commande qui va permettre à la caméra de suivre le joueur
        */
        void LateUpdate()
        {
            if (focus.position != transform.position)
            {
                position = focus.position - offset;

                position.x = Mathf.Clamp(position.x, minPosition.x, maxPosition.x);
                position.y = Mathf.Clamp(position.y, minPosition.y, maxPosition.y);

                position.x += joystick.Horizontal * infrontOf;
                position.y += joystick.Vertical * infrontOf;

                transform.position = Vector3.Lerp( transform.position, position, Time.deltaTime * smoothTime);
                //transform.position = Vector3.Lerp(Mathf.Clamp(transform.position.x, minX, maxX), Mathf.Clamp(transform.position.y, minY, maxY), Time.deltaTime * smoothTime);

                /*transform.position = new Vector3(
                    Mathf.Clamp(transform.position.x, minX, maxX),
                    Mathf.Clamp(transform.position.y, minY, maxY),
                    transform.position.z);*/

                //float clampedX = Mathf.Clamp(transform.position.x, minBounds.x + halfWidth, maxBounds.x - halfWidth);
                //float clampedY = Mathf.Clamp(transform.position.y, minBounds.y + halfHeight, maxBounds.y - halfHeight);
                //transform.position = new Vector3(clampedX, clampedY, transform.position.z);
            }
        }

        /// <summary>
        /// Met le zoom orthographique de la caméra
        ///  </summary>
        /// <param name="zoom"> float pour la taille du zoom </param>
        public void setZoom(float zoom)
        {
            gameObject.GetComponent<Camera>().orthographicSize += zoom;
        }

        /// <summary>
        /// met la caméra dans une position avant qu'elle revienne lentement à la position du joueur
        /// </summary>
        /// <remarks>
        /// cette fonction est seleument utilisée dans la classe <c>JoueurChasseur</c>
        /// </remarks>
        /// <param name="shootPosition"> Vector3 </param>
        public void CameraRecoil(Vector3 shootPosition)
        {
            Vector3 shootDirection = transform.localPosition - shootPosition;

            transform.localPosition = shootDirection;
        }

        /// <summary>
        /// Swich entre 2 caméra
        /// </summary>
        void SwitchC()
        {
            enabled = !enabled;
            cam.enabled = !cam.enabled;
        }

    }
