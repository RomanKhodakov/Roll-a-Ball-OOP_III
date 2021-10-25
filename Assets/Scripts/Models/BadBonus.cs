using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Debug;

namespace RomanKhodakovHomeWork
{
    public sealed class BadBonus : InteractiveObject, IFlying
    {
        private float _lengthFly;
        private float _newBadSpeed = 0.3f; 
        public event Action<float> OnPointBadChange = delegate (float i) { };

        private void Awake()
        {
            _lengthFly = UnityEngine.Random.Range(1.0f, 2.0f);
        }

        protected override void Interaction()
        {
            OnPointBadChange.Invoke(_newBadSpeed);
            Log($"Your speed now is {_newBadSpeed}");
        }

        public void Flying()
        {
            transform.localPosition = new Vector3(transform.localPosition.x,
                Mathf.PingPong(Time.time, _lengthFly),
                transform.localPosition.z);
        }
    }
}
