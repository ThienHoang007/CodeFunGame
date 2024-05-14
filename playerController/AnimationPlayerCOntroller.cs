using System;
using System.Collections;
using UnityEngine;

public class AnimationPlayerController : MonoBehaviour
{
    private Animator AnimatorPlayer;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        AnimatorPlayer = GetComponent<Animator>();
        StartCoroutine(nextFrame());
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAnimationPlayer(GetStatePlayer(player));
    }
    private void UpdateAnimationPlayer(playerController.PlayerState playerState)
    {
        for (int i=0;i <= maxStatePlayer();i++)
        {
            if((playerController.PlayerState)i == playerState)
            {
                AnimatorPlayer.SetBool(((playerController.PlayerState)i).ToString(), true);
            }
            else AnimatorPlayer.SetBool(((playerController.PlayerState)i).ToString(), false);
        }
    }
    private int maxStatePlayer()
    {
        playerController.PlayerState[] states = (playerController.PlayerState[])Enum.GetValues(typeof(playerController.PlayerState));
        return (int)states[states.Length - 1];
    }
    private playerController.PlayerState GetStatePlayer(GameObject player)
    {
        if (player.GetComponent<playerController>().playerState == PlayerControllerBase.PlayerState.Die) return playerController.PlayerState.Die;
        else if (player.GetComponent<playerController>().playerState == playerController.PlayerState.Attach) return playerController.PlayerState.Attach;
        else if (player.GetComponent<Rigidbody2D>().velocity.x != 0) return playerController.PlayerState.Run;
        else return PlayerControllerBase.PlayerState.Idle;
    }
    private IEnumerator nextFrame()
    {
        this.enabled = false;
        yield return new WaitForSeconds(0.4f);
        this.enabled = true;
    }
}
