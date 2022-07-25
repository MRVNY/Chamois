// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using RPGM.Gameplay;
// using System;
// using TMPro;
//
// public class randonneurRando : MonoBehaviour
// {
//     //PnJ donneur de randonnées
//     public GameObject donneurDeRando2;
//     private ConversationScript conversationScript;
//     public int rnd;
//     private DataStorerRandonneur dataSt;
//     public Boolean randoEnCours;
//     public float tpsRando;
//     public int meilleureRando;
//     public TextMeshProUGUI textRando;
//     // Randonnée de l'Épion
//     public GameObject startEpion;
//     public GameObject suiteEpion;
//     public GameObject endEpion;
//
//     // Randonnée du Fort de la Batterie
//     public GameObject startEndBatterie;
//     public GameObject suiteBatterie;
//     public GameObject suite2Batterie;
//     
//     // Randonnée de la Dent des Portes
//     public GameObject startEndDentPortes;
//     public GameObject suiteDentPortes;
//     public GameObject suite2DentPortes;
//
//     // Randonnée du Grand Roc
//     public GameObject startEndGrandRoc;
//     public GameObject suiteGrandRoc;
//     public GameObject suite2GrandRoc;
//
//     // Randonnée de la Pointe de la Chaurionde
//     public GameObject startEndPointeChaurionde;
//     public GameObject suitePointeChaurionde;
//     public GameObject suite2PointeChaurionde;
//
//     // Randonnée du Mont Morbier
//     public GameObject startMorbier;
//     public GameObject suiteMorbier;
//     public GameObject endMorbier;
//
//     // Randonnée de la Croix du Nivolet
//     public GameObject startNivolet;
//     public GameObject suiteNivolet;
//     public GameObject endNivolet;
//
//     // Randonnée de la Pointe de la Galoppaz
//     public GameObject startGaloppaz;
//     public GameObject suiteGaloppaz;
//     public GameObject endGaloppaz;
//
//     // Randonnée du Mont Colombier
//     public GameObject startColombier;
//     public GameObject suiteColombier;
//     public GameObject endColombier;
//
//     // Randonnée de la Pointe de l'Arcalod
//     public GameObject startArcalod;
//     public GameObject suiteArcalod;
//     public GameObject endArcalod;
//
//     // Randonnée du Mont Trélod
//     public GameObject startTrelod;
//     public GameObject suiteTrelod;
//     public GameObject endTrelod;
//
//     // Start is called before the first frame update
//     EncycloContentRandonneur ency;
//
//
//     public GameObject epion;
//     public GameObject fortBatterie;
//     public GameObject dentPortes;
//     public GameObject grandRoc;
//     public GameObject pointesChaurionde;
//     public GameObject morbier;
//     public GameObject nivolet;
//     public GameObject galoppaz;
//     public GameObject colombier;
//     public GameObject arcalod;
//     public GameObject trelod;
//
//     public bool actEpion;
//     public bool actFortBatterie;
//     public bool actDentPortes;
//     public bool actGrandRoc;
//     public bool actPointesChaurionde;
//     public bool actMorbier;
//     public bool actNivolet;
//     public bool actGaloppaz;
//     public bool actColombier;
//     public bool actArcalod;
//     public bool actTrelod;
//
//     public TextAsset jsonFile;
//     public TextAsset jsonFileEncy;
//     public List<ConversationInfos> data;
//     public List<EncyInfo> data2;
//     public EncyInfo info;
//
//     /*public int epionScore;
//     public int batterieScore;
//     public int dentPortesScore;
//     public int grandRocScore;
//     public int pointesChauriondeScore;
//     public int morbierScore;
//     public int nivoletScore;
//     public int galoppazScore;
//     public int colombierScore;
//     public int arcalodScore;
//     public int trelodScore;*/
//
//     /*public int epionScore = GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().epionScore;
//     public int batterieScore = GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().batterieScore;
//     public int dentPortesScore = GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().dentPortesScore;
//     public int grandRocScore = GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().grandRocScore;
//     public int pointesChauriondeScore = GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().pointesChauriondeScore;
//     public int morbierScore = GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().morbierScore;
//     public int nivoletScore = GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().nivoletScore;
//     public int galoppazScore = GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().galoppazScore;
//     public int colombierScore = GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().colombierScore;
//     public int arcalodScore = GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().arcalodScore;
//     public int trelodScore = GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().trelodScore;*/
//
//     //GameObject test;
//
//     void Start()
//     {
//         conversationScript = donneurDeRando2.GetComponent<ConversationScript>();
//         /*epionScore = GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().epionScore;
//         batterieScore = GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().batterieScore;
//         dentPortesScore = GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().dentPortesScore;
//         grandRocScore = GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().grandRocScore;
//         pointesChauriondeScore = GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().pointesChauriondeScore;
//         morbierScore = GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().morbierScore;
//         nivoletScore = GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().nivoletScore;
//         galoppazScore = GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().galoppazScore;
//         colombierScore = GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().colombierScore;
//         arcalodScore = GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().arcalodScore;
//         trelodScore = GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().trelodScore;*/
//         randoEnCours = false;
//         tpsRando = 0;
//
//         if (Global.Personnage == "Randonneur")
//         {
//             dataSt = DataStorerRandonneur.Instance;
//
//         }
//         // Récupération des données dans le JSON, lié dans le GameObject "NPC Collection"
//         ConversationInfosList infosInJson = JsonUtility.FromJson<ConversationInfosList>(jsonFile.text);
//         data = new List<ConversationInfos>();
//
//         foreach (ConversationInfos convinfo in infosInJson.convinfos)
//         {
//             data.Add(convinfo);
//         }
//
//         EncyInfoList infosInJson2 = JsonUtility.FromJson<EncyInfoList>(jsonFileEncy.text);
//         data2 = new List<EncyInfo>();
//
//         foreach (EncyInfo encyinfo in infosInJson2.encyinfos)
//         {
//             data2.Add(encyinfo);
//         }
//
//         ency = GOPointer.EncyclopedieManager.GetComponent<EncycloContentRandonneur>();
//         GameObject.Find("RandoEpion").SetActive(false);
//         GameObject.Find("RandoFortBatterie").SetActive(false);
//         GameObject.Find("RandoDentPortes").SetActive(false);
//         GameObject.Find("RandoGrandRoc").SetActive(false);
//         GameObject.Find("RandoPointeChaurionde").SetActive(false);
//         GameObject.Find("RandoMorbier").SetActive(false);
//         GameObject.Find("RandoNivolet").SetActive(false);
//         GameObject.Find("RandoGaloppaz").SetActive(false);
//         GameObject.Find("RandoColombier").SetActive(false);
//         GameObject.Find("RandoArcalod").SetActive(false);
//         GameObject.Find("RandoTrelod").SetActive(false);
//
//         actEpion = false;
//         actFortBatterie = false;
//         actDentPortes = false;
//         actGrandRoc = false;
//         actPointesChaurionde = false;
//         actMorbier = false;
//         actNivolet = false;
//         actGaloppaz = false;
//         actColombier = false;
//         actArcalod = false;
//         actTrelod = false;
//
//
//
//         //donneur2rando
//         donneurQuete();
//
//         // Initial items of NPC conversation array
//         /*var initialdonneurDRando = donneurDeRando.GetComponent<ConversationScript>().items;
//         var initialstartRando1 = startRando1.GetComponent<ConversationScript>().items;
//         var initialsuiteRando1 = suiteRando1.GetComponent<ConversationScript>().items;
//         var initialendRando1 = endRando1.GetComponent<ConversationScript>().items;
//         var initialstartRando2 = startRando2.GetComponent<ConversationScript>().items;
//         var initialendRando2 = endRando2.GetComponent<ConversationScript>().items;
//         var initialstartRando3 = startRando3.GetComponent<ConversationScript>().items;
//         var initialendRando3 = endRando3.GetComponent<ConversationScript>().items;
//         var initialstartRando4 = startRando4.GetComponent<ConversationScript>().items;
//         var initialendRando4 = endRando4.GetComponent<ConversationScript>().items;
//         var initialstartRando5 = startRando5.GetComponent<ConversationScript>().items;
//         var initialendRando5 = endRando5.GetComponent<ConversationScript>().items;*/
//     }
//
//     public void Update()
//     {
//         if (randoEnCours)
//         {
//             tpsRando += Time.deltaTime;
//         }
//
//         // changement état Epion
//         if (actEpion == true)
//         {
//             epion.SetActive(true);
//         }
//         else
//         {
//             epion.SetActive(false);
//         }
//
//         // changement état Fort Batterie
//         if (actFortBatterie == true)
//         {
//             fortBatterie.SetActive(true);
//         }
//         else
//         {
//             fortBatterie.SetActive(false);
//         }
//
//         // changement état Dent des Portes
//         if (actDentPortes == true)
//         {
//             dentPortes.SetActive(true);
//         }
//         else
//         {
//             dentPortes.SetActive(false);
//         }
//
//         // changement état Grand Roc
//         if (actGrandRoc == true)
//         {
//             grandRoc.SetActive(true);
//         }
//         else
//         {
//             grandRoc.SetActive(false);
//         }
//
//         // changement état Pointes Chaurionde
//         if (actPointesChaurionde == true)
//         {
//             pointesChaurionde.SetActive(true);
//         }
//         else
//         {
//             pointesChaurionde.SetActive(false);
//         }
//
//         // changement état Morbier
//         if (actMorbier == true)
//         {
//             morbier.SetActive(true);
//         }
//         else
//         {
//             morbier.SetActive(false);
//         }
//
//         // changement état Nivolet
//         if (actNivolet == true)
//         {
//             nivolet.SetActive(true);
//         }
//         else
//         {
//             nivolet.SetActive(false);
//         }
//
//         // changement état Galoppaz
//         if (actGaloppaz == true)
//         {
//             galoppaz.SetActive(true);
//         }
//         else
//         {
//             galoppaz.SetActive(false);
//         }
//
//         // changement état Colombier
//         if (actColombier == true)
//         {
//             colombier.SetActive(true);
//         }
//         else
//         {
//             colombier.SetActive(false);
//         }
//
//         // changement état Arcalod
//         if (actArcalod == true)
//         {
//             arcalod.SetActive(true);
//         }
//         else
//         {
//             arcalod.SetActive(false);
//         }
//
//         // changement état Trelod
//         if (actTrelod == true)
//         {
//             trelod.SetActive(true);
//         }
//         else
//         {
//             trelod.SetActive(false);
//         }
//     }
//
//     // Randonnée de l'Épion
//     public void donnerRandoEpion()
//     {
//         ency.addInfoToList(data2[29].hint, ency.quete);
//         //SELF
//         conversationScript.items.Clear();
//         ConversationPiece c = new ConversationPiece() { id = data[40].ID, text = data[40].texte, options = new List<ConversationOption>(), hint = data[40].hint };
//         conversationScript.items.Add(c);
//         conversationScript.OnAfterDeserialize();
//
//         //START POINT
//         startEpion.GetComponent<ConversationScript>().items.Clear();
//
//         ConversationOption o1 = new ConversationOption() { text = data[41].branche1Reponse, targetId = data[41].branche1ID };
//         ConversationOption o2 = new ConversationOption() { text = data[41].branche2Reponse, targetId = data[41].branche2ID };
//         ConversationPiece c1 = new ConversationPiece() { id = data[41].ID, text = data[41].texte, options = new List<ConversationOption>(), hint = data[41].hint };
//         c1.options.Add(o1);
//         c1.options.Add(o2);
//         startEpion.GetComponent<ConversationScript>().Add(c1);
//
//         ConversationPiece c2 = new ConversationPiece() { id = data[42].ID, text = data[42].texte, options = new List<ConversationOption>(), hint = data[42].hint };
//         startEpion.GetComponent<ConversationScript>().Add(c2);
//         startEpion.GetComponent<ConversationScript>().OnAfterDeserialize();
//         actEpion = true;
//     }
//
//     public void lancerRandoEpion()
//     {
//         
//         ency.addInfoToList(data2[40].hint, ency.quete);
//         //SELF
//         startEpion.GetComponent<ConversationScript>().items.Clear();
//         ConversationPiece c = new ConversationPiece() { id = data[43].ID, text = data[43].texte, options = new List<ConversationOption>(), hint = data[43].hint };
//         startEpion.GetComponent<ConversationScript>().items.Add(c);
//         startEpion.GetComponent<ConversationScript>().OnAfterDeserialize();
//
//         //CHECKPOINT
//         suiteEpion.GetComponent<ConversationScript>().items.Clear();
//
//         ConversationOption o1 = new ConversationOption() { text = data[44].branche1Reponse, targetId = data[44].branche1ID };
//         ConversationOption o2 = new ConversationOption() { text = data[44].branche2Reponse, targetId = data[44].branche2ID };
//         ConversationPiece c1 = new ConversationPiece() { id = data[44].ID, text = data[44].texte, options = new List<ConversationOption>(), hint = data[44].hint };
//         c1.options.Add(o1);
//         c1.options.Add(o2);
//         suiteEpion.GetComponent<ConversationScript>().Add(c1);
//
//         ConversationPiece c2 = new ConversationPiece() { id = data[45].ID, text = data[45].texte, options = new List<ConversationOption>(), hint = data[45].hint };
//         suiteEpion.GetComponent<ConversationScript>().Add(c2);
//         suiteEpion.GetComponent<ConversationScript>().OnAfterDeserialize();
//         startEpion.GetComponent<ConversationScript>().items.Clear();
//         randoEnCours = true;
//         tpsRando = 0;
//
//     }
//
//     public void suiteRandoEpion()
//     {
//         ency.addInfoToList(data2[51].hint, ency.quete);
//         //SELF
//         suiteEpion.GetComponent<ConversationScript>().items.Clear();
//         ConversationPiece c = new ConversationPiece() { id = data[46].ID, text = data[46].texte, options = new List<ConversationOption>(), hint = data[46].hint };
//         suiteEpion.GetComponent<ConversationScript>().items.Add(c);
//         suiteEpion.GetComponent<ConversationScript>().OnAfterDeserialize();
//
//         //END POINT
//         endEpion.GetComponent<ConversationScript>().items.Clear();
//
//         ConversationOption o1 = new ConversationOption() { text = data[47].branche1Reponse, targetId = data[47].branche1ID };
//         ConversationOption o2 = new ConversationOption() { text = data[47].branche2Reponse, targetId = data[47].branche2ID };
//         ConversationPiece c1 = new ConversationPiece() { id = data[47].ID, text = data[47].texte, options = new List<ConversationOption>(), hint = data[47].hint };
//         c1.options.Add(o1);
//         c1.options.Add(o2);
//         endEpion.GetComponent<ConversationScript>().Add(c1);
//
//         ConversationPiece c2 = new ConversationPiece() { id = data[48].ID, text = data[48].texte, options = new List<ConversationOption>(), hint = data[48].hint };
//         endEpion.GetComponent<ConversationScript>().Add(c2);
//         endEpion.GetComponent<ConversationScript>().OnAfterDeserialize();
//         suiteEpion.GetComponent<ConversationScript>().items.Clear();
//     }
//
//     public void terminerEpion()
//     {
//         ency.addInfoToList(data2[62].hint, ency.quete);
//         endEpion.GetComponent<ConversationScript>().items.Clear();
//         ConversationPiece c = new ConversationPiece() { id = data[49].ID, text = data[49].texte, options = new List<ConversationOption>(), hint = data[49].hint };
//         endEpion.GetComponent<ConversationScript>().items.Add(c);
//         endEpion.GetComponent<ConversationScript>().OnAfterDeserialize();
//         actEpion = false;
//
//         randoEnCours = false;
//
//         rnd = 10000 - (25 * (int)tpsRando);
//         GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().epionCurrent = rnd;
//
//
//         if (GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().epion == false)
//         {
//             GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().epion = true;
//             GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().nbRando += 1;
//             GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().epionScore = GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().epionCurrent;
//             GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().epionCurrent = 0 ;
//             dataSt.setData("epionScore", GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().epionScore);
//
//         }
//         else
//         {
//             if(GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().epionScore < GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().epionCurrent)
//             {
//                 GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().epionScore = GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().epionCurrent;
//                 GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().epionCurrent = 0;
//                 dataSt.setData("epionScore", GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().epionScore);
//             }
//             else
//             {
//                 GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().epionCurrent = 0;
//             }
//         }
//         if(meilleureRando < rnd)
//         {
//             meilleureRando = rnd;
//             PlayerPrefs.SetInt("meilleureRando", meilleureRando);
//         }
//
//         donneurQuete();
//     }
//
//     // Randonnée du Fort de la Batterie
//
//     public void donnerRandoBatterie()
//     {
//         ency.addInfoToList(data2[30].hint, ency.quete);
//         //SELF
//         conversationScript.items.Clear();
//         ConversationPiece c = new ConversationPiece() { id = data[50].ID, text = data[50].texte, options = new List<ConversationOption>(), hint = data[50].hint };
//         conversationScript.items.Add(c);
//         conversationScript.OnAfterDeserialize();
//
//         //START POINT
//         startEndBatterie.GetComponent<ConversationScript>().items.Clear();
//
//         ConversationOption o1 = new ConversationOption() { text = data[51].branche1Reponse, targetId = data[51].branche1ID };
//         ConversationOption o2 = new ConversationOption() { text = data[51].branche2Reponse, targetId = data[51].branche2ID };
//         ConversationPiece c1 = new ConversationPiece() { id = data[51].ID, text = data[51].texte, options = new List<ConversationOption>(), hint = data[51].hint };
//         c1.options.Add(o1);
//         c1.options.Add(o2);
//         startEndBatterie.GetComponent<ConversationScript>().Add(c1);
//
//         ConversationPiece c2 = new ConversationPiece() { id = data[52].ID, text = data[52].texte, options = new List<ConversationOption>(), hint = data[52].hint };
//         startEndBatterie.GetComponent<ConversationScript>().Add(c2);
//         startEndBatterie.GetComponent<ConversationScript>().OnAfterDeserialize();
//         actFortBatterie = true;
//     }
//
//
//     public void lancerRandoBatterie()
//     {
//         ency.addInfoToList(data2[41].hint, ency.quete);
//         //SELF
//         startEndBatterie.GetComponent<ConversationScript>().items.Clear();
//         ConversationPiece c = new ConversationPiece() { id = data[53].ID, text = data[53].texte, options = new List<ConversationOption>(), hint = data[53].hint };
//         startEndBatterie.GetComponent<ConversationScript>().items.Add(c);
//         startEndBatterie.GetComponent<ConversationScript>().OnAfterDeserialize();
//
//         //CHECKPOINT
//         suiteBatterie.GetComponent<ConversationScript>().items.Clear();
//
//         ConversationOption o1 = new ConversationOption() { text = data[54].branche1Reponse, targetId = data[54].branche1ID };
//         ConversationOption o2 = new ConversationOption() { text = data[54].branche2Reponse, targetId = data[54].branche2ID };
//         ConversationPiece c1 = new ConversationPiece() { id = data[54].ID, text = data[54].texte, options = new List<ConversationOption>(), hint = data[54].hint };
//         c1.options.Add(o1);
//         c1.options.Add(o2);
//         suiteBatterie.GetComponent<ConversationScript>().Add(c1);
//
//         ConversationPiece c2 = new ConversationPiece() { id = data[55].ID, text = data[55].texte, options = new List<ConversationOption>(), hint = data[55].hint };
//         suiteBatterie.GetComponent<ConversationScript>().Add(c2);
//         suiteBatterie.GetComponent<ConversationScript>().OnAfterDeserialize();
//         startEndBatterie.GetComponent<ConversationScript>().items.Clear();
//         randoEnCours = true;
//         tpsRando = 0;
//
//     }
//
//     public void suiteRandoBatterie()
//     {
//         ency.addInfoToList(data2[52].hint, ency.quete);
//         //SELF
//         suiteBatterie.GetComponent<ConversationScript>().items.Clear();
//         ConversationPiece c = new ConversationPiece() { id = data[56].ID, text = data[56].texte, options = new List<ConversationOption>(), hint = data[56].hint };
//         suiteBatterie.GetComponent<ConversationScript>().items.Add(c);
//         suiteBatterie.GetComponent<ConversationScript>().OnAfterDeserialize();
//
//         //END POINT
//         suite2Batterie.GetComponent<ConversationScript>().items.Clear();
//
//         ConversationOption o1 = new ConversationOption() { text = data[57].branche1Reponse, targetId = data[57].branche1ID };
//         ConversationOption o2 = new ConversationOption() { text = data[57].branche2Reponse, targetId = data[57].branche2ID };
//         ConversationPiece c1 = new ConversationPiece() { id = data[57].ID, text = data[57].texte, options = new List<ConversationOption>(), hint = data[57].hint };
//         c1.options.Add(o1);
//         c1.options.Add(o2);
//         suite2Batterie.GetComponent<ConversationScript>().Add(c1);
//         ConversationPiece c2 = new ConversationPiece() { id = data[58].ID, text = data[58].texte, options = new List<ConversationOption>(), hint = data[58].hint };
//         suite2Batterie.GetComponent<ConversationScript>().Add(c2);
//         suite2Batterie.GetComponent<ConversationScript>().OnAfterDeserialize();
//         suiteBatterie.GetComponent<ConversationScript>().items.Clear();
//
//     }
//
//     public void terminerBatterie()
//     {
//         ency.addInfoToList(data2[63].hint, ency.quete);
//         suite2Batterie.GetComponent<ConversationScript>().items.Clear();
//         ConversationPiece c = new ConversationPiece() { id = data[59].ID, text = data[59].texte, options = new List<ConversationOption>(), hint = data[59].hint };
//         suite2Batterie.GetComponent<ConversationScript>().items.Add(c);
//         suite2Batterie.GetComponent<ConversationScript>().OnAfterDeserialize();
//         actFortBatterie = false;
//
//         randoEnCours = false;
//
//         rnd = 10000 - (25 * (int)tpsRando);
//         GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().batterieCurrent = rnd;
//
//         if (GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().batterie == false)
//         {
//             GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().batterie = true;
//             GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().nbRando += 1;
//             GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().batterieScore = GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().batterieCurrent;
//             GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().batterieCurrent = 0;
//             dataSt.setData("batterieScore", GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().batterieScore);
//         }
//         else
//         {
//             if (GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().batterieScore < GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().batterieCurrent)
//             {
//                 GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().batterieScore = GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().batterieCurrent;
//                 GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().batterieCurrent = 0;
//                 dataSt.setData("batterieScore", GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().batterieScore);
//             }
//             else
//             {
//                 GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().batterieCurrent = 0;
//             }
//         }
//
//         if (meilleureRando < rnd)
//         {
//             meilleureRando = rnd;
//             PlayerPrefs.SetInt("meilleureRando", meilleureRando);
//         }
//         donneurQuete();
//
//     }
//
//     // Randonnée de la Dent des Portes
//
//     public void donnerRandoDentPortes()
//     {
//         ency.addInfoToList(data2[31].hint, ency.quete);
//         //SELF
//         conversationScript.items.Clear();
//         ConversationPiece c = new ConversationPiece() { id = data[60].ID, text = data[60].texte, options = new List<ConversationOption>(), hint = data[60].hint };
//         conversationScript.items.Add(c);
//         conversationScript.OnAfterDeserialize();
//
//         //START POINT
//         startEndDentPortes.GetComponent<ConversationScript>().items.Clear();
//
//         ConversationOption o1 = new ConversationOption() { text = data[61].branche1Reponse, targetId = data[61].branche1ID };
//         ConversationOption o2 = new ConversationOption() { text = data[61].branche2Reponse, targetId = data[61].branche2ID };
//         ConversationPiece c1 = new ConversationPiece() { id = data[61].ID, text = data[61].texte, options = new List<ConversationOption>(), hint = data[61].hint };
//         c1.options.Add(o1);
//         c1.options.Add(o2);
//         startEndDentPortes.GetComponent<ConversationScript>().Add(c1);
//
//         ConversationPiece c2 = new ConversationPiece() { id = data[62].ID, text = data[62].texte, options = new List<ConversationOption>(), hint = data[62].hint };
//         startEndDentPortes.GetComponent<ConversationScript>().Add(c2);
//         startEndDentPortes.GetComponent<ConversationScript>().OnAfterDeserialize();
//         actDentPortes = true;
//     }
//
//     public void lancerRandoDentPortes()
//     {
//         ency.addInfoToList(data2[42].hint, ency.quete);
//         //SELF
//         startEndDentPortes.GetComponent<ConversationScript>().items.Clear();
//         ConversationPiece c = new ConversationPiece() { id = data[63].ID, text = data[63].texte, options = new List<ConversationOption>(), hint = data[63].hint };
//         startEndDentPortes.GetComponent<ConversationScript>().items.Add(c);
//         startEndDentPortes.GetComponent<ConversationScript>().OnAfterDeserialize();
//
//         //CHECKPOINT
//         suiteDentPortes.GetComponent<ConversationScript>().items.Clear();
//
//         ConversationOption o1 = new ConversationOption() { text = data[64].branche1Reponse, targetId = data[64].branche1ID };
//         ConversationOption o2 = new ConversationOption() { text = data[64].branche2Reponse, targetId = data[64].branche2ID };
//         ConversationPiece c1 = new ConversationPiece() { id = data[64].ID, text = data[64].texte, options = new List<ConversationOption>(), hint = data[64].hint };
//         c1.options.Add(o1);
//         c1.options.Add(o2);
//         suiteDentPortes.GetComponent<ConversationScript>().Add(c1);
//
//         ConversationPiece c2 = new ConversationPiece() { id = data[65].ID, text = data[65].texte, options = new List<ConversationOption>(), hint = data[65].hint };
//         suiteDentPortes.GetComponent<ConversationScript>().Add(c2);
//         suiteDentPortes.GetComponent<ConversationScript>().OnAfterDeserialize();
//         startEndDentPortes.GetComponent<ConversationScript>().items.Clear();
//         randoEnCours = true;
//         tpsRando = 0;
//
//     }
//
//     public void suiteRandoDentPortes()
//     {
//         ency.addInfoToList(data2[53].hint, ency.quete);
//         //SELF
//         suiteDentPortes.GetComponent<ConversationScript>().items.Clear();
//         ConversationPiece c = new ConversationPiece() { id = data[66].ID, text = data[66].texte, options = new List<ConversationOption>(), hint = data[66].hint };
//         suiteDentPortes.GetComponent<ConversationScript>().items.Add(c);
//         suiteDentPortes.GetComponent<ConversationScript>().OnAfterDeserialize();
//
//         //END POINT
//         suite2DentPortes.GetComponent<ConversationScript>().items.Clear();
//
//         ConversationOption o1 = new ConversationOption() { text = data[67].branche1Reponse, targetId = data[67].branche1ID };
//         ConversationOption o2 = new ConversationOption() { text = data[67].branche2Reponse, targetId = data[67].branche2ID };
//         ConversationPiece c1 = new ConversationPiece() { id = data[67].ID, text = data[67].texte, options = new List<ConversationOption>(), hint = data[67].hint };
//         c1.options.Add(o1);
//         c1.options.Add(o2);
//         suite2DentPortes.GetComponent<ConversationScript>().Add(c1);
//
//         ConversationPiece c2 = new ConversationPiece() { id = data[68].ID, text = data[68].texte, options = new List<ConversationOption>(), hint = data[68].hint };
//         suite2DentPortes.GetComponent<ConversationScript>().Add(c2);
//         suite2DentPortes.GetComponent<ConversationScript>().OnAfterDeserialize();
//         suiteDentPortes.GetComponent<ConversationScript>().items.Clear();
//
//     }
//
//     public void terminerDentPortes()
//     {
//         ency.addInfoToList(data2[64].hint, ency.quete);
//         suite2DentPortes.GetComponent<ConversationScript>().items.Clear();
//         ConversationPiece c = new ConversationPiece() { id = data[69].ID, text = data[69].texte, options = new List<ConversationOption>(), hint = data[69].hint };
//         suite2DentPortes.GetComponent<ConversationScript>().items.Add(c);
//         suite2DentPortes.GetComponent<ConversationScript>().OnAfterDeserialize();
//         actDentPortes = false;
//
//         randoEnCours = false;
//
//         rnd = 10000 - (25 * (int)tpsRando);
//         GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().dentPortesCurrent = rnd;
//
//         if (GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().dentPortes == false)
//         {
//             GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().dentPortes = true;
//             GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().nbRando += 1;
//             GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().dentPortesScore = GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().dentPortesCurrent;
//             GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().dentPortesCurrent = 0;
//             dataSt.setData("dentPortesScore", GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().dentPortesScore);
//         }
//         else
//         {
//             if (GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().dentPortesScore < GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().dentPortesCurrent)
//             {
//                 GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().dentPortesScore = GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().dentPortesCurrent;
//                 GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().dentPortesCurrent = 0;
//                 dataSt.setData("dentPortesScore", GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().dentPortesScore);
//             }
//             else
//             {
//                 GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().dentPortesCurrent = 0;
//             }
//         }
//         if (meilleureRando < rnd)
//         {
//             meilleureRando = rnd;
//             PlayerPrefs.SetInt("meilleureRando", meilleureRando);
//         }
//         donneurQuete();
//
//     }
//
//     // Randonnée du Grand Roc
//
//     public void donnerRandoGrandRoc()
//     {
//         ency.addInfoToList(data2[32].hint, ency.quete);
//         //SELF
//         conversationScript.items.Clear();
//         ConversationPiece c = new ConversationPiece() { id = data[70].ID, text = data[70].texte, options = new List<ConversationOption>(), hint = data[70].hint };
//         conversationScript.items.Add(c);
//         conversationScript.OnAfterDeserialize();
//
//         //START POINT
//         startEndGrandRoc.GetComponent<ConversationScript>().items.Clear();
//
//         ConversationOption o1 = new ConversationOption() { text = data[71].branche1Reponse, targetId = data[71].branche1ID };
//         ConversationOption o2 = new ConversationOption() { text = data[71].branche2Reponse, targetId = data[71].branche2ID };
//         ConversationPiece c1 = new ConversationPiece() { id = data[71].ID, text = data[71].texte, options = new List<ConversationOption>(), hint = data[71].hint };
//         c1.options.Add(o1);
//         c1.options.Add(o2);
//         startEndGrandRoc.GetComponent<ConversationScript>().Add(c1);
//
//         ConversationPiece c2 = new ConversationPiece() { id = data[72].ID, text = data[72].texte, options = new List<ConversationOption>(), hint = data[72].hint };
//         startEndGrandRoc.GetComponent<ConversationScript>().Add(c2);
//         startEndGrandRoc.GetComponent<ConversationScript>().OnAfterDeserialize();
//         actGrandRoc = true;
//     }
//
//     public void lancerRandoGrandRoc()
//     {
//         ency.addInfoToList(data2[43].hint, ency.quete);
//         //SELF
//         startEndGrandRoc.GetComponent<ConversationScript>().items.Clear();
//         ConversationPiece c = new ConversationPiece() { id = data[73].ID, text = data[73].texte, options = new List<ConversationOption>(), hint = data[73].hint };
//         startEndGrandRoc.GetComponent<ConversationScript>().items.Add(c);
//         startEndGrandRoc.GetComponent<ConversationScript>().OnAfterDeserialize();
//
//         //CHECKPOINT
//         suiteGrandRoc.GetComponent<ConversationScript>().items.Clear();
//
//         ConversationOption o1 = new ConversationOption() { text = data[74].branche1Reponse, targetId = data[74].branche1ID };
//         ConversationOption o2 = new ConversationOption() { text = data[74].branche2Reponse, targetId = data[74].branche2ID };
//         ConversationPiece c1 = new ConversationPiece() { id = data[74].ID, text = data[74].texte, options = new List<ConversationOption>(), hint = data[74].hint };
//         c1.options.Add(o1);
//         c1.options.Add(o2);
//         suiteGrandRoc.GetComponent<ConversationScript>().Add(c1);
//
//         ConversationPiece c2 = new ConversationPiece() { id = data[75].ID, text = data[75].texte, options = new List<ConversationOption>(), hint = data[75].hint };
//         suiteGrandRoc.GetComponent<ConversationScript>().Add(c2);
//         suiteGrandRoc.GetComponent<ConversationScript>().OnAfterDeserialize();
//         startEndGrandRoc.GetComponent<ConversationScript>().items.Clear();
//         randoEnCours = true;
//         tpsRando = 0;
//
//     }
//
//     public void suiteRandoGrandRoc()
//     {
//         ency.addInfoToList(data2[54].hint, ency.quete);
//         //SELF
//         suiteGrandRoc.GetComponent<ConversationScript>().items.Clear();
//         ConversationPiece c = new ConversationPiece() { id = data[76].ID, text = data[76].texte, options = new List<ConversationOption>(), hint = data[76].hint };
//         suiteGrandRoc.GetComponent<ConversationScript>().items.Add(c);
//         suiteGrandRoc.GetComponent<ConversationScript>().OnAfterDeserialize();
//
//         //END POINT
//         suite2GrandRoc.GetComponent<ConversationScript>().items.Clear();
//
//         ConversationOption o1 = new ConversationOption() { text = data[77].branche1Reponse, targetId = data[77].branche1ID };
//         ConversationOption o2 = new ConversationOption() { text = data[77].branche2Reponse, targetId = data[77].branche2ID };
//         ConversationPiece c1 = new ConversationPiece() { id = data[77].ID, text = data[77].texte, options = new List<ConversationOption>(), hint = data[77].hint };
//         c1.options.Add(o1);
//         c1.options.Add(o2);
//         suite2GrandRoc.GetComponent<ConversationScript>().Add(c1);
//
//         ConversationPiece c2 = new ConversationPiece() { id = data[78].ID, text = data[78].texte, options = new List<ConversationOption>(), hint = data[78].hint };
//         suite2GrandRoc.GetComponent<ConversationScript>().Add(c2);
//         suite2GrandRoc.GetComponent<ConversationScript>().OnAfterDeserialize();
//         suiteGrandRoc.GetComponent<ConversationScript>().items.Clear();
//
//     }
//
//     public void terminerGrandRoc()
//     {
//         ency.addInfoToList(data2[65].hint, ency.quete);
//         suite2GrandRoc.GetComponent<ConversationScript>().items.Clear();
//         ConversationPiece c = new ConversationPiece() { id = data[79].ID, text = data[79].texte, options = new List<ConversationOption>(), hint = data[79].hint };
//         suite2GrandRoc.GetComponent<ConversationScript>().items.Add(c);
//         suite2GrandRoc.GetComponent<ConversationScript>().OnAfterDeserialize();
//         actGrandRoc = false;
//
//         randoEnCours = false;
//
//         rnd = 10000 - (25 * (int)tpsRando); 
//         GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().grandRocCurrent = rnd;
//
//         if (GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().grandRoc == false)
//         {
//             GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().grandRoc = true;
//             GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().nbRando += 1;
//             GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().grandRocScore = GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().grandRocCurrent;
//             GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().grandRocCurrent = 0;
//             dataSt.setData("grandRocScore", GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().grandRocScore);
//         }
//         else
//         {
//             if (GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().grandRocScore < GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().grandRocCurrent)
//             {
//                 GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().grandRocScore = GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().grandRocCurrent;
//                 GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().grandRocCurrent = 0;
//                 dataSt.setData("grandRocScore", GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().grandRocScore);
//             }
//             else
//             {
//                 GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().grandRocCurrent = 0;
//             }
//         }
//         if (meilleureRando < rnd)
//         {
//             meilleureRando = rnd;
//             PlayerPrefs.SetInt("meilleureRando", meilleureRando);
//         }
//         donneurQuete();
//
//     }
//
//     // Randonnée de la Pointe de la Chaurionde
//
//     public void donnerRandoPointeChaurionde()
//     {
//         ency.addInfoToList(data2[33].hint, ency.quete);
//         //SELF
//         conversationScript.items.Clear();
//         ConversationPiece c = new ConversationPiece() { id = data[80].ID, text = data[80].texte, options = new List<ConversationOption>(), hint = data[80].hint };
//         conversationScript.items.Add(c);
//         conversationScript.OnAfterDeserialize();
//
//         //START POINT
//         startEndPointeChaurionde.GetComponent<ConversationScript>().items.Clear();
//
//         ConversationOption o1 = new ConversationOption() { text = data[81].branche1Reponse, targetId = data[81].branche1ID };
//         ConversationOption o2 = new ConversationOption() { text = data[81].branche2Reponse, targetId = data[81].branche2ID };
//         ConversationPiece c1 = new ConversationPiece() { id = data[81].ID, text = data[81].texte, options = new List<ConversationOption>(), hint = data[81].hint };
//         c1.options.Add(o1);
//         c1.options.Add(o2);
//         startEndPointeChaurionde.GetComponent<ConversationScript>().Add(c1);
//
//         ConversationPiece c2 = new ConversationPiece() { id = data[82].ID, text = data[82].texte, options = new List<ConversationOption>(), hint = data[82].hint };
//         startEndPointeChaurionde.GetComponent<ConversationScript>().Add(c2);
//         startEndPointeChaurionde.GetComponent<ConversationScript>().OnAfterDeserialize();
//         actPointesChaurionde = true;
//     }
//
//     public void lancerRandoPointeChaurionde()
//     {
//         ency.addInfoToList(data2[44].hint, ency.quete);
//         //SELF
//         startEndPointeChaurionde.GetComponent<ConversationScript>().items.Clear();
//         ConversationPiece c = new ConversationPiece() { id = data[83].ID, text = data[83].texte, options = new List<ConversationOption>(), hint = data[83].hint };
//         startEndPointeChaurionde.GetComponent<ConversationScript>().items.Add(c);
//         startEndPointeChaurionde.GetComponent<ConversationScript>().OnAfterDeserialize();
//
//         //CHECKPOINT
//         suitePointeChaurionde.GetComponent<ConversationScript>().items.Clear();
//
//         ConversationOption o1 = new ConversationOption() { text = data[84].branche1Reponse, targetId = data[84].branche1ID };
//         ConversationOption o2 = new ConversationOption() { text = data[84].branche2Reponse, targetId = data[84].branche2ID };
//         ConversationPiece c1 = new ConversationPiece() { id = data[84].ID, text = data[84].texte, options = new List<ConversationOption>(), hint = data[84].hint };
//         c1.options.Add(o1);
//         c1.options.Add(o2);
//         suitePointeChaurionde.GetComponent<ConversationScript>().Add(c1);
//
//         ConversationPiece c2 = new ConversationPiece() { id = data[85].ID, text = data[85].texte, options = new List<ConversationOption>(), hint = data[85].hint };
//         suitePointeChaurionde.GetComponent<ConversationScript>().Add(c2);
//         suitePointeChaurionde.GetComponent<ConversationScript>().OnAfterDeserialize();
//         startEndPointeChaurionde.GetComponent<ConversationScript>().items.Clear();
//         randoEnCours = true;
//         tpsRando = 0;
//
//     }
//
//     public void suiteRandoPointeChaurionde()
//     {
//         ency.addInfoToList(data2[55].hint, ency.quete);
//         //SELF
//         suitePointeChaurionde.GetComponent<ConversationScript>().items.Clear();
//         ConversationPiece c = new ConversationPiece() { id = data[86].ID, text = data[86].texte, options = new List<ConversationOption>(), hint = data[86].hint };
//         suitePointeChaurionde.GetComponent<ConversationScript>().items.Add(c);
//         suitePointeChaurionde.GetComponent<ConversationScript>().OnAfterDeserialize();
//
//         //END POINT
//         suite2PointeChaurionde.GetComponent<ConversationScript>().items.Clear();
//
//         ConversationOption o1 = new ConversationOption() { text = data[87].branche1Reponse, targetId = data[87].branche1ID };
//         ConversationOption o2 = new ConversationOption() { text = data[87].branche2Reponse, targetId = data[87].branche2ID };
//         ConversationPiece c1 = new ConversationPiece() { id = data[87].ID, text = data[87].texte, options = new List<ConversationOption>(), hint = data[87].hint };
//         c1.options.Add(o1);
//         c1.options.Add(o2);
//         suite2PointeChaurionde.GetComponent<ConversationScript>().Add(c1);
//
//         ConversationPiece c2 = new ConversationPiece() { id = data[88].ID, text = data[88].texte, options = new List<ConversationOption>(), hint = data[88].hint };
//         suite2PointeChaurionde.GetComponent<ConversationScript>().Add(c2);
//         suite2PointeChaurionde.GetComponent<ConversationScript>().OnAfterDeserialize();
//         suitePointeChaurionde.GetComponent<ConversationScript>().items.Clear();
//
//     }
//
//     public void terminerPointeChaurionde()
//     {
//         ency.addInfoToList(data2[66].hint, ency.quete);
//         suite2PointeChaurionde.GetComponent<ConversationScript>().items.Clear();
//         ConversationPiece c = new ConversationPiece() { id = data[89].ID, text = data[89].texte, options = new List<ConversationOption>(), hint = data[89].hint };
//         suite2PointeChaurionde.GetComponent<ConversationScript>().items.Add(c);
//         suite2PointeChaurionde.GetComponent<ConversationScript>().OnAfterDeserialize();
//         actPointesChaurionde = false;
//
//         randoEnCours = false;
//
//         rnd = 10000 - (25 * (int)tpsRando); 
//         GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().pointesChauriondeCurrent = rnd;
//
//         if (GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().pointesChaurionde == false)
//         {
//             GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().pointesChaurionde = true;
//             GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().nbRando += 1;
//             GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().pointesChauriondeScore = GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().pointesChauriondeCurrent;
//             GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().pointesChauriondeCurrent = 0;
//             dataSt.setData("pointesChauriondeScore", GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().pointesChauriondeScore);
//         }
//         else
//         {
//             if (GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().pointesChauriondeScore < GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().pointesChauriondeCurrent)
//             {
//                 GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().pointesChauriondeScore = GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().pointesChauriondeCurrent;
//                 GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().pointesChauriondeCurrent = 0;
//                 dataSt.setData("pointesChauriondeScore", GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().pointesChauriondeScore);
//             }
//             else
//             {
//                 GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().pointesChauriondeCurrent = 0;
//             }
//         }
//         if (meilleureRando < rnd)
//         {
//             meilleureRando = rnd;
//             PlayerPrefs.SetInt("meilleureRando", meilleureRando);
//         }
//         donneurQuete();
//
//     }
//
//     // Randonnée du Mont Morbier
//
//     public void donnerRandoMorbier()
//     {
//         ency.addInfoToList(data2[34].hint, ency.quete);
//         //SELF
//         conversationScript.items.Clear();
//         ConversationPiece c = new ConversationPiece() { id = data[90].ID, text = data[90].texte, options = new List<ConversationOption>(), hint = data[90].hint };
//         conversationScript.items.Add(c);
//         conversationScript.OnAfterDeserialize();
//
//         //START POINT
//         startMorbier.GetComponent<ConversationScript>().items.Clear();
//
//         ConversationOption o1 = new ConversationOption() { text = data[91].branche1Reponse, targetId = data[91].branche1ID };
//         ConversationOption o2 = new ConversationOption() { text = data[91].branche2Reponse, targetId = data[91].branche2ID };
//         ConversationPiece c1 = new ConversationPiece() { id = data[91].ID, text = data[91].texte, options = new List<ConversationOption>(), hint = data[91].hint };
//         c1.options.Add(o1);
//         c1.options.Add(o2);
//         startMorbier.GetComponent<ConversationScript>().Add(c1);
//
//         ConversationPiece c2 = new ConversationPiece() { id = data[92].ID, text = data[92].texte, options = new List<ConversationOption>(), hint = data[92].hint };
//         startMorbier.GetComponent<ConversationScript>().Add(c2);
//         startMorbier.GetComponent<ConversationScript>().OnAfterDeserialize();
//         actMorbier = true;
//     }
//
//     public void lancerRandoMorbier()
//     {
//         ency.addInfoToList(data2[45].hint, ency.quete);
//         //SELF
//         startMorbier.GetComponent<ConversationScript>().items.Clear();
//         ConversationPiece c = new ConversationPiece() { id = data[93].ID, text = data[93].texte, options = new List<ConversationOption>(), hint = data[93].hint };
//         startMorbier.GetComponent<ConversationScript>().items.Add(c);
//         startMorbier.GetComponent<ConversationScript>().OnAfterDeserialize();
//
//         //CHECKPOINT
//         suiteMorbier.GetComponent<ConversationScript>().items.Clear();
//
//         ConversationOption o1 = new ConversationOption() { text = data[94].branche1Reponse, targetId = data[94].branche1ID };
//         ConversationOption o2 = new ConversationOption() { text = data[94].branche2Reponse, targetId = data[94].branche2ID };
//         ConversationPiece c1 = new ConversationPiece() { id = data[94].ID, text = data[94].texte, options = new List<ConversationOption>(), hint = data[94].hint };
//         c1.options.Add(o1);
//         c1.options.Add(o2);
//         suiteMorbier.GetComponent<ConversationScript>().Add(c1);
//
//         ConversationPiece c2 = new ConversationPiece() { id = data[95].ID, text = data[95].texte, options = new List<ConversationOption>(), hint = data[95].hint };
//         suiteMorbier.GetComponent<ConversationScript>().Add(c2);
//         suiteMorbier.GetComponent<ConversationScript>().OnAfterDeserialize();
//         startMorbier.GetComponent<ConversationScript>().items.Clear();
//         randoEnCours = true;
//         tpsRando = 0;
//
//     }
//
//     public void suiteRandoMorbier()
//     {
//         ency.addInfoToList(data2[56].hint, ency.quete);
//         //SELF
//         suiteMorbier.GetComponent<ConversationScript>().items.Clear();
//         ConversationPiece c = new ConversationPiece() { id = data[96].ID, text = data[96].texte, options = new List<ConversationOption>(), hint = data[96].hint };
//         suiteMorbier.GetComponent<ConversationScript>().items.Add(c);
//         suiteMorbier.GetComponent<ConversationScript>().OnAfterDeserialize();
//
//         //END POINT
//         endMorbier.GetComponent<ConversationScript>().items.Clear();
//
//         ConversationOption o1 = new ConversationOption() { text = data[97].branche1Reponse, targetId = data[97].branche1ID };
//         ConversationOption o2 = new ConversationOption() { text = data[97].branche2Reponse, targetId = data[97].branche2ID };
//         ConversationPiece c1 = new ConversationPiece() { id = data[97].ID, text = data[97].texte, options = new List<ConversationOption>(), hint = data[97].hint };
//         c1.options.Add(o1);
//         c1.options.Add(o2);
//         endMorbier.GetComponent<ConversationScript>().Add(c1);
//
//         ConversationPiece c2 = new ConversationPiece() { id = data[98].ID, text = data[98].texte, options = new List<ConversationOption>(), hint = data[98].hint };
//         endMorbier.GetComponent<ConversationScript>().Add(c2);
//         endMorbier.GetComponent<ConversationScript>().OnAfterDeserialize();
//         suiteMorbier.GetComponent<ConversationScript>().items.Clear();
//
//     }
//
//     public void terminerMorbier()
//     {
//         ency.addInfoToList(data2[67].hint, ency.quete);
//         endMorbier.GetComponent<ConversationScript>().items.Clear();
//         ConversationPiece c = new ConversationPiece() { id = data[99].ID, text = data[99].texte, options = new List<ConversationOption>(), hint = data[99].hint };
//         endMorbier.GetComponent<ConversationScript>().items.Add(c);
//         endMorbier.GetComponent<ConversationScript>().OnAfterDeserialize();
//         actMorbier = false;
//
//         randoEnCours = false;
//
//         rnd = 10000 - (25 * (int)tpsRando); 
//         GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().morbierCurrent = rnd;
//
//         if (GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().morbier == false)
//         {
//             GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().morbier = true;
//             GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().nbRando += 1;
//             GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().morbierScore = GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().morbierCurrent;
//             GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().morbierCurrent = 0;
//             dataSt.setData("morbierScore", GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().morbierScore);
//         }
//         else
//         {
//             if (GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().morbierScore < GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().morbierCurrent)
//             {
//                 GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().morbierScore = GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().morbierCurrent;
//                 GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().morbierCurrent = 0;
//                 dataSt.setData("morbierScore", GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().morbierScore);
//             }
//             else
//             {
//                 GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().morbierCurrent = 0;
//             }
//         }
//         if (meilleureRando < rnd)
//         {
//             meilleureRando = rnd;
//             PlayerPrefs.SetInt("meilleureRando", meilleureRando);
//         }
//         donneurQuete();
//
//     }
//
//     // Randonnée de la Croix du Nivolet
//
//     public void donnerRandoNivolet()
//     {
//         ency.addInfoToList(data2[35].hint, ency.quete);
//         //SELF
//         conversationScript.items.Clear();
//         ConversationPiece c = new ConversationPiece() { id = data[100].ID, text = data[100].texte, options = new List<ConversationOption>(), hint = data[100].hint };
//         conversationScript.items.Add(c);
//         conversationScript.OnAfterDeserialize();
//
//         //START POINT
//         startNivolet.GetComponent<ConversationScript>().items.Clear();
//
//         ConversationOption o1 = new ConversationOption() { text = data[101].branche1Reponse, targetId = data[101].branche1ID };
//         ConversationOption o2 = new ConversationOption() { text = data[101].branche2Reponse, targetId = data[101].branche2ID };
//         ConversationPiece c1 = new ConversationPiece() { id = data[101].ID, text = data[101].texte, options = new List<ConversationOption>(), hint = data[101].hint };
//         c1.options.Add(o1);
//         c1.options.Add(o2);
//         startNivolet.GetComponent<ConversationScript>().Add(c1);
//
//         ConversationPiece c2 = new ConversationPiece() { id = data[102].ID, text = data[102].texte, options = new List<ConversationOption>(), hint = data[102].hint };
//         startNivolet.GetComponent<ConversationScript>().Add(c2);
//         startNivolet.GetComponent<ConversationScript>().OnAfterDeserialize();
//         actNivolet = true;
//     }
//
//     public void lancerRandoNivolet()
//     {
//         ency.addInfoToList(data2[46].hint, ency.quete);
//         //SELF
//         startNivolet.GetComponent<ConversationScript>().items.Clear();
//         ConversationPiece c = new ConversationPiece() { id = data[103].ID, text = data[103].texte, options = new List<ConversationOption>(), hint = data[103].hint };
//         startNivolet.GetComponent<ConversationScript>().items.Add(c);
//         startNivolet.GetComponent<ConversationScript>().OnAfterDeserialize();
//
//         //CHECKPOINT
//         suiteNivolet.GetComponent<ConversationScript>().items.Clear();
//         ConversationOption o1 = new ConversationOption() { text = data[104].branche1Reponse, targetId = data[104].branche1ID };
//         ConversationOption o2 = new ConversationOption() { text = data[104].branche2Reponse, targetId = data[104].branche2ID };
//         ConversationPiece c1 = new ConversationPiece() { id = data[104].ID, text = data[104].texte, options = new List<ConversationOption>(), hint = data[104].hint };
//         c1.options.Add(o1);
//         c1.options.Add(o2);
//         suiteNivolet.GetComponent<ConversationScript>().Add(c1);
//
//         ConversationPiece c2 = new ConversationPiece() { id = data[105].ID, text = data[105].texte, options = new List<ConversationOption>(), hint = data[105].hint };
//         suiteNivolet.GetComponent<ConversationScript>().Add(c2);
//         suiteNivolet.GetComponent<ConversationScript>().OnAfterDeserialize();
//         startNivolet.GetComponent<ConversationScript>().items.Clear();
//         randoEnCours = true;
//         tpsRando = 0;
//
//     }
//
//     public void suiteRandoNivolet()
//     {
//         ency.addInfoToList(data2[57].hint, ency.quete);
//         //SELF
//         suiteNivolet.GetComponent<ConversationScript>().items.Clear();
//         ConversationPiece c = new ConversationPiece() { id = data[106].ID, text = data[106].texte, options = new List<ConversationOption>(), hint = data[106].hint };
//         suiteNivolet.GetComponent<ConversationScript>().items.Add(c);
//         suiteNivolet.GetComponent<ConversationScript>().OnAfterDeserialize();
//
//         //END POINT
//         endNivolet.GetComponent<ConversationScript>().items.Clear();
//
//         ConversationOption o1 = new ConversationOption() { text = data[107].branche1Reponse, targetId = data[107].branche1ID };
//         ConversationOption o2 = new ConversationOption() { text = data[107].branche2Reponse, targetId = data[107].branche2ID };
//         ConversationPiece c1 = new ConversationPiece() { id = data[107].ID, text = data[107].texte, options = new List<ConversationOption>(), hint = data[107].hint };
//         c1.options.Add(o1);
//         c1.options.Add(o2);
//         endNivolet.GetComponent<ConversationScript>().Add(c1);
//
//         ConversationPiece c2 = new ConversationPiece() { id = data[108].ID, text = data[108].texte, options = new List<ConversationOption>(), hint = data[108].hint };
//         endNivolet.GetComponent<ConversationScript>().Add(c2);
//         endNivolet.GetComponent<ConversationScript>().OnAfterDeserialize();
//         suiteNivolet.GetComponent<ConversationScript>().items.Clear();
//
//     }
//
//     public void terminerNivolet()
//     {
//         ency.addInfoToList(data2[68].hint, ency.quete);
//         endNivolet.GetComponent<ConversationScript>().items.Clear();
//         ConversationPiece c = new ConversationPiece() { id = data[109].ID, text = data[109].texte, options = new List<ConversationOption>(), hint = data[109].hint };
//         endNivolet.GetComponent<ConversationScript>().items.Add(c);
//         endNivolet.GetComponent<ConversationScript>().OnAfterDeserialize();
//         actNivolet = false;
//
//         randoEnCours = false;
//
//         rnd = 10000 - (25 * (int)tpsRando); 
//         GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().nivoletCurrent = rnd;
//
//         if (GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().nivolet == false)
//         {
//             GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().nivolet = true;
//             GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().nbRando += 1;
//             GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().nivoletScore = GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().nivoletCurrent;
//             GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().nivoletCurrent = 0;
//             dataSt.setData("nivoletScore", GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().nivoletScore);
//         }
//         else
//         {
//             if (GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().nivoletScore < GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().nivoletCurrent)
//             {
//                 GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().nivoletScore = GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().nivoletCurrent;
//                 GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().nivoletCurrent = 0;
//                 dataSt.setData("nivoletScore", GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().nivoletScore);
//             }
//             else
//             {
//                 GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().nivoletCurrent = 0;
//             }
//         }
//         if (meilleureRando < rnd)
//         {
//             meilleureRando = rnd;
//             PlayerPrefs.SetInt("meilleureRando", meilleureRando);
//         }
//         donneurQuete();
//
//     }
//
//     // Randonnée de la Pointe de la Galoppaz
//
//     public void donnerRandoGaloppaz()
//     {
//         ency.addInfoToList(data2[36].hint, ency.quete);
//         //SELF
//         conversationScript.items.Clear();
//         ConversationPiece c = new ConversationPiece() { id = data[110].ID, text = data[110].texte, options = new List<ConversationOption>(), hint = data[110].hint };
//         conversationScript.items.Add(c);
//         conversationScript.OnAfterDeserialize();
//
//         //START POINT
//         startGaloppaz.GetComponent<ConversationScript>().items.Clear();
//
//         ConversationOption o1 = new ConversationOption() { text = data[111].branche1Reponse, targetId = data[111].branche1ID };
//         ConversationOption o2 = new ConversationOption() { text = data[111].branche2Reponse, targetId = data[111].branche2ID };
//         ConversationPiece c1 = new ConversationPiece() { id = data[111].ID, text = data[111].texte, options = new List<ConversationOption>(), hint = data[111].hint };
//         c1.options.Add(o1);
//         c1.options.Add(o2);
//         startGaloppaz.GetComponent<ConversationScript>().Add(c1);
//
//         ConversationPiece c2 = new ConversationPiece() { id = data[112].ID, text = data[112].texte, options = new List<ConversationOption>(), hint = data[112].hint };
//         startGaloppaz.GetComponent<ConversationScript>().Add(c2);
//         startGaloppaz.GetComponent<ConversationScript>().OnAfterDeserialize();
//         actGaloppaz = true;
//     }
//
//     public void lancerRandoGaloppaz()
//     {
//         ency.addInfoToList(data2[47].hint, ency.quete);
//         //SELF
//         startGaloppaz.GetComponent<ConversationScript>().items.Clear();
//         ConversationPiece c = new ConversationPiece() { id = data[113].ID, text = data[113].texte, options = new List<ConversationOption>(), hint = data[113].hint };
//         startGaloppaz.GetComponent<ConversationScript>().items.Add(c);
//         startGaloppaz.GetComponent<ConversationScript>().OnAfterDeserialize();
//
//         //CHECKPOINT
//         suiteGaloppaz.GetComponent<ConversationScript>().items.Clear();
//
//         ConversationOption o1 = new ConversationOption() { text = data[114].branche1Reponse, targetId = data[114].branche1ID };
//         ConversationOption o2 = new ConversationOption() { text = data[114].branche2Reponse, targetId = data[114].branche2ID };
//         ConversationPiece c1 = new ConversationPiece() { id = data[114].ID, text = data[114].texte, options = new List<ConversationOption>(), hint = data[114].hint };
//         c1.options.Add(o1);
//         c1.options.Add(o2);
//         suiteGaloppaz.GetComponent<ConversationScript>().Add(c1);
//
//         ConversationPiece c2 = new ConversationPiece() { id = data[115].ID, text = data[115].texte, options = new List<ConversationOption>(), hint = data[115].hint };
//         suiteGaloppaz.GetComponent<ConversationScript>().Add(c2);
//         suiteGaloppaz.GetComponent<ConversationScript>().OnAfterDeserialize();
//         startGaloppaz.GetComponent<ConversationScript>().items.Clear();
//         randoEnCours = true;
//         tpsRando = 0;
//
//     }
//
//     public void suiteRandoGaloppaz()
//     {
//         ency.addInfoToList(data2[58].hint, ency.quete);
//         //SELF
//         suiteGaloppaz.GetComponent<ConversationScript>().items.Clear();
//         ConversationPiece c = new ConversationPiece() { id = data[116].ID, text = data[116].texte, options = new List<ConversationOption>(), hint = data[116].hint };
//         suiteGaloppaz.GetComponent<ConversationScript>().items.Add(c);
//         suiteGaloppaz.GetComponent<ConversationScript>().OnAfterDeserialize();
//
//         //END POINT
//         endGaloppaz.GetComponent<ConversationScript>().items.Clear();
//
//         ConversationOption o1 = new ConversationOption() { text = data[117].branche1Reponse, targetId = data[117].branche1ID };
//         ConversationOption o2 = new ConversationOption() { text = data[117].branche2Reponse, targetId = data[117].branche2ID };
//         ConversationPiece c1 = new ConversationPiece() { id = data[117].ID, text = data[117].texte, options = new List<ConversationOption>(), hint = data[117].hint };
//         c1.options.Add(o1);
//         c1.options.Add(o2);
//         endGaloppaz.GetComponent<ConversationScript>().Add(c1);
//
//         ConversationPiece c2 = new ConversationPiece() { id = data[118].ID, text = data[118].texte, options = new List<ConversationOption>(), hint = data[118].hint };
//         endGaloppaz.GetComponent<ConversationScript>().Add(c2);
//         endGaloppaz.GetComponent<ConversationScript>().OnAfterDeserialize();
//         suiteGaloppaz.GetComponent<ConversationScript>().items.Clear();
//
//     }
//
//     public void terminerGaloppaz()
//     {
//         ency.addInfoToList(data2[69].hint, ency.quete);
//         endGaloppaz.GetComponent<ConversationScript>().items.Clear();
//         ConversationPiece c = new ConversationPiece() { id = data[119].ID, text = data[119].texte, options = new List<ConversationOption>(), hint = data[119].hint };
//         endGaloppaz.GetComponent<ConversationScript>().items.Add(c);
//         endGaloppaz.GetComponent<ConversationScript>().OnAfterDeserialize();
//         actGaloppaz = false;
//
//         randoEnCours = false;
//
//         rnd = 10000 - (25 * (int)tpsRando); 
//         GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().galoppazCurrent = rnd;
//
//         if (GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().galoppaz == false)
//         {
//             GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().galoppaz = true;
//             GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().nbRando += 1;
//             GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().galoppazScore = GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().galoppazCurrent;
//             GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().galoppazCurrent = 0;
//             dataSt.setData("galoppazScore", GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().galoppazScore);
//         }
//         else
//         {
//             if (GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().galoppazScore < GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().galoppazCurrent)
//             {
//                 GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().galoppazScore = GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().galoppazCurrent;
//                 GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().galoppazCurrent = 0;
//                 dataSt.setData("galoppazScore", GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().galoppazScore);
//             }
//             else
//             {
//                 GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().galoppazCurrent = 0;
//             }
//         }
//         if (meilleureRando < rnd)
//         {
//             meilleureRando = rnd;
//             PlayerPrefs.SetInt("meilleureRando", meilleureRando);
//         }
//         donneurQuete();
//
//     }
//
//     // Randonnée du Mont Colombier
//
//     public void donnerRandoColombier()
//     {
//         ency.addInfoToList(data2[37].hint, ency.quete);
//         //SELF
//         conversationScript.items.Clear();
//         ConversationPiece c = new ConversationPiece() { id = data[120].ID, text = data[120].texte, options = new List<ConversationOption>(), hint = data[120].hint };
//         conversationScript.items.Add(c);
//         conversationScript.OnAfterDeserialize();
//
//         //START POINT
//         startColombier.GetComponent<ConversationScript>().items.Clear();
//
//         ConversationOption o1 = new ConversationOption() { text = data[121].branche1Reponse, targetId = data[121].branche1ID };
//         ConversationOption o2 = new ConversationOption() { text = data[121].branche2Reponse, targetId = data[121].branche2ID };
//         ConversationPiece c1 = new ConversationPiece() { id = data[121].ID, text = data[121].texte, options = new List<ConversationOption>(), hint = data[121].hint };
//         c1.options.Add(o1);
//         c1.options.Add(o2);
//         startColombier.GetComponent<ConversationScript>().Add(c1);
//
//         ConversationPiece c2 = new ConversationPiece() { id = data[122].ID, text = data[122].texte, options = new List<ConversationOption>(), hint = data[122].hint };
//         startColombier.GetComponent<ConversationScript>().Add(c2);
//         startColombier.GetComponent<ConversationScript>().OnAfterDeserialize();
//         actColombier = true;
//     }
//
//     public void lancerRandoColombier()
//     {
//         ency.addInfoToList(data2[48].hint, ency.quete);
//         //SELF
//         startColombier.GetComponent<ConversationScript>().items.Clear();
//         ConversationPiece c = new ConversationPiece() { id = data[123].ID, text = data[123].texte, options = new List<ConversationOption>(), hint = data[123].hint };
//         startColombier.GetComponent<ConversationScript>().items.Add(c);
//         startColombier.GetComponent<ConversationScript>().OnAfterDeserialize();
//
//         //CHECKPOINT
//         suiteColombier.GetComponent<ConversationScript>().items.Clear();
//
//         ConversationOption o1 = new ConversationOption() { text = data[124].branche1Reponse, targetId = data[124].branche1ID };
//         ConversationOption o2 = new ConversationOption() { text = data[124].branche2Reponse, targetId = data[124].branche2ID };
//         ConversationPiece c1 = new ConversationPiece() { id = data[124].ID, text = data[124].texte, options = new List<ConversationOption>(), hint = data[124].hint };
//         c1.options.Add(o1);
//         c1.options.Add(o2);
//         suiteColombier.GetComponent<ConversationScript>().Add(c1);
//
//         ConversationPiece c2 = new ConversationPiece() { id = data[125].ID, text = data[125].texte, options = new List<ConversationOption>(), hint = data[125].hint };
//         suiteColombier.GetComponent<ConversationScript>().Add(c2);
//         suiteColombier.GetComponent<ConversationScript>().OnAfterDeserialize();
//         startColombier.GetComponent<ConversationScript>().items.Clear();
//         randoEnCours = true;
//         tpsRando = 0;
//
//     }
//
//     public void suiteRandoColombier()
//     {
//         ency.addInfoToList(data2[59].hint, ency.quete);
//         //SELF
//         suiteColombier.GetComponent<ConversationScript>().items.Clear();
//         ConversationPiece c = new ConversationPiece() { id = data[126].ID, text = data[126].texte, options = new List<ConversationOption>(), hint = data[126].hint };
//         suiteColombier.GetComponent<ConversationScript>().items.Add(c);
//         suiteColombier.GetComponent<ConversationScript>().OnAfterDeserialize();
//
//         //END POINT
//         endColombier.GetComponent<ConversationScript>().items.Clear();
//
//         ConversationOption o1 = new ConversationOption() { text = data[127].branche1Reponse, targetId = data[127].branche1ID };
//         ConversationOption o2 = new ConversationOption() { text = data[127].branche2Reponse, targetId = data[127].branche2ID };
//         ConversationPiece c1 = new ConversationPiece() { id = data[127].ID, text = data[127].texte, options = new List<ConversationOption>(), hint = data[127].hint };
//         c1.options.Add(o1);
//         c1.options.Add(o2);
//         endColombier.GetComponent<ConversationScript>().Add(c1);
//
//         ConversationPiece c2 = new ConversationPiece() { id = data[128].ID, text = data[128].texte, options = new List<ConversationOption>(), hint = data[128].hint };
//         endColombier.GetComponent<ConversationScript>().Add(c2);
//         endColombier.GetComponent<ConversationScript>().OnAfterDeserialize();
//         suiteColombier.GetComponent<ConversationScript>().items.Clear();
//
//     }
//
//     public void terminerColombier()
//     {
//         ency.addInfoToList(data2[70].hint, ency.quete);
//         endColombier.GetComponent<ConversationScript>().items.Clear();
//         ConversationPiece c = new ConversationPiece() { id = data[129].ID, text = data[129].texte, options = new List<ConversationOption>(), hint = data[129].hint };
//         endColombier.GetComponent<ConversationScript>().items.Add(c);
//         endColombier.GetComponent<ConversationScript>().OnAfterDeserialize();
//         actColombier = false;
//
//         randoEnCours = false;
//
//         rnd = 10000 - (25 * (int)tpsRando); 
//         GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().colombierCurrent = rnd;
//
//         if (GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().colombier == false)
//         {
//             GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().colombier = true;
//             GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().nbRando += 1;
//             GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().colombierScore = GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().colombierCurrent;
//             GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().colombierCurrent = 0;
//             dataSt.setData("colombierScore", GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().colombierScore);
//         }
//         else
//         {
//             if (GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().colombierScore < GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().colombierCurrent)
//             {
//                 GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().colombierScore = GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().colombierCurrent;
//                 GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().colombierCurrent = 0;
//                 dataSt.setData("colombierScore", GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().colombierScore);
//             }
//             else
//             {
//                 GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().colombierCurrent = 0;
//             }
//         }
//         if (meilleureRando < rnd)
//         {
//             meilleureRando = rnd;
//             PlayerPrefs.SetInt("meilleureRando", meilleureRando);
//         }
//         donneurQuete();
//
//     }
//
//     // Randonnée de la Pointe de l'Arcalod
//
//     public void donnerRandoArcalod()
//     {
//         ency.addInfoToList(data2[38].hint, ency.quete);
//         //SELF
//         conversationScript.items.Clear();
//         ConversationPiece c = new ConversationPiece() { id = data[130].ID, text = data[130].texte, options = new List<ConversationOption>(), hint = data[130].hint };
//         conversationScript.items.Add(c);
//         conversationScript.OnAfterDeserialize();
//
//         //START POINT
//         startArcalod.GetComponent<ConversationScript>().items.Clear();
//
//         ConversationOption o1 = new ConversationOption() { text = data[131].branche1Reponse, targetId = data[131].branche1ID };
//         ConversationOption o2 = new ConversationOption() { text = data[131].branche2Reponse, targetId = data[131].branche2ID };
//         ConversationPiece c1 = new ConversationPiece() { id = data[131].ID, text = data[131].texte, options = new List<ConversationOption>(), hint = data[131].hint };
//         c1.options.Add(o1);
//         c1.options.Add(o2);
//         startArcalod.GetComponent<ConversationScript>().Add(c1);
//
//         ConversationPiece c2 = new ConversationPiece() { id = data[132].ID, text = data[132].texte, options = new List<ConversationOption>(), hint = data[132].hint };
//         startArcalod.GetComponent<ConversationScript>().Add(c2);
//         startArcalod.GetComponent<ConversationScript>().OnAfterDeserialize();
//         actArcalod = true;
//     }
//
//     public void lancerRandoArcalod()
//     {
//         ency.addInfoToList(data2[49].hint, ency.quete);
//         //SELF
//         startArcalod.GetComponent<ConversationScript>().items.Clear();
//         ConversationPiece c = new ConversationPiece() { id = data[133].ID, text = data[133].texte, options = new List<ConversationOption>(), hint = data[133].hint };
//         startArcalod.GetComponent<ConversationScript>().items.Add(c);
//         startArcalod.GetComponent<ConversationScript>().OnAfterDeserialize();
//
//         //CHECKPOINT
//         suiteArcalod.GetComponent<ConversationScript>().items.Clear();
//
//         ConversationOption o1 = new ConversationOption() { text = data[134].branche1Reponse, targetId = data[134].branche1ID };
//         ConversationOption o2 = new ConversationOption() { text = data[134].branche2Reponse, targetId = data[134].branche2ID };
//         ConversationPiece c1 = new ConversationPiece() { id = data[134].ID, text = data[134].texte, options = new List<ConversationOption>(), hint = data[134].hint };
//         c1.options.Add(o1);
//         c1.options.Add(o2);
//         suiteArcalod.GetComponent<ConversationScript>().Add(c1);
//
//         ConversationPiece c2 = new ConversationPiece() { id = data[135].ID, text = data[135].texte, options = new List<ConversationOption>(), hint = data[135].hint };
//         suiteArcalod.GetComponent<ConversationScript>().Add(c2);
//         suiteArcalod.GetComponent<ConversationScript>().OnAfterDeserialize();
//         startArcalod.GetComponent<ConversationScript>().items.Clear();
//         randoEnCours = true;
//         tpsRando = 0;
//
//     }
//
//     public void suiteRandoArcalod()
//     {
//         ency.addInfoToList(data2[60].hint, ency.quete);
//         //SELF
//         suiteArcalod.GetComponent<ConversationScript>().items.Clear();
//         ConversationPiece c = new ConversationPiece() { id = data[136].ID, text = data[136].texte, options = new List<ConversationOption>(), hint = data[136].hint };
//         suiteArcalod.GetComponent<ConversationScript>().items.Add(c);
//         suiteArcalod.GetComponent<ConversationScript>().OnAfterDeserialize();
//
//         //END POINT
//         endArcalod.GetComponent<ConversationScript>().items.Clear();
//
//         ConversationOption o1 = new ConversationOption() { text = data[137].branche1Reponse, targetId = data[137].branche1ID };
//         ConversationOption o2 = new ConversationOption() { text = data[137].branche2Reponse, targetId = data[137].branche2ID };
//         ConversationPiece c1 = new ConversationPiece() { id = data[137].ID, text = data[137].texte, options = new List<ConversationOption>(), hint = data[137].hint };
//         c1.options.Add(o1);
//         c1.options.Add(o2);
//         endArcalod.GetComponent<ConversationScript>().Add(c1);
//
//         ConversationPiece c2 = new ConversationPiece() { id = data[138].ID, text = data[138].texte, options = new List<ConversationOption>(), hint = data[138].hint };
//         endArcalod.GetComponent<ConversationScript>().Add(c2);
//         endArcalod.GetComponent<ConversationScript>().OnAfterDeserialize();
//         suiteArcalod.GetComponent<ConversationScript>().items.Clear();
//
//     }
//
//     public void terminerArcalod()
//     {
//         ency.addInfoToList(data2[71].hint, ency.quete);
//         endArcalod.GetComponent<ConversationScript>().items.Clear();
//         ConversationPiece c = new ConversationPiece() { id = data[139].ID, text = data[139].texte, options = new List<ConversationOption>(), hint = data[139].hint };
//         endArcalod.GetComponent<ConversationScript>().items.Add(c);
//         endArcalod.GetComponent<ConversationScript>().OnAfterDeserialize();
//         actArcalod = false;
//
//         randoEnCours = false;
//
//         rnd = 10000 - (25 * (int)tpsRando); 
//         GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().arcalodCurrent = rnd;
//
//         if (GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().arcalod == false)
//         {
//             GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().arcalod = true;
//             GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().nbRando += 1;
//             GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().arcalodScore = GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().arcalodCurrent;
//             GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().arcalodCurrent = 0;
//             dataSt.setData("arcalodScore", GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().arcalodScore);
//         }
//         else
//         {
//             if (GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().arcalodScore < GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().arcalodCurrent)
//             {
//                 GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().arcalodScore = GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().arcalodCurrent;
//                 GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().arcalodCurrent = 0;
//                 dataSt.setData("arcalodScore", GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().arcalodScore);
//             }
//             else
//             {
//                 GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().arcalodCurrent = 0;
//             }
//         }
//         if (meilleureRando < rnd)
//         {
//             meilleureRando = rnd;
//             PlayerPrefs.SetInt("meilleureRando", meilleureRando);
//         }
//         donneurQuete();
//
//     }
//
//     // Randonnée du Mont Trélod
//
//     public void donnerRandoTrelod()
//     {
//         ency.addInfoToList(data2[39].hint, ency.quete);
//         //SELF
//         conversationScript.items.Clear();
//         ConversationPiece c = new ConversationPiece() { id = data[140].ID, text = data[140].texte, options = new List<ConversationOption>(), hint = data[140].hint };
//         conversationScript.items.Add(c);
//         conversationScript.OnAfterDeserialize();
//
//         //START POINT
//         startTrelod.GetComponent<ConversationScript>().items.Clear();
//
//         ConversationOption o1 = new ConversationOption() { text = data[141].branche1Reponse, targetId = data[141].branche1ID };
//         ConversationOption o2 = new ConversationOption() { text = data[141].branche2Reponse, targetId = data[141].branche2ID };
//         ConversationPiece c1 = new ConversationPiece() { id = data[141].ID, text = data[141].texte, options = new List<ConversationOption>(), hint = data[141].hint };
//         c1.options.Add(o1);
//         c1.options.Add(o2);
//         startTrelod.GetComponent<ConversationScript>().Add(c1);
//
//         ConversationPiece c2 = new ConversationPiece() { id = data[142].ID, text = data[142].texte, options = new List<ConversationOption>(), hint = data[142].hint };
//         startTrelod.GetComponent<ConversationScript>().Add(c2);
//         startTrelod.GetComponent<ConversationScript>().OnAfterDeserialize();
//         actTrelod = true;
//     }
//
//     public void lancerRandoTrelod()
//     {
//         ency.addInfoToList(data2[50].hint, ency.quete);
//         //SELF
//         startTrelod.GetComponent<ConversationScript>().items.Clear();
//         ConversationPiece c = new ConversationPiece() { id = data[143].ID, text = data[143].texte, options = new List<ConversationOption>(), hint = data[143].hint };
//         startTrelod.GetComponent<ConversationScript>().items.Add(c);
//         startTrelod.GetComponent<ConversationScript>().OnAfterDeserialize();
//
//         //CHECKPOINT
//         suiteTrelod.GetComponent<ConversationScript>().items.Clear();
//
//         ConversationOption o1 = new ConversationOption() { text = data[144].branche1Reponse, targetId = data[144].branche1ID };
//         ConversationOption o2 = new ConversationOption() { text = data[144].branche2Reponse, targetId = data[144].branche2ID };
//         ConversationPiece c1 = new ConversationPiece() { id = data[144].ID, text = data[144].texte, options = new List<ConversationOption>(), hint = data[144].hint };
//         c1.options.Add(o1);
//         c1.options.Add(o2);
//         suiteTrelod.GetComponent<ConversationScript>().Add(c1);
//
//         ConversationPiece c2 = new ConversationPiece() { id = data[145].ID, text = data[145].texte, options = new List<ConversationOption>(), hint = data[145].hint };
//         suiteTrelod.GetComponent<ConversationScript>().Add(c2);
//         suiteTrelod.GetComponent<ConversationScript>().OnAfterDeserialize();
//         startTrelod.GetComponent<ConversationScript>().items.Clear();
//         randoEnCours = true;
//         tpsRando = 0;
//
//     }
//
//     public void suiteRandoTrelod()
//     {
//         ency.addInfoToList(data2[61].hint, ency.quete);
//         //SELF
//         suiteTrelod.GetComponent<ConversationScript>().items.Clear();
//         ConversationPiece c = new ConversationPiece() { id = data[146].ID, text = data[146].texte, options = new List<ConversationOption>(), hint = data[146].hint };
//         suiteTrelod.GetComponent<ConversationScript>().items.Add(c);
//         suiteTrelod.GetComponent<ConversationScript>().OnAfterDeserialize();
//
//         //END POINT
//         endTrelod.GetComponent<ConversationScript>().items.Clear();
//
//         ConversationOption o1 = new ConversationOption() { text = data[147].branche1Reponse, targetId = data[147].branche1ID };
//         ConversationOption o2 = new ConversationOption() { text = data[147].branche2Reponse, targetId = data[147].branche2ID };
//         ConversationPiece c1 = new ConversationPiece() { id = data[147].ID, text = data[147].texte, options = new List<ConversationOption>(), hint = data[147].hint };
//         c1.options.Add(o1);
//         c1.options.Add(o2);
//         endTrelod.GetComponent<ConversationScript>().Add(c1);
//
//         ConversationPiece c2 = new ConversationPiece() { id = data[148].ID, text = data[148].texte, options = new List<ConversationOption>(), hint = data[148].hint };
//         endTrelod.GetComponent<ConversationScript>().Add(c2);
//         endTrelod.GetComponent<ConversationScript>().OnAfterDeserialize();
//         suiteTrelod.GetComponent<ConversationScript>().items.Clear();
//
//     }
//
//     public void terminerTrelod()
//     {
//         ency.addInfoToList(data2[72].hint, ency.quete);
//         endTrelod.GetComponent<ConversationScript>().items.Clear();
//         ConversationPiece c = new ConversationPiece() { id = data[149].ID, text = data[149].texte, options = new List<ConversationOption>(), hint = data[149].hint };
//         endTrelod.GetComponent<ConversationScript>().items.Add(c);
//         endTrelod.GetComponent<ConversationScript>().OnAfterDeserialize();
//         actTrelod = false;
//
//         randoEnCours = false;
//
//         rnd = 10000 - (25 * (int)tpsRando);
//         GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().trelodCurrent = rnd;
//
//         if (GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().trelod == false)
//         {
//             GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().trelod = true;
//             GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().nbRando += 1;
//             GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().trelodScore = GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().trelodCurrent;
//             GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().trelodCurrent = 0;
//             dataSt.setData("trelodScore", GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().trelodScore);
//         }
//         else
//         {
//             if (GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().trelodScore < GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().trelodCurrent)
//             {
//                 GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().trelodScore = GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().trelodCurrent;
//                 GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().trelodCurrent = 0;
//                 dataSt.setData("trelodScore", GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().trelodScore);
//             }
//             else
//             {
//                 GOPointer.PlayerRandonneur.GetComponent<PlayerRandonneur>().trelodCurrent = 0;
//             }
//         }
//         if (meilleureRando < rnd)
//         {
//             meilleureRando = rnd;
//             PlayerPrefs.SetInt("meilleureRando", meilleureRando);
//         }
//         donneurQuete();
//
//     }
//
//     public void donneurQuete()
//     {
//         ConversationOption o1 = new ConversationOption() { text = data[0].branche1Reponse, targetId = data[0].branche1ID };
//         ConversationOption o2 = new ConversationOption() { text = data[0].branche2Reponse, targetId = data[0].branche2ID };
//         ConversationOption o3 = new ConversationOption() { text = data[0].branche3Reponse, targetId = data[0].branche3ID };
//         ConversationPiece c1 = new ConversationPiece() { id = data[0].ID, text = data[0].texte, options = new List<ConversationOption>(), hint = data[0].hint };
//         c1.options.Add(o1);
//         c1.options.Add(o2);
//         c1.options.Add(o3);
//         conversationScript.Add(c1);
//
//         o1 = new ConversationOption() { text = data[1].branche1Reponse, targetId = data[1].branche1ID };
//         o2 = new ConversationOption() { text = data[1].branche2Reponse, targetId = data[1].branche2ID };
//         c1 = new ConversationPiece() { id = data[1].ID, text = data[1].texte, options = new List<ConversationOption>(), hint = data[1].hint };
//         c1.options.Add(o1);
//         c1.options.Add(o2);
//         conversationScript.Add(c1);
//
//         c1 = new ConversationPiece() { id = data[2].ID, text = data[2].texte, options = new List<ConversationOption>(), hint = data[2].hint };
//         conversationScript.Add(c1);
//
//         c1 = new ConversationPiece() { id = data[3].ID, text = data[3].texte, options = new List<ConversationOption>(), hint = data[3].hint };
//         conversationScript.Add(c1);
//
//         o1 = new ConversationOption() { text = data[4].branche1Reponse, targetId = data[4].branche1ID };
//         o2 = new ConversationOption() { text = data[4].branche2Reponse, targetId = data[4].branche2ID };
//         c1 = new ConversationPiece() { id = data[4].ID, text = data[4].texte, options = new List<ConversationOption>(), hint = data[4].hint };
//         c1.options.Add(o1);
//         c1.options.Add(o2);
//         conversationScript.Add(c1);
//
//         c1 = new ConversationPiece() { id = data[5].ID, text = data[5].texte, options = new List<ConversationOption>(), hint = data[5].hint };
//         conversationScript.Add(c1);
//
//         c1 = new ConversationPiece() { id = data[6].ID, text = data[6].texte, options = new List<ConversationOption>(), hint = data[6].hint };
//         conversationScript.Add(c1);
//
//         o1 = new ConversationOption() { text = data[7].branche1Reponse, targetId = data[7].branche1ID };
//         o2 = new ConversationOption() { text = data[7].branche2Reponse, targetId = data[7].branche2ID };
//         o3 = new ConversationOption() { text = data[7].branche3Reponse, targetId = data[7].branche3ID };
//         c1 = new ConversationPiece() { id = data[7].ID, text = data[7].texte, options = new List<ConversationOption>(), hint = data[7].hint };
//         c1.options.Add(o1);
//         c1.options.Add(o2);
//         c1.options.Add(o3);
//         conversationScript.Add(c1);
//
//         o1 = new ConversationOption() { text = data[8].branche1Reponse, targetId = data[8].branche1ID };
//         o2 = new ConversationOption() { text = data[8].branche2Reponse, targetId = data[8].branche2ID };
//         c1 = new ConversationPiece() { id = data[8].ID, text = data[8].texte, options = new List<ConversationOption>(), hint = data[8].hint };
//         c1.options.Add(o1);
//         c1.options.Add(o2);
//         conversationScript.Add(c1);
//
//         c1 = new ConversationPiece() { id = data[9].ID, text = data[9].texte, options = new List<ConversationOption>(), hint = data[9].hint };
//         conversationScript.Add(c1);
//
//         c1 = new ConversationPiece() { id = data[10].ID, text = data[10].texte, options = new List<ConversationOption>(), hint = data[10].hint };
//         conversationScript.Add(c1);
//
//         o1 = new ConversationOption() { text = data[11].branche1Reponse, targetId = data[11].branche1ID };
//         o2 = new ConversationOption() { text = data[11].branche2Reponse, targetId = data[11].branche2ID };
//         c1 = new ConversationPiece() { id = data[11].ID, text = data[11].texte, options = new List<ConversationOption>(), hint = data[11].hint };
//         c1.options.Add(o1);
//         c1.options.Add(o2);
//         conversationScript.Add(c1);
//
//         c1 = new ConversationPiece() { id = data[12].ID, text = data[12].texte, options = new List<ConversationOption>(), hint = data[12].hint };
//         conversationScript.Add(c1);
//
//         c1 = new ConversationPiece() { id = data[13].ID, text = data[13].texte, options = new List<ConversationOption>(), hint = data[13].hint };
//         conversationScript.Add(c1);
//
//         o1 = new ConversationOption() { text = data[14].branche1Reponse, targetId = data[14].branche1ID };
//         o2 = new ConversationOption() { text = data[14].branche2Reponse, targetId = data[14].branche2ID };
//         o3 = new ConversationOption() { text = data[14].branche3Reponse, targetId = data[14].branche3ID };
//         c1 = new ConversationPiece() { id = data[14].ID, text = data[14].texte, options = new List<ConversationOption>(), hint = data[14].hint };
//         c1.options.Add(o1);
//         c1.options.Add(o2);
//         c1.options.Add(o3);
//         conversationScript.Add(c1);
//
//         o1 = new ConversationOption() { text = data[15].branche1Reponse, targetId = data[15].branche1ID };
//         o2 = new ConversationOption() { text = data[15].branche2Reponse, targetId = data[15].branche2ID };
//         c1 = new ConversationPiece() { id = data[15].ID, text = data[15].texte, options = new List<ConversationOption>(), hint = data[15].hint };
//         c1.options.Add(o1);
//         c1.options.Add(o2);
//         conversationScript.Add(c1);
//
//         c1 = new ConversationPiece() { id = data[16].ID, text = data[16].texte, options = new List<ConversationOption>(), hint = data[16].hint };
//         conversationScript.Add(c1);
//
//         c1 = new ConversationPiece() { id = data[17].ID, text = data[17].texte, options = new List<ConversationOption>(), hint = data[17].hint };
//         conversationScript.Add(c1);
//
//         o1 = new ConversationOption() { text = data[18].branche1Reponse, targetId = data[18].branche1ID };
//         o2 = new ConversationOption() { text = data[18].branche2Reponse, targetId = data[18].branche2ID };
//         c1 = new ConversationPiece() { id = data[18].ID, text = data[18].texte, options = new List<ConversationOption>(), hint = data[18].hint };
//         c1.options.Add(o1);
//         c1.options.Add(o2);
//         conversationScript.Add(c1);
//
//         c1 = new ConversationPiece() { id = data[19].ID, text = data[19].texte, options = new List<ConversationOption>(), hint = data[19].hint };
//         conversationScript.Add(c1);
//
//         c1 = new ConversationPiece() { id = data[20].ID, text = data[20].texte, options = new List<ConversationOption>(), hint = data[20].hint };
//         conversationScript.Add(c1);
//
//         o1 = new ConversationOption() { text = data[21].branche1Reponse, targetId = data[21].branche1ID };
//         o2 = new ConversationOption() { text = data[21].branche2Reponse, targetId = data[21].branche2ID };
//         o3 = new ConversationOption() { text = data[21].branche3Reponse, targetId = data[21].branche3ID };
//         c1 = new ConversationPiece() { id = data[21].ID, text = data[21].texte, options = new List<ConversationOption>(), hint = data[21].hint };
//         c1.options.Add(o1);
//         c1.options.Add(o2);
//         c1.options.Add(o3);
//         conversationScript.Add(c1);
//
//         o1 = new ConversationOption() { text = data[22].branche1Reponse, targetId = data[22].branche1ID };
//         o2 = new ConversationOption() { text = data[22].branche2Reponse, targetId = data[22].branche2ID };
//         c1 = new ConversationPiece() { id = data[22].ID, text = data[22].texte, options = new List<ConversationOption>(), hint = data[22].hint };
//         c1.options.Add(o1);
//         c1.options.Add(o2);
//         conversationScript.Add(c1);
//
//         c1 = new ConversationPiece() { id = data[23].ID, text = data[23].texte, options = new List<ConversationOption>(), hint = data[23].hint };
//         conversationScript.Add(c1);
//
//         c1 = new ConversationPiece() { id = data[24].ID, text = data[24].texte, options = new List<ConversationOption>(), hint = data[24].hint };
//         conversationScript.Add(c1);
//
//         o1 = new ConversationOption() { text = data[25].branche1Reponse, targetId = data[25].branche1ID };
//         o2 = new ConversationOption() { text = data[25].branche2Reponse, targetId = data[25].branche2ID };
//         c1 = new ConversationPiece() { id = data[25].ID, text = data[25].texte, options = new List<ConversationOption>(), hint = data[25].hint };
//         c1.options.Add(o1);
//         c1.options.Add(o2);
//         conversationScript.Add(c1);
//
//         c1 = new ConversationPiece() { id = data[26].ID, text = data[26].texte, options = new List<ConversationOption>(), hint = data[26].hint };
//         conversationScript.Add(c1);
//
//         c1 = new ConversationPiece() { id = data[27].ID, text = data[27].texte, options = new List<ConversationOption>(), hint = data[27].hint };
//         conversationScript.Add(c1);
//
//         o1 = new ConversationOption() { text = data[28].branche1Reponse, targetId = data[28].branche1ID };
//         o2 = new ConversationOption() { text = data[28].branche2Reponse, targetId = data[28].branche2ID };
//         o3 = new ConversationOption() { text = data[28].branche3Reponse, targetId = data[28].branche3ID };
//         c1 = new ConversationPiece() { id = data[28].ID, text = data[28].texte, options = new List<ConversationOption>(), hint = data[28].hint };
//         c1.options.Add(o1);
//         c1.options.Add(o2);
//         c1.options.Add(o3);
//         conversationScript.Add(c1);
//
//         o1 = new ConversationOption() { text = data[29].branche1Reponse, targetId = data[29].branche1ID };
//         o2 = new ConversationOption() { text = data[29].branche2Reponse, targetId = data[29].branche2ID };
//         c1 = new ConversationPiece() { id = data[29].ID, text = data[29].texte, options = new List<ConversationOption>(), hint = data[29].hint };
//         c1.options.Add(o1);
//         c1.options.Add(o2);
//         conversationScript.Add(c1);
//
//         c1 = new ConversationPiece() { id = data[30].ID, text = data[30].texte, options = new List<ConversationOption>(), hint = data[30].hint };
//         conversationScript.Add(c1);
//
//         c1 = new ConversationPiece() { id = data[31].ID, text = data[31].texte, options = new List<ConversationOption>(), hint = data[31].hint };
//         conversationScript.Add(c1);
//
//         o1 = new ConversationOption() { text = data[32].branche1Reponse, targetId = data[32].branche1ID };
//         o2 = new ConversationOption() { text = data[32].branche2Reponse, targetId = data[32].branche2ID };
//         c1 = new ConversationPiece() { id = data[32].ID, text = data[32].texte, options = new List<ConversationOption>(), hint = data[32].hint };
//         c1.options.Add(o1);
//         c1.options.Add(o2);
//         conversationScript.Add(c1);
//
//         c1 = new ConversationPiece() { id = data[33].ID, text = data[33].texte, options = new List<ConversationOption>(), hint = data[33].hint };
//         conversationScript.Add(c1);
//
//         c1 = new ConversationPiece() { id = data[34].ID, text = data[34].texte, options = new List<ConversationOption>(), hint = data[34].hint };
//         conversationScript.Add(c1);
//
//         o1 = new ConversationOption() { text = data[35].branche1Reponse, targetId = data[35].branche1ID };
//         o2 = new ConversationOption() { text = data[35].branche2Reponse, targetId = data[35].branche2ID };
//         c1 = new ConversationPiece() { id = data[35].ID, text = data[35].texte, options = new List<ConversationOption>(), hint = data[35].hint };
//         c1.options.Add(o1);
//         c1.options.Add(o2);
//         conversationScript.Add(c1);
//
//         o1 = new ConversationOption() { text = data[36].branche1Reponse, targetId = data[36].branche1ID };
//         o2 = new ConversationOption() { text = data[36].branche2Reponse, targetId = data[36].branche2ID };
//         c1 = new ConversationPiece() { id = data[36].ID, text = data[36].texte, options = new List<ConversationOption>(), hint = data[36].hint };
//         c1.options.Add(o1);
//         c1.options.Add(o2);
//         conversationScript.Add(c1);
//
//         c1 = new ConversationPiece() { id = data[37].ID, text = data[37].texte, options = new List<ConversationOption>(), hint = data[37].hint };
//         conversationScript.Add(c1);
//
//         c1 = new ConversationPiece() { id = data[38].ID, text = data[38].texte, options = new List<ConversationOption>(), hint = data[38].hint };
//         conversationScript.Add(c1);
//
//         c1 = new ConversationPiece() { id = data[39].ID, text = data[39].texte, options = new List<ConversationOption>(), hint = data[39].hint };
//         conversationScript.Add(c1);
//
//         conversationScript.OnAfterDeserialize();
//
//         //textRando.SetText("Randonnées découvertes : \n{0} / 11", 11);
//     }
//
// }