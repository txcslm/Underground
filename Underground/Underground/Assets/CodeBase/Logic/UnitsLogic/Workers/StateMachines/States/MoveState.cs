using CodeBase.Logic.Units.Workers.StateMachines.Interfaces;
using UnityEngine;

namespace CodeBase.Logic.Units.Workers.StateMachines.States.Interfaces
{
	public class MoveState : State
	{
		private readonly Worker _worker;
		private readonly ITarget _target;

		public MoveState(IStateChanger stateChanger, Worker worker, ITarget target ) : base(stateChanger)
		{
			_worker = worker;
			_target = target;
		}
		
		public override void Enter()
		{
			Debug.Log("Enter Move State");
		}

		protected override void OnUpdate()
		{
			Debug.Log("OnUpdate");
			_worker.MoveTo(_target.Position);
		}
	}
}