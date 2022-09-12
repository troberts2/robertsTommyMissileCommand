using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector3 target;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject explosion;

    void Start()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = target - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
        StartCoroutine(bulletMove());
        
        
    }

    void Update() 
    {
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
        if(transform.position.y == target.y - .1f)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    IEnumerator bulletMove()
    {
        bool arrived = false;
        while(!arrived)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
            //I do the .1f instead of == 0 because I was getting a bug where arrived would never turn true and couldn't fix it.
            if(Vector2.Distance(transform.position, target) <= 0.1f)
            {
                arrived = true;
            }
            yield return null;
        }
        if(arrived)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        
    }
}
