using Arr.EventsSystem;
using Arr.ModulesSystem;
using Arr.Utils;
using UnityEngine;
using EventHandler = Arr.EventsSystem.EventHandler;

namespace Arr.ModulesLoader
{
    public abstract class MonoModulesLoader : MonoBehaviour
    {
        protected abstract IModule[] Modules { get; }
        
        protected virtual EventHandler EventHandler => GlobalEvents.Instance;

        private ModulesHandler modulesHandler;
        
        private void Start()
        {
            modulesHandler = new ModulesHandler(Modules, EventHandler);
            
            modulesHandler.Start().CatchExceptions();
        }

        private void OnDestroy()
        {
            modulesHandler.Stop().CatchExceptions();
        }
    }
}