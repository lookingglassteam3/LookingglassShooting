using LooklingGlassShooting.Models;
using UnityEngine;

public class DamageArea : MonoBehaviour
{
    private Player m_player;

    [SerializeField]
    private int m_power = 1;

    public void Initialize(GameObject player)
    {
        m_player = player.GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            m_player.Damage(m_power);
            Destroy(other.gameObject);
        }
    }
}
