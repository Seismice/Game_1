using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    private RewardCreator _rewardCreator;
    public Slider HealthSlider;
    [SerializeField] private TMP_Text PlayerGoldUI;
    [SerializeField] private TMP_Text DamageText;
    [SerializeField] private TMP_Text RubinText;
    void Start()
    {
        _rewardCreator = GetComponent<RewardCreator>();

        GlobalEventManager.OnUIManager = ShowUI;
        GlobalEventManager.ShowUIManager();
    }
    public void ShowUI()
    {
        PlayerGoldUI.text = _rewardCreator.PlayerGold.ToString();
        DamageText.text = _rewardCreator.PlayerDamage.ToString();
        RubinText.text = _rewardCreator.PlayerRubin.ToString();
    }
}
