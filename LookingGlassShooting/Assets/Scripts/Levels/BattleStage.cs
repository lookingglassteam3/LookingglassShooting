﻿using System;
using LooklingGlassShooting.Models;
using UnityEngine;
using UniRx;
using UnityEngine.SceneManagement;

public class BattleStage : MonoBehaviour
{
    private float roundTime;
    private Timer _timer;
    private Player[] Players;
    private RoundEffect _roundEffect;


    public GameObject parent;
    [SerializeField] private GameObject Player1Prefab;
    [SerializeField] private GameObject Player2Prefab;

    [SerializeField] private GameObject DamageAreaManagerPrefab;
    

    [SerializeField] private Transform Player1InitialTransform;
    [SerializeField] private Transform Player2InitialTransform;

    [SerializeField] private ParticleController Player1Particle;
    [SerializeField] private ParticleController Player2Particle;

    [SerializeField] private AudioSource m_BGM;
    private bool canReload = false;
    void Start()
    {
        // 仮で夏vs冬
        GlobalRegistory.SetSeasons(SeasonFormat.Spring,SeasonFormat.Winter);

        canReload = false;
        _timer = GetComponent<Timer>();
        roundTime = GlobalRegistory.GetRoundTime();
        roundTime = 60;
        _timer.TimerSet((int)roundTime);
        _roundEffect = GetComponent<RoundEffect>();


        var p1 = Instantiate(Player1Prefab,Player1InitialTransform.position, Player1InitialTransform.rotation);
        var p2 = Instantiate(Player2Prefab,Player2InitialTransform.position,Player2InitialTransform.rotation);
        Players = new []
        {
            p1.transform.GetComponent<Player>(),
            p2.transform.GetComponent<Player>()
        };
        var seasons = GlobalRegistory.GetSeasons();
        for (int i = 0; i < 2; i++)
        {
            Players[i].Season = seasons[i];
            Players[i].Life = 100;
        }
        Players[0].onDamage += Player1Particle.Damage;
        Players[0].onDamage += _roundEffect.PlayDamageSound;
        Players[1].onDamage += Player2Particle.Damage;
        Players[1].onDamage += _roundEffect.PlayDamageSound;

        Players[0].onKnockDown.AddListener(EventKnockOut);
        Players[1].onKnockDown.AddListener(EventKnockOut);

        var d = Instantiate(DamageAreaManagerPrefab);
        d.GetComponent<DamageAreaManager>().Initialize(p1, p2);

        _timer.onTimeUp.AddListener(EventTimeUp);
        
        EventReady();
    }

    void Update()
    {
        if (canReload && Input.GetKeyDown(KeyCode.R))
        {
            if(m_BGM != null) m_BGM.Stop();
            Scene loadScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(loadScene.name);
        }
    }

    public void EventReady()
    {
        _roundEffect.ShowReady();
        Observable.Timer(TimeSpan.FromSeconds(3)).Subscribe(_ =>
        {
            EventBattleStart();
        }).AddTo(this);
    }

    private void EventBattleStart()
    {
        _roundEffect.ShowGo();
        _timer.TimerStart();
        if(m_BGM != null) m_BGM.Play();
        for (int i = 0; i < 2; i++)
        {
            Players[i].status = PlayerState.Fight;
        }
        Player1Particle.gameObject.SetActive(true);
        Player2Particle.gameObject.SetActive(true);
    }

    public void EventKnockOut()
    {
        _roundEffect.ShowFinish();
        _timer.TimerStop();
        for (int i = 0; i < 2; i++)
        {
            if(Players[i].status != PlayerState.Down)
            {
                _roundEffect.PlayDownSound();
                Debug.Log("勝負あり！ " + i + " の勝ちだ！！！");
                Judge(i);
            }
        }
        
    }

    public void EventCountDown()
    {
        
    }

    public void EventTimeUp()
    {
        _roundEffect.ShowTimeup();
        _timer.TimerStop();
        if (Players[0].Life == Players[1].Life)
        {
            Debug.Log("引き分け！");
            
        }
        else if(Players[0].Life > Players[1].Life)
        {
            Debug.Log("勝負あり！ 0 の勝ちだ！！！");
            Judge(0);
        }
        else if(Players[0].Life < Players[1].Life)
        {
            Debug.Log("勝負あり！ 1 の勝ちだ！！！");
            Judge(1);
        }
    }

    private void Judge(int i)
    {
        canReload = true;
        _roundEffect.ShowWinnerEffect(i);
    }
}
