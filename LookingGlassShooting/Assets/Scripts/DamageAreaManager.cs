using UnityEngine;

public class DamageAreaManager : MonoBehaviour
{
    [SerializeField]
    GameObject m_damageArea = null;

    /// <summary>
    /// 原点からダメージエリアまでの距離
    /// </summary>
    [SerializeField]
    float m_damageAreasLength = 11;

    public void Initialize(GameObject player1, GameObject player2)
    {
        if (m_damageArea != null)
        {
            var damageArea = Instantiate(m_damageArea,
                new Vector3(0, 0, -m_damageAreasLength),
                Quaternion.identity, transform);
            damageArea.GetComponent<DamageArea>().Initialize(player2);

            damageArea = Instantiate(m_damageArea,
                new Vector3(0, 0, m_damageAreasLength),
                Quaternion.identity, transform);
            damageArea.GetComponent<DamageArea>().Initialize(player1);
        }
    }
}
