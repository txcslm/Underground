using CodeBase.Logic.UnitsLogic.Workers.Pools;
using UnityEngine;
using Zenject;

namespace CodeBase.Logic.UnitsLogic.Workers.Spawner
{
	public class WorkerSpawner : MonoBehaviour
	{
		[Inject]
		private WorkerPool _pool;
		
		public void Spawn()
		{
			var worker = _pool.Create();
			worker.transform.localPosition = transform.position;
			worker.gameObject.SetActive(true);
		}
	}
}