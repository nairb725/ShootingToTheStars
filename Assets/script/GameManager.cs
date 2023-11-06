using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject target;

    private float _startTime;

    [SerializeField]
    private TMP_Text m_TimerText;

    [SerializeField]
    private TMP_Text m_KillText;

    private float _startTimePowerUp;

    [SerializeField]
    private AudioManager audioManager;

    [SerializeField]
    private TMP_Text m_PowerUpText;

    private float TimeRemainPowerUp;

    public bool FollowOrNo = true;

    [SerializeField]
    private float MaxTimePowerUp = 20f;

    private int killCounter = 0;

    public static GameManager Instance;

    public bool _isPlaying = true;

    void Awake()
    {
        if (Instance == null) // If there is no instance already
        {
            DontDestroyOnLoad(gameObject); // Keep the GameObject, this component is attached to, across different scenes
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

            if (TimeRemainPowerUp < MaxTimePowerUp)
            {
                m_PowerUpText.text = string.Format("{0}", TimeRemainPowerUp.ToString()[0]) + "/10";
            }
            else
            {
                m_PowerUpText.text = string.Format("Ready To Use");
            }

            if(Input.GetKeyDown(KeyCode.T) && TimeRemainPowerUp > MaxTimePowerUp) {

                TimeRemainPowerUp = 0f;
                PowerUp();  
            }

            int minute = Mathf.FloorToInt(currentTime / 60F);
            int second = Mathf.FloorToInt(currentTime - minute * 60);
            m_TimerText.text = string.Format("{0:0}:{1:00}", minute, second);
        }
    }

    public void GameOver()
    {
        //TODO : Stop playing
        _isPlaying = false;
        //TODO : Display game over screen with a delay (Hint : Search for the "Invoke" method in the Unity Documentation)
    }

    public void AddKill()
    {
        killCounter++;
        m_KillText.text = string.Format(killCounter.ToString() + " kills");
    }

    public void PowerUp()
    {
        FollowOrNo = true;
        audioManager.sound();
        Invoke("Follow", 3.0f);
    }

    public void Follow()
    {
        FollowOrNo = false;
    }

    public bool isPlaying()
    {
        //TODO : Stop playing
        return _isPlaying;
        //TODO : Display game over screen with a delay (Hint : Search for the "Invoke" method in the Unity Documentation)
    }
}
