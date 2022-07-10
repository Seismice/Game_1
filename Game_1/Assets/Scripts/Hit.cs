using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    Game _game;
    Player _player;
    // Start is called before the first frame update
    void Start()
    {
        _game = GameObject.FindObjectOfType<Game>();
        _player = GameObject.FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if (_game.IsEndGame)
            return;
        GetComponent<Health>().GetHit(_game.PlayerDamage);

        _player.RunAttack();
        
    }
}
