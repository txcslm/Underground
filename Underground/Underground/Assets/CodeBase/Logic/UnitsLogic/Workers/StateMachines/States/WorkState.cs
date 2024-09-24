using CodeBase.Logic.Units.Workers.StateMachines.Interfaces;

namespace CodeBase.Logic.Units.Workers.StateMachines.States.Interfaces
{
	public class WorkState : State
	{
		private readonly Worker _worker;

		public WorkState(IStateChanger stateChanger, Worker worker) : base(stateChanger)
		{
			_worker = worker;
		}

		public override void Enter()
		{
			_worker.Work();
		}
	}
}