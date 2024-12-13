using CodeBase.Logic.UnitsLogic.Workers.StateMachines.Interfaces;

namespace CodeBase.Logic.UnitsLogic.Workers.StateMachines.States
{
	public class WorkState : State
	{
		private readonly Worker _worker;

		public WorkState(IStateChanger stateChanger, Worker worker) : base(stateChanger)
		{
			_worker = worker;
		}

		public override void Enter() =>
			_worker.Work();
	}
}