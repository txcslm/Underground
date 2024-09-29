using CodeBase.Infrastructure.Providers;
using Zenject;

namespace CodeBase.Infrastructure.Installers
{
	public class SceneInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.BindInterfacesAndSelfTo<ConfigProvider>().AsSingle();
			Container.BindInterfacesAndSelfTo<TargetProvider>().AsSingle();
			Container.Bind<IAssetProvider>().To<ResourceFolderAssetProvider>().AsSingle();
		}
	}
}