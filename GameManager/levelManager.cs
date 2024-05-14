using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelsManager : MonoBehaviour
{
    private static LevelsManager instance = null;
    public static LevelsManager Instance => instance;

    private void Awake()
    {
        if (instance == null) instance = this;
        else if (this.GetInstanceID() != instance.GetInstanceID()) Destroy(this);
        PlayerPrefs.SetInt(StringData.valueLevel, 1);
    }
    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name, LoadSceneMode.Single);
    }
    public void LevelUp() => PlayerPrefs.SetInt(StringData.valueLevel, PlayerPrefs.GetInt(StringData.valueLevel) + 1);
}
