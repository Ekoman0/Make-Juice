using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.SmartFormat.Utilities;



[ExecuteInEditMode]
public class LevelMaker : MonoBehaviour
{
  
    public FinishFruit FinishFruit;
    public TextMeshProUGUI MakeJuiceText;
    public FinishJuice FinishJuice;
    public TextMeshProUGUI LevelText;

    public SpawnFruits SpawnSystem;
    public GameObject RedLine;
    public Vector3 RedLinePosition;
    public GameObject GreenLine;
    public Vector3 GreenLinePosition;
    public GameObject JuiceColor;

    public Material[] JuiceMaterial;
    public GameObject[] Strawberry; 
    public GameObject[] Mandarin; 
    public GameObject[] Apple; 
    public GameObject[] Tomato; 
    public GameObject[] Grapes;
    public GameObject[] Pineapple;
    public GameObject[] Melon;
    public GameObject[] Watermelon;

    public static string ChoosedJuice;

    private void OnValidate()
    {

        //RedLine.transform.position = RedLinePosition;

        //GreenLine.transform.position = GreenLinePosition;


    }
 

    public void RedLineTransform()
    {
        RedLine.transform.position = new Vector3(0.19f, UnityEngine.Random.Range(-2f, 2f), 0f);

        RedLinePosition = RedLine.transform.position;
    }

    public void GreenLineTransform()
    {
        GreenLine.transform.position = new Vector3(0.19f, UnityEngine.Random.Range(-2f, 2f), 0f);

        GreenLinePosition = RedLine.transform.position;
    }

    public void SetSceneName(string Nextlevel, string NowLevel)
    {
        FinishFruit.NextLevelScene = NowLevel;
        FinishJuice.NextLevelScene = Nextlevel;
        LevelText.text = NowLevel;
    }

    public void ChooseJuice()
    {
        int a = UnityEngine.Random.Range(0, 8);
      
        if (a == 0)
        {
          
            SpawnSystem.Fruits = new GameObject[2];
            for (int i = 0; i < Strawberry.Length; i++)
            {
                SpawnSystem.Fruits[i] = Strawberry[i];
            }
            ChoosedJuice = "Strawberry was chosen";
            JuiceColor.GetComponent<Renderer>().material = JuiceMaterial[0];

            MakeJuiceText.gameObject.GetComponent<LocalizeStringEvent>().StringReference.TableReference = "Tutorial";
            MakeJuiceText.gameObject.GetComponent<LocalizeStringEvent>().StringReference.TableEntryReference = "StrawberryJuice";
            MakeJuiceText.text = "ÇİLEK SUYU YAP";




        }

        if (a == 1)
        {

            SpawnSystem.Fruits = new GameObject[3];
            for (int i = 0; i < Mandarin.Length; i++)
            {
                SpawnSystem.Fruits[i] = Mandarin[i];
            }
            ChoosedJuice = "Mandarin was chosen";
            JuiceColor.GetComponent<Renderer>().material = JuiceMaterial[1];

            MakeJuiceText.gameObject.GetComponent<LocalizeStringEvent>().StringReference.TableReference = "Tutorial";
            MakeJuiceText.gameObject.GetComponent<LocalizeStringEvent>().StringReference.TableEntryReference = "MandarinJuice";
            MakeJuiceText.text = "MANDALİNA SUYU YAP";




        }

        if (a == 2)
        {

            SpawnSystem.Fruits = new GameObject[4];
            for (int i = 0; i < Apple.Length; i++)
            {
                SpawnSystem.Fruits[i] = Apple[i];
            }
            ChoosedJuice = "Apple was chosen";
            JuiceColor.GetComponent<Renderer>().material = JuiceMaterial[0];

            MakeJuiceText.gameObject.GetComponent<LocalizeStringEvent>().StringReference.TableReference = "Tutorial";
            MakeJuiceText.gameObject.GetComponent<LocalizeStringEvent>().StringReference.TableEntryReference = "AppleJuice";
            MakeJuiceText.text = "ELMA SUYU YAP";



        }

        if (a == 3)
        {
            SpawnSystem.Fruits = new GameObject[5];
            for (int i = 0; i < Tomato.Length; i++)
            {
                SpawnSystem.Fruits[i] = Tomato[i];
            }
            ChoosedJuice = "Tomato was chosen";
            JuiceColor.GetComponent<Renderer>().material = JuiceMaterial[0];

            MakeJuiceText.gameObject.GetComponent<LocalizeStringEvent>().StringReference.TableReference = "Tutorial";
            MakeJuiceText.gameObject.GetComponent<LocalizeStringEvent>().StringReference.TableEntryReference = "TomatoJuice";
            MakeJuiceText.text = "DOMATES SUYU YAP";




        }

        if (a == 4)
        {
            SpawnSystem.Fruits = new GameObject[6];
            for (int i = 0; i < Grapes.Length; i++)
            {
                SpawnSystem.Fruits[i] = Grapes[i];
            }
            ChoosedJuice = "Grapes was chosen";
            JuiceColor.GetComponent<Renderer>().material = JuiceMaterial[2];

            MakeJuiceText.gameObject.GetComponent<LocalizeStringEvent>().StringReference.TableReference = "Tutorial";
            MakeJuiceText.gameObject.GetComponent<LocalizeStringEvent>().StringReference.TableEntryReference = "GrapesJuice";
            MakeJuiceText.text = "ÜZÜM SUYU YAP";




        }

        if (a == 5)
        {
            SpawnSystem.Fruits = new GameObject[7];
            for (int i = 0; i < Pineapple.Length; i++)
            {
                SpawnSystem.Fruits[i] = Pineapple[i];
            }
            JuiceColor.GetComponent<Renderer>().material = JuiceMaterial[3];

            ChoosedJuice = "Pineapple was chosen";

            MakeJuiceText.gameObject.GetComponent<LocalizeStringEvent>().StringReference.TableReference = "Tutorial";
            MakeJuiceText.gameObject.GetComponent<LocalizeStringEvent>().StringReference.TableEntryReference = "PineappleJuice";
            MakeJuiceText.text = "ANANAS SUYU YAP";



        }

        if (a == 6)
        {
            SpawnSystem.Fruits = new GameObject[8];
            for (int i = 0; i < Melon.Length; i++)
            {
                SpawnSystem.Fruits[i] = Melon[i];
            }
            ChoosedJuice = "Melon was chosen";
            JuiceColor.GetComponent<Renderer>().material = JuiceMaterial[3];

            MakeJuiceText.gameObject.GetComponent<LocalizeStringEvent>().StringReference.TableReference = "Tutorial";
            MakeJuiceText.gameObject.GetComponent<LocalizeStringEvent>().StringReference.TableEntryReference = "MelonJuice";
            MakeJuiceText.text = "KAVUN SUYU YAP";


        }

        if (a == 7)
        {
            SpawnSystem.Fruits = new GameObject[9];
            for (int i = 0; i < Watermelon.Length; i++)
            {
                SpawnSystem.Fruits[i] = Watermelon[i];
            }
            ChoosedJuice = "Watermelon was chosen";
            JuiceColor.GetComponent<Renderer>().material = JuiceMaterial[0];
          
            MakeJuiceText.gameObject.GetComponent<LocalizeStringEvent>().StringReference.TableReference = "Tutorial";
            MakeJuiceText.gameObject.GetComponent<LocalizeStringEvent>().StringReference.TableEntryReference = "WatermelonJuice";
            MakeJuiceText.text = "KARPUZ SUYU YAP";



        }
    }
}
