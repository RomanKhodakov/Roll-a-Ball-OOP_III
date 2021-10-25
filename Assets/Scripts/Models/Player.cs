using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RomanKhodakovHomeWork
{
    public sealed class Player : MonoBehaviour
    {
        public float Speed { get; private set; } = 1.0f;
        private Rigidbody _rigidbody;
        internal void SetSpeed(float _newSpeed)
        {
            Speed = _newSpeed;
        }

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
        public void Move(float x, float y, float z)
        {
            _rigidbody.AddForce(new Vector3(x, y, z) * Speed);
        }
    }
}
