using Sirenix.OdinInspector;
using UnityEngine;

namespace CodeBase.Infrastructure.Input.Configs
{
	[CreateAssetMenu(fileName = "CameraConfig", menuName = "Input/CameraConfig")]
	public class CameraConfig : ScriptableObject
	{
		[BoxGroup("Horizontal Translation")]
		[SerializeField]
		private float _maxSpeed = 15f;

		[BoxGroup("Horizontal Translation")]
		[SerializeField]
		private float _acceleration = 10f;

		[BoxGroup("Horizontal Translation")]
		[SerializeField]
		private float _damping = 15f;

		[BoxGroup("Vertical Translation")]
		[SerializeField]
		private float _stepSize = 2f;

		[BoxGroup("Vertical Translation")]
		[SerializeField]
		private float _zoomDampening = 3f;

		[BoxGroup("Vertical Translation")]
		[SerializeField]
		private float _minHeight = 18f;

		[BoxGroup("Vertical Translation")]
		[SerializeField]
		private float _maxHeight = 100f;

		[BoxGroup("Vertical Translation")]
		[SerializeField]
		private float _zoomSpeed = 10f;

		[BoxGroup("Rotation")]
		[SerializeField]
		private float _maxRotationSpeedX = 0.2f;

		[BoxGroup("Rotation")]
		[SerializeField] 
		private float _maxRotationSpeedY = 0.2f;

		[BoxGroup("Rotation")] 
		[SerializeField]
		private float _minRotationY = 1f;

		[BoxGroup("Rotation")]
		[SerializeField] 
		private float _maxRotationY = 60f;

		[BoxGroup("Rotation")]
		[SerializeField] 
		private float _rotationDamping = 100f;
		

		public float MaxSpeed => _maxSpeed;

		public float Acceleration => _acceleration;

		public float Damping => _damping;

		public float StepSize => _stepSize;

		public float ZoomDampening => _zoomDampening;

		public float MinHeight => _minHeight;

		public float MaxHeight => _maxHeight;

		public float ZoomSpeed => _zoomSpeed;

		public float MaxRotationSpeedX => _maxRotationSpeedX;

		public float MaxRotationSpeedY => _maxRotationSpeedY;

		public float MinRotationY => _minRotationY;

		public float MaxRotationY => _maxRotationY;

		public float RotationDamping => _rotationDamping;
		
	}
}