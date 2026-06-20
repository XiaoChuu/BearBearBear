using UnityEngine;

public class PondTrap : MonoBehaviour
{
    public GameObject pondPrefab;
    float timer = 0.0f;
    float placeTimer = 15.0f;
    bool isReadyToPlace = false;

    public GameObject chargeBar;
    public GameObject currentCharge;
    SpriteRenderer chargeRender;
    Vector3 barSize;
    Vector3 barPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        chargeRender = currentCharge.GetComponent<SpriteRenderer>();
        barSize = currentCharge.transform.localScale;
        barPos = currentCharge.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        chargingPower();

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (timer >= placeTimer)
        {
            chargeRender.color = new Color(0.0f / 255.0f, 105.0f / 255.0f, 255.0f / 255.0f);
            timer = placeTimer;
            isReadyToPlace = true;
        }

        if (Input.GetMouseButtonDown(1) && isReadyToPlace)
        {
            Instantiate(pondPrefab, new Vector3(mousePos.x, pondPrefab.transform.position.y, 0), pondPrefab.transform.localRotation);
            isReadyToPlace = false;
            timer = 0;
            chargeRender.color = Color.cyan;
        }
    }

    void chargingPower()
    {
        currentCharge.transform.localScale = new Vector3(barSize.x * (float)timer / placeTimer, barSize.y, 1);
        currentCharge.transform.localPosition = new Vector3(barPos.x - (barSize.x * (1 - (float)timer / placeTimer) / 2.0f), barPos.y, 1);
    }
}
