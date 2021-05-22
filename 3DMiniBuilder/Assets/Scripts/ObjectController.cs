using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniBuilder.Models;
using MiniBuilder.Services;

namespace MiniBuilder.Scripts
{
    public class ObjectController : MonoBehaviour
    {
        public ObjectModel Model = new ObjectModel();

        private readonly IObjectService _objectService = new ObjectService(
            new SpawnService()
        );

        public void Start()
        {
            Model = _objectService.Start(Model, gameObject);
        }

        public void OnMouseDown()
        {
            _objectService.OnMouseDown(Model);
        }

        void Update()
        {
            _objectService.Update(Model);
        }

        public void SwitchObjectPhysics()
        {
            Model = _objectService.SwitchObjectPhysics(Model);
        }
    }

}