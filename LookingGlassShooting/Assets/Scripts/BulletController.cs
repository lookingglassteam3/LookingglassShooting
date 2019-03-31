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

    public void Initialize(float speed)
    {
        var rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(0, 0, speed) * 100);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(m_lifeTime);

        Destroy(gameObject);
    }
}
