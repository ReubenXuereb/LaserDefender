using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

   // Config Param
   [Header("Player")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding;
    [SerializeField] int health = 200;
    [SerializeField] AudioClip deathSound;
    [SerializeField] [Range(0,1)] float deathSoundVolume = 0.75f;
    [SerializeField] AudioClip shootSound;
    [SerializeField] [Range(0,1)] float shootSoundVolume = 0.25f;

    [Header("Projectile")]
    [SerializeField] GameObject laserBullet;
    
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileFiringPeriod = 0.1f;

    Coroutine firingCoroutine;
    [SerializeField] Sprite[] hitSprites;
    public SpriteRenderer debrisRef;


    float xMin, xMax, yMin, yMax;
    
   
    

    void Start()
    {
          setUpMoveBounderies();
    }

   

    
    void Update()
    {
        Move();
        Fire();
    }

    
    private void Fire()
    {
        if(Input.GetButtonDown("Fire1"))
        {
           firingCoroutine = StartCoroutine(fireContinuously());

        }
        if(Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCoroutine);
        }
    }

    IEnumerator fireContinuously()
    {

        while(true)
        {
            GameObject laser = Instantiate(laserBullet, transform.position, Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
            AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
            yield return new WaitForSeconds(projectileFiringPeriod);
        }


    }

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;   
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;  

        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
        transform.position = new Vector2(newXPos, newYPos);
    }

    private void  setUpMoveBounderies()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0,0,0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1,0,0)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0,0,0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0,1,0)).y - padding;
    
    }

     private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if(!damageDealer){return;}
        processHit(damageDealer);

    }

    private void processHit(DamageDealer damageDealer)
    {
        health -= damageDealer.getDamage();
        damageDealer.hit();
        if (health <= 0)
        {
           FindObjectOfType<HealthDisplay>().UpdateHealth();
           Die();
        }
        else
        {
            showNextHitSprite();
        }
    }

    

    private void showNextHitSprite()
    {
        if(health <=350 && health > 250)
           debrisRef.sprite = hitSprites[0];

        if(health <=250 && health > 150)
           debrisRef.sprite = hitSprites[1];

        if(health <=150)
           debrisRef.sprite = hitSprites[2];
    }

    private void Die()
    {
         PlayerPrefs.SetInt("CurrentScore", FindObjectOfType<GameManager>().getScore());
         FindObjectOfType<Level>().UpdateHighScore();
         FindObjectOfType<Level>().StartDelayAnimation("Death Scene", 2);
         Destroy(gameObject);
         AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);
    }

    public int getHealth()
    {
        return health;
    }
}









    




    


