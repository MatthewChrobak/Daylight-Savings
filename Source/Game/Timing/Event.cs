using System;

namespace Game.Timing
{
    public class Event
    {
        private Action _event;
        private int _nextTrigger;
        private int _frequency;

        public Event(Action @event, int frequency) {
            this._event = @event;
            this._frequency = frequency;
            this._nextTrigger = Environment.TickCount;
        }

        public void Probe()
        {
            if (this._nextTrigger <= Environment.TickCount) {
                this._event.Invoke();

                // Update the next trigger time.
                this._nextTrigger = Environment.TickCount + _frequency;
            }
        }
    }
}
