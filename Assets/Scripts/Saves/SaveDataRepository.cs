using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace RomanKhodakovHomeWork
{
    public sealed class SaveDataRepository
    {
        private readonly JsonData<SavedData> _data;

        private const string _folderName = "dataSave";
        private const string _fileName = "data.bat";
        private readonly string _path;

        public SaveDataRepository()
        {
            _data = new JsonData<SavedData>();
            _path = Path.Combine(Application.dataPath, _folderName);

        }

        public void Save(Player player)
        {
            if (!Directory.Exists(Path.Combine(_path)))
            {
                Directory.CreateDirectory(_path);
            }
            var savePlayer = new SavedData
            {
                Position = player.transform.position,
                CurrentSpeed = player.Speed
            };

            _data.Save(savePlayer, Path.Combine(_path, _fileName));
        }

        public void Load(Player player)
        {
            var file = Path.Combine(_path, _fileName);
            if (!File.Exists(file)) return;
            var newPlayer = _data.Load(file);
            player.transform.position = newPlayer.Position;
            player.SetSpeed(newPlayer.CurrentSpeed);

            Debug.Log(newPlayer);
        }
    }
}
