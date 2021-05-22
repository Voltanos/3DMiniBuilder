using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniBuilder.Models;
using MiniBuilder.Services;

namespace MiniBuilder.Scripts
{
    public class GameManagerController : MonoBehaviour
    {
        public static GameManagerController Instance;
        
        public GameManagerModel Model = new GameManagerModel();

        private readonly IGameManagerService _gameManagerService = new GameManagerService(
            new SpawnService(),
            new InputService(),
            new TransformService()
        );

        public void Awake()
        {
            Instance = this;
        }

        public void SetSelectedObject(GameObject selectedObject)
        {
            Model = _gameManagerService.SetSelectedObject(Model, selectedObject);
        }

        public void SpawnPrefab(int index)
        {
            Model = _gameManagerService.SpawnPrefab(Model, index);
        }

        void Update()
        {
            Model = _gameManagerService.Update(Model);
        }
    }

}