using UnityEngine;
using Zenject;

namespace Scripts.Systems.GridMovement
{
    public class GridMovementInstaller : MonoInstaller
    {
        [SerializeField] private ImpactController _controller;
        [SerializeField] private Config _config;

        public override void InstallBindings() {
            Container.Bind<GridContent>().To<GridContentTargetNotifying>().AsSingle();

            Container.Bind<Config>().FromInstance(_config).AsSingle();
            Container.Bind<ImpactCalculator>().AsSingle();
            Container.Bind<TraceCorrector>().To<ImpactTraceCorrector>().AsSingle();
            Container.Bind<Controller>().To<ImpactController>().FromInstance(_controller).AsSingle();
        }
    }
}