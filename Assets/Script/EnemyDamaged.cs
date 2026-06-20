using UnityEngine;

public class EnemyDamaged : MonoBehaviour
{
    public int hp;
    int maxHp = 50;
    public GameObject hpBarSize;
    Vector3 barSize;
    Vector3 barPos;
    public GameObject enemyExplosionPrefab;
    public GameObject enemyBigExplosionPrefab;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hp = maxHp;
        barSize = hpBarSize.transform.localScale;
        barPos = hpBarSize.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        hpBarSize.transform.localScale = new Vector3(barSize.x * (float)hp / maxHp, barSize.y, 1);
        hpBarSize.transform.localPosition = new Vector3(barPos.x - (barSize.x * (1 - (float)hp / maxHp) / 2.0f), barPos.y, 1);
    }

    public void takeDamage(int damage, bool isMaxCharge) 
    {
        hp -= damage;

        if (hp <= 0)
        {
            if (isMaxCharge)
            {
                Instantiate(enemyBigExplosionPrefab, gameObject.transform.position, Quaternion.identity);
                Destroy(gameObject);
                Score.score++;
            }
            else
            {
                Instantiate(enemyExplosionPrefab, gameObject.transform.position, Quaternion.identity);
                Destroy(gameObject);
                Score.score++;
                //Debug.Log(Score.score);
            }
        }
    }

    public void takeHeal(int heal)
    {
        hp += heal;

        if (hp >= maxHp)
        {
            hp = maxHp;
        }
    }
}
