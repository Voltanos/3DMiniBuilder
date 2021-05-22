using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MiniBuilder.Services
{
    public interface ISpawnService
    {
        public GameObject SpawnWithNoRotation(GameObject instance, Vector3 spawnPosition);
        public Text SpawnText(Text instance, Transform parent);
        public void Destroy(GameObject instance);
        public void ExitApp();
    }
}