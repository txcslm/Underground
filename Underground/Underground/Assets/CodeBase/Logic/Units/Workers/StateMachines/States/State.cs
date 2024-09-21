using System;
using System.Collections.Generic;
using CodeBase.Logic.Units.Workers.StateMachines.Interfaces;
using CodeBase.Logic.Units.Workers.StateMachines.Transitions;

namespace CodeBase.Logic.Units.Workers.StateMachines.States.Interfaces
{
	public abstract class State
	{
		private readonly IStateChanger _stateChanger;
		private readonly List<Transition> _transitions = new();

		public State(IStateChanger stateChanger)
		{
			_stateChanger = stateChanger;
		}

		public void AddTransition(Transition transition)
		{
			if (transition == null)
				throw new ArgumentNullException(nameof(transition));

			if (_transitions.Contains(transition))
				throw new ArgumentException(nameof(transition));

			_transitions.Add(transition);
		}

		public virtual void Enter()
		{
		}

		public virtual void Exit()
		{
		}

		public void Update()
		{
			foreach (Transition transition in _transitions)
			{
				if (transition.TryTransit(out State nextState) == false)
					continue;
				
				_stateChanger.ChangeState(nextState);
				return;
			}
			
			OnUpdate();
		}

		protected virtual void OnUpdate()
		{
		}
	}
}