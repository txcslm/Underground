using CodeBase.Infrastructure.Providers;
using UnityEngine;
using Zenject;

namespace CodeBase.Logic.WorldLogic.ProvisionLogic
{
	public class ProvisionFactory
	{
		[Inject]
		private IInstantiator _instantiator;
		
		private IAssetProvider _assetProvider;
		
		public ProvisionFactory(IAssetProvider assetProvider)
		{
			_assetProvider = assetProvider;
		}
		
		public Provision Create()
		{
			Provision provision = _assetProvider.GetMonoBehaviour<Provision>("Provision/Prefabs/Provision");
			provision = _instantiator.InstantiatePrefabForComponent<Provision>(provision);
			
			return provision;
		}
	}
}