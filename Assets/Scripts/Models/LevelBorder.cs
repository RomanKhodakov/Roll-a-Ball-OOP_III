using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RomanKhodakovHomeWork
{
    public sealed class LevelBorder : InteractiveObject
    {
        public delegate void OnPointChange();
        public event OnPointChange BorderInteraction;

        protected override void Interaction()
        {
            BorderInteraction.Invoke();
        }
    }
}
