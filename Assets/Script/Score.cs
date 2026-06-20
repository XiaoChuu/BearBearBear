using UnityEngine;

public class Score : MonoBehaviour
{
    [HideInInspector] public static int score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 0;
    }

    void Update()
    {
        
    }
}
