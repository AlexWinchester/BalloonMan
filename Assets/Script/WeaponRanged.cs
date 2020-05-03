using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRanged : Weapon
{
    public Vector2 projectilePosition;
    public string projectileName;
    public int projectileSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Update Projectile Position
        projectilePosition = transform.position;
    }

    public void Shoot(Vector2 trajectory)
    {
        if (timer >= attackSpeed)
        {
            new GameObject(name).AddComponent<Projectile>()
                .Sprite(sprite)
                .Trajectory(trajectory)
                .Position(projectilePosition)
                .Speed(projectileSpeed)
                .Damage(damage)
                .Range(range);

            didAttack = true;
        }
    }
}
