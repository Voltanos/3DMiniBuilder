using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniBuilder.Models;

namespace MiniBuilder.Services
{
    public class InputService : IInputService
    {
        public InputModel CheckInput(InputModel model)
        {
            model.Vert = Input.GetAxis("Vertical");
            model.Horz = Input.GetAxis("Horizontal");

            model.Up = (model.Vert > 0);
            model.Down = (model.Vert < 0);
            model.Left = (model.Horz < 0);
            model.Right = (model.Horz > 0);

            model.Fire1 = Input.GetButtonDown("Fire1");
            model.Space = Input.GetButtonDown("Jump");
            model.Library = Input.GetButtonDown("Library");
            model.Delete = Input.GetButtonDown("Delete");
            model.ExitApp = Input.GetButtonDown("Cancel");

            model.Position = Input.GetButtonDown("TransformPosition");
            model.Rotation = Input.GetButtonDown("TransformRotation");
            model.Scale = Input.GetButtonDown("TransformScale");

            model.XCoordinate = Input.GetButtonDown("XCoordinate");
            model.YCoordinate = Input.GetButtonDown("YCoordinate");
            model.ZCoordinate = Input.GetButtonDown("ZCoordinate");

            return model;
        }

        public Vector2 GetMovementDirectionVector(InputModel model)
        {
            return new Vector2(model.Horz, model.Vert);
        }
    }
}