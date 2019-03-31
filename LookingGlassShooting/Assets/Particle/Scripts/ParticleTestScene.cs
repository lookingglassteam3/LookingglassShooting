using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LooklingGlassShooting.Models;

public class ParticleTestScene : MonoBehaviour
{

    public GameObject ownParticle;
    public GameObject enemyParticle;
    public SeasonFormat player1;
    public SeasonFormat player2;
    // Start is called before the first frame update
    void Start()
    {
        GlobalRegistory.SetSeasons(player1, player2);
        ownParticle.SetActive(true);
        enemyParticle.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
