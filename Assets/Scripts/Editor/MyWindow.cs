using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace RomanKhodakovHomeWork
{
	public class MyWindow : EditorWindow
	{
		public static GameObject ObjectInstantiate;
		public bool _groupEnabled;
		public int _wallLength = 1;
		public int _angle = 90;
		private Queue<Transform> _queueRoot = new Queue<Transform>();

		private void OnGUI()
		{
			GUILayout.Label("Базовые настройки", EditorStyles.boldLabel);
			ObjectInstantiate =
				EditorGUILayout.ObjectField("Объект который хотим вставить",
						ObjectInstantiate, typeof(GameObject), true)
					as GameObject;

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
				if (ObjectInstantiate)
				{
					ObjectInstantiate.transform.localScale = new Vector3(1, 1, _wallLength);
					GameObject root = new GameObject("New Wall");
					_queueRoot.Enqueue(root.transform);
					Vector3 pos = new Vector3(12, 0.5f, 10);
					GameObject temp = Instantiate(ObjectInstantiate, pos, Quaternion.AngleAxis(_angle, Vector3.up));
					temp.transform.parent = root.transform;
					//var tempRenderer = temp.GetComponent<Renderer>();
				}
			}

			//bool destroyRoot = false;
			//if (_queueRoot.Count > 0)
			//{
			//	destroyRoot = GUILayout.Button("Удалить последнюю стену");
			//}

			//if (destroyRoot)
			//{
			//	DestroyImmediate(_queueRoot.Dequeue().gameObject);
			//}
		}
	}
}