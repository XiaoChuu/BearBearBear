using UnityEngine;

public class HealerMovement : MonoBehaviour
{
    borderData border;
    float walkSpeed = 2.0f;
    int healRate = 3;
    float healTimer = 0;
    Animator HealerAnim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        borderManager();
        HealerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyMove();

        if (gameObject.transform.position.x <= 7.0f)
        {
            walkSpeed = 0;
            HealerAnim.SetTrigger("HealerHeal");
            healTimer += Time.deltaTime;

            if (healTimer >= 0.1f)
            {
                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
                foreach (GameObject enemyObj in enemies)
                {
                    EnemyDamaged enemy = enemyObj.GetComponent<EnemyDamaged>();
                    enemy.takeHeal(healRate);
                }

                healTimer = 0;
            }
        }
    }

    void borderManager()
    {
        border.upBorder = 5.0f;
        border.downBorder = -5.0f;
        border.leftBorder = -9.0f;
        border.rightBorder = 9.0f;
    }

    void enemyMove()
    {
        Vector3 pos = gameObject.transform.position;
        pos.x += -walkSpeed * Time.deltaTime;
        gameObject.transform.position = pos;
    }
}
