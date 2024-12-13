using System.Collections.Generic;
using CodeBase.Logic.UnitsLogic.Workers.StateMachines;
using CodeBase.Logic.UnitsLogic.Workers.StateMachines.States;
using CodeBase.Logic.UnitsLogic.Workers.StateMachines.Transitions;
using UnityEngine;
using Zenject;

namespace CodeBase.Logic.UnitsLogic.Workers.Factory
{
	public class WorkerStateMachineFactory : MonoBehaviour
	{
		[Inject]
		private IInstantiator _instantiator;
	
		public WorkerStateMachine Create(Worker worker)
		{
			WorkerStateMachine stateMachine = _instantiator.Instantiate<WorkerStateMachine>();
		
        
			IdleState idleState = _instantiator.Instantiate<IdleState>(new List<object> {stateMachine, worker});
			MoveState moveState = _instantiator.Instantiate<MoveState>(new List<object> {stateMachine, worker});
			WorkState workState = _instantiator.Instantiate<WorkState>(new List<object> {stateMachine, worker});
			GiveProvisionState giveProvisionState = _instantiator.Instantiate<GiveProvisionState>(new List<object> {stateMachine, worker});
        
			ToMoveStateTransition toMoveStateTransition = _instantiator.Instantiate<ToMoveStateTransition>(new List<object> {moveState, worker});
			ToWorkStateTransition toWorkStateTransition = _instantiator.Instantiate<ToWorkStateTransition>(new List<object> {workState, worker});
			ToGiveProvisionStateTransition toGiveProvisionStateTransition = _instantiator.Instantiate<ToGiveProvisionStateTransition>(new List<object> {giveProvisionState, worker});
			ToIdleStateTransition toIdleStateTransition = _instantiator.Instantiate<ToIdleStateTransition>(new List<object> {idleState, worker});

			idleState.AddTransition(toMoveStateTransition);
			workState.AddTransition(toMoveStateTransition);
			moveState.AddTransition(toGiveProvisionStateTransition);
			moveState.AddTransition(toWorkStateTransition);
			workState.AddTransition(toIdleStateTransition);
			giveProvisionState.AddTransition(toMoveStateTransition);
			giveProvisionState.AddTransition(toIdleStateTransition);

			stateMachine.ChangeState(idleState);
		
			return stateMachine;
		}
	}
}