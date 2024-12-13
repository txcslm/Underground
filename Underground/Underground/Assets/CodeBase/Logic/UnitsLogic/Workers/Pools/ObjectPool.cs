using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Logic.UnitsLogic.Workers.Pools
{
	public abstract class ObjectPool<T> where T : MonoBehaviour
	{
		protected Queue<T> _pools;
		
		public abstract T Get();
		public abstract T Create();

		public abstract void Initialize();

		public abstract void Despawn(T provision);

		public abstract void Dispose();
	}
}