using System;
using CodeBase.Logic.Units.Workers;
using CodeBase.Logic.Units.Workers.Pools;
using CodeBase.Logic.Units.Workers.Spawner;
using CodeBase.Logic.Units.Workers.StateMachines.States.Interfaces;
using CodeBase.Logic.WorldLogic.ProvisionLogic;
using UnityEngine;
using Zenject;

namespace CodeBase.Logic.TownLogic
{
	public class Town : MonoBehaviour, ITarget
	{
		[SerializeField] private WorkerSpawner _workerSpawner;

		[Inject]
		 private WorkerPool _workerPool;
		
		public Vector3 Position => transform.position;

		public void Start()
		{
			_workerSpawner.Spawn();
		}

		public void Update()
		{
			
			var results = Physics.OverlapSphere(transform.position, 20f);
			
			Debug.Log(_workerPool.Workers.Count);
			
			foreach (Collider other in results)
			{
				if (!other.TryGetComponent(out Provision target))
				{
					Debug.Log("no target");
					
					continue;
				}
				
				Debug.Log(target.Position);
					
				_workerPool.Workers[0].SetTarget(target);
			}
		}
		
		private void OnDrawGizmos()
		{
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(transform.position, 20f);
		}
	}
}