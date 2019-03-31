using UnityEngine;
using UnityEditor;

namespace nmxi.websocket{
    [CustomEditor(typeof(ClientControllerSample))]
    public class CCSampleInspCustom : Editor {

        public override void OnInspectorGUI(){
            base.OnInspectorGUI();
            var clientControllerSample = target as ClientControllerSample;
            
            GUILayout.Space(20);
            EditorGUILayout.BeginHorizontal();
            {
                EditorGUILayout.Space();
                EditorGUI.BeginDisabledGroup(!EditorApplication.isPlaying);
                if (GUILayout.Button("Connect to Server", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true), GUILayout.Height(30))){
                    clientControllerSample.ConnectToServer();
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
                if (GUILayout.Button("Send Message Test", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true), GUILayout.Height(30))){
                    clientControllerSample.SendTest();
                }
                EditorGUI.EndDisabledGroup();
                EditorGUILayout.Space();
            }
            EditorGUILayout.EndHorizontal();
            GUILayout.Space(20);
        }
    }
}