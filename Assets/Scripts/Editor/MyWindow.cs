using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace RomanKhodakovHomeWork
{
    public class MyWindow : EditorWindow
    {
        private GameObject root;
        public bool _groupEnabled;
        public int _wallLength = 1;
        public int _angle = 90;
        private Queue<Transform> _queueRoot = new Queue<Transform>();

        private void OnGUI()
        {
            GUILayout.Label("Базовые настройки", EditorStyles.boldLabel);

            _groupEnabled = EditorGUILayout.BeginToggleGroup("Дополнительные настройки",
                _groupEnabled);

            _wallLength = EditorGUILayout.IntSlider("Длина стены",
                _wallLength, 1, 50);

            _angle = EditorGUILayout.IntSlider("Поворот стены",
                _angle, 0, 360);

            EditorGUILayout.EndToggleGroup();
            var button = GUILayout.Button("Создать стену");
            if (button)
            {
                if (!root)
                {
                    root = new GameObject("New Wall");
                }

                Vector3 pos = new Vector3(12, 0.5f, 10);
                GameObject temp = GameObject.CreatePrimitive(PrimitiveType.Cube);
                temp.transform.localScale = new Vector3(1, 1, _wallLength);
                temp.transform.position = pos;
                temp.transform.rotation = Quaternion.AngleAxis(_angle, Vector3.up);
                temp.transform.parent = root.transform;
                _queueRoot.Enqueue(temp.transform);
            }

            bool destroyRoot = false;
            if (_queueRoot.Count > 0)
            {
            	destroyRoot = GUILayout.Button("Удалить последнюю стену");
            }

            if (destroyRoot)
            {
            	DestroyImmediate(_queueRoot.Dequeue().gameObject);
            }
        }
    }
}