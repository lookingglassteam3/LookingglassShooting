﻿using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    private GameObject m_bullet = null;

    private bool m_isPlayerOne = true;

    [SerializeField]
    private float m_bulletSpeed = 10.0f;

    void Start()
    {
        if (transform.parent.tag == "Player2")
        {
            m_isPlayerOne = false;
        }
    }

    void Update()
    {
        if (m_isPlayerOne)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                var bullet = Instantiate(m_bullet, transform.position, Quaternion.identity);
                bullet.GetComponent<BulletController>().Initialize(m_bulletSpeed);
            }
            return;
        }

        if (Input.GetButtonDown("Fire2"))
        {
            var bullet = Instantiate(m_bullet, transform.position, Quaternion.identity);
            bullet.GetComponent<BulletController>().Initialize(m_bulletSpeed);
            return;
        }
    }
}
