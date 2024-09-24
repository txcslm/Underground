using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace CodeBase.Logic.Units.Workers.Pools
{
	public class WorkerPool : ObjectPool<Worker>
	{
		[Inject]
		private readonly WorkerFactory _factory;

		private List<Worker> _workers;
		
		public IReadOnlyList<Worker> Workers => _workers;

		public WorkerPool()
		{
			Initialize();
		}
		
		public override Worker Create()
		{
			Worker worker = _factory.Create();

			if(_workers == null)
				Initialize();

			if (_workers != null)
			{
				_workers.Add(worker);
				Debug.Log(_workers.Count);
			}

			worker.gameObject.SetActive(false);

			return worker;
		}

		public override void Despawn(Worker worker)
		{
			worker.gameObject.SetActive(false);
			_workers.Remove(worker);
		}

		public override sealed void Initialize()
		{
			_workers = new List<Worker>();
		}

		public override void Dispose()
		{
			foreach (var worker in _workers)
			{
				worker.Dispose();
			}

			_workers.Clear();
		}
	}
}