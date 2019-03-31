using UnityEngine;

public class RoundEffect : MonoBehaviour
{
    void Start()
    {
        
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
    }
}
