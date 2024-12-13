using CodeBase.Logic.Interfaces;

namespace CodeBase.Logic.UnitsLogic.Workers.Providers
{
	public class TargetProvider
	{
		public ITarget CurrentTarget { get; private set; }

		public void SetTarget(ITarget target) =>
			CurrentTarget = target;
	}
}