using System.Collections.Generic;

namespace Game.Models
{
    public abstract class Observable
    {
        private List<IObserver> _observers;

        public Observable()
        {
            this._observers = new List<IObserver>();
        }

        public void NotifyAll()
        {
            foreach (var observer in this._observers)
            {
                observer.Notify(this);
            }
        }

        public void Attach(IObserver o)
        {
            this._observers.Add(o);
        }

        public void Detatch(IObserver o)
        {
            this._observers.Remove(o);
        }
    }
}
