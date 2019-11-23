using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _speed = 8f;
    private GameObject _laserPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LaserMovement();
    }

    private void LaserMovement()
    {
        Vector3 transformPosition = Time.deltaTime * _speed * Vector3.up;
        Vector3 offset = new Vector3(0, 1f, 0);

        transform.Translate(transformPosition + offset);

        if (transform.position.y > 8f)
        {
            Destroy(gameObject);
        }
    }
}
