using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private int dmg;
    private float range;
    private float speed;

    private Vector2 startPos;
    public void Setup(int dmg, float range, float speed)
    {
        this.dmg = dmg;
        this.range = range;
        this.speed = speed;
    }
    void Update()
    {
        if (Vector2.Distance(transform.position, startPos) <= 0.1f)
            Destroy(gameObject);

        transform.position = Vector2.MoveTowards(transform.position, transform.up, speed * Time.deltaTime);
    }
}
