﻿using System;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;


public class SaveWindow : EditorWindow
{
    private float _saveTime = 42f;
    private float _nextSave = 0f;

    [MenuItem("Window/NOBODY_CAN_SAVE_ME_NOW")]
    public static void ShowSaveWindow()
    {
        SaveWindow sw = GetWindow<SaveWindow>("SAVER");
        sw.minSize = new Vector2(1, 0.1f);
        sw.Save();
    }

    private void OnGUI()
    {
        int timeToSave = (int)(_nextSave - EditorApplication.timeSinceStartup);
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Save each:");
        int num;
        if (int.TryParse(EditorGUILayout.TextField(_saveTime.ToString()), out num))
        {
            _saveTime = num;
        }
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Next save in:");
        GUILayout.Label(timeToSave + " sec");
        EditorGUILayout.EndHorizontal();

        if (GUILayout.Button("SAVE") || EditorApplication.timeSinceStartup > _nextSave)
        {
            Save();
        }
        Repaint();
    }

    private void Save()
    {
        EditorSceneManager.SaveOpenScenes();
        Debug.Log("Auto Saved " + DateTime.Now.ToLongTimeString());
        _nextSave = (int)(EditorApplication.timeSinceStartup + _saveTime);
    }
}