using System;
using UnityEngine;

namespace RomanKhodakovHomeWork
{
	public sealed class CreateBonus : MonoBehaviour
	{
		[SerializeField] private GameObject _goodBonus;
		[SerializeField] private GameObject _badBonus;

		private PathBot _rootWayPoint;

		public GameObject InstantiateGoodBonus(Vector3 pos)
		{
			if (!_rootWayPoint)
			{
				_rootWayPoint = new GameObject("GoodBonus").AddComponent<PathBot>();
			}

			if (_goodBonus != null)
			{
				return Instantiate(_goodBonus, pos, Quaternion.identity, _rootWayPoint.transform);
			}

			throw new Exception($"Нет префаба на компоненте {typeof(CreateBonus)} {gameObject.name}");
		}
		public GameObject InstantiateBadBonus(Vector3 pos)
		{
			if (!_rootWayPoint)
			{
				_rootWayPoint = new GameObject("BadBonus").AddComponent<PathBot>();
			}

			if (_badBonus != null)
			{
				return Instantiate(_badBonus, pos, Quaternion.identity, _rootWayPoint.transform);
			}

			throw new Exception($"Нет префаба на компоненте {typeof(CreateBonus)} {gameObject.name}");
		}
	}
}