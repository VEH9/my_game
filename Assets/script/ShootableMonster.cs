using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableMonster : Monster
{
    [SerializeField]
    private float rate = 1.0F;

    private Bullet bullet;

    protected override void Awake()
    {
        bullet = Resources.Load<Bullet>("Bullet");
    }

    protected override void Start()
    {
        InvokeRepeating("Shoot", rate, rate);
    }

    private void Shoot()
    {
        Vector3 position = transform.position; position.x -= 0.5F;
        Bullet newBullet = Instantiate(bullet, position, bullet.transform.rotation) as Bullet;

        newBullet.Parent = gameObject;
        newBullet.Direction = -newBullet.transform.right;
    }

    //protected override void OnTriggerEnter2D(Collider2D collider)
    //{
    //    Unit unit = collider.GetComponent<Unit>();

    //    if (unit && unit is KnightPlayer)
    //    {
    //        if (Mathf.Abs(unit.transform.position.x - transform.position.x) < 0.3F) ReceiveDamage();
    //        else unit.ReceiveDamage();
    //    }
    //}
}
