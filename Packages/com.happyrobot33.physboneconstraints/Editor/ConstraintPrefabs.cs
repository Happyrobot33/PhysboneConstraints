using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

namespace PhysboneConstraints.Editor
{
    //scriptableobject class for storing all the references to the constraints prefabs
    [CreateAssetMenu(fileName = "ConstraintPrefabs", menuName = "Physbone Constraints/Constraint Prefabs", order = 1)]
    public class ConstraintPrefabs : ScriptableObject
    {
        public List<Prefab> prefabs = new List<Prefab>();
    }

    //editor for ConstraintPrefabs
    [CustomEditor(typeof(ConstraintPrefabs))]
    public class ConstraintPrefabsEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            //we want to show the array of prefabs with + and - buttons instead of the default array drawer, along with not having the foldout and the size field

            //get the constraint prefabs
            SerializedProperty prefabs = serializedObject.FindProperty(nameof(ConstraintPrefabs.prefabs));

            //draw the array header
            EditorGUILayout.BeginHorizontal();
            Rect headerRect = GUILayoutUtility.GetRect(0, EditorGUIUtility.singleLineHeight);
            //add the add button to the header
            if (GUI.Button(new Rect(headerRect.x, headerRect.y, 20, headerRect.height), "+"))
            {
                //add a new element to the array
                prefabs.InsertArrayElementAtIndex(prefabs.arraySize);
                //make sure we save the changes
                serializedObject.ApplyModifiedProperties();
            }
            //place the label next to the button
            EditorGUI.LabelField(new Rect(headerRect.x + 20, headerRect.y, headerRect.width - 20, headerRect.height), "Constraint Prefabs");
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginVertical();

            //draw the array
            for (int i = 0; i < prefabs.arraySize; i++)
            {
                //get the prefab
                SerializedProperty prefab = prefabs.GetArrayElementAtIndex(i);

                //get the property drawer for the prefab
                PropertyDrawer drawer = new PrefabDrawer();

                //create a rect
                Rect rect = GUILayoutUtility.GetRect(0, drawer.GetPropertyHeight(prefab, GUIContent.none));

                //draw the prefab
                drawer.OnGUI(rect, prefab, GUIContent.none);

                //display a remove button in the rect
                if (GUI.Button(new Rect(rect.x + PrefabDrawer.outlineWidth, rect.y + PrefabDrawer.outlineWidth, 20, 20), "-"))
                {
                    //remove the prefab
                    prefabs.DeleteArrayElementAtIndex(i);
                    //decrement i so we don't skip an element
                    i--;
                    //make sure we save the changes
                    serializedObject.ApplyModifiedProperties();
                    //move to the next element
                    continue;
                }
            }

            EditorGUILayout.EndVertical();
        }
    }

    [Serializable]
    public class Prefab
    {
        public GameObject prefab;
        public string prefabName;
        public string prefabDescription;
    }

    //property drawer for Prefab class
    [CustomPropertyDrawer(typeof(Prefab))]
    public class PrefabDrawer : PropertyDrawer
    {
        public const int outlineWidth = 3;
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            //offset the position by indent
            position.x += EditorGUI.indentLevel * 15;
            position.width -= EditorGUI.indentLevel * 15;
            //get the prefab property
            SerializedProperty prefab = property.FindPropertyRelative(nameof(Prefab.prefab));
            //get the name property
            SerializedProperty name = property.FindPropertyRelative(nameof(Prefab.prefabName));
            //get the description property
            SerializedProperty description = property.FindPropertyRelative(nameof(Prefab.prefabDescription));

            //get the name
            if (name.stringValue == "")
            {
                name.stringValue = "??????";
            }

            //change check
            EditorGUI.BeginChangeCheck();

            //outline
            EditorGUI.DrawRect(position, new Color(0.5f, 0.5f, 0.5f, 1));
            //offset the position for future drawing
            position.x += outlineWidth;
            position.y += outlineWidth;
            position.width -= outlineWidth * 2;
            position.height -= outlineWidth * 2;
            //draw a rect
            EditorGUI.DrawRect(position, new Color(0.2f, 0.2f, 0.2f, 0.5f));

            EditorGUI.indentLevel += 2;
            //display a header
            EditorGUI.LabelField(new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight), name.stringValue, EditorStyles.boldLabel);
            EditorGUI.indentLevel++;
            //draw the prefab field
            EditorGUI.PropertyField(new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing, position.width, EditorGUIUtility.singleLineHeight), prefab, GUIContent.none);
            //draw the name field
            EditorGUI.PropertyField(new Rect(position.x, position.y + (2 * EditorGUIUtility.singleLineHeight) + EditorGUIUtility.standardVerticalSpacing, position.width, EditorGUIUtility.singleLineHeight), name, GUIContent.none);
            //draw the description field
            EditorGUI.PropertyField(new Rect(position.x, position.y + (3 * EditorGUIUtility.singleLineHeight) + EditorGUIUtility.standardVerticalSpacing, position.width, EditorGUIUtility.singleLineHeight), description, GUIContent.none);
            EditorGUI.indentLevel--;
            EditorGUI.indentLevel -= 2;

            //if the prefab has changed
            if (EditorGUI.EndChangeCheck())
            {
                //save the changes
                property.serializedObject.ApplyModifiedProperties();
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            //return the height of the prefab field and the name field
            return EditorGUIUtility.singleLineHeight * 4 + EditorGUIUtility.standardVerticalSpacing + outlineWidth * 2;
        }
    }
}
