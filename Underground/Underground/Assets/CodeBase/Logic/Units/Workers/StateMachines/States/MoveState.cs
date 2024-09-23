using CodeBase.Logic.Units.Workers.StateMachines.Interfaces;

namespace CodeBase.Logic.Units.Workers.StateMachines.States.Interfaces
{
	public class MoveState : State
	{
		public MoveState(IStateChanger stateChanger) : base(stateChanger)
		{
		}
	}
}