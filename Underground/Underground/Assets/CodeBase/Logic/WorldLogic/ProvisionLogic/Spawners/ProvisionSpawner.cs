using CodeBase.Logic.WorldLogic.ProvisionLogic.Pools;
using UnityEngine;
using Zenject;

namespace CodeBase.Logic.WorldLogic.ProvisionLogic.Spawners
{
	public class ProvisionSpawner : MonoBehaviour
	{
		[Inject]
		private ProvisionPool _pool;

		private void Start()
		{
			Spawn();
		}

		private void Spawn()
		{
			Provision provision = _pool.Create();
			provision.gameObject.SetActive(true);
			provision.transform.position = transform.position;
		}
	}
}