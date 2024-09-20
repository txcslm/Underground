using System;
using CodeBase.Infrastructure.Providers;
using UnityEngine;

namespace CodeBase.Infrastructure.Installers
{
	public class ResourceFolderAssetProvider : IAssetProvider
	{
		public T GetScriptable<T>(string path) where T : ScriptableObject =>
			Resources.Load<T>(path) ?? throw new Exception("Asset not found: " + typeof(T).Name + " " + path);
	}
}