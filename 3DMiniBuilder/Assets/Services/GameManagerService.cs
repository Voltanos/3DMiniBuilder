using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniBuilder.Models;
using MiniBuilder.Scripts;
using MiniBuilder.Enumerations;

namespace MiniBuilder.Services
{
    public class GameManagerService : IGameManagerService
    {
        #region Services

        private readonly ISpawnService _spawnService;
        private readonly IInputService _inputService;
        private readonly ITransformService _transformService;

        #endregion

        #region Constructors

        public GameManagerService(ISpawnService spawnService, IInputService inputService, ITransformService transformService)
        {
            _spawnService = spawnService;
            _inputService = inputService;
            _transformService = transformService;
        }

        #endregion

        #region Public Methods

        public GameManagerModel SetSelectedObject(GameManagerModel model, GameObject selectedObject)
        {
            ObjectController objScript = selectedObject.GetComponent<ObjectController>();
            SwitchObjectPhysics(model.ObjScript);
            SwitchObjectPhysics(objScript);
            model.SelectedObject = selectedObject;
            model.ObjScript = objScript;
            return model;
        }

        public GameManagerModel SpawnPrefab(GameManagerModel model, int index)
        {
            if (!IndexInRange(model, index))
            {
                return model;
            }

            _spawnService.SpawnWithNoRotation(model.Prefabs[index], model.SpawnPoint);
            return model;
        }

        public GameManagerModel Update(GameManagerModel model)
        {
            model.Input = _inputService.CheckInput(model.Input);
            model = EnableLibrary(model);
            model = DeleteObject(model);

            model.Transform = _transformService.SwitchTransformState(model.Transform, model.Input.Position, TransformState.POSITION);
            model.Transform = _transformService.SwitchTransformState(model.Transform, model.Input.Rotation, TransformState.ROTATION);
            model.Transform = _transformService.SwitchTransformState(model.Transform, model.Input.Scale, TransformState.SCALE);

            model.Transform = _transformService.SwitchCoordinateState(model.Transform, model.Input.XCoordinate, CoordinateState.X);
            model.Transform = _transformService.SwitchCoordinateState(model.Transform, model.Input.YCoordinate, CoordinateState.Y);
            model.Transform = _transformService.SwitchCoordinateState(model.Transform, model.Input.ZCoordinate, CoordinateState.Z);

            model = UpdateObjectControlUI(model);

            TransformObject(model);

            ExitApp(model);

            return model;
        }

        #endregion

        #region Helper Methods

        public void ExitApp(GameManagerModel model)
        {
            if (model.Input.ExitApp)
            {
                _spawnService.ExitApp();
            }
        }

        public GameManagerModel UpdateObjectControlUI(GameManagerModel model)
        {
            if (model.SelectedObject == null)
            {
                model.ObjectControlPanel.SetActive(false);
                return model;
            }

            model.ObjectControlPanel.SetActive(true);

            model.TransformText.text = UpdateTransformText(model.Transform._transformState);
            model.CoordinateText.text = UpdateCoordinateText(model.Transform._coordinateState);

            return model;
        }

        public string UpdateTransformText(TransformState state)
        {
            string text = "";

            switch (state)
            {
                case TransformState.POSITION:
                    text = "Position";
                    break;

                case TransformState.ROTATION:
                    text = "Rotation";
                    break;

                case TransformState.SCALE:
                    text = "Scale";
                    break;
            }

            return text;
        }

        public string UpdateCoordinateText(CoordinateState state)
        {
            string text = "";

            switch (state)
            {
                case CoordinateState.X:
                    text = "X";
                    break;

                case CoordinateState.Y:
                    text = "Y";
                    break;

                case CoordinateState.Z:
                    text = "Z";
                    break;
            }

            return text;
        }

        public void TransformObject(GameManagerModel model)
        {
            if (model.ObjScript == null)
            {
                return;
            }

            _transformService.TransformObject(model.Transform, model.ObjScript, model.Input.Vert / 100);
        }

        public void SwitchObjectPhysics(ObjectController objScript)
        {
            if (objScript == null)
            {
                return;
            }

            objScript.SwitchObjectPhysics();
        }

        public GameManagerModel DeleteObject(GameManagerModel model)
        {
            if (!model.Input.Delete || model.SelectedObject == null)
            {
                return model;
            }

            _spawnService.Destroy(model.SelectedObject);
            model.SelectedObject = null;
            return model;
        }

        public bool IndexInRange(GameManagerModel model, int index)
        {
            if (index > -1 && index < model.Prefabs.Count)
            {
                return true;
            }

            return false;
        }

        public GameManagerModel EnableLibrary(GameManagerModel model)
        {
            if (!model.Input.Library)
            {
                return model;
            }

            model.LibraryPanel.SetActive(!model.LibraryPanel.activeSelf);
            model.MainPanel.SetActive(!model.MainPanel.activeSelf);

            return model;
        }

        #endregion
    }
}