using CodeBase.Logic.Units.Workers.Animators;
using CodeBase.Logic.Units.Workers.Factory;
using CodeBase.Logic.Units.Workers.StateMachines;
using CodeBase.Logic.Units.Workers.StateMachines.States.Interfaces;
using CodeBase.Logic.WorldLogic.ProvisionLogic;
using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.Logic.Units.Workers
{
	[RequireComponent(typeof(WorkerStateMachineFactory))]
	public class Worker : MonoBehaviour
	{
		private WorkerAnimator _animator;
		private WorkerStateMachine _stateMachine;
		private NavMeshAgent _agent;
		private ITarget _target;

		public void Awake()
		{
			_agent = GetComponent<NavMeshAgent>(); 
			_animator = GetComponentInChildren<WorkerAnimator>();
			_stateMachine = GetComponent<WorkerStateMachineFactory>().Create(this, _target);
		}

		private void Update()
		{
			_stateMachine?.Update();
		}

		public void MoveTo(Vector3 target)
		{
			Debug.Log(target);
			_animator.PlayRun();
			_agent.SetDestination(target);
		}
		
		public void SetTarget(ITarget target)
		{
			_target = target;
		}

		public void Work()
		{
			_animator.PlayWork();
		}

		public void Dispose()
		{
			//_stateMachine?.Dispose();
		}
	}
}
