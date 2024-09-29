using CodeBase.Logic.Units.Workers.StateMachines.States.Interfaces;
using CodeBase.Logic.Units.Workers.StateMachines.Transitions;
using UnityEngine;

namespace CodeBase.Logic.Units.Workers.Factory
{
	public class ToMoveStateTransition : Transition
	{
		private readonly Worker _worker;
		private readonly TargetProvider _targetProvider;

		public ToMoveStateTransition(MoveState moveState, Worker worker, TargetProvider targetProvider) : base(moveState)
		{
			_worker = worker;
			_targetProvider = targetProvider;
		}
		
		protected override bool CanTransit()
		{
			if (_targetProvider == null)
				return false;
			
			return Vector3.Distance(_worker.transform.position, _targetProvider.CurrentTarget.Position) > 1f;
		}
	}
}