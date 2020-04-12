using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public AudioClip gameOverClip;
    public Animator animator;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Player")
        {
            if (collision.gameObject.transform.position.y > this.transform.position.y + 0.3)
            {
                
                Destroy(this.gameObject, 1f);
                animator.SetBool("Dead", true);

            }
            else
            {
                AudioSource.PlayClipAtPoint(gameOverClip, transform.position);
                Destroy(collision.gameObject);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
