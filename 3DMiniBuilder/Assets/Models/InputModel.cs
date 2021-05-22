using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniBuilder.Models
{
    [System.Serializable]
    public class InputModel
    {
        // Directional Buttons.
        public bool Up;
        public bool Down;
        public bool Left;
        public bool Right;

        // Fire / Action buttons.
        public bool Fire1;

        // Jump Buttons.
        public bool Space;

        // Library Button.
        public bool Library;

        // Delete Button.
        public bool Delete;

        // Exit App Button.
        public bool ExitApp;

        // Transform Switch Buttons.
        public bool Position;
        public bool Rotation;
        public bool Scale;

        // Coordinate Switch Buttons.
        public bool XCoordinate;
        public bool YCoordinate;
        public bool ZCoordinate;

        public float Vert;
        public float Horz;

        public InputModel()
        {
            Up = false;
            Down = false;
            Left = false;
            Right = false;
            Fire1 = false;
            Space = false;
            Library = false;
            Delete = false;
            ExitApp = false;
            Position = false;
            Rotation = false;
            Scale = false;
            XCoordinate = false;
            YCoordinate = false;
            ZCoordinate = false;

            Vert = 0.0f;
            Horz = 0.0f;
        }
    }
}
