using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Character {

    void Start() {
        isPlayer = true;
        speed = 3;
        damageMelee = 2;
        damageRanged = 1;
        attackSpeedMelee = 50;
        attackSpeedRanged = 100;
        maxHealth = 10;
        currentHealth = maxHealth;
        maxEnergy = 10;
        currentEnergy = maxEnergy;
    }

    void Update() {

        // Move Player with keyboard
        trajectory = GetTrajectory();
        moveVelocity = trajectory * speed;
        rigidBody.MovePosition(rigidBody.position + moveVelocity * Time.deltaTime);

        // Shoot with mouse
        if (Input.GetMouseButton(0))
        {
            Shoot()
        }
    }


    void FixedUpdate() {

    }

    private Vector2 GetTrajectory()
    {
        return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
    }
}
