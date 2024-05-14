using UnityEngine;
public class playerController : PlayerControllerBase
{
    [Header("Data Start")]
    public DataPlayer dataPlayer;
    private float speedPlayer;
    private float heightPlayer;
    private float timeAttachPlayer;
    private float damagePlayer;

    [Header("Data Player")]
    [HideInInspector] public float SpeedPlayer;
    [HideInInspector] public float HeightPlayer;
    [HideInInspector] public float TimeAttachPlayer;
    [HideInInspector] public float DamagePlayer;

    private bool isAttach = true;
    public bool isStop = false;

    private Rigidbody2D rigibody;
    private RaycastHit2D hit;
    public PlayerState playerState = PlayerState.Idle;
    private void Start()
    {
        rigibody = GetComponent<Rigidbody2D>();
        SetPlayer();
        setDataPlayer();
    }
    private void Update()
    {
        if (Time.timeScale == 0) return;
        Move(rigibody, SpeedPlayer);
        Flip(rigibody, this.gameObject);
        Jump(rigibody, HeightPlayer, hit, this.gameObject, "ground");
        Attach(ref playerState, timeAttachPlayer, ref isAttach, ref isStop, () => { isAttach = true; });
        StopPlayer(rigibody, isStop);
    }
    public override void SetPlayer()
    {
        speedPlayer = dataPlayer.Speed;
        heightPlayer = dataPlayer.Hieght;
        damagePlayer = dataPlayer.Damage;
        timeAttachPlayer = dataPlayer.AttachSppedUp;
    }
    private void setDataPlayer()
    {
        SpeedPlayer = speedPlayer;
        HeightPlayer = heightPlayer;
        DamagePlayer = damagePlayer;
        TimeAttachPlayer = timeAttachPlayer;
    }
}
