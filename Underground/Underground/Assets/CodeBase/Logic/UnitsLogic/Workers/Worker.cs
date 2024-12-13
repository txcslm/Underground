using CodeBase.Logic.UnitsLogic.Workers.Animators;
using CodeBase.Logic.UnitsLogic.Workers.Factory;
using CodeBase.Logic.UnitsLogic.Workers.StateMachines;
using CodeBase.Logic.WorldLogic.ProvisionLogic;
using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.Logic.UnitsLogic.Workers
{
	public class Worker : MonoBehaviour
	{
		[SerializeField] private LayerMask _layerMask;
		[SerializeField] private Transform _parentPoint;
		[SerializeField] private WorkerAnimator _animator;
		
		private WorkerStateMachine _stateMachine;
		private NavMeshAgent _agent;

		public bool IsBusy { get; private set; }

		public void Awake()
		{
			_agent = GetComponent<NavMeshAgent>(); 
			_stateMachine = GetComponent<WorkerStateMachineFactory>().Create(this);
		}

		private void Update()
		{
			_stateMachine?.Update();
		}

		public void MoveTo(Vector3 target)
		{
			_animator.PlayRun();
			_agent.SetDestination(target);
		}
		
		public void Work()
		{
			ChangeBusy();
			_animator.PlayWork();

			Collider[] results = new Collider[1];
			
			int size = Physics.OverlapSphereNonAlloc(transform.position, 2f, results, _layerMask);

			foreach (Collider other in results)
			{
				if (!other.TryGetComponent(out Provision target))
					continue;

				target.SetParent(_parentPoint);
				
				break;
			}
		}

		public void GiveProvision()
		{
			ChangeBusy();
			_animator.StopRun();
			_agent.ResetPath();
		}

		public void Chill()
		{
			_animator.StopRun();
			_agent.ResetPath();
		}

		public void StopWork()
		{
			ChangeBusy();
			_animator.StopWork();
		}

		public void Dispose()
		{
			//_stateMachine?.Dispose();
		}

		private void ChangeBusy()
		{
			IsBusy = !IsBusy;
		}
	}
}