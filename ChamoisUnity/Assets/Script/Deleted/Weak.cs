// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
//
// public class Weak : MonoBehaviour
// {
//     // Start is called before the first frame update
//     private int id;
//     void Start()
//     {
//         id = GetInstanceID();
//     }
//
//     // Update is called once per frame
//     void Update()
//     {
//     }
//
//     private void OnCollisionEnter2D(Collision2D other)
//     {
//         if(other.collider.CompareTag("Bullet"))
//             GOPointer.ListeChamoisSauvages.GetComponent<ListChamois>().isProie(gameObject);
//     }
// }
