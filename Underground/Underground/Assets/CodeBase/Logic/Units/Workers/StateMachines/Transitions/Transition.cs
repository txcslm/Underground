using CodeBase.Logic.Units.Workers.StateMachines.States.Interfaces;

namespace CodeBase.Logic.Units.Workers.StateMachines.Transitions
{
	public abstract class Transition
	{
		private State _nextState;

		public Transition(State nextState)
		{
			_nextState = nextState;
		}

		public bool TryTransit(out State nextState)
		{
			nextState = _nextState;

			return CanTransit();
		}

		public abstract bool CanTransit();
	}
}