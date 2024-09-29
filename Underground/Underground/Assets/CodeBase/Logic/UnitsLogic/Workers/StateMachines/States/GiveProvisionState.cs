using CodeBase.Logic.Units.Workers.StateMachines.Interfaces;
using CodeBase.Logic.WorldLogic.ProvisionLogic;

namespace CodeBase.Logic.Units.Workers.StateMachines.States.Interfaces
{
	public class GiveProvisionState : State
	{

		public GiveProvisionState(IStateChanger stateChanger) : base(stateChanger)
		{
		}

		public override void Enter()
		{
		}
	}
}