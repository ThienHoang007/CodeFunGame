using UnityEngine;
using UnityEngine.UI;

public class controllerAudio : MonoBehaviour
{
    private Slider slider;
    private void Start()
    {
        slider = this.GetComponent<UnityEngine.UI.Slider>();
        slider.value = PlayerPrefs.GetFloat(StringData.Audio);
        slider.onValueChanged.AddListener(changeAudio);
    }
    private void changeAudio(float value) => PlayerPrefs.SetFloat(StringData.Audio, value);
}
