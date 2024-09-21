using UnityEngine;

namespace CodeBase.Logic.Units.Workers.Animators
{
	public class WorkerAnimator : MonoBehaviour
	{
		private const string Run = "IsRun";
		private const string Work = "IsWork";

		private readonly static int IsRun = Animator.StringToHash(Run);
		private readonly static int IsWork = Animator.StringToHash(Work);

		private Animator _animator;

		private void Awake() =>
			_animator = GetComponent<Animator>();
		
		public void PlayRun() =>
			_animator.SetBool(IsRun, true);

		public void PlayWork() =>
			_animator.SetBool(IsWork, true);

		public void StopRun() =>
			_animator.SetBool(IsRun, false);

		public void StopWork() =>
			_animator.SetBool(IsWork, false);
	}
}