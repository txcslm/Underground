using CodeBase.Logic.Units.Workers;
using CodeBase.Logic.Units.Workers.Pools;
using CodeBase.Logic.Units.Workers.StateMachines.States.Interfaces;
using Zenject;

namespace CodeBase.Infrastructure.Installers
{
	public class WorkerInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.BindInterfacesAndSelfTo<WorkerPool>().AsSingle();
			Container.BindInterfacesAndSelfTo<WorkerFactory>().AsSingle();
		}
	}
}