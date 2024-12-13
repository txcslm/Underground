using CodeBase.Logic.UnitsLogic.Workers.Providers;
using CodeBase.Logic.UnitsLogic.Workers.StateMachines.States;
using UnityEngine;

namespace CodeBase.Logic.UnitsLogic.Workers.StateMachines.Transitions
{
	public class ToIdleStateTransition : Transition
	{
		private readonly Worker _worker;
		private readonly TargetProvider _targetProvider;

		public ToIdleStateTransition(IdleState nextState, Worker worker, TargetProvider targetProvider) : base(nextState)
		{
			_worker = worker;
			_targetProvider = targetProvider;
		}

		protected override bool CanTransit() =>
			Vector3.Distance(_worker.transform.position, _targetProvider.CurrentTarget.Position) < 1f;
	}
}