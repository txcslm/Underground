using CodeBase.Logic.WorldLogic.Environment.GateLogic.Animators;
using CodeBase.Logic.WorldLogic.Environment.GateLogic.Tags;
using UnityEngine;

namespace CodeBase.Logic.WorldLogic.Environment.GateLogic
{
	[RequireComponent(typeof(GateAnimator), typeof(BoxCollider))]
	public class Gate : MonoBehaviour
	{
		[SerializeField] private GateAnimator _animator;

		private void OnTriggerEnter(Collider other)
		{
			if (!other.TryGetComponent(out GateOpenTag _))
				return;
			
			_animator.Open();
		}

		private void OnTriggerExit(Collider other)
		{
			if (!other.TryGetComponent(out GateOpenTag _))
				return;
			
			_animator.Close();
		}
	}
}