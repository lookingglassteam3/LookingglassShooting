using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour
{
    private float m_speed;

    /// <summary>
    /// 単位は秒
    /// </summary>
    [SerializeField]
    private float m_lifeTime = 3.0f;

    private void Start()
    {
        StartCoroutine(Wait());
    }

    public void Initialize(float speed)
    {
        m_speed = speed;
    }

    void Update()
    {
        transform.Translate(new Vector3(0, 0, m_speed * Time.deltaTime));
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(m_lifeTime);

        Destroy(gameObject);
    }
}
