using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    static public int scoreCount;
    [SerializeField] private List<float> missileSpawnList = new List<float>() {};
    [SerializeField] private GameObject enemyBullet;
    [SerializeField] private float bulletRainRate;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(bulletRain());
    }

    // Update is called once per frame
    void Update()
    {
        Debugger();
    }
    IEnumerator bulletRain()
    {
        while(true)
        {
            Instantiate(enemyBullet, new Vector2(missileSpawnList[Random.Range(0, missileSpawnList.Count)], 6), Quaternion.identity);
            yield return new WaitForSeconds(bulletRainRate);
        }
        
    }

    void Debugger()
    {
        if(Input.GetKey(KeyCode.R)) 
        { 
            UnityEngine.SceneManagement.SceneManager.LoadScene(0); 
        } 
    }

}
