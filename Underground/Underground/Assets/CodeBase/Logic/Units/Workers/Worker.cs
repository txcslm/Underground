using CodeBase.Logic.Units.Workers.Animators;
using CodeBase.Logic.Units.Workers.Factory;
using CodeBase.Logic.Units.Workers.StateMachines;
using UnityEngine;
using Zenject;

namespace CodeBase.Logic.Units.Workers
{
	[RequireComponent(typeof(WorkerStateMachineFactory))]
	public class Worker : MonoBehaviour
	{
		private WorkerAnimator _animator;
		
		private WorkerStateMachine _stateMachine;
		
		public void Awake()
		{
			_stateMachine = GetComponent<WorkerStateMachineFactory>().Create();

			_animator = GetComponent<WorkerAnimator>();
		}
		
		private void Update()
		{
			Debug.Log(_stateMachine);
			_stateMachine?.Update();
		}
	}
}