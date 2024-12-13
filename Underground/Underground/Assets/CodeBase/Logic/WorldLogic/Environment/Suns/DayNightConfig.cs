using Sirenix.OdinInspector;
using UnityEngine;

namespace CodeBase.Logic.WorldLogic.Environment.Suns
{
	[CreateAssetMenu(fileName = "DayNightConfig", menuName = "Systems/DayNightConfig")]
	public class DayNightConfig : ScriptableObject
	{
		[BoxGroup("Time")]
		[SerializeField] 
		private float _speed = 2.5f;
		
		[BoxGroup("Time")]
		[SerializeField] 
		private float _nightSpeedModifier = 2f;
		
		[BoxGroup("Rotation")]
		[SerializeField] 
		private float _minRotationX = 15f;
		
		[BoxGroup("Rotation")]
		[SerializeField] 
		private float _maxRotationX = 175f;
		
		public float Speed => _speed;
		public float NightSpeedModifier => _nightSpeedModifier;
		public float MinRotationX => _minRotationX;
		public float MaxRotationX => _maxRotationX;

	}
}