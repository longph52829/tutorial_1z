using System.Collections;
using UnityEngine;

public class spawn_quai : MonoBehaviour
{
    public GameObject[] quai;
    public float time;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(spawn_wait());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator spawn_wait()
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            
            spawn();
        }
    }

    public void spawn()
    {
        var random =  quai[Random.Range(0, quai.Length)];
        
        if (quai.Length > 0)
        {
            Instantiate(random, transform.position, Quaternion.identity);
        }
    }
}
