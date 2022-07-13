using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    private Timer _timer;
    private Player _player;
    private RewardCreator _rewardCreator;
    void Start()
    {
        _rewardCreator = GameObject.FindGameObjectWithTag("GameTag").GetComponent<RewardCreator>();
        _timer = GameObject.FindGameObjectWithTag("GameTag").GetComponent<Timer>();

        _player = GameObject.FindGameObjectWithTag("PlayerTag").GetComponent<Player>();
    }

    void OnMouseDown()
    {
        if (_timer.IsEndGame)
            return;
        GetComponent<Health>().GetHit(_rewardCreator.PlayerDamage);

        _player.RunAttack();
    }
}
