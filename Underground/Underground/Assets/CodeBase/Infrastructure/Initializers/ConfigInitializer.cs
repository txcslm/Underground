using CodeBase.Infrastructure.Providers;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Initializers
{
	public class ConfigInitializer : MonoBehaviour, IInitializable
	{
		[Inject] private ConfigProvider _configProvider;
		
		public void Initialize()
		{
			_configProvider.LoadConfigs();
		}
	}
}