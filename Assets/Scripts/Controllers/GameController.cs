using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RomanKhodakovHomeWork
{
    public sealed class GameController : MonoBehaviour, IDisposable
    {
        private List<InteractiveObject> _interactiveObjects;
        private DisplayEndGame _displayEndGame;
        private Reference _reference;
        private InputController _inputController;
        private CameraController _cameraController;

        private void Awake()
        {
            _reference = new Reference();
            Player player = _reference.GetPlayer;
            _displayEndGame = new DisplayEndGame(_reference.EndGame);
            _inputController = new InputController(player);
            _cameraController = new CameraController(player.transform,_reference.MainCamera.transform);
            _interactiveObjects = FindObjectsOfType<InteractiveObject>().ToList();
            foreach (var o in _interactiveObjects)
            {
                if (o is LevelBorder levelBorder)
                {
                    levelBorder.BorderInteraction += CaughtPlayer;
                    levelBorder.BorderInteraction += _displayEndGame.GameOver;
                    _reference.RestartButton.onClick.AddListener(RestartGame);
                    _reference.RestartButton.gameObject.SetActive(false);
                }
                if (o is GoodBonus goodBonus)
                {
                    goodBonus.OnPointGoodChange += player.SetSpeed;
                }
                if (o is BadBonus badBonus)
                {
                    badBonus.OnPointBadChange += player.SetSpeed;
                }
            }
        }

        private void RestartGame()
        {
            SceneManager.LoadScene(sceneBuildIndex: 0);
            Time.timeScale = 1.0f;
        }

        private void CaughtPlayer()
        {
            _reference.RestartButton.gameObject.SetActive(true);
            Time.timeScale = 0.0f;
        }

        private void Update()
        {
            for (var i = 0; i < _interactiveObjects.Count; i++)
            {
                var interactiveObject = _interactiveObjects[i];

                if (interactiveObject == null)
                {
                    continue;
                }

                if (interactiveObject is IFlying fly)
                {
                    fly.Flying();
                }
            }
            _inputController.Execute();
            _cameraController.Execute();
        }

        public void Dispose()
        {
            foreach (var o in _interactiveObjects)
            {
                if (o is LevelBorder levelBorder)
                {
                    levelBorder.BorderInteraction -= CaughtPlayer;
                    levelBorder.BorderInteraction -= _displayEndGame.GameOver;
                }
            }
        }
    }
}
