using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemstonePickup : MonoBehaviour
{
    private Text scoreText;
    public AudioClip pickupClip;

    private void Start()
    {
        scoreText = GameObject.Find("Score").GetComponent<Text>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Player")
        {
            AudioSource.PlayClipAtPoint(pickupClip, transform.position);
            Destroy(this.gameObject);
            scoreText.GetComponent<scoreController>().score += 1;
            scoreText.GetComponent<scoreController>().UpdateScore();
        }
    }
}
