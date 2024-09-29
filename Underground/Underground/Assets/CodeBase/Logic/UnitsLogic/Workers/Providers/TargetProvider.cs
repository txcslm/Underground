using CodeBase.Logic.Units.Workers.StateMachines.States.Interfaces;

public class TargetProvider
{
	public ITarget CurrentTarget { get; private set; }

	public void SetTarget(ITarget target) =>
		CurrentTarget = target;
}