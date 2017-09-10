using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeBulletDamage : MonoBehaviour {

    public int hp;
    public float damageTime;
    public Color damageColor;
    private Color defaultColor;

    private SpriteRenderer mySpriteRenderer;

    private void Start()
    {
        mySpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        defaultColor = mySpriteRenderer.color;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Bullet bullet = collision.gameObject.GetComponent<Bullet>();

        if (bullet != null)
        {
            hp -= bullet.damage;

            if (hp <= 0)
            {
                Destroy(this.gameObject);
            }
            else
            {
                StartCoroutine(FlashHit());
            }
        }
    }

    private IEnumerator FlashHit()
    {
        mySpriteRenderer.color = damageColor;
        yield return new WaitForSeconds(damageTime);
        mySpriteRenderer.color = defaultColor;
    }
}
