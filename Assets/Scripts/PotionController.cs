using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionController : MonoBehaviour
{
    public enum PotionType
    {
        Speed,
        Jump
    }

    public PotionType potionType;
    public int potionModAmount = 0;
    public AudioClip pickupClip;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            if (potionType == PotionType.Jump)
            {
                collision.gameObject.GetComponent<PlayerMovement>().hasJumpPotion = true;
                collision.gameObject.GetComponent<PlayerMovement>().jumpModAmount = potionModAmount;
            }
            else if (potionType == PotionType.Speed)
            {
                collision.gameObject.GetComponent<PlayerMovement>().hasSpeedPotion = true;
                collision.gameObject.GetComponent<PlayerMovement>().speedModAmount = potionModAmount;
            }

            Destroy(this.gameObject);
            AudioSource.PlayClipAtPoint(pickupClip, transform.position);
        }
    }
}
