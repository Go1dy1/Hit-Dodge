using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Implementations.Other
{
    public class AbstractHandler : MonoBehaviour
    {
        [SerializeField] protected bool _isActive = true;

        public bool IsActive => _isActive;

        public virtual void Activate()
        {
            _isActive = true;
        }

        public virtual void Deactivate()
        {
            _isActive = false;
        }
    }
}