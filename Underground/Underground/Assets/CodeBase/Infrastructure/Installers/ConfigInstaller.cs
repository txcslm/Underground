using CodeBase.Infrastructure.Initializers;
using Zenject;

namespace CodeBase.Infrastructure.Installers
{
	public class ConfigInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.BindInterfacesAndSelfTo<ConfigInitializer>().FromInstance(GetComponent<ConfigInitializer>()).AsSingle().NonLazy();
		}
	}
}