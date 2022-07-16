using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private int GameTime = 300;
    [SerializeField] private TMP_Text GameTimeText;
    [SerializeField] private EndMenu EndMenu;
    private int _currentTime;
    private RewardCreator _rewardCreator;
    public bool IsEndGame { get; set; }
    void Start()
    {
        Time.timeScale = 1;

        InvokeRepeating("TimerToEnd", 0, 1);

        _rewardCreator = GetComponent<RewardCreator>();
    }

    void TimerToEnd()
    {
        _currentTime++;

        GameTimeText.text = (GameTime - _currentTime).ToString();

        if (_currentTime >= GameTime)
        {
            Time.timeScale = 0;

            IsEndGame = true;
            EndMenu.gameObject.SetActive(true);
            EndMenu.ShowEndGame(_rewardCreator.PlayerGold);
        }
    }
}
