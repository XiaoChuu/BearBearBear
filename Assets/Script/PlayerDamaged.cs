using System;
using System.Drawing;
using UnityEngine;

public class PlayerDamaged : MonoBehaviour
{
    public int hp;
    int maxHp = 100;
    public GameObject hpBarSize;
    Vector3 barSize;
    Vector3 barPos;
    SceneChanger sceneChanger;
    public GameObject playerExplode;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hp = maxHp;

        barSize = hpBarSize.transform.localScale;
        barPos = hpBarSize.transform.localPosition;

        sceneChanger = FindFirstObjectByType<SceneChanger>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            hp = 0;
            sceneChanger.nextScene();
        }
        hpBarSize.transform.localScale = new Vector3(barSize.x * (float)hp / maxHp, barSize.y, 1);
        hpBarSize.transform.localPosition = new Vector3(barPos.x - (barSize.x * (1 - (float)hp / maxHp) / 2.0f), barPos.y, 1);
    }

    public void takeDamage(int damage)
    { 
        hp -= damage;
        Instantiate(playerExplode, gameObject.transform.position, Quaternion.identity);
    }
}
