using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LooklingGlassShooting.Models;

public enum Season
{
    spring,summer,fall,winter
}
 enum PlayerNum
{
    player1,player2
}

public class ParticleController : MonoBehaviour
{
    [SerializeField]
    ParticleSystem spring;
    [SerializeField]
    ParticleSystem summer;
    [SerializeField]
    ParticleSystem fall;
    [SerializeField]
    ParticleSystem winter;

    //public Season own;
    private SeasonFormat ownSeason;
    private SeasonFormat enemySeason;


    private ParticleSetting own;
    private ParticleSetting enemy;
    
    //public Season enemy;
    [SerializeField]
    private PlayerNum player;
    public int Life;


    private struct ParticleSetting
    {
        public ParticleSystem particle { get; }
        public float max { get;  }
        public SeasonFormat season { get; }
        public ParticleSetting(SeasonFormat Season,ParticleSystem Particle, float Max)
        {
            particle = Particle;
            max = Max;
            season = Season;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

        //GlobalRegistory.SetSeasons(SeasonFormat.Spring, SeasonFormat.Summer);
        var PlayerSeasons = GlobalRegistory.GetSeasons();
        if(player == PlayerNum.player1)
        {
            ownSeason = PlayerSeasons[0];
            enemySeason = PlayerSeasons[1];
        }
        else
        {
            ownSeason = PlayerSeasons[1];
            enemySeason = PlayerSeasons[0];
        }

        own  = SetSeason(ownSeason);
        enemy = SetSeason(enemySeason);
        own.particle.Play();
        enemy.particle.Play();
        Damage(100);
        
    }
    ParticleSetting SetSeason(SeasonFormat season)
    {
        ParticleSystem p;
        ParticleSetting particleSetting;
        switch (season)
        {
            case SeasonFormat.Spring:
                {
                    particleSetting = new ParticleSetting(season,spring,15);
                    break;
                }
            case SeasonFormat.Summer:
                {
                    particleSetting = new ParticleSetting(season, summer, 2);
                    break;
                }
            case SeasonFormat.Fall:
                {
                    particleSetting = new ParticleSetting(season, fall, 15);
                    break;
                }
            case SeasonFormat.Winter:
                {
                    particleSetting = new ParticleSetting(season, winter, 15);
                    break;
                }
            default:
                {
                    particleSetting = new ParticleSetting();
                    break;
                }
        }
        return particleSetting;
        
    }
    // Update is called once per frame
    void Update()
    {
        //calcEmission(Life);
        //ここをとってくるようにする
    }
    public void Damage(int ownLife)
    {
        var emission = own.particle.emission;
        emission.rateOverTime = calcParticle(ownLife, own.max);
        emission = enemy.particle.emission;
        emission.rateOverTime = calcParticle(100 - ownLife, enemy.max);
    }
    private float calcParticle(int life, float max)
    {
        return life * max / 100.0f;
    }
    private float calcParticleSummer(int life)
    {
        return life * 5 / 100.0f;
    }
}