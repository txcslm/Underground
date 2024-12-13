using System.Collections.Generic;
using CodeBase.Logic.UnitsLogic.Workers.Pools;
using CodeBase.Logic.WorldLogic.ProvisionLogic.Factories;
using Zenject;

namespace CodeBase.Logic.WorldLogic.ProvisionLogic.Pools
{
	public class ProvisionPool : ObjectPool<Provision>
	{
		[Inject]
		private readonly ProvisionFactory _factory;

		private Queue<Provision> _provisions;
		
		public ProvisionPool()
		{
			Initialize();
		}

		public override Provision Get() =>
			_provisions.Dequeue();

		public override Provision Create()
		{
			Provision provision = _factory.Create();

			if(_provisions == null)
				Initialize();

			_provisions?.Enqueue(provision);

			provision.gameObject.SetActive(false);

			return provision;
		}

		public override void Despawn(Provision provision)
		{
			provision.gameObject.SetActive(false);
			_provisions.Dequeue();
		}

		public override sealed void Initialize()
		{
			_provisions = new Queue<Provision>();
		}

		public override void Dispose()
		{
			// foreach (var worker in _provisions)
			// {
			// 	worker.Dispose();
			// }

			_provisions.Clear();
		}
	}
}