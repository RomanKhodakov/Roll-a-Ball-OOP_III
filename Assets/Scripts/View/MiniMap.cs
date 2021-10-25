using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RomanKhodakovHomeWork
{
    public sealed class MiniMap : MonoBehaviour
    {
        private Transform _mainCamTrans;
        private Vector3 _offset;
        private void Start()
        {
            _offset = new Vector3(10, 0, 10);
            _mainCamTrans = Camera.main.transform;
            var rt = Resources.Load<RenderTexture>("MiniMap/MiniMapTexture");
            GetComponent<Camera>().targetTexture = rt;
        }
        private void LateUpdate()
        {
            transform.position = (_mainCamTrans.position / 2) + _offset;
            transform.rotation = Quaternion.Euler(90, _mainCamTrans.eulerAngles.y, 0);
        }
    }
}

