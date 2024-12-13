using CodeBase.Logic.UnitsLogic.Workers.Providers;
using CodeBase.Logic.UnitsLogic.Workers.StateMachines.States;
using UnityEngine;

namespace CodeBase.Logic.UnitsLogic.Workers.StateMachines.Transitions
{
	public class ToWorkStateTransition: Transition
	{
		private readonly Worker _worker;
		private readonly TargetProvider _target;

		public ToWorkStateTransition(WorkState nextState, Worker worker, TargetProvider target) : base(nextState)
		{
			_worker = worker;
			_target = target;
		}

		protected override bool CanTransit() =>
			Vector3.Distance(_worker.transform.position, _target.CurrentTarget.Position) < 1f;
	}
}