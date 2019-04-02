using LooklingGlassShooting.Models;
using UnityEngine;
using UnityStandardAssets.Effects;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    private GameObject m_bullet = null;

    [SerializeField]
    private float m_bulletSpeed = 10.0f;

    private PlayerId playerId;
    void Start()
    {
        if (transform.parent.tag == "Player1")
        {
            playerId = PlayerId.Player1;
        }
        else
        {
            playerId = PlayerId.Player2;
        }
    }

    void Update()
    {
        string inputKey;
        switch (playerId)
        {
            case PlayerId.Player1:
                inputKey = "Fire1";
                break;
            case PlayerId.Player2:
                inputKey = "Fire2";
                break;
            default:
                inputKey = "";
                break;
        }

        if (Input.GetButtonDown(inputKey))
        {
            if (m_bullet != null)
            {
                var bullet = Instantiate(m_bullet, transform.position , Quaternion.identity);
                var rig = bullet.GetComponent<Rigidbody>();
                rig.AddForce(transform.forward * m_bulletSpeed * 100.0f);
            }
        }
    }
}
