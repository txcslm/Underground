using UnityEngine;

namespace CodeBase.Logic.Units.Workers.Animators
{
	public class WorkerAnimator : MonoBehaviour
	{
		private const string Speed = "Speed";
		private const string Work = "IsWork";
		
		private const float PlayValue = 1f;
		private const float StopValue = 0f;

		private readonly static int IsWorkHash = Animator.StringToHash(Work);
		private readonly static int SpeedHash = Animator.StringToHash(Speed);

		private Animator _animator;

		private void Awake() =>
			_animator = GetComponent<Animator>();
		
		public void PlayRun() =>
			_animator.SetFloat(SpeedHash, PlayValue);

		public void PlayWork() =>
			_animator.SetBool(IsWorkHash, true);

		public void StopRun() =>
			_animator.SetFloat(SpeedHash, StopValue);

		public void StopWork() =>
			_animator.SetBool(IsWorkHash, false);
	}
}