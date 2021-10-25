using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RomanKhodakovHomeWork
{
    public sealed class Reference
    {
        private Player _player;
        private Camera _mainCamera;
        private GameObject _endGame;
        private Canvas _canvas;
        private Button _restartButton;
        //private GameObject _bonuse;
        public Player GetPlayer
        {
            get
            {
                if (_player == null)
                {
                    var gameObject = Resources.Load<Player>("Player");
                    _player = Object.Instantiate(gameObject);
                }

                return _player;
            }
        }
        public Camera MainCamera
        {
            get
            {
                if (_mainCamera == null)
                {
                    _mainCamera = Camera.main;
                }
                return _mainCamera;
            }
        }
        public Canvas Canvas
        {
            get
            {
                if (_canvas == null)
                {
                    _canvas = Object.FindObjectOfType<Canvas>();
                }
                return _canvas;
            }
        }
        public Button RestartButton
        {
            get
            {
                if (_restartButton == null)
                {
                    var gameObject = Resources.Load<Button>("UI/RestartButton");
                    _restartButton = Object.Instantiate(gameObject, Canvas.transform);
                }

                return _restartButton;
            }
        }
        public GameObject EndGame
        {
            get
            {
                if (_endGame == null)
                {
                    var gameObject = Resources.Load<GameObject>("UI/EndGame");
                    _endGame = Object.Instantiate(gameObject, Canvas.transform);
                }

                return _endGame;
            }
        }
        //public GameObject Bonuse
        //{
        //    get
        //    {
        //        if (_bonuse == null)
        //        {
        //            var gameObject = Resources.Load<GameObject>("UI/Bonuse");
        //            _bonuse = Object.Instantiate(gameObject, Canvas.transform);
        //        }

        //        return _bonuse;
        //    }
        //}



    }
}


