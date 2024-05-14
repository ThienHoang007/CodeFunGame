using System.Collections.Generic;
using UnityEngine;

public class EventAnimation : MonoBehaviour
{
    [SerializeField] private GameObject skill;
    [SerializeField] private GameObject skillFor;
    private List<GameObject> skills = new List<GameObject>();
    private RaycastHit2D[] hits;
    private RaycastHit2D hit;
    private Vector3 point;

    private void Update()
    {
        hit = Physics2D.Raycast(this.transform.parent.transform.position, Vector2.down, 15f);
        point = hit.point;
    }
    public void SetEndPlayerAttachAnimation()
    {
        this.transform.parent.GetComponent<playerController>().playerState = playerController.PlayerState.Idle;
        this.transform.parent.GetComponent<playerController>().isStop = false;
    }
    public void AddDamageForAllMonster()
    {
        hits = Physics2D.RaycastAll(this.transform.position + (this.transform.parent.localScale.x > 0 ? new Vector3(-0.4f,0f,0f) : new Vector3(0.4f,0f,0f))
            , this.transform.parent.localScale.x > 0 ? new Vector2(1, 0) : new Vector2(-1, 0), 2f, Physics2D.AllLayers);
        if(hits.Length > 0 )
        {
            foreach (var hit in hits)
            {
                if (hit.collider.gameObject.CompareTag("monster")) hit.collider.GetComponent<controllerHealthMonster>().takeDamageAndDie_Monster(this.transform.parent.GetComponent<playerController>().DamagePlayer);
            }
        }
    }
    public void addHealthForPlayer()
    {
        this.transform.parent.GetComponent<HealthPlayerController>().takeHealthForPlayer(this.transform.parent.GetComponent<playerController>().DamagePlayer);
    }
    public void AddSkillFor()
    {
        if (!skillFor.GetComponent<Skill4BuckPlayer>().isSkill4) return;
        if(skills.Count == 0)
        {
            var game = Instantiate(skill, point, Quaternion.identity);
            game.GetComponent<bulletPlayerController>().normal = this.transform.parent.localScale.x > 0 ? new Vector2(1, 0) : new Vector2(-1, 0);
            skills.Add(game);
        }
        else
        {
            foreach(var skill in skills)
            { 
                if(!skill.activeSelf)
                {
                    skill.SetActive(true);
                    skill.transform.position = point;
                    skill.GetComponent<bulletPlayerController>().speed = skill.GetComponent<bulletPlayerController>().Speed;
                    skill.GetComponent<bulletPlayerController>().normal = this.transform.parent.localScale.x > 0 ? new Vector2(1, 0) : new Vector2(-1, 0);
                    return;
                }
            }
            var game = Instantiate(skill, point, Quaternion.identity);
            game.GetComponent<bulletPlayerController>().normal = this.transform.parent.localScale.x > 0 ? new Vector2(1, 0) : new Vector2(-1, 0);
            skills.Add(game);
        }
    }
    public void GameOver()
    {
        print("die");
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver", UnityEngine.SceneManagement.LoadSceneMode.Additive);
        this.transform.parent.gameObject.SetActive(false);
    }
}
