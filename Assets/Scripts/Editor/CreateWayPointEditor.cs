#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace RomanKhodakovHomeWork
{
	[CustomEditor(typeof(CreateBonus))]
	public class CreateWayPointEditor : UnityEditor.Editor
	{
		private CreateBonus _testTarget;

		private void OnEnable()
		{
			_testTarget = (CreateBonus)target;
		}


		private void OnSceneGUI()
		{
			if (Event.current.button == 0 && Event.current.type == EventType.MouseDown)
			{
				Ray ray = Camera.current.ScreenPointToRay(new Vector3(Event.current.mousePosition.x,
					SceneView.currentDrawingSceneView.camera.pixelHeight - Event.current.mousePosition.y));

				if (Physics.Raycast(ray, out var hit))
				{
					_testTarget.InstantiateGoodBonus(hit.point + new Vector3 (0, 1f));
					SetObjectDirty(_testTarget.gameObject);
				}
			}
			if (Event.current.button == 1 && Event.current.type == EventType.MouseDown)
			{
				Ray ray = Camera.current.ScreenPointToRay(new Vector3(Event.current.mousePosition.x,
					SceneView.currentDrawingSceneView.camera.pixelHeight - Event.current.mousePosition.y));

				if (Physics.Raycast(ray, out var hit))
				{
					_testTarget.InstantiateBadBonus(hit.point + new Vector3(0, 1f));
					SetObjectDirty(_testTarget.gameObject);
				}
			}
            Selection.activeGameObject = _testTarget.gameObject;
		}

        public void SetObjectDirty(GameObject obj)
		{
			if (!Application.isPlaying)
			{
				EditorUtility.SetDirty(obj);
				EditorSceneManager.MarkSceneDirty(obj.scene);
			}
		}
	}
#endif
}