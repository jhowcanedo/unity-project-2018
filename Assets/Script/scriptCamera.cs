using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptCamera : MonoBehaviour
{
    public GameObject player;
    public float offsetY = 2f;
    public float velocidade;
    private Rigidbody2D rbd;

    public float xMin, xMax, yMin, yMax;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rbd = GetComponent<Rigidbody2D>();
        rbd.velocity = new Vector2(velocidade, 0);
        
    }

    // Update is called once per frame
    /*void Update()
    {
        Vector3 pos = new Vector3(player.transform.position.x, player.transform.position.y + offsetY, -10);
        transform.position = pos;
    }*/

    private void LateUpdate()
    {
        float x = Mathf.Clamp(player.transform.position.x, xMin, xMax);
        float y = Mathf.Clamp(player.transform.position.y, yMin, yMax);
        gameObject.transform.position = new Vector3(x, y+offsetY, gameObject.transform.position.z);
    }
}
