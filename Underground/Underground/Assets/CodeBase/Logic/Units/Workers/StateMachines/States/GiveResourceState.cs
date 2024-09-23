using CodeBase.Logic.Units.Workers.StateMachines.Interfaces;

namespace CodeBase.Logic.Units.Workers.StateMachines.States.Interfaces
{
	public class GiveResourceState : State
	{
		public GiveResourceState(IStateChanger stateChanger) : base(stateChanger)
		{
		}
	}
}