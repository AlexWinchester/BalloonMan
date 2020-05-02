using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Character {

    private Vector2 moveVelocity;

    void Start() {
        isPlayer = true;
        speed = 3;
        damage = 1;
        maxHealth = 10;
        currentHealth = maxHealth;
        maxEnergy = 10;
        currentEnergy = maxEnergy;
        rigidBody = getRigidBody();
        boxCollider = getBoxCollider();
    }

    void Update() {

        trajectory = GetTrajectory();
        moveVelocity = trajectory * speed;
        rigidBody.MovePosition(rigidBody.position + moveVelocity * Time.fixedDeltaTime);
    }


    void FixedUpdate() {

    }

    private Vector2 GetTrajectory()
    {
        return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
    }
}
