using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public TextMeshProUGUI killCountText; 
    private int totalKills = 0;
    public GameObject MissonStatus;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddKill()
    {
        totalKills++;
        UpdateKillCountText();
    }

    private void UpdateKillCountText()
    {

        if (killCountText != null)
        {
            killCountText.text = "Kills: " + totalKills.ToString();
        }
        if (totalKills == 5)
        {

            MissonStatus.SetActive(true);


        }

    }
}
