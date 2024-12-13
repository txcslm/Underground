using CodeBase.Logic.Interfaces;
using UnityEngine;

namespace CodeBase.Logic.WorldLogic.ProvisionLogic
{
	public class Provision: MonoBehaviour, ITarget
	{
		public Vector3 Position => transform.position;

		public void SetParent(Transform parent)
		{
			Debug.Log("SetParent");
			transform.parent = parent;
		}

		public void Destroy()
		{
			Destroy(this);
		}
	}
}