using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptRollingBG : MonoBehaviour
{

    private float largura;
    public GameObject cam;
    public float parallax, startpos;

    // Start is called before the first frame update
    void Start()
    {
        largura = GetComponent<SpriteRenderer>().bounds.size.x;
        startpos = transform.position.x;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float respawn = (cam.transform.position.x * (1 - parallax));
        float distancia = (cam.transform.position.x * parallax);
        transform.position = new Vector2(startpos + distancia, cam.transform.position.y);


        if (respawn > startpos + largura)
            startpos += largura;
        else if (respawn < startpos - largura)
            startpos -= largura;
    }
}
