using System.Collections.Generic;
using System.Linq;
using CodeBase.Logic.UnitsLogic.Workers.Factory;
using Zenject;

namespace CodeBase.Logic.UnitsLogic.Workers.Pools
{
	public class WorkerPool : ObjectPool<Worker>
	{
		[Inject]
		private readonly WorkerFactory _factory;

		private Queue<Worker> _workers;
		
		public WorkerPool()
		{
			Initialize();
		}

		public override Worker Get() =>
			_workers.FirstOrDefault();

		public override Worker Create()
		{
			Worker worker = _factory.Create();

			if(_workers == null)
				Initialize();

			_workers?.Enqueue(worker);

			worker.gameObject.SetActive(false);

			return worker;
		}

		public override void Despawn(Worker provision)
		{
			provision.gameObject.SetActive(false);
			 _workers.Dequeue();
		}

		public override sealed void Initialize()
		{
			_workers = new Queue<Worker>();
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