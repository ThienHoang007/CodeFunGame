using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public static GameManager Instance => instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null && this.GetInstanceID() != instance.GetInstanceID()) Destroy(this);
    }
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        Save(new DataGame());
    }
    public void loadScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene, LoadSceneMode.Single);
    }
    public void SaveIdCharacter(int value)
    {
        DataGame GameData;
        if (Load<DataGame>(PlayerPrefs.GetString(StringData.nameDataGame)) == null || Load<DataGame>(PlayerPrefs.GetString(StringData.nameDataGame)).idCharacter.Count == 0) GameData = new DataGame();
        else GameData = Load<DataGame>(PlayerPrefs.GetString(StringData.nameDataGame));
        if(GameData.idCharacter == null)
        {
            GameData.idCharacter = new List<int> { value };
            Save(GameData);
            PlayerPrefs.SetInt(StringData.idCharacter, value);
            return;
        }
        GameData.idCharacter.Add(value);
        Save(GameData);
        PlayerPrefs.SetInt(StringData.idCharacter, value);
    }
    public void Save(object Object)
    {
        string dataGame = JsonUtility.ToJson(Object);
        PlayerPrefs.SetString(StringData.nameDataGame, dataGame);
    }
    public T Load<T>(string path)
    {
        return JsonUtility.FromJson<T>(path);
    }
    public bool isCharacter_Player(int id)
    {
        var data = Load<DataGame>(PlayerPrefs.GetString(StringData.nameDataGame));
        foreach (var item in data.idCharacter)
        {
            if (id == item) return true;
        }
        return false;
    }
}
