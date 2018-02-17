using System.Linq;
using UnityEngine;

public class InstantiateShip : MonoBehaviour {


    public float radius;
    public GameObject pirates;
    // Use this for initialization
    void Start()
    {

        Ships();
    }

    // Update is called once per frame
    void Update()
    {
    }
    [ContextMenu("Delete Ships")]
    void Delete_ship()
    {
        foreach (Transform t in transform.Cast<Transform>().ToArray())
        {
            DestroyImmediate(t.gameObject);
        }
    }

    [ContextMenu("Instantiate Ships")]
    void Ships()
    {
        for (float i = 0;i<Mathf.PI*2 ; i += Mathf.PI / 8)
        {
            var enemy = Instantiate(pirates, transform);
            var tr = enemy.transform;
            tr.position = new Vector3(transform.position.x + radius * Mathf.Sin(i), 0f, transform.position.z + radius * Mathf.Cos(i));
        }
    }
}
