using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text Score;
    [SerializeField] private TMP_Text RecordScore;
    
    public void ShowEndGame(int gold)
    {
        Score.text = gold.ToString();

        if(SettingClass.GoldRecord < gold)
        {
            SettingClass.GoldRecord = gold;
        }

        RecordScore.text = SettingClass.GoldRecord.ToString();
    }

    public void ButtonRestartClick()
    {
        SceneManager.LoadScene("Main_2");
    }
}
