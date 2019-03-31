using UnityEngine;

public class CharacterCreator : MonoBehaviour
{
    [SerializeField]
    GameObject[] m_characters;

    private void Start()
    {
        var n = Random.Range(0, m_characters.Length);

        var rotationY = 0;
        if (gameObject.tag == "Player2")
            rotationY = 180;

        Instantiate(m_characters[n],
            transform.position,
            Quaternion.Euler(new Vector3(0, rotationY, 0)),
            transform);
    }
}
