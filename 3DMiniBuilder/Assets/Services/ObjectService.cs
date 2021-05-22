using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniBuilder.Models;
using MiniBuilder.Scripts;

namespace MiniBuilder.Services
{
    public class ObjectService : IObjectService
    {
        #region Services

        private readonly ISpawnService _spawnService;

        #endregion

        #region Constructors

        public ObjectService(ISpawnService spawnService)
        {
            _spawnService = spawnService;
        }

        #endregion

        #region Public Methods

        public ObjectModel Start(ObjectModel model, GameObject main)
        {
            model.Main = main;
            model.RB = main.GetComponent<Rigidbody>();
            model.BC = main.GetComponent<BoxCollider>();
            model.SC = main.GetComponent<SphereCollider>();
            model.CC = main.GetComponent<CapsuleCollider>();
            model.TR = main.transform;
            return model;
        }

        public void OnMouseDown(ObjectModel model)
        {
            GameManagerController.Instance.SetSelectedObject(model.Main);
        }

        public void Update(ObjectModel model)
        {
            Delete(model);
        }

        public ObjectModel SwitchObjectPhysics(ObjectModel model)
        {
            model.RB.useGravity = !model.RB.useGravity;

            if (model.BC != null)
            {
                model.BC.enabled = !model.BC.enabled;
            }

            if (model.SC != null)
            {
                model.SC.enabled = !model.SC.enabled;
            }

            if (model.CC != null)
            {
                model.CC.enabled = !model.CC.enabled;
            }

            return model;
        }

        #endregion

        #region Helper Methods

        public void Delete(ObjectModel model)
        {
            if (
                (model.Main.transform.position.x <= model.MinRange.x) ||
                (model.Main.transform.position.x >= model.MaxRange.x) ||
                (model.Main.transform.position.y <= model.MinRange.y) ||
                (model.Main.transform.position.y >= model.MaxRange.y) ||
                (model.Main.transform.position.z <= model.MinRange.z) ||
                (model.Main.transform.position.z >= model.MaxRange.z)
            )
            {
                _spawnService.Destroy(model.Main);
            }
        }

        #endregion
    }
}