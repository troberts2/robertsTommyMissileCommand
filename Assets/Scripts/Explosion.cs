using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 temp = transform.position;
        temp.z = 0.0f;
        transform.position = temp;
        StartCoroutine(Despawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Despawn(){
        while(true){
            yield return new WaitForSeconds(.4f);
            Destroy(gameObject);
        }
    }
}
