using CodeBase.Logic.UnitsLogic.Workers.StateMachines.Interfaces;

namespace CodeBase.Logic.UnitsLogic.Workers.StateMachines.States
{
	public class IdleState: State
	{
		private readonly IStateChanger _stateChanger;
		private readonly Worker _worker;

		public IdleState(IStateChanger stateChanger, Worker worker) : base(stateChanger)
		{
			_stateChanger = stateChanger;
			_worker = worker;
		}

		public override void Enter()
		{
			_worker.Chill();
		}
	}
}