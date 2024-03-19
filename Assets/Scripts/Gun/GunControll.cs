using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GunControll : MonoBehaviour
{
    public GameObject ballPrefab;
    public CoinsManager coinsManager;

    public Transform spawnParent;
    public Transform spawnPoint;

    private float fireForce = 0.3f;
    private float moveSpeed = 1f;
    public float horizontalLimit = 3f;

    private Rigidbody2D rb;

    private Vector2 touchStartPos;
    private Vector3 startPos;

    private bool isDragging = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchStartPos = touch.position;
                    startPos = transform.position;
                    break;

                case TouchPhase.Moved:
                    isDragging = true;
                    Vector3 dragDelta = Camera.main.ScreenToWorldPoint(touch.position) - Camera.main.ScreenToWorldPoint(touchStartPos);
                    transform.position = new Vector3(startPos.x + dragDelta.x * moveSpeed, transform.position.y, transform.position.z);
                    break;


                case TouchPhase.Ended:
                    isDragging = false;
                    if (coinsManager.money >= coinsManager.amount)
                    {
                        coinsManager.money -= coinsManager.amount;
                        PlayerPrefs.SetFloat("Coin", coinsManager.money);
                        PlayerPrefs.Save();
                        coinsManager.UpdateMoneyText();
                        ShootBall();
                    }
                    break;
            }
        }
    }

    private void ShootBall()
    {
        GameObject ball = Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity, spawnParent);
        Rigidbody2D ballRb = ball.GetComponent<Rigidbody2D>();
        Vector2 fireDirection = Vector2.up;

        ballRb.velocity = fireDirection * fireForce;
    }
}

