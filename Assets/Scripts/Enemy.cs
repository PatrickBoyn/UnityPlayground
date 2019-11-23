using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4f;

    private GameObject _playerPrefab;

    private GameObject _laserPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 transformPosition = Time.deltaTime * _speed * Vector3.down;
        float randomX = UnityEngine.Random.Range(-9.23f, 9.23f);
        transform.Translate(transformPosition);

        if (transform.position.y < -5f)
        {
            transform.position = new Vector3(randomX, 7f, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{ other.transform.tag} collided with Enemy.");
        
        switch (other.transform.tag)
        {
            case "Player":
                Destroy(_playerPrefab);
                break;
            case "Laser":
                Destroy(_laserPrefab);
                break;
        }
    }
}
