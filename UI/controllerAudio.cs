using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class controllerMenuAudio : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Text txtLevel;
    private void Start()
    {
        slider.value = PlayerPrefs.GetFloat(StringData.Audio);
        slider.onValueChanged.AddListener(changeAudio);
        txtLevel.text = "Level : " + PlayerPrefs.GetString(StringData.NameLevel);
    }
    private void changeAudio(float value) => PlayerPrefs.SetFloat(StringData.Audio, value);
    public void removeScene()
    {
        Time.timeScale = 1.0f;
        SceneManager.UnloadSceneAsync("Menu");
    }
    public void removeSceneLevel()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("SceneLoad", LoadSceneMode.Single);
    }
}
