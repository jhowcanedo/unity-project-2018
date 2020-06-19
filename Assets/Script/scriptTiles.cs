using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptTiles : MonoBehaviour
{
    private float altura;
    private float largura;
    public GameObject camera; 
    
    
    // Start is called before the first frame update
    void Start()
    {
        altura = Camera.main.orthographicSize;
        largura = altura * Camera.main.aspect;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < camera.transform.position.y-largura-1.5)
        {
            Destroy(this.gameObject);
        }
    }
}
