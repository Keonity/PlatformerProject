using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public AudioClip gameOverClip;
    public AudioClip killClip;
    public Animator animator;

    private void Death()
    {
        Destroy(this.gameObject, 1f);
        AudioSource.PlayClipAtPoint(killClip, transform.position);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Player")
        {
            if (collision.gameObject.transform.position.y > this.transform.position.y + 0.3)
            {
                
                animator.SetBool("Dead", true);
                Death();

            }
            else
            {
                AudioSource.PlayClipAtPoint(gameOverClip, transform.position);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("Dead", false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
