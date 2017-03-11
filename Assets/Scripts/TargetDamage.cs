using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDamage : MonoBehaviour {

    public int hitPoints = 2;
    public Sprite damageSprite;
    public float damageImpactSpeed;

    private int currentHitPoints;
    private float damageImpactSpeedSqr;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHitPoints = hitPoints;
        damageImpactSpeedSqr = damageImpactSpeed * damageImpactSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag != "Damager") { return; }

        if (collision.relativeVelocity.sqrMagnitude < damageImpactSpeedSqr) { return; }

        spriteRenderer.sprite = damageSprite;
        currentHitPoints--;

        if (currentHitPoints <= 0) { Kill(); }
    }

    private void Kill()
    {
        spriteRenderer.enabled = false;
        Collider2D collider = gameObject.GetComponent<Collider2D>();
        Rigidbody2D rigidbody = gameObject.GetComponent<Rigidbody2D>();
        collider.enabled = false;
        rigidbody.isKinematic = true;
    }
}
