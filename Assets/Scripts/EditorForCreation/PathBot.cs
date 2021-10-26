using System.Linq;
using UnityEngine;

namespace RomanKhodakovHomeWork
{
	public class PathBot : MonoBehaviour
	{
		[SerializeField]
		private Color _lineColor = Color.red;
		[SerializeField, Range(0.1f, 5.0f)] private float _radius = 0.5f;

		private void OnDrawGizmos()
		{
			var nodes = GetComponentsInChildren<Transform>().Skip(1).Select(t => t.position).ToArray();
			Gizmos.color = _lineColor;
			for (var i = 0; i < nodes.Length; i++)
			{
				var currentNode = nodes[i];
				var previousNode = Vector3.zero;
				if (i > 0)
				{
					previousNode = nodes[i - 1];
				}
				else if (i == 0 && nodes.Length > 1)
				{
					previousNode = nodes[nodes.Length - 1];
				}
				Gizmos.DrawLine(previousNode, currentNode);
				Gizmos.DrawWireSphere(currentNode, _radius);
			}
		}
	}
}