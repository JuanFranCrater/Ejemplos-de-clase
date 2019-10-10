using UnityEngine;
using System.Collections;

public class Shooter3D : MonoBehaviour
{
    [Range(1, 10)]
    public float shootSpeed = 1;
    private float _shootTimer;

    [Header("Input")]
    public bool useLeftClick;
    public bool useRightClick;
    public KeyCode shootKey;
    public string shootAxis;

    [Header("Bullet")]
    public GameObject bulletPrefab;
    public Transform bulletStart;
    public float bulletSpeed = 20;
    public float lifeTime;

    private AudioSource _audioSource;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        _shootTimer = 0;
    }
	
	void Update ()
    {
        _shootTimer -= Time.deltaTime;
        if(_shootTimer <= 0)
        {
            if (Input.GetKey(shootKey) || (useLeftClick && Input.GetMouseButton(0)) || (useRightClick && Input.GetMouseButton(1)) || (shootAxis != "" && Input.GetAxis(shootAxis) > 0))
            {
                Fire();
                _shootTimer = 1 / shootSpeed;
            }
        }
    }

    private void Fire()
    {
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, bulletStart.position, bulletStart.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;
        Destroy(bullet, lifeTime);
        if (_audioSource != null)
            _audioSource.Play();
    }
}
