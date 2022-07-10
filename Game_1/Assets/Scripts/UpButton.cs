using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpButton : MonoBehaviour
{
    public bool isRubin;
    public bool isHero;
    public GameObject HeroPrefab;
    public GameObject UpImagePrefab;
    public TMP_Text DamageText;
    public TMP_Text PriceText;

    public int Damage = 10;
    public int Price = 100;
    public Image ItemUpDamage;

    Game _game;
    // Start is called before the first frame update
    void Start()
    {
        _game = GameObject.FindObjectOfType<Game>();
        DamageText.text = "+" + Damage.ToString();
        PriceText.text = Price.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpClick()
    {
        if (!isRubin && _game.PlayerGold >= Price
            || isRubin && _game.PlayerRubin >= Price)
        {
            if (!isRubin)
                _game.PlayerGold -= Price;
            else
                _game.PlayerRubin -= Price;

            if (isHero != true)
            {
                _game.PlayerDamage += Damage;
            }
            else
            {
                GameObject hero = Instantiate(HeroPrefab) as GameObject;
                Vector3 heroPosition = new Vector3(Random.Range(3.0f, 7.0f),
                    -1.0f, 0);
                hero.transform.position = heroPosition;
            }


            GameObject upDamageEfect = Instantiate(UpImagePrefab) as GameObject;

            Transform canvas = GameObject.Find("Canvas").transform;

            upDamageEfect.transform.SetParent(canvas);
            upDamageEfect.GetComponent<Image>().sprite = ItemUpDamage.sprite;
            
            Destroy(upDamageEfect, 1);

            if (isHero != true)
            {
                Destroy(gameObject);
            }
        }
    }
}
