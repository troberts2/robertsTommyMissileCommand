using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelController : MonoBehaviour
{
    [SerializeField] private bool canShoot = true;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = target - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
        if((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0)) && canShoot)
        {
            StartCoroutine(FireRate());
        }
    }
 
 
     IEnumerator FireRate()
     {
         canShoot = false;
         InstaniateProjectile();
         yield return new WaitForSeconds(0.2f);
         canShoot = true;
     }

     void InstaniateProjectile()
     {
        GameObject bullet = Instantiate (bulletPrefab, transform.position, Quaternion.identity);
        
     }
}
