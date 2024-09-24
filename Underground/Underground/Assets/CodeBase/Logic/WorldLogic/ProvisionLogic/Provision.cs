using CodeBase.Logic.Units.Workers.StateMachines.States.Interfaces;
using UnityEngine;

namespace CodeBase.Logic.WorldLogic.ProvisionLogic
{
	public class Provision: MonoBehaviour, ITarget
	{
		public Vector3 Position => transform.position;

		private void OnTriggerEnter(Collider other)
		{
			if (other.TryGetComponent(out ProvisionCollectorTag collectorTag))
			{
				transform.SetParent(collectorTag.transform);
			}
		}
	}
}