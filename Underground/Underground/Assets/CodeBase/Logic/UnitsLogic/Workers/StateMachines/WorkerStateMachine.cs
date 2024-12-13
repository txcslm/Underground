using CodeBase.Logic.UnitsLogic.Workers.StateMachines.Interfaces;
using CodeBase.Logic.UnitsLogic.Workers.StateMachines.States;
using UnityEngine;

namespace CodeBase.Logic.UnitsLogic.Workers.StateMachines
{
	public class WorkerStateMachine : IStateChanger
	{
		private State _currentState;

		public void ChangeState(State state)
		{
			_currentState?.Exit();
			_currentState = state;
			Debug.Log("Change State" + _currentState.GetType().Name);
			_currentState?.Enter();
		}

		public void Update()
		{
			Debug.Log("Current Update" + _currentState.GetType().Name);
			_currentState?.Update();
		}
	}
}