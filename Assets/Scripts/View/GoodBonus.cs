using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Debug;


namespace RomanKhodakovHomeWork
{
    public sealed class GoodBonus : InteractiveObject, IFlying
    {
        private float _lengthFly;
        private float _newGoodSpeed = 3.0f; 
        public event Action<float> OnPointGoodChange = delegate (float i) { };
        private void Awake()
        {
            _lengthFly = UnityEngine.Random.Range(0.5f, 1.0f);
        }
        
        protected override void Interaction()
        {
            OnPointGoodChange.Invoke(_newGoodSpeed);
            Log($"Your speed now is {_newGoodSpeed}");
        }
        public void Flying()
        {
            transform.localPosition = new Vector3(transform.localPosition.x,
                Mathf.PingPong(Time.time, _lengthFly),
                transform.localPosition.z);
        }
    }
}
