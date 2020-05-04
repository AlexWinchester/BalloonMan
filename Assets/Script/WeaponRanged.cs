using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRanged : Weapon
{
    public Vector2 projectilePosition;
    public string projectileName;
    public float speedProjectile;
    public Sprite spriteProjectile;

    //Awake is called as soon as component is added to GameObject
    protected override void Awake()
    {
        base.Awake();
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        // Set placement
        transform.position = transform.position + new Vector3(0, 0, 1);
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        // Update Projectile Position
        projectilePosition = transform.position;
    }

    protected override void LateUpdate()
    {
        base.LateUpdate();
    }

    public void Shoot(Vector2 trajectory)
    {
        if (timer >= attackSpeed)
        {
            new GameObject(projectileName).AddComponent<Projectile>()
                .Sprite(spriteProjectile)
                .Trajectory(trajectory)
                .Position(projectilePosition)
                .Speed(speedProjectile)
                .Damage(damage)
                .Range(range);

            didAttack = true;
        }
    }

    public WeaponRanged SpriteProjectile(Sprite sprite)
    {
        spriteProjectile = sprite;
        return this;
    }

    public WeaponRanged SpeedProjectile(float speed)
    {
        speedProjectile = speed;
        return this;
    }

}
