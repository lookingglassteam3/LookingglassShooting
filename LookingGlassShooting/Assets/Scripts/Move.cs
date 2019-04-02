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
        horizontal = Input.GetAxis("Horizontal") * -1;

        MoveGameObject(horizontal, vertical);
    }

    void MovePlayerSecond()
    {
        var horizontal = 0.0f;
        var vertical = 0.0f;

        vertical = Input.GetAxis("Vertical2");
        horizontal = Input.GetAxis("Horizontal2") * -1;

        MoveGameObject(horizontal, vertical);
    }

    void MoveGameObject(float horizontal, float vertical)
    {

        Vector3 pos = transform.position + new Vector3(horizontal, vertical, 0) * m_speed * Time.deltaTime;

        if (pos.x < -m_movableRange.x + m_movableRangeOffset.x)
        {
            pos.x = -m_movableRange.x + m_movableRangeOffset.x;
        }


        if (m_movableRange.x + m_movableRangeOffset.x < pos.x)
        {
            pos.x = m_movableRange.x + m_movableRangeOffset.x;
        }

        if (m_movableRange.y + m_movableRangeOffset.y < pos.y)
        {
            pos.y = m_movableRange.y + m_movableRangeOffset.y;
        }

        if (pos.y < -m_movableRange.y + m_movableRangeOffset.y)
        {
            pos.y = -m_movableRange.y + m_movableRangeOffset.y;
        }


        transform.position = pos;
    }
}
