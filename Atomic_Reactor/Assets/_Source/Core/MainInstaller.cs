using Core.StateMachine;
using Core.StateMachine.GameStates;
using ResourceSystem;
using ResourceSystem.Services;
using Zenject;

namespace Core
{
    public class MainInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindTimers();
            BindCore();
            BindStateMachine();
            BindStates();
            BindResources();
        }

        private void BindResources()
        {
            Container.BindInterfacesAndSelfTo<RecordLogic>()
                .AsSingle()
                .NonLazy();
        }

        private void BindStates()
        {
            Container.Bind<GameStatesContainer>()
                .AsSingle()
                .NonLazy();
        }

        private void BindCore()
        {
            Container.Bind<GameInfo>()
                .AsSingle()
                .NonLazy();
        }

        private void BindTimers()
        {
            Container.Bind<MonoTimerHandler>()
                .FromComponentInHierarchy()
                .AsSingle()
                .NonLazy();

            Container.Bind<ResourceTimerLoader>()
                .AsSingle()
                .NonLazy();
        }

        private void BindStateMachine()
        {
            Container.Bind<GameStateMachine>()
                .AsSingle()
                .NonLazy();

            Container.Bind<StateMachineLoader>()
                .AsSingle()
                .NonLazy();
        }
    }
}
