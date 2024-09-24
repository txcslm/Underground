using CodeBase.Logic.Units.Workers.StateMachines.States.Interfaces;
using CodeBase.Logic.Units.Workers.StateMachines.Transitions;
using UnityEngine;

namespace CodeBase.Logic.Units.Workers.Factory
{
	public class ToMoveStateTransition : Transition
	{
		private readonly Worker _worker;
		private ITarget _target;

		public ToMoveStateTransition(MoveState moveState, Worker worker, ITarget target) : base(moveState)
		{
			_worker = worker;
			_target = target;
		}
		
		public void SetTarget(ITarget newTarget)
		{
			_target = newTarget;
		}
		
		protected override bool CanTransit()
		{
			Debug.Log(_target.Position);
			
			if (_target == null)
				return false;
			
			Debug.Log(_target.Position);
			
			return Vector3.Distance(_worker.transform.position, _target.Position) > 1f;
		}
	}
}