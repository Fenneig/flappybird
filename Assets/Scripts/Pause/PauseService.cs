using System.Collections.Generic;
using System.Linq;

namespace Flappybird.Pause
{
    public class PauseService : IPausable
    {
        private readonly List<IPausable> _handlers;
        
        public PauseService()
        {
            _handlers = new List<IPausable>();
        }
        
        public void Register(IPausable handler)
        {
            _handlers.Add(handler);
        }

        public void Unregister(IPausable handler)
        {
            if (_handlers.Contains(handler)) _handlers.Remove(handler);
        }
        
        public void SetPause(bool isPaused)
        {
            foreach (var handler in _handlers.ToList()) handler.SetPause(isPaused);
        }
    }
}