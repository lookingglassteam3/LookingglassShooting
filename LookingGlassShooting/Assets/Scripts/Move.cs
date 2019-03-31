using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField]
    private float m_speed = 1.0f;

    private string m_tag;

    [SerializeField]
    private Vector2 m_movableRange = new Vector2(5.0f, 2.0f);

    [SerializeField]
    private Vector2 m_movableRangeOffset = new Vector2(0.0f, 2.0f);

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
        if (transform.position.x < -m_movableRange.x + m_movableRangeOffset.x)
        {
            if(horizontal < 0.0f)
            {
                horizontal = 0.0f;
            }
        }

        if(transform.position.x > m_movableRange.x + m_movableRangeOffset.x)
        {
            if(horizontal > 0.0f)
            {
                horizontal = 0.0f;
            }
        }

        if (transform.position.y < -m_movableRange.y + m_movableRangeOffset.y)
        {
            if(vertical < 0.0f)
            {
                vertical = 0.0f;
            }
        }

        if(transform.position.y > m_movableRange.y + m_movableRangeOffset.y)
        {
            if (vertical > 0.0f)
            {
                vertical = 0.0f;
            }
        }

        transform.position += new Vector3(horizontal, vertical, 0) * m_speed * Time.deltaTime;
    }
}
