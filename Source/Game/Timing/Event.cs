using System;

namespace Game.Timing
{
    public class Event
    {
        private Action<dynamic> _event;
        private int _nextTrigger;
        public int _frequency;
        private dynamic _args;
        private bool _inGameRequirement;

        public Event(Action<dynamic> @event, dynamic args, int frequency, bool inGameRequirement) {
            this._event = @event;
            this._frequency = frequency;
            this._args = args;
            this._nextTrigger = Environment.TickCount;
            this._inGameRequirement = inGameRequirement;
        }

        public Event(Action @event, int frequency, bool inGameRequirement) : this((e) => @event.Invoke(), null, frequency, inGameRequirement)
        {

        }

        public bool Probe()
        {
            if (this._inGameRequirement && StateSystem.GameState != States.InGame) {
                return false;
            }

            if (this._nextTrigger <= Environment.TickCount) {
                this._event.Invoke(this._args);

                // Update the next trigger time.
                this._nextTrigger = Environment.TickCount + _frequency;
                return true;
            }

            return false;
        }
    }
}
