using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MiniBuilder.Services
{
    public class SpawnService : ISpawnService
    {
        public GameObject SpawnWithNoRotation(GameObject instance, Vector3 spawnPosition)
        {
            return GameObject.Instantiate(instance, spawnPosition, Quaternion.identity);
        }

        public Text SpawnText(Text instance, Transform parent)
        {
            return GameObject.Instantiate(instance, parent);
        }

        public void Destroy(GameObject instance)
        {
            GameObject.Destroy(instance);
        }

        public void ExitApp()
        {
            Application.Quit();
        }
    }
}