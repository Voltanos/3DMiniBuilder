using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniBuilder.Models;

namespace MiniBuilder.Services
{
    public interface IInputService
    {
        public InputModel CheckInput(InputModel model);
        public Vector2 GetMovementDirectionVector(InputModel model);
    }
}