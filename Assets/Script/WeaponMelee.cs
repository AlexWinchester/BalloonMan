using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMelee : Weapon
{

    //Awake is called as soon as component is added to GameObject
    protected override void Awake()
    {
        base.Awake();
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        
    }

    protected override void LateUpdate()
    {
        base.LateUpdate();
    }

    public void Swing(Vector2 trajectory)
    {


        didAttack = true;
    }
}
