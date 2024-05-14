using UnityEngine.SceneManagement;
using UnityEngine;
using Unity.VisualScripting;
public class SceneManagers : MonoBehaviour
{
    private static SceneManagers instance = null;
    public static SceneManagers Instance => instance;

    private float characterId;
    public float CharacterId => characterId;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null && this.GetInstanceID() != instance.GetInstanceID())
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    public void LoadScene(string name, LoadSceneMode mode)
    {
        SceneManager.LoadScene(name, mode);
    }
    public void setIdCharacter(int id)
    {
        PlayerPrefs.SetInt("IdCharacter", id);
        characterId = id;
    }
    public void replay() => SceneManager.LoadScene("SceneLoad", LoadSceneMode.Single);
    public void toMenu() => SceneManager.LoadScene("MenuLevels", LoadSceneMode.Single);
}
