using Zenject;
using UnityEngine;
public class CoreInstaller:MonoInstaller
{
    [SerializeField] AudioService audioService;

    public override void InstallBindings()
    {
        Container.Bind<DataLoader>().AsSingle();


        Container.Bind<AudioService>().FromInstance(audioService);

    }


}
