using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckoController : MonoBehaviour
{
    public float speed = 5.0f;

    public int maxHealth = 5;
    public float timeInvincible = 2;

    public int health { get { return currentHealth; } }
    int currentHealth;

    bool isInvinciable;
    float invincibleTimer;


    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;

    Animator animator;

    
    // Start is called before the first frame update
    void Start()
    {
          rigidbody2d = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (isInvinciable)
        {
            invincibleTimer -= Time.deltaTime;
            if(invincibleTimer < 0 )
            {
                isInvinciable = false;
            }
        }
    }

    void FixedUpdate()
    { 
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

         rigidbody2d.MovePosition(position);
    }

     public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if(isInvinciable)
            {
                return;
            }
            isInvinciable = true;
            invincibleTimer = timeInvincible;
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }
}  