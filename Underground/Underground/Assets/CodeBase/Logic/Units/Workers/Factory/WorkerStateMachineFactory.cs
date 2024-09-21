using CodeBase.Logic.Units.Workers.StateMachines;
using UnityEngine;

namespace CodeBase.Logic.Units.Workers.Factory
{
	public class WorkerStateMachineFactory : MonoBehaviour
	{
		public WorkerStateMachine Create()
		{
			var stateMachine = new WorkerStateMachine();
			
			return stateMachine;
		}
	}
}