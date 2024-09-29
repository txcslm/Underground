using CodeBase.Logic.Units.Workers.StateMachines.Interfaces;

namespace CodeBase.Logic.Units.Workers.StateMachines.States.Interfaces
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