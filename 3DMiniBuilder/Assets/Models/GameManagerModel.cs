using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MiniBuilder.Scripts;

namespace MiniBuilder.Models
{
    [System.Serializable]
    public class GameManagerModel
    {
        public GameObject MainPanel;
        public GameObject LibraryPanel;
        public GameObject ObjectControlPanel;
        public GameObject SelectedObject;

        public Text TransformText;
        public Text CoordinateText;

        public ObjectController ObjScript;

        public TransformModel Transform;
        
        public InputModel Input;

        public List<GameObject> Prefabs;

        public Vector3 SpawnPoint;

        public int PrefabIndex;

        public GameManagerModel()
        {
            MainPanel = null;
            LibraryPanel = null;
            ObjectControlPanel = null;
            SelectedObject = null;

            ObjScript = null;

            Transform = new TransformModel();
            
            Input = new InputModel();

            Prefabs = new List<GameObject>();

            SpawnPoint = new Vector3();

            PrefabIndex = -1;
        }
    }
}
