using System;
using CodeBase.Infrastructure.Input.Configs;
using CodeBase.Logic.WorldLogic.Environment.Suns;
using UnityEngine;

namespace CodeBase.Infrastructure.Providers
{
	public class ConfigProvider
	{
		private readonly IAssetProvider _assetProvider;

		public ConfigProvider(IAssetProvider assetProvider) =>
			_assetProvider = assetProvider;

		public CameraConfig CameraConfig { get; private set; }
		public DayNightConfig DayNightConfig { get; private set; }

		public void LoadConfigs()
		{
			CameraConfig = Load<CameraConfig>();
			DayNightConfig = Load<DayNightConfig>();
		}

		private T Load<T>() where T : ScriptableObject
		{
			string name = typeof(T).Name;
			string path = "Configs/" + name;
			
			T config = _assetProvider.GetScriptable<T>(path) ?? throw new ArgumentNullException($"Не нашел!)");
			
			return config;
		}
	}
}