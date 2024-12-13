using CodeBase.Infrastructure.Providers;
using Zenject;

namespace CodeBase.Logic.UnitsLogic.Workers.Factory
{
	public class WorkerFactory
	{
		private readonly IAssetProvider _assetProvider;

		[Inject] 
		private IInstantiator _instantiator;
		
		public WorkerFactory(IAssetProvider assetProvider)
		{
			_assetProvider = assetProvider;
		}
		
		public Worker Create()
		{
			Worker worker = _assetProvider.GetMonoBehaviour<Worker>("Worker/Prefab/Worker");
			worker = _instantiator.InstantiatePrefabForComponent<Worker>(worker);
			return worker;
		}
	}
}