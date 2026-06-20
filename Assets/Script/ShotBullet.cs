using UnityEngine;

public class ShotBullet : MonoBehaviour
{
    public GameObject player;
    public GameObject BulletPrefab;
    public GameObject PowerBulletPrefab;

    //Charge
    public GameObject chargeBar;
    public GameObject currentCharge;
    public int chargeDamage;
    int maxCharge = 35;
    float chargeTimer;
    Vector3 barSize;
    Vector3 barPos;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        barSize = currentCharge.transform.localScale;
        barPos = currentCharge.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        shot();
        charge();
    }

    void shot() 
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (chargeDamage >= maxCharge)
            {
                GameObject bullet = Instantiate(PowerBulletPrefab, player.transform.position, Quaternion.identity);
                bullet.GetComponent<Bullet>().damage += chargeDamage;
                chargeDamage = 0;
                
            }
            else
            {
                GameObject bullet = Instantiate(BulletPrefab, player.transform.position, Quaternion.identity);
                bullet.GetComponent<Bullet>().damage += chargeDamage;
                chargeDamage = 0;
            }
            chargeBarUnvisitable();
        }
    }

    void charge() 
    {
        if (Input.GetMouseButton(0))
        {
            chargeBarVisitable();
            chargingPower();
            chargeTimer += Time.deltaTime;
            //Debug.Log(chargeDamage);
            if (chargeTimer > 0.1f)
            {
                if (chargeDamage < maxCharge)
                {
                    chargeDamage++;
                }
                else
                {
                    chargeDamage = maxCharge;
                }
                chargeTimer = 0;
            }
        }
    }

    void chargeBarVisitable()
    {
        chargeBar.SetActive(true);
        currentCharge.SetActive(true);
    }

    void chargeBarUnvisitable()
    {
        chargeBar.SetActive(false);
        currentCharge.SetActive(false);
    }

    void chargingPower()
    {
        currentCharge.transform.localScale = new Vector3(barSize.x * (float)chargeDamage / maxCharge, barSize.y, 1);
        currentCharge.transform.localPosition = new Vector3(barPos.x - (barSize.x * (1 - (float)chargeDamage / maxCharge) / 2.0f), barPos.y, 1);
    }
}
