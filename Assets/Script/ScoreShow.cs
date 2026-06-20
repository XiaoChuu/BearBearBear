using UnityEngine;
using UnityEngine.UI;

public class ScoreShow : MonoBehaviour
{
    public Text pointShow;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pointShow.text = "あなたは" + Score.score + "体撃破した";
    }
}
