using CodeBase.Infrastructure.Providers;
using UnityEngine;

namespace CodeBase.Logic.Units.Workers.Pools
{
	public class WorkerFactory
	{

		private readonly IAssetProvider _assetProvider;
		

		public WorkerFactory(IAssetProvider assetProvider)
		{
			_assetProvider = assetProvider;
		}
		
		public Worker Create()
		{
			Worker worker = _assetProvider.GetMonoBehaviour<Worker>("Worker/Prefab/Worker");
			worker = Object.Instantiate(worker);
			return worker;
		}
	}
}