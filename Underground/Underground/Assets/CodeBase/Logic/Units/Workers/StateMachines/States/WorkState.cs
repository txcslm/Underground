using CodeBase.Logic.Units.Workers.StateMachines.Interfaces;

namespace CodeBase.Logic.Units.Workers.StateMachines.States.Interfaces
{
	public class WorkState : State
	{
		public WorkState(IStateChanger stateChanger) : base(stateChanger)
		{
		}
	}
}