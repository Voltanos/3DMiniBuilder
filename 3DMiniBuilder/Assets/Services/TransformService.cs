using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniBuilder.Models;
using MiniBuilder.Enumerations;
using MiniBuilder.Scripts;

namespace MiniBuilder.Services
{
    public class TransformService : ITransformService
    {
        #region Public Methods

        public TransformModel SwitchTransformState(TransformModel model, bool key, TransformState state)
        {
            if (key)
            {
                model._transformState = state;
            }

            return model;
        }

        public TransformModel SwitchCoordinateState(TransformModel model, bool key, CoordinateState state)
        {
            if (key)
            {
                model._coordinateState = state;
            }

            return model;
        }

        public void TransformObject(TransformModel model, ObjectController objScript, float vert)
        {
            // Position.
            if (model._transformState == TransformState.POSITION && model._coordinateState == CoordinateState.X)
            {
                objScript.Model.TR.position = ModifyX(objScript.Model.TR.position, vert);
            }

            else if (model._transformState == TransformState.POSITION && model._coordinateState == CoordinateState.Y)
            {
                objScript.Model.TR.position = ModifyY(objScript.Model.TR.position, vert);
            }

            else if (model._transformState == TransformState.POSITION && model._coordinateState == CoordinateState.Z)
            {
                objScript.Model.TR.position = ModifyZ(objScript.Model.TR.position, vert);
            }

            // Scale.
            else if (model._transformState == TransformState.SCALE && model._coordinateState == CoordinateState.X)
            {
                objScript.Model.TR.localScale = ModifyX(objScript.Model.TR.localScale, vert);
            }

            else if (model._transformState == TransformState.SCALE && model._coordinateState == CoordinateState.Y)
            {
                objScript.Model.TR.localScale = ModifyY(objScript.Model.TR.localScale, vert);
            }

            else if (model._transformState == TransformState.SCALE && model._coordinateState == CoordinateState.Z)
            {
                objScript.Model.TR.localScale = ModifyZ(objScript.Model.TR.localScale, vert);
            }

            // Rotation.
            else if (model._transformState == TransformState.ROTATION && model._coordinateState == CoordinateState.X)
            {
                objScript.Model.TR.Rotate(vert, 0, 0, Space.Self);
            }

            else if (model._transformState == TransformState.ROTATION && model._coordinateState == CoordinateState.Y)
            {
                objScript.Model.TR.Rotate(0, vert, 0, Space.Self);
            }

            else if (model._transformState == TransformState.ROTATION && model._coordinateState == CoordinateState.Z)
            {
                objScript.Model.TR.Rotate(0, 0, vert, Space.Self);
            }
        }

        #endregion

        #region Helper Methods

        public Vector3 ModifyX(Vector3 old, float vert)
        {
            old.x += vert;
            return old;
        }

        public Vector3 ModifyY(Vector3 old, float vert)
        {
            old.y += vert;
            return old;
        }

        public Vector3 ModifyZ(Vector3 old, float vert)
        {
            old.z += vert;
            return old;
        }

        #endregion
    }
}