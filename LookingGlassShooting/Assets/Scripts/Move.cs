using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField]
    private float m_speed = 1.0f;

    private string m_tag;

    void Start()
    {
        m_tag = transform.tag;
    }

    void Update()
    {
        if (m_tag == "Player1")
        {
            MovePlayerOne();
            return;
        }

        if (m_tag == "Player2")
        {
            MovePlayerSecond();
        }
    }

    void MovePlayerOne()
    {
        var horizontal = 0.0f;
        var vertical = 0.0f;

        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");

        MoveGameObject(horizontal, vertical);
    }

    void MovePlayerSecond()
    {
        var horizontal = 0.0f;
        var vertical = 0.0f;

        vertical = Input.GetAxis("Vertical2");
        horizontal = Input.GetAxis("Horizontal2");

        MoveGameObject(horizontal, vertical);
    }

    void MoveGameObject(float horizontal, float vertical)
    {
        transform.position += new Vector3(horizontal, vertical, 0) * m_speed * Time.deltaTime;
    }
}
