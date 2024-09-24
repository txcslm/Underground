using CodeBase.Logic.Units.Workers.StateMachines.Interfaces;

namespace CodeBase.Logic.Units.Workers.StateMachines.States.Interfaces
{
	public class IdleState: State
	{
		private readonly IStateChanger _stateChanger;

		public IdleState(IStateChanger stateChanger) : base(stateChanger)
		{
			_stateChanger = stateChanger;
		}
	}
}