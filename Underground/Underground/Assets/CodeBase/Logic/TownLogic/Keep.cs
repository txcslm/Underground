using System.Collections;
using CodeBase.Logic.Interfaces;
using CodeBase.Logic.UnitsLogic.Workers;
using CodeBase.Logic.UnitsLogic.Workers.Pools;
using CodeBase.Logic.UnitsLogic.Workers.Providers;
using CodeBase.Logic.UnitsLogic.Workers.Spawner;
using CodeBase.Logic.WorldLogic.ProvisionLogic;
using UnityEngine;
using Zenject;

namespace CodeBase.Logic.TownLogic
{
	public class Keep : MonoBehaviour, ITarget
	{
		[SerializeField] private WorkerSpawner _workerSpawner;
		[SerializeField] private LayerMask _layerMask;
		
		[Inject]
		private WorkerPool _workerPool;

		[Inject] 
		private TargetProvider _targetProvider;
		
		public Vector3 Position => transform.position;

		public void Start()
		{
			_workerSpawner.Spawn();

			StartCoroutine(Work());
		}

		private IEnumerator Work()
		{
			Worker worker =_workerPool.Get();
			
			Collider[] colliders = Physics.OverlapSphere(transform.position, 20f, _layerMask);

			foreach (Collider other in colliders)
			{
				if (!other.TryGetComponent(out Provision target))
					continue;

				if (worker.IsBusy)
					continue;
				
				_targetProvider.SetTarget(target);
			}
			
			yield return new WaitForSecondsRealtime(10f);
			
			_targetProvider.SetTarget(this);
			worker.StopWork();
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(transform.position, 20f);
		}
	}
}