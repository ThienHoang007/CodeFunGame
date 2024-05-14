using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    private static SkillManager instance = null;
    public static SkillManager Instance { get { return instance; } }

    private HealthPlayerController healthPlayerController;
    public HealthPlayerController HealthPlayer {  get { return healthPlayerController; } }

    public List<DataSkillBuck> Bucks = new List<DataSkillBuck>();
    public List<DataSkillBuck> Steves = new List<DataSkillBuck>();
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null) instance = this;
        else if (this.GetInstanceID() != instance.GetInstanceID())
        {
            Destroy(this);
        }
    }
    private void Start()
    {
        healthPlayerController = GameObject.Find("player").GetComponent<HealthPlayerController>();
    }
    public List<DataSkillBuck> GetListDataSkill(int id)
    {
        if (id == 1) return Bucks;
        else if (id == 2) return Steves;
        else return null;
    }
}