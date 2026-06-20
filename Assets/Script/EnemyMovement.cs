using UnityEngine;

public struct borderData
{
    public float upBorder;
    public float downBorder;
    public float leftBorder;
    public float rightBorder;
};

public class EnemyMovement : MonoBehaviour
{
    borderData border;
    float walkSpeed;
    float preWalkSpeed;
    float attackTimer = 0;
    PlayerDamaged player;
    bool isAttackingPlayer = false;
    bool isInWater = false;
    Animator bearAnim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        borderManager();
        walkSpeed = Random.Range(3f, 7f);
        preWalkSpeed = walkSpeed;
        player = FindFirstObjectByType<PlayerDamaged>();
        bearAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyMove();
        if (isAttackingPlayer)
        {
            walkSpeed = 0;
            attackTimer += Time.deltaTime;
            bearAnim.SetTrigger("BearAttack");
            if (attackTimer >= 0.5f)
            {           
                attackTimer = 0;
                player.takeDamage(5);
            }
        }
        else if (isInWater)
        {
            walkSpeed = 0.5f;
        }
        else if (!isInWater && !isAttackingPlayer)
        {
            walkSpeed = preWalkSpeed;
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

        if (gameObject.transform.position.x < border.leftBorder)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isAttackingPlayer = true;    
        }
        else if (collision.tag == "Pond")
        {
            isInWater = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Pond")
        {
            isInWater = false;
        }
    }
}
