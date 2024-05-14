using UnityEngine;

public class moveCamera : MonoBehaviour
{
    private GameObject player;
    private AudioSource Audio;
    private void Start()
    {
        player = GameObject.Find("player");
        Audio = this.GetComponent<AudioSource>();
        PlayerPrefs.SetFloat(StringData.Audio, 1);
    }
    void Update()
    {
        this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 2.5f, -10);
        Audio.volume = PlayerPrefs.GetFloat(StringData.Audio);
    }
}
