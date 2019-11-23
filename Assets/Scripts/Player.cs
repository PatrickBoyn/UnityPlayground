using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private float _fireRate = 0.5f;

    private float _canFire = -1f;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement(0, -3.8f, -11.20f, 11.24f);
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            FireLaser();
        }
    }

    private void PlayerMovement(float topBoundary, float bottomBoundary, float leftBoundary, float rightBoundary)
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

        transform.Translate(Time.deltaTime * _speed * direction);

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, bottomBoundary, topBoundary), 0);

        if (transform.position.x < leftBoundary)
        {
            transform.position = new Vector3(leftBoundary * -1, transform.position.y, 0);
        }
        else if (transform.position.x > rightBoundary)
        {
            transform.position = new Vector3(rightBoundary * -1, transform.position.y, 0);
        }
    }

    private void FireLaser()
    {
        _canFire = Time.time + _fireRate;
        Instantiate(_laserPrefab, transform.position, Quaternion.identity);
    }
}
