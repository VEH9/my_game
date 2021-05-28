using UnityEngine;
using System.Collections;
using System.Linq;

public class MoveableMonster : Monster
{
    [SerializeField]
    private float speed = 2.0F;

    [SerializeField]
    private float rate = 2.0F;

    private Bullet bullet;

    private Vector3 direction;

    protected override void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        bullet = Resources.Load<Bullet>("Assets/Bullet");
    }
    
    private void Shoot()
    {
        Vector3 position = transform.position;
        position.y += 0.5F;
        Bullet newBullet = Instantiate(bullet, position, bullet.transform.rotation) as Bullet;

        newBullet.Parent = gameObject;
        newBullet.Direction = newBullet.transform.right;
        
    }

    private SpriteRenderer sprite;

    //protected override void Awake()
    //{
    //    sprite = GetComponentInChildren<SpriteRenderer>();
    //}

    protected override void Start()
    {
        direction = transform.up;
        InvokeRepeating("Shoot", rate, rate);
    }

    protected override void Update()
    {
        Move();
    }

    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();

        if (unit && unit.gameObject)
        {
            unit.ReceiveDamage();
            Destroy(gameObject);
        }
    }
    

    private void Move()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * direction.y * 2f, 0.1F);

        if (colliders.Length > 0 && colliders.All(x => !x.GetComponent<Character>())) direction *= -1.0F;

        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }
}
