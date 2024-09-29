using CodeBase.Logic.Units.Workers.Animators;
using CodeBase.Logic.Units.Workers.Pools;
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