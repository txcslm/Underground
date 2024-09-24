using CodeBase.Logic.Units.Workers.StateMachines.Interfaces;

namespace CodeBase.Logic.Units.Workers.StateMachines.States.Interfaces
{
	public class GiveProvisionState : State
	{
		public GiveProvisionState(IStateChanger stateChanger) : base(stateChanger)
		{
		}
	}
}