using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RomanKhodakovHomeWork
{
    public sealed class InputController : IExecute
    {
        private readonly Player _player;
        private readonly SaveDataRepository _saveDataRepository;
        private readonly KeyCode _savePlayer = KeyCode.C;
        private readonly KeyCode _loadPlayer = KeyCode.V;

        public InputController(Player player)
        {
            _player = player;
            _saveDataRepository = new SaveDataRepository();
        }

        public void Execute()
        {
            _player.Move(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

            if (Input.GetKeyDown(_savePlayer))
            {
                _saveDataRepository.Save(_player);
                Debug.Log("Saved");
            }
            if (Input.GetKeyDown(_loadPlayer))
            {
                _saveDataRepository.Load(_player);
                Debug.Log("Loaded");
            }
        }
    }
}

