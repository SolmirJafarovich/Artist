using UnityEngine;
using Zenject;

public class CutsceneInstaller : MonoBehaviour
{
   [SerializeField] private CutsceneService _cutsceneService;

   private void Awake()
    {
        ProjectContext.Instance.Container.Bind<CutsceneService>().FromInstance(_cutsceneService);
    }
}