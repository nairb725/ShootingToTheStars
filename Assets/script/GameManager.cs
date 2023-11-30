using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject target;

    [SerializeField]
    private Canvas GameOverScreen;

    [SerializeField]
    private Canvas GamePlayScreen;

    private float _startTime;

    [SerializeField]
    private TMP_Text m_TimerText;

    [SerializeField]
    private TMP_Text m_KillText;

    [SerializeField]
    private TMP_Text m_TimeFighting;

    [SerializeField]
    private TMP_Text m_EnnemyKilled;

    [SerializeField]
    private TMP_Text m_Score;

    private float _startTimePowerUp;

    [SerializeField]
    private AudioManagerRaduis audioManagerRaduis;

    [SerializeField]
    private AudioManagerGiraffe audioManagerGiraffe;

    [SerializeField]
    private TMP_Text m_PowerUpText;

    private float TimeRemainPowerUp;

    public bool RaduisPropuls = false;

    public bool GiraffeReady = false;

    [SerializeField]
    private TMP_Text m_PowerUpTextGirafe;

    private float TimeRemainPowerUpGirafe;

    [SerializeField]
    private float MaxTimePowerUp = 10f;
    
    [SerializeField]
    private float MaxTimePowerUpGirafe = 10f;

    private int killCounter = 0;

    public static GameManager Instance;

    public bool _isPlaying = true;

    void Awake()
    {
        if (Instance == null) // If there is no instance already
        {
            Instance = this;
        }
        else if (Instance != this) // If there is already an instance and it's not `this` instance
        {
            Destroy(gameObject); // Destroy the GameObject, this component is attached to
        }
    }

    void  Start()
    {
        TimeRemainPowerUp = 0f;
        TimeRemainPowerUpGirafe = 0f;
    }
    public GameObject DefineTarget() { 
        return target;
    }
    
    void Update()
    {
        //TODO : Update timer while in game
        if (_isPlaying == true)
        {
            float currentTime = Time.time - _startTime;
            TimeRemainPowerUp = TimeRemainPowerUp + Time.deltaTime;
            TimeRemainPowerUpGirafe = TimeRemainPowerUpGirafe + Time.deltaTime;
            //Power Up Scream
            if (TimeRemainPowerUp < MaxTimePowerUp)
            {
                m_PowerUpText.text = string.Format("{0}", TimeRemainPowerUp.ToString()[0]) + "/" + MaxTimePowerUp;
            }
            else
            {
                m_PowerUpText.text = string.Format("E To Use");
            }
            //Power Up Scream key input
            if (Input.GetKeyDown(KeyCode.E) && TimeRemainPowerUp > MaxTimePowerUp)
            {

                TimeRemainPowerUp = 0f;
                PowerUp();
            }

            //Power Up Girafe
            if (TimeRemainPowerUpGirafe < MaxTimePowerUpGirafe)
            {
                m_PowerUpTextGirafe.text = m_PowerUpTextGirafe.text = TimeRemainPowerUpGirafe.ToString("F0") + "/" + MaxTimePowerUpGirafe;
            }
            else
            {
                m_PowerUpTextGirafe.text = string.Format("Q To Use");
            }
            //Power Up Girafe key input
            if (Input.GetKeyDown(KeyCode.A) && TimeRemainPowerUpGirafe > MaxTimePowerUpGirafe)
            {

                TimeRemainPowerUpGirafe = 0f;
                PowerUpGirafe();
            }
          
            

            int minute = Mathf.FloorToInt(currentTime / 60F);
            int second = Mathf.FloorToInt(currentTime - minute * 60);
            m_TimerText.text = string.Format("{0:0}:{1:00}", minute, second);
        }
    }

    public void GameOver()
    {
        _isPlaying = false;
        Invoke("SetupGameOverScreen", 0f);
        Invoke("ShowGameOverScreen", 2f);
    }

    void SetupGameOverScreen()
    {
        m_TimeFighting.text = ("Time Fighting : " + m_TimerText.text);
        m_EnnemyKilled.text = ("Ennemy Killed : " + killCounter);
        if(killCounter < 50)
        {
            m_Score.text = ("The Fuhrer is disappointed");
        }
        if (killCounter > 50 && killCounter <125)
        {
            m_Score.text = ("You can do better Gunter");
        }
        if (killCounter > 125)
        {
            m_Score.text = ("Pure blood soldier good job !");

        }

    }
    void ShowGameOverScreen()
    {
        GamePlayScreen.gameObject.SetActive(false);
        GameOverScreen.gameObject.SetActive(true);
    }

    public void AddKill()
    {
        killCounter++;
        m_KillText.text = string.Format(killCounter.ToString() + " kills");
    }

    public void PowerUp()
    {
        audioManagerRaduis.sound();
        RaduisPropuls = true;
        Invoke("Raduis", 1.0f);
    }

    public void PowerUpGirafe()
    {
        audioManagerGiraffe.sound();
        GiraffeReady = true;
        Invoke("Giraffe", 1f);
    }

    public void Giraffe()
    {
        GiraffeReady = false;
    }

    public void Raduis()
    {
        RaduisPropuls = false;
    }

    public bool isPlaying()
    {
        return _isPlaying;
    }
}
