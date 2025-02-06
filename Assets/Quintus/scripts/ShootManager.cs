using UnityEngine;
using UnityEngine.InputSystem;
public class ShootManager : MonoBehaviour
{
    public Transform bulletspawnpoint;
    public GameObject bulletprefab;
    public float bulletspeed;

    [SerializeField] private PlayerControls playerControls;
    [SerializeField] private PlayerInput playerInput;

    private bool shootpressed;
    private bool isShooting;

    public ParticleSystem particles;
    public AudioSource audiosource;
    public AudioClip[] shootsounds;

    void OnJump(InputAction.CallbackContext context)
    {
        Debug.Log("Trigger pressed");
        shootpressed = context.ReadValueAsButton();
        isShooting = true;
        Debug.Log("pressed the space bar");
        GameObject bullet = Instantiate(bulletprefab, bulletspawnpoint.position, bulletspawnpoint.rotation);
        particles.Play();
        bullet.GetComponent<BulletScript>().movSpeed = bulletspeed;
        audiosource.PlayOneShot(shootsounds[0], 1f);
    }

    private void Awake()
    {
        playerControls = new PlayerControls();
        playerControls.Controls.shoot.performed += OnJump;
        //playerControls.Controls.shoot.canceled += OnJump;
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    void Update()
    {
    }
}
