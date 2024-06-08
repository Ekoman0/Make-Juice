/*
using System;
using TMPro;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LevelMaker))]
public class LevelMakerEditor : Editor
{
    public string NextLevel = "Level";
    public string NowLevel = "Level";
    public override void OnInspectorGUI()
    {
        // Varsay�lan Inspector'� �iz
       //DrawDefaultInspector();

        // CubeController referans�n� al
        LevelMaker myScript = (LevelMaker)target;

        // Buton ekle
        if (GUILayout.Button("Create Level"))
        {
            // Butona t�kland���nda ApplyChanges metodunu �a��r
            myScript.RedLineTransform();
            myScript.GreenLineTransform();
            myScript.ChooseJuice();
        }

        EditorGUILayout.Space(); // Bo�luk eklemek i�in
        EditorGUILayout.Space(); // Bo�luk eklemek i�in
        EditorGUILayout.Space(); // Bo�luk eklemek i�in



        myScript.RedLine = (GameObject)EditorGUILayout.ObjectField("RedLine", myScript.RedLine, typeof(GameObject), true);
        myScript.RedLinePosition = EditorGUILayout.Vector3Field("RedLinePosition", myScript.RedLinePosition);

        // Buton ekle
        if (GUILayout.Button("Random RedLine Transform"))
        {
            // Butona t�kland���nda ApplyChanges metodunu �a��r
            myScript.RedLineTransform();
        }
        myScript.GreenLine = (GameObject)EditorGUILayout.ObjectField("GreenLine", myScript.GreenLine, typeof(GameObject), true);
        myScript.GreenLinePosition = EditorGUILayout.Vector3Field("GreenLinePosition", myScript.GreenLinePosition);


        if (GUILayout.Button("Random GreenLine Transform"))
        {
            // Butona t�kland���nda ApplyChanges metodunu �a��r
            myScript.GreenLineTransform();
        }

        myScript.SpawnSystem = (SpawnFruits)EditorGUILayout.ObjectField("SpawnSystem", myScript.SpawnSystem, typeof(SpawnFruits), true);
       

        SerializedProperty strawberryArray = serializedObject.FindProperty("Strawberry");
        EditorGUILayout.PropertyField(strawberryArray, new GUIContent("Strawberry"), true);

        SerializedProperty MandarinArray = serializedObject.FindProperty("Mandarin");
        EditorGUILayout.PropertyField(MandarinArray, new GUIContent("Mandarin"), true);

        SerializedProperty AppleAray = serializedObject.FindProperty("Apple");
        EditorGUILayout.PropertyField(AppleAray, new GUIContent("Apple"), true);

        SerializedProperty TomatoArray = serializedObject.FindProperty("Tomato");
        EditorGUILayout.PropertyField(TomatoArray, new GUIContent("Tomato"), true);

        SerializedProperty GrapesArray = serializedObject.FindProperty("Grapes");
        EditorGUILayout.PropertyField(GrapesArray, new GUIContent("Grapes"), true);

        SerializedProperty PineappleArray = serializedObject.FindProperty("Pineapple");
        EditorGUILayout.PropertyField(PineappleArray, new GUIContent("Pineapple"), true);

        SerializedProperty MelonArray = serializedObject.FindProperty("Melon");
        EditorGUILayout.PropertyField(MelonArray, new GUIContent("Melon"), true);

        SerializedProperty WatermelonArray = serializedObject.FindProperty("Watermelon");
        EditorGUILayout.PropertyField(WatermelonArray, new GUIContent("Watermelon"), true);


        SerializedProperty JuiceMaterial = serializedObject.FindProperty("JuiceMaterial");
        EditorGUILayout.PropertyField(JuiceMaterial, new GUIContent("JuiceMaterial"), true);

        myScript.JuiceColor = (GameObject)EditorGUILayout.ObjectField("JuiceColor", myScript.JuiceColor, typeof(GameObject), true);

        if (GUILayout.Button("Choose Juice"))
        {
            // Butona t�kland���nda ApplyChanges metodunu �a��r
            myScript.ChooseJuice();
        }

        myScript.FinishFruit = (FinishFruit)EditorGUILayout.ObjectField("FinishFruit", myScript.FinishFruit, typeof(FinishFruit), true);
        myScript.FinishJuice = (FinishJuice)EditorGUILayout.ObjectField("FinishJuice", myScript.FinishJuice, typeof(FinishJuice), true);
        myScript.LevelText = (TextMeshProUGUI)EditorGUILayout.ObjectField("FinishJuice", myScript.LevelText, typeof(TextMeshProUGUI), true);


        NextLevel = EditorGUILayout.TextField("NextLevel:", NextLevel);
        NowLevel= EditorGUILayout.TextField("NowLevel:", NowLevel);

        // Buton ekle
        if (GUILayout.Button("Save Level Name"))
        {
            // Butona t�kland���nda ApplyChanges metodunu �a��r
            myScript.SetSceneName(NextLevel,NowLevel);
        }

        myScript.MakeJuiceText = (TextMeshProUGUI)EditorGUILayout.ObjectField("Make Juice Text", myScript.MakeJuiceText, typeof(TextMeshProUGUI), true);


        // De�i�iklikleri uygula
        serializedObject.ApplyModifiedProperties();

       



        EditorGUILayout.LabelField(LevelMaker.ChoosedJuice, EditorStyles.boldLabel);

        if (GUI.changed)
        {
            EditorUtility.SetDirty(myScript);
        }
    }
}
*/