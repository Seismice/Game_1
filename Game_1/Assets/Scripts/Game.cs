using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game : MonoBehaviour
{
    public int GameTime = 5;
    const int FREQUENCYOFMONSTERS = 5;
    public Slider HealthSlider;
    public Transform StartPosition;
    public EndMenu EndMenu;
    public GameObject RubinPrefab;
    public GameObject GoldPrefab;
    public GameObject[] MonstersPrefabs;
    public TMP_Text GameTimeText;
    public TMP_Text PlayerGoldUI;
    public TMP_Text DamageText;
    public TMP_Text RubinText;
    public int PlayerGold;
    public int PlayerRubin;
    public int PlayerDamage = 10;
    int _count;
    int _currentTime;
    public bool IsEndGame { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

        SpawnMonster();

        InvokeRepeating("Timer", 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerGoldUI.text = PlayerGold.ToString();
        DamageText.text = PlayerDamage.ToString();
        RubinText.text = PlayerRubin.ToString();
    }

    public void TakeRubin(int rubin)
    {
        PlayerRubin += rubin;
        GameObject rubinObject = Instantiate(RubinPrefab) as GameObject;
        Destroy(rubinObject, 3);
    }

    public void TakeGold(int gold)
    {
        PlayerGold += gold;
        GameObject goldObject = Instantiate(GoldPrefab) as GameObject;
        Destroy(goldObject, 2);

        SpawnMonster();
    }

    public void SpawnMonster()
    {
        _count++;

        int randomMaxValue = _count / FREQUENCYOFMONSTERS + 1;

        if (randomMaxValue >= MonstersPrefabs.Length)
            randomMaxValue = MonstersPrefabs.Length;

        int index = Random.Range(0, randomMaxValue);
        
        GameObject monsterObject = Instantiate(MonstersPrefabs[index]) as GameObject;

        monsterObject.transform.position = StartPosition.position;
    }

    void Timer()
    {
        _currentTime++;

        GameTimeText.text = (GameTime - _currentTime).ToString();

        if (_currentTime >= GameTime)
        {
            Time.timeScale = 0;

            IsEndGame = true;
            EndMenu.gameObject.SetActive(true);
            EndMenu.ShowEndGame(PlayerGold);
        }
    }
}
