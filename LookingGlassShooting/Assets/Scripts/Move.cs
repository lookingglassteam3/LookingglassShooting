using LooklingGlassShooting.Models;
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
            MovePlayer(PlayerId.Player1);
        }
        else if (m_tag == "Player2")
        {
            MovePlayer(PlayerId.Player2);
        }
    }

    void MovePlayer(PlayerId id)
    {
        var horizontal = 0.0f;
        var vertical = 0.0f;

        if (id == PlayerId.Player1)
        {
            vertical = Input.GetAxis("Vertical");
            horizontal = Input.GetAxis("Horizontal");
        }
        else if(id == PlayerId.Player2)
        {
            vertical = Input.GetAxis("Vertical2");
            horizontal = Input.GetAxis("Horizontal2");
        }
        else
        {
            vertical = 0;
            horizontal = 0;
        }
        MoveGameObject(horizontal, vertical);
    }

    void MoveGameObject(float horizontal, float vertical)
    {

        Vector3 pos = new Vector3(horizontal, vertical, 0) * m_speed * Time.deltaTime;
        // posはローカル変換して動かす
        var movePos = transform.position + transform.rotation * pos;
        // 移動制限値でClampする
        movePos.x = Mathf.Clamp(movePos.x, m_movableRangeOffset.x - m_movableRange.x,m_movableRangeOffset.x + m_movableRange.x);
        movePos.y = Mathf.Clamp(movePos.y, m_movableRangeOffset.y - m_movableRange.y,m_movableRangeOffset.y + m_movableRange.y);
        transform.position = movePos;
    }
}
