using CodeBase.Logic.Units.Workers.StateMachines.States.Interfaces;

namespace CodeBase.Logic.Units.Workers.StateMachines.Interfaces
{
	public interface IStateChanger
	{
		void ChangeState(State state);
	}
}