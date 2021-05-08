using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float bound_Y = 6f;
    public bool platform_move_left, platform_move_right, isBreakable, isSpike, isPlatform;

    private Animator anim;

    void Awake()
    {
        if(isBreakable)
        {
            anim = GetComponent<Animator>();
        }
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector2 temp = transform.position;
        temp.y += moveSpeed * Time.deltaTime;
        transform.position = temp;

        if(temp.y>=bound_Y)
        {
            gameObject.SetActive(false);
        }
    }

    void BreakableDeactivate()
    {
        Invoke("DeactivateGameObject", 0.3f);
    }

    void DeactivateGameObject()
    {
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag=="Player")
        {
            if(isSpike)
            {
                target.transform.position = new Vector2(1000f, 1000f);

                SoundManager.instance.GameOverSound();
                GameManager.instance.RestartGame();
            }
        }
    }//on trigger enter

    void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.tag=="Player")
        {
            if(isBreakable)
            {
                SoundManager.instance.LandSound();

                anim.Play("Break");
            }
            if(isPlatform)
            {
                SoundManager.instance.LandSound();
            }
        }
    }//on collision enter

    void OnCollisionStay2D(Collision2D target)
    {
        if(target.gameObject.tag=="Player")
        {
            if(platform_move_left)
            {
                target.gameObject.GetComponent<PlayerMovement>().PlatformMove(-1f);
            }
            if(platform_move_right)
            {
                target.gameObject.GetComponent<PlayerMovement>().PlatformMove(1f);
            }
        }
    }//on collision stay
}

