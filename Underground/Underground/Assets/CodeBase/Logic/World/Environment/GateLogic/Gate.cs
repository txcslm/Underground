using CodeBase.Logic.Units.Workers;
using CodeBase.Logic.World.Environment.GateLogic.Animators;
using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.Logic.World.Environment.GateLogic
{
	[RequireComponent(typeof(GateAnimator), typeof(BoxCollider))]
	public class Gate : MonoBehaviour
	{
		[SerializeField] private GateAnimator _animator;

		private void OnTriggerEnter(Collider other)
		{
			if (!other.TryGetComponent(out Worker _))
				return;
			
			_animator.Open();
		}

		private void OnTriggerExit(Collider other)
		{
			if (!other.TryGetComponent(out Worker _))
				return;
			
			_animator.Close();
		}
	}
}