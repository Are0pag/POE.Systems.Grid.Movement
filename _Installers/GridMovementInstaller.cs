using UnityEngine;
using Zenject;

namespace Scripts.Systems.GridMovement
{
    public class GridMovementInstaller : MonoInstaller
    {
        [SerializeField] private Controller _controller;

        public override void InstallBindings() {
            Container.Bind<GridContent>().AsSingle();
            Container.Bind<TraceCorrector>().AsSingle();
            Container.Bind<Controller>().FromInstance(_controller).AsSingle();
        }
    }
}