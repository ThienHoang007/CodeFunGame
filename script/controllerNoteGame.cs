using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class controllerNoteGame : MonoBehaviour
{
    public Text txtNote;
    public Slider loadBar;
    public float speedLoad;
    // Start is called before the first frame update
    void Start()
    {
        txtNote.text = "Note : " + getNoteGame(Random.Range(0, 4));
        loadBar.value = 0;
    }
    private void Update()
    {
        loadBar.value += speedLoad * Time.deltaTime;
        if (loadBar.value >= loadBar.maxValue) SceneManager.LoadScene("Level" + PlayerPrefs.GetInt(StringData.valueLevel));
    }
    private string getNoteGame(int value)
    {
        switch(value)
        {
            case 0:
                return "Chiêu L của steve hồi rất lâu, hãy cẩn thận khi sử dụng nó !";
            case 1:
                return "Buck có khả năng miễn thương cao nhờ vào chiêu J cảu minh";
            case 2:
                return "Goblin có sát thương cao hãy cẩn thận với chúng";
            default:
                return "Sản phẩm được Nguyễn Hoàng Thiện phát hành";
        }
    }
}
