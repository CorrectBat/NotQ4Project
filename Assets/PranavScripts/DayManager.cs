using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UI.Text;

public class DayManager : MonoBehaviour
{
    public Text dayText;
    private int currentDay;
    void Start()
    {
        PlayerPrefs.DeleteKey("CurrentDay");
        currentDay = PlayerPrefs.GetInt("CurrentDay", 1);
        UpdateDayUI();
    }

    public void OnShopOpened()
    {
        currentDay++;
        PlayerPrefs.SetInt("CurrentDay", currentDay);
        PlayerPrefs.Save();
        UpdateDayUI();
    }

    private void UpdateDayUI()
    {
        dayText.text = "Day " + currentDay.ToString();
    }
}
