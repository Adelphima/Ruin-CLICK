using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translation : MonoBehaviour
{
    public GameObject Square;
    public GameObject Glyth_Placeholder;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Glyth_Placeholder.transform.position = Vector3.MoveTowards(Glyth_Placeholder.transform.position, Square.transform.position, speed);
    }
}
