using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class logicGame : MonoBehaviour
{
    [SerializeField] private GameObject pit;
    private GameObject player;
    private int valueLogic = 1;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        StartCoroutine(logicOnes(1, 1, 1, 1, 1, 1, new Vector3(34f, 1.78f, 0f), new Vector3(75f, 1.78f, 0f), new Vector3(52f, 0f, 0f)));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LogicGamePlay(int id1, int id2, int time1, int time2, int quanlyti1
        , int quanlity2, Vector3 position1, Vector3 position2)
    {
        var game1 = StartPit(position1);
        StartCoroutine(game1.GetComponent<InstanceMonster>().InstacneMonsterAfterTime(id1, quanlyti1, time1));
        var game2 = StartPit(position2);
        game2.transform.localScale = new Vector3(-1, 1, 1);
        StartCoroutine(game2.GetComponent<InstanceMonster>().InstacneMonsterAfterTime(id2, quanlity2, time2));
        MonsterManager.Instance.valueMonster = quanlyti1 + quanlity2;
        StartCoroutine(game1.GetComponent<InstanceMonster>().diactivePit());
        StartCoroutine(game2.GetComponent<InstanceMonster>().diactivePit());
    }
    public GameObject StartPit(Vector3 position)
    {
        return Instantiate(pit, position, Quaternion.identity);
    }
    private IEnumerator logicOnes(int id1, int id2, int time1, int time2, int quanlity1, int quanlity2
        , Vector3 posPit1, Vector3 posPit2, Vector3 posPlayer)
    {
        yield return new WaitUntil(() => player.transform.position.x > posPlayer.x);
        LogicGamePlay(id1, id2, time1, time2, quanlity1, quanlity2, posPit1, posPit2);
        valueLogic++;
        try
        {
            getLogic(valueLogic).Invoke();
        }
        catch
        {
            yield break;
        }
    }
    private System.Action getLogic(int value)
    {
        print("nguyenHoangThien");
        print(valueLogic);
        switch (valueLogic){
            case 2:
                return scriptTwo;
            case 3:
                return scriptThree;
            case 4:
                return scriptFor;
            default:
                return null;
        }
    }
    private void scriptTwo() => StartCoroutine(logicOnes(0, 2, 1, 1, 2, 3, new Vector3(92f, -5f, 0f), new Vector3(138f, -5f, 0f), new Vector3(119f, 0f, 0f)));
    private void scriptThree() => StartCoroutine(logicOnes(1, 0, 1, 1, 3, 2, new Vector3(292f, 6f, 0f), new Vector3(358f, 6f, 0f), new Vector3(323f, 0f, 0f)));
    private void scriptFor() => StartCoroutine(logicOnes(0, 2, 1, 1, 3, 3, new Vector3(438f, 6f, 0f), new Vector3(546f, 6f, 0f), new Vector3(491f, 0f, 0f)));
}
