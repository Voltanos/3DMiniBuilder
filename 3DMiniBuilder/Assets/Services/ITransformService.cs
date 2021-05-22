using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniBuilder.Models;
using MiniBuilder.Enumerations;
using MiniBuilder.Scripts;

namespace MiniBuilder.Services
{
    public interface ITransformService
    {
        public TransformModel SwitchTransformState(TransformModel model, bool key, TransformState state);
        public TransformModel SwitchCoordinateState(TransformModel model, bool key, CoordinateState state);
        public void TransformObject(TransformModel model, ObjectController objScript, float vert);
    }
}