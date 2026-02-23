using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] InputController inputController;
    [SerializeField] PositionInputController positionInput;
    [SerializeField] PhoneInputController phoneInputController;
    [SerializeField] PhonePositionInputController phonePositionInputController;
    [SerializeField] PlayerCubeSpawner spawner;
    [SerializeField] GameFlow gameflow;
    public override void InstallBindings()
    {
        CheckDevice();

        Container.Bind<IImpactableObjectSpawner>().To<PlayerCubeSpawner>().FromInstance(spawner).AsSingle();
        Container.Bind<IMergeService>().To<MergeService>().AsSingle();
        Container.Bind<VisualizeService>().AsSingle();
        Container.Bind<IGameOver>().To<GameFlow>().FromInstance(gameflow).AsSingle();
    }

    void CheckDevice()
    {
        if (Application.isMobilePlatform)
        {
            Container.Bind<IHoldInput>().To<PhoneInputController>().FromInstance(phoneInputController).AsSingle();
            Container.Bind<IPositionInput>().To<PhonePositionInputController>().FromInstance(phonePositionInputController).AsSingle();

            phoneInputController.gameObject.SetActive(true);
            inputController.gameObject.SetActive(false);
        }
        else
        {
            Container.Bind<IHoldInput>().To<InputController>().FromInstance(inputController).AsSingle();
            Container.Bind<IPositionInput>().To<PositionInputController>().FromInstance(positionInput).AsSingle();

            phoneInputController.gameObject.SetActive(false);
            inputController.gameObject.SetActive(true);
        }
    }    
}
