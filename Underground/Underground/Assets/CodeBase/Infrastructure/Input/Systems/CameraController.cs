using CodeBase.Infrastructure.Providers;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace CodeBase.Infrastructure.Input.Systems
{
	public class CameraController : MonoBehaviour
	{
		[Inject] private ConfigProvider _provider;

		private CameraControls _cameraActions;
		private InputAction _movement;
		private Transform _cameraTransform;

		private float _speed;
		private float _zoomHeight;

		private Vector3 _targetPosition;
		private Vector3 _horizontalVelocity;
		private Vector3 _lastPosition;
		private Vector3 _startDrag;

		private void Awake()
		{
			_cameraActions = new CameraControls();
			_cameraTransform = GetComponentInChildren<Camera>().transform;
		}

		private void OnEnable()
		{
			_zoomHeight = _cameraTransform.localPosition.y;
			_cameraTransform.LookAt(transform);

			_lastPosition = transform.position;

			_movement = _cameraActions.Camera.MoveCamera;
			_cameraActions.Camera.RotateCamera.performed += RotateCamera;
			_cameraActions.Camera.ZoomCamera.performed += ZoomCamera;
			_cameraActions.Camera.Enable();
		}

		private void OnDisable()
		{
			_cameraActions.Camera.RotateCamera.performed -= RotateCamera;
			_cameraActions.Camera.ZoomCamera.performed -= ZoomCamera;
			_cameraActions.Camera.Disable();
		}

		private void Update()
		{
			GetKeyboardMovement();
			DragCamera();

			UpdateVelocity();
			UpdateBasePosition();
			UpdateCameraPosition();
		}

		private void UpdateVelocity()
		{
			_horizontalVelocity = (transform.position - _lastPosition) / Time.deltaTime;
			_horizontalVelocity.y = 0f;
			_lastPosition = transform.position;
		}

		private void GetKeyboardMovement()
		{
			Vector3 inputValue = _movement.ReadValue<Vector2>().x * GetCameraRight() + _movement.ReadValue<Vector2>().y * GetCameraForward();

			inputValue = inputValue.normalized;

			if (inputValue.sqrMagnitude > 0.1f)
				_targetPosition += inputValue;
		}

		private void DragCamera()
		{
			if (!Mouse.current.rightButton.isPressed)
				return;

			Plane plane = new Plane(Vector3.up, Vector3.zero);
			Ray ray = Camera.main!.ScreenPointToRay(Mouse.current.position.ReadValue());

			if (!plane.Raycast(ray, out float distance))
				return;

			if (Mouse.current.rightButton.wasPressedThisFrame)
				_startDrag = ray.GetPoint(distance);
			else
				_targetPosition += _startDrag - ray.GetPoint(distance);
		}

		private void UpdateBasePosition()
		{
			if (_targetPosition.sqrMagnitude > 0.1f)
			{
				_speed = Mathf.Lerp(_speed, _provider.CameraConfig.MaxSpeed, Time.deltaTime * _provider.CameraConfig.Acceleration);
				transform.position += _targetPosition * (_speed * Time.deltaTime);
			}
			else
			{
				_horizontalVelocity = Vector3.Lerp(_horizontalVelocity, Vector3.zero, Time.deltaTime * _provider.CameraConfig.Damping);
				transform.position += _horizontalVelocity * Time.deltaTime;
			}

			_targetPosition = Vector3.zero;
		}

		private void ZoomCamera(InputAction.CallbackContext input)
		{
			float inputValue = -input.ReadValue<Vector2>().y;

			if (!(Mathf.Abs(inputValue) > 0.1f))
				return;

			_zoomHeight = _cameraTransform.localPosition.y + inputValue * _provider.CameraConfig.StepSize;

			if (_zoomHeight < _provider.CameraConfig.MinHeight)
				_zoomHeight = _provider.CameraConfig.MinHeight;
			else if (_zoomHeight > _provider.CameraConfig.MaxHeight)
				_zoomHeight = _provider.CameraConfig.MaxHeight;
		}

		private void UpdateCameraPosition()
		{
			Vector3 zoomTarget = new Vector3(_cameraTransform.localPosition.x, _zoomHeight, _cameraTransform.localPosition.z);
			zoomTarget -= _provider.CameraConfig.ZoomSpeed * (_zoomHeight - _cameraTransform.localPosition.y) * Vector3.forward;

			_cameraTransform.localPosition = Vector3.Lerp(_cameraTransform.localPosition, zoomTarget, Time.deltaTime * _provider.CameraConfig.ZoomDampening);
			_cameraTransform.LookAt(transform);
		}

		private void RotateCamera(InputAction.CallbackContext input)
		{
			if (!Mouse.current.middleButton.isPressed)
				return;

			float inputValueX = input.ReadValue<Vector2>().x;
			float inputValueY = input.ReadValue<Vector2>().y;

			Vector3 currentRotation = transform.rotation.eulerAngles;

			float targetRotationX = Mathf.Clamp(currentRotation.x + inputValueY * _provider.CameraConfig.MaxRotationSpeedY,
				_provider.CameraConfig.MinRotationY,
				_provider.CameraConfig.MaxRotationY);
			float targetRotationY = currentRotation.y + inputValueX * _provider.CameraConfig.MaxRotationSpeedX;

			Quaternion targetRotation = Quaternion.Euler(targetRotationX, targetRotationY, 0f);

			transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * _provider.CameraConfig.RotationDamping);
		}

		private Vector3 GetCameraForward()
		{
			Vector3 forward = _cameraTransform.forward;
			forward.y = 0f;
			return forward;
		}

		private Vector3 GetCameraRight()
		{
			Vector3 right = _cameraTransform.right;
			right.y = 0f;
			return right;
		}
	}
}