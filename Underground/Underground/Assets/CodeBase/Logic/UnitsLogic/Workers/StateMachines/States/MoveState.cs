using CodeBase.Logic.Units.Workers.StateMachines.Interfaces;
using UnityEngine;

namespace CodeBase.Logic.Units.Workers.StateMachines.States.Interfaces
{
	public class MoveState : State
	{
		private readonly Worker _worker;
		private readonly TargetProvider _target;

		public MoveState(IStateChanger stateChanger, Worker worker, TargetProvider target ) : base(stateChanger)
		{
			_worker = worker;
			_target = target;
		}
		
		public override void Enter()
		{
		}

		protected override void OnUpdate() =>
			_worker.MoveTo(_target.CurrentTarget.Position);
	}
}