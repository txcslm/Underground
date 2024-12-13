using CodeBase.Logic.UnitsLogic.Workers.Providers;
using CodeBase.Logic.UnitsLogic.Workers.StateMachines.States;

namespace CodeBase.Logic.UnitsLogic.Workers.StateMachines.Transitions
{
	public class ToGiveProvisionStateTransition : Transition
	{
		private readonly Worker _worker;
		private readonly TargetProvider _targetProvider;

		public ToGiveProvisionStateTransition(GiveProvisionState nextState, Worker worker, TargetProvider targetProvider) : base(nextState)
		{
			_worker = worker;
			_targetProvider = targetProvider;
		}

		protected override bool CanTransit() =>
			_worker.IsBusy && _targetProvider.CurrentTarget.Position == _worker.transform.position;
	}
}