using CodeBase.Logic.UnitsLogic.Workers.Factory;
using CodeBase.Logic.UnitsLogic.Workers.Pools;
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