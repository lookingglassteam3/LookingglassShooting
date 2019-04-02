using UnityEngine;

public class RoundEffect : MonoBehaviour
{

    [SerializeField] private Animator m_EndBoard;

    [SerializeField] private AudioSource m_SoundEffect;
    [SerializeField] private AudioClip m_DamageSound;
    [SerializeField] private AudioClip m_DownSound;
    void Start()
    {
        m_SoundEffect = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    public void ShowReady()
    {
        // ToDO: バトル開始前エフェクト
        Debug.Log("バトル開始前エフェクト");
    }

    public void ShowGo()
    {
        // ToDo: ラウンド開始合図を出す
        Debug.Log("ラウンド開始合図");
    }

    public void ShowFinish()
    {
        // ToDO: KOフィニッシュエフェクトを出す
        Debug.Log("KOフィニッシュエフェクト");
    }

    public void ShowTimeup()
    {
        // ToDO: タイムアップフェクトを出す
        Debug.Log("タイムアップフェクト");
    }

    public void ShowWinnerEffect(int winner)
    {
        // ToDo: 勝利エフェクトを出す
        Debug.Log("勝利エフェクト");
        m_EndBoard.SetInteger("Winner",winner + 1);
    }

    public void PlayDamageSound(int life)
    {
        if (m_SoundEffect != null && m_DamageSound != null && life > 0)
        {
            m_SoundEffect.clip = m_DamageSound;
            m_SoundEffect.Play();
        }else if (m_SoundEffect != null && m_DownSound != null && life < 0)
        {
            m_SoundEffect.clip = m_DownSound;
            m_SoundEffect.Play();
        }
    }

    public void PlayDownSound()
    {
        if (m_SoundEffect != null && m_DownSound != null)
        {
            m_SoundEffect.clip = m_DownSound;
            m_SoundEffect.Play();
        }
    }
}
