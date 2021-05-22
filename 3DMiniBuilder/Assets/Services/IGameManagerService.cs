using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniBuilder.Models;

namespace MiniBuilder.Services
{
    public interface IGameManagerService
    {
        public GameManagerModel SetSelectedObject(GameManagerModel model, GameObject selectedObject);
        public GameManagerModel SpawnPrefab(GameManagerModel model, int index);
        public GameManagerModel Update(GameManagerModel model);
    }
}