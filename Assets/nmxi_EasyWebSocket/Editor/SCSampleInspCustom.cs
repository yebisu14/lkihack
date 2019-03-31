using UnityEngine;
using UnityEditor;

namespace nmxi.websocket{
    [CustomEditor(typeof(ServerControllerSample))]
    public class SCSampleInspCustom : Editor {

        public override void OnInspectorGUI(){
            base.OnInspectorGUI();
            var serverControllerSample = target as ServerControllerSample;
            
            GUILayout.Space(20);
            EditorGUILayout.BeginHorizontal();
            {
                EditorGUILayout.Space();
                EditorGUI.BeginDisabledGroup(!EditorApplication.isPlaying);
                if (GUILayout.Button("Start Server", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true), GUILayout.Height(30))){
                    serverControllerSample.StartServer();
                }
                EditorGUI.EndDisabledGroup();
                EditorGUILayout.Space();
            }
            EditorGUILayout.EndHorizontal();
        
            GUILayout.Space(20);
            EditorGUILayout.BeginHorizontal();
            {
                EditorGUILayout.Space();
                EditorGUI.BeginDisabledGroup(!EditorApplication.isPlaying);
                if (GUILayout.Button("Broadcast message Test", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true), GUILayout.Height(30))){
                    serverControllerSample.SendTest();
                }
                EditorGUI.EndDisabledGroup();
                EditorGUILayout.Space();
            }
            EditorGUILayout.EndHorizontal();
            GUILayout.Space(20);
        }
    }
}