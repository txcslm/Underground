using UnityEngine;

namespace CodeBase.Infrastructure.Providers
{
	public interface IAssetProvider
	{
		T GetScriptable<T>(string path) where T : ScriptableObject;
	}
}