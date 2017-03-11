using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Resetter : MonoBehaviour {

    public Rigidbody2D projectile;
    public float resetSpeed = 0.025f;

    private float resetSpeedSqr;
    private SpringJoint2D spring;

    private void Start()
    {
        resetSpeedSqr = resetSpeed * resetSpeed;
        spring = projectile.GetComponent<SpringJoint2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) { Reset(); }

        if (spring == null && projectile.velocity.sqrMagnitude < resetSpeedSqr) { Reset(); }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Rigidbody2D rigidbody = other.GetComponent<Rigidbody2D>();
        if (rigidbody == projectile) { Reset(); }
    }

    private void Reset()
    {
        SceneManager.LoadScene("Main");
    }
}
