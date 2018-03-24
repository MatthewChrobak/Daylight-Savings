using System;

namespace Game.Timing
{
    public class Event
    {
        private Action<dynamic> _event;
        private int _nextTrigger;
        private int _frequency;
        private dynamic _args;

        public Event(Action<dynamic> @event, dynamic args, int frequency) {
            this._event = @event;
            this._frequency = frequency;
            this._args = args;
            this._nextTrigger = Environment.TickCount;
        }

        public Event(Action @event, int frequency) : this((e) => @event.Invoke(), null, frequency)
        {

        }

        public void Probe()
        {
            if (this._nextTrigger <= Environment.TickCount) {
                this._event.Invoke(this._args);

                // Update the next trigger time.
                this._nextTrigger = Environment.TickCount + _frequency;
            }
        }
    }
}
