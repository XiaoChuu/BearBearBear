using UnityEngine;

public class EnemyGen : MonoBehaviour
{
    borderData border;
    public GameObject enemyPrefab;
    public GameObject enemyHealerPrefab;
    SpriteRenderer enemySprite;
    float spawnTimer = 1.0f;
    float currentTime;
    float picSizeX, picSizeY;
    Vector3 spawnPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        borderManager();
        enemySprite = enemyPrefab.GetComponent<SpriteRenderer>();
        picSizeX = enemySprite.bounds.size.x / 2;
        picSizeY = enemySprite.bounds.size.y / 2;
        spawnPos.x = 12.0f;
        spawnPos.y = Random.Range(border.downBorder + picSizeY, border.upBorder - picSizeY);
    }

    // Update is called once per frame
    void Update()
    {
        enemy_Spawn();
    }

    void borderManager()
    {
        border.upBorder = 3.0f;
        border.downBorder = -5.0f;
        border.leftBorder = -9.0f;
        border.rightBorder = 9.0f;
    }

    void enemy_Spawn()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= spawnTimer)
        {
            int spawnRate = Random.Range(0, 100);

            if (spawnRate < 75)
            {
                Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            }
            else
            {
                Instantiate(enemyHealerPrefab, spawnPos, Quaternion.identity);
            }

            currentTime = 0;
            spawnPos.y = Random.Range(border.downBorder + picSizeY, border.upBorder - picSizeY);
            //Debug.Log($"<color=red>downBorder:{border.downBorder} / upBorder:{border.upBorder} / picSizeY:{picSizeY} / spawnPos{spawnPos.y}</color>");
        }
    }
}
