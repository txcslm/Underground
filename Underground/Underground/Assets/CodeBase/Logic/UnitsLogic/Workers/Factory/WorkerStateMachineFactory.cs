using CodeBase.Logic.Units.Workers.StateMachines;
using CodeBase.Logic.Units.Workers.StateMachines.States.Interfaces;
using CodeBase.Logic.UnitsLogic.Workers.StateMachines.Transitions;
using UnityEngine;

namespace CodeBase.Logic.Units.Workers.Factory
{
	public class WorkerStateMachineFactory : MonoBehaviour
	{
		public WorkerStateMachine Create(Worker worker, ITarget target)
		{
			var stateMachine = new WorkerStateMachine();
			
			var idleState = new IdleState(stateMachine);
			var moveState = new MoveState(stateMachine, worker, target);
			var workState = new WorkState(stateMachine, worker);
			
			var toMoveStateTransition = new ToMoveStateTransition(moveState, worker, target);
			var toWorkStateTransition = new ToWorkStateTransition(workState, worker, target);

			idleState.AddTransition(toMoveStateTransition);
			workState.AddTransition(toMoveStateTransition);
			moveState.AddTransition(toWorkStateTransition);
			stateMachine.ChangeState(idleState);
			return stateMachine;
		}
	}
}