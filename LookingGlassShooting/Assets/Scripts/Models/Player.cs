using UnityEngine;
using UnityEngine.Events;

namespace LooklingGlassShooting.Models
{
    public class Player: MonoBehaviour
    {
        [SerializeField]
        public int Life = 100;
        [SerializeField]
        public SeasonFormat Season = SeasonFormat.Spring;

        [SerializeField]
        public PlayerState status = PlayerState.Ready;

        public UnityEvent onKnockDown = new UnityEvent();

        
        public Player(SeasonFormat season = SeasonFormat.Spring): base()
        {
            Life = 100;
            Season = season;
        }

        public void Damage(int power)
        {
            Life -= power;
            if (Life <= 0 && status != PlayerState.Down)
            {
                status = PlayerState.Down;
                onKnockDown.Invoke();
            }
        }
    }

    public enum SeasonFormat
    {
        Spring,Summer,Fall,Winter
    }

    public enum PlayerState
    {
        Ready,Fight,Down,Win
    }
}

