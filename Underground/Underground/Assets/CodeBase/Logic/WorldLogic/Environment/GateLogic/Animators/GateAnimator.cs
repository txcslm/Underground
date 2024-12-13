using UnityEngine;

namespace CodeBase.Logic.WorldLogic.Environment.GateLogic.Animators
{
	public class GateAnimator : MonoBehaviour
	{
		private const string OpenTrigger = "Open";
		private const string CloseTrigger = "Close";

		private readonly static int OpenHash = Animator.StringToHash(OpenTrigger);
		private readonly static int CloseHash = Animator.StringToHash(CloseTrigger);

		private Animator _animator;

		private void Awake() =>
			_animator = GetComponent<Animator>();

		public void Open() =>
			_animator.SetTrigger(OpenHash);

		public void Close() =>
			_animator.SetTrigger(CloseHash);
	}
}