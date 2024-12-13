using CodeBase.Logic.UnitsLogic.Workers.StateMachines.States;

namespace CodeBase.Logic.UnitsLogic.Workers.StateMachines.Interfaces
{
	public interface IStateChanger
	{
		void ChangeState(State state);
	}
}