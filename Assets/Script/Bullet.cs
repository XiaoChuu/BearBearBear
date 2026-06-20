using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    borderData border;
    float shotSpeed = 10f;
    Vector3 dir;
    [HideInInspector] public float damage = 15;
    SoundManager soundManager;
    public AudioClip boom;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        borderManager();
        bulletDirCal();
        
        Destroy(gameObject, 5f);
        soundManager = FindFirstObjectByType<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        bulletShot();

        gameObject.transform.Rotate(0, 0, 180 * Time.deltaTime * 5.0f);
    }

    void borderManager()
    {
        border.upBorder = 5.0f;
        border.downBorder = -5.0f;
        border.leftBorder = -9.0f;
        border.rightBorder = 10.0f;
    }

    void bulletShot() 
    {
        Vector3 pos = gameObject.transform.position;
        pos += dir * shotSpeed * Time.deltaTime;
        gameObject.transform.position = pos;
    }

    void bulletDirCal() 
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        dir = (mousePos - gameObject.transform.position).normalized;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(gameObject);
            soundManager.playSE(boom);
            if (damage >= 50)
            {
                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
                foreach (GameObject enemyObj in enemies)
                {
                    EnemyDamaged enemy = enemyObj.GetComponent<EnemyDamaged>();
                    enemy.takeDamage((int)damage, true);
                }
            }
            else
            {
                EnemyDamaged enemy = collision.GetComponent<EnemyDamaged>();
                enemy.takeDamage((int)damage, false);
            }
        }
    }
    
}
