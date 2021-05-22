using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniBuilder.Models
{
    [System.Serializable]
    public class ObjectModel
    {
        public GameObject Main;

        public Rigidbody RB;
        public BoxCollider BC;
        public SphereCollider SC;
        public CapsuleCollider CC;
        public Transform TR;

        public Vector3 MinRange;
        public Vector3 MaxRange;

        public ObjectModel()
        {
            Main = null;

            RB = null;
            BC = null;
            SC = null;
            CC = null;
            TR = null;

            MinRange = new Vector3();
            MaxRange = new Vector3();
        }
    }
}
