using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneSwitcherManager : MonoBehaviour
{
    [SerializeField] private SceneSwitcherManagerSubscriptionEventChannelSO sceneSwitcherManagerSubscriptionEventChannel;
    [SerializeField] private Fader fader;
    [SerializeField] private bool switchWithFade;

    private string currentSceneName;
    private string callingSceneName;

    private void Start()
    {
        this.currentSceneName = SceneManager.GetActiveScene().name;
        //SwitchScene("SecondScene");
    }
    
    private void OnEnable()
    {
        sceneSwitcherManagerSubscriptionEventChannel.OnEventRaised += SwitchScene;
    }

    private void OnDisable()
    {
        sceneSwitcherManagerSubscriptionEventChannel.OnEventRaised -= SwitchScene;
    }

    private void SwitchScene(string destinationSceneName)
    {
        if(this.switchWithFade)
            StartCoroutine(fader.FadeInAndOut(() => LoadDestinationScene(destinationSceneName)));
        else
            LoadDestinationScene(destinationSceneName);
    }

    private void LoadDestinationScene(string destinationSceneName)
    {
        this.callingSceneName = this.currentSceneName;

        AsyncOperation preloadDestinationSceneAsync = SceneManager.LoadSceneAsync(destinationSceneName, LoadSceneMode.Additive);
        
        preloadDestinationSceneAsync.completed += (async) => 
        {
            AsyncOperation unloadCallingSceneAsync = SceneManager.UnloadSceneAsync(this.callingSceneName);

            unloadCallingSceneAsync.completed += (async) =>
            {
                Scene destinationScene = SceneManager.GetSceneByName(destinationSceneName);
        
                if (destinationScene.IsValid())
                    SceneManager.SetActiveScene(destinationScene);
                
                this.currentSceneName = SceneManager.GetActiveScene().name;
            };
        };
    }
}