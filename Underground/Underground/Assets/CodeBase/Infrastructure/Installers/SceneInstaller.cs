using CodeBase.Infrastructure.Providers;
using CodeBase.Logic.Units.Workers.Pools;
using Zenject;

namespace CodeBase.Infrastructure.Installers
{
	public class SceneInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.BindInterfacesAndSelfTo<ConfigProvider>().AsSingle();
			Container.Bind<IAssetProvider>().To<ResourceFolderAssetProvider>().AsSingle();
		}
	}
}