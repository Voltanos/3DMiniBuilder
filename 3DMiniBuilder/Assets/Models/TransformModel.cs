using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniBuilder.Enumerations;

namespace MiniBuilder.Models
{
    [System.Serializable]
    public class TransformModel
    {
        public TransformState _transformState;
        public CoordinateState _coordinateState;

        public TransformModel()
        {
            _transformState = TransformState.POSITION;
            _coordinateState = CoordinateState.X;
        }
    }
}