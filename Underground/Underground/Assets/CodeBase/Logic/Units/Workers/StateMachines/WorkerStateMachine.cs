using CodeBase.Logic.Units.Workers.StateMachines.Interfaces;
using CodeBase.Logic.Units.Workers.StateMachines.States.Interfaces;
using UnityEngine;

namespace CodeBase.Logic.Units.Workers.StateMachines
{
	public class WorkerStateMachine : IStateChanger
	{
		private State _currentState;

		public void ChangeState(State state)
		{
			_currentState?.Exit();
			_currentState = state;
			_currentState?.Enter();
		}

		public void Update()
		{
			Debug.Log(_currentState.GetType());
			_currentState?.Update();
		}
	}
}