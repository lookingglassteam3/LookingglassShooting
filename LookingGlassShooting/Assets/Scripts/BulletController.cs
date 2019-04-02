using System.Collections;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    /// <summary>
    /// 単位は秒
    /// </summary>
    [SerializeField]
    private float m_lifeTime = 3.0f;

    void Start()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(m_lifeTime);

        Destroy(gameObject);
    }
}
