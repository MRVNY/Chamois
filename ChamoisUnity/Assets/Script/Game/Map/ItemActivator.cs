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
   
   public List<ActivatorItem> ActivatorItems = new List<ActivatorItem>();
   
   public static ItemActivator currentActivator;
   public static GameObject CurrentMap;


   void OnEnable()
   {
      currentActivator = this;
      CurrentMap = transform.parent.gameObject;
      //ActivatorItems = new List<ActivatorItem>();

      StartCoroutine("CheckActivation");
   }

   IEnumerator CheckActivation()
   {
      if (GOPointer.currentPlayer != null)
      {
         List<ActivatorItem> removeList = new List<ActivatorItem>();
         if (ActivatorItems.Count > 0)
         {
            foreach (ActivatorItem item in ActivatorItems)
            {
               if (Vector3.Distance(GOPointer.currentPlayer.transform.position, item.ItemPos) > distanceFromPlayer)
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
}

public class ActivatorItem
{
   public GameObject Item;
   public Vector3 ItemPos;
}
