using UnityEngine;

namespace CodeBase.Infrastructure.Providers
{
	public interface IAssetProvider
	{
		T GetScriptable<T>(string path) where T : ScriptableObject;

		T GetMonoBehaviour<T>(string path) where T : MonoBehaviour;
	}
}