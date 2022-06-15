using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Object = System.Object;

public class ItemActivator : MonoBehaviour
{
   //[SerializeField] 
   private int distanceFromPlayer = 150;
   
   private GameObject _player;

   public List<ActivatorItem> ActivatorItems;

   void Start()
   {
      if (Global.Personnage == "Chamois")
      {
         _player = GOPointer.PlayerChamois;
      }
      else if (Global.Personnage == "Chasseur")
      {
         _player = GOPointer.PlayerChasseur; 
      }
      else
      {
         _player = GOPointer.PlayerRandonneur; 
      }
      ActivatorItems = new List<ActivatorItem>();

      StartCoroutine("CheckActivation");
   }

   IEnumerator CheckActivation()
   {
      List<ActivatorItem> removeList = new List<ActivatorItem>();
      if (ActivatorItems.Count > 0)
      {
         foreach (ActivatorItem item in ActivatorItems)
         {
            if (Vector3.Distance(_player.transform.position, item.ItemPos) > distanceFromPlayer)
            {
               if (item.Item == null)
               {
                  removeList.Add(item);
               }
               else
               {
                  item.Item.SetActive(false);
               }
            }
            else
            {
               if (item.Item == null)
               {
                  removeList.Add(item);
               }
               else
               {
                  item.Item.SetActive(true);
               }
            }
         }
      }
      yield return new WaitForSeconds(0.01f);

      if (removeList.Count > 0)
      {
         foreach (ActivatorItem item in removeList)
         {
            ActivatorItems.Remove(item);
         }
      }
      
      yield return new WaitForSeconds(0.01f);
      StartCoroutine("CheckActivation");
   }
}

public class ActivatorItem
{
   public GameObject Item;
   public Vector3 ItemPos;
}
