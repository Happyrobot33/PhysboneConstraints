using UnityEngine;
using UnityEditor;

namespace PhysboneConstraints.Editor
{
    public class PhysboneConstraints : EditorWindow
    {
        public static ConstraintPrefabs ConstraintPrefabs;

        //find the constraint prefabs asset in the package upon script load
        [InitializeOnLoadMethod]
        static void FindConstraintPrefabs()
        {
            //find the constraint prefabs asset in our package folder
            ConstraintPrefabs = AssetDatabase.LoadAssetAtPath<ConstraintPrefabs>("Packages/com.happyrobot33.physboneconstraints/Editor/Definitions.asset");

            //make sure it was found
            if (ConstraintPrefabs == null)
            {
                //if it wasn't found, log an error
                Debug.LogError("Could not find ConstraintPrefabs asset. Please make sure the Physbone Constraints package is installed correctly.");
            }

        }

        [MenuItem("GameObject/Physbone Constraints", false, 10)]
        static void CreatePhysboneConstraints()
        {
            //show the window without it being dockable
            PhysboneConstraints window = GetWindow<PhysboneConstraints>(true, "Physbone Constraints", true);
            window.Show();
        }

        const float width = 200;
        const float height = 200;
        private static Rect autoHeight;
        void OnGUI()
        {
            autoHeight = EditorGUILayout.BeginVertical();
            //display buttons for each constraint prefab
            foreach (Prefab prefab in ConstraintPrefabs.prefabs)
            {
                if (GUILayout.Button(prefab.prefabName))
                {
                    //if the button is pressed, instantiate the prefab
                    GameObject instance = Instantiate(prefab.prefab);
                    //set the instance's name
                    instance.name = prefab.prefabName;
                    //check if there was a selected object
                    if (Selection.activeTransform)
                    {
                        //set the instance's parent to the selected object
                        instance.transform.SetParent(Selection.activeTransform, false);
                    }
                    //select the instance
                    Selection.activeGameObject = instance;
                    //close the window
                    Close();
                }

                //display description
                EditorGUILayout.LabelField(prefab.prefabDescription, EditorStyles.wordWrappedLabel);

                //seperator
                //EditorGUILayout.Space();
            }
            EditorGUILayout.EndVertical();

            //make the height match the buttons
            if (Event.current.type == EventType.Repaint)
                position = new Rect(position.x, position.y, width, autoHeight.height);
        }

        void OnLostFocus()
        {
            //if the window loses focus, close it
            Close();
        }
    }
}
