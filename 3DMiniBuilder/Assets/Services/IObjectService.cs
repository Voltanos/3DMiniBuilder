using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniBuilder.Models;

namespace MiniBuilder.Services
{
    public interface IObjectService
    {
        public ObjectModel Start(ObjectModel model, GameObject main);
        public void OnMouseDown(ObjectModel model);
        public void Update(ObjectModel model);
        public ObjectModel SwitchObjectPhysics(ObjectModel model);
    }
}