using CodeBase.Logic.WorldLogic.ProvisionLogic;
using CodeBase.Logic.WorldLogic.ProvisionLogic.Pools;
using Zenject;

namespace CodeBase.Infrastructure.Installers
{
	public class ProvisionInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.BindInterfacesAndSelfTo<ProvisionPool>().AsSingle();
			Container.BindInterfacesAndSelfTo<ProvisionFactory>().AsSingle();
		}
	}
}