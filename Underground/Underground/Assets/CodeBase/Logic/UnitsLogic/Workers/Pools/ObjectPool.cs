using UnityEngine;

namespace CodeBase.Logic.Units.Workers.Pools
{
	public abstract class ObjectPool<T> where T : MonoBehaviour
	{
		public abstract T Create();

		public abstract void Initialize();

		public abstract void Despawn(Worker worker);

		public abstract void Dispose();
	}
}