using System;
using UnityEngine;

namespace CodeBase.Infrastructure.Providers
{
	public class ResourceFolderAssetProvider : IAssetProvider
	{
		public T GetScriptable<T>(string path) where T : ScriptableObject =>
			Resources.Load<T>(path) ?? throw new Exception("Asset not found: " + typeof(T).Name + " " + path);

		public T GetMonoBehaviour<T>(string path) where T : MonoBehaviour =>
			Resources.Load<T>(path) ?? throw new Exception("Asset not found: " + typeof(T).Name + " " + path);
	}
}