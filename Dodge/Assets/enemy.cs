using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public GameObject prefab;
    public GameObject prefab_f;
    public Transform parent;
    private int num;

    private void Start()
    {
        num = 0;
        StartCoroutine(maker());
        StartCoroutine(maker2());
    }

    void make(Vector2 pos)
    {
        GameObject obj = MonoBehaviour.Instantiate(prefab);
        obj.name = num.ToString() + "enemy";
        obj.transform.parent = parent;
        obj.transform.position = pos;
        StartCoroutine(delete(obj,10f));
    }
    void makef(Vector2 pos)
    {
        GameObject obj = MonoBehaviour.Instantiate(prefab_f);
        obj.name = num.ToString() + "enemy";
        obj.transform.parent = parent;
        obj.transform.position = pos;
        StartCoroutine(delete(obj,5f));
    }
    IEnumerator delete(GameObject obj,float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(obj);

    }
    IEnumerator maker()
    {
        while (true)
        {
            make(new Vector2(10, Random.Range(-5, 5)));
            make(new Vector2(-10, Random.Range(-5, 5)));
            make(new Vector2(Random.Range(-5, 5), 6));
            make(new Vector2(Random.Range(-5, 5), -6));
            yield return new WaitForSeconds(2.0f);
        }
    }IEnumerator maker2()
    {
        while (true)
        {
            yield return new WaitForSeconds(10.0f);
            int num = Random.Range(1, 4);
            switch (num){
                case 1:
                    makef(new Vector2(10, Random.Range(-5, 5)));
                    break;
                case 2:
                    makef(new Vector2(-10, Random.Range(-5, 5)));
                    break;
                case 3:
                    makef(new Vector2(Random.Range(-5, 5), 6));
                    break;
                case 4:
                    makef(new Vector2(Random.Range(-5, 5), -6));
                    break;
            }
            
        }
    }
}
