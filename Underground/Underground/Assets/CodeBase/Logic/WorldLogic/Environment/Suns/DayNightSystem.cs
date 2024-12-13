using System.Collections;
using CodeBase.Infrastructure.Providers;
using UnityEngine;
using Zenject;

namespace CodeBase.Logic.WorldLogic.Environment.Suns
{
	public class DayNightSystem : MonoBehaviour
	{
		[Inject] private ConfigProvider _configProvider;
		
		private Transform _lightTransform;

		private void Awake() =>
			_lightTransform = GetComponent<Light>().transform;

		private void Start() =>	StartCoroutine(TimeCoroutine());

		private void OnDestroy() =>
			StopCoroutine(TimeCoroutine());

		private IEnumerator TimeCoroutine()
		{
			const float Epsilon = 0.1f;
			
			while (true)
			{
				float currentRotationX = _lightTransform.eulerAngles.x;
				
				if (Mathf.Abs(currentRotationX - _configProvider.DayNightConfig.MaxRotationX) < Epsilon)
				{
					_lightTransform.eulerAngles = new Vector3(_configProvider.DayNightConfig.MinRotationX, _lightTransform.eulerAngles.y, _lightTransform.eulerAngles.z);
				}
				else
				{
					float speed = currentRotationX >= 180f ? _configProvider.DayNightConfig.Speed * _configProvider.DayNightConfig.NightSpeedModifier : _configProvider.DayNightConfig.Speed;
					_lightTransform.Rotate(Vector3.right, speed * Time.deltaTime);
				}

				yield return null;
			}	
		}
	}
}