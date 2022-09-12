using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    private Vector3 target;
    [SerializeField] private List<GameObject> missileSpawnList = new List<GameObject>() {};
    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject house in GameObject.FindGameObjectsWithTag("House"))
        {
            missileSpawnList.Add(house);
        }
        target = missileSpawnList[Random.Range(0, missileSpawnList.Count)].transform.position;
        Vector2 lookDir = target - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, Time.deltaTime * speed);
        if(Vector3.Distance(gameObject.transform.position, target) == 0)
        {
            StartCoroutine(hit());
        }
        if(missileSpawnList.Count < 1){
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("House"))
        {
            StartCoroutine(hit());
            Destroy(col.gameObject);
            
            
        }
        if(col.CompareTag("explosion"))
        {
            gainScore(100);
            Destroy(gameObject);
        }

    }
    IEnumerator hit()
    {
        animator.SetTrigger("Hit");
        yield return new WaitForSeconds(.4f);

        Destroy(gameObject);
    }

    void gainScore(int score){
        GameController.scoreCount += score;
    }
    
}
