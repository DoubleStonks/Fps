using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [HideInInspector]
    public WeaponManager Manager;

    public ParticleSystem muzzleflash;
    public Animator animator;

    public int MaxAmmo = 10;
    private int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;

    [SerializeField]
    [Range(0.1f, 5f)]
    private float fireRate = 1f;

    [SerializeField]
    [Range(1, 100)]
    private int damage = 1;

    [SerializeField]
    private Transform firePoint;

    [SerializeField]
    private AudioSource GunFireSource;

    private float timer;


    void Start()
    {
        currentAmmo = MaxAmmo;
    }

    void OnEnable()
    {
        isReloading = false;
        animator.SetBool("Reloading", false);
    }



    void Update()
    {

        if (isReloading)
        {
            return;
        }


        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        timer += Time.deltaTime;
        if (timer >= fireRate)
        {
            if (Input.GetButton("Fire1"))
            {
                timer = 0f;
                FireGun();

            }
        }
    }


    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading...");

        animator.SetBool("reload", true);

        yield return new WaitForSeconds(reloadTime - .25f);

        animator.SetBool("reload", false);

        yield return new WaitForSeconds(.25f);

        currentAmmo = MaxAmmo;
        isReloading = false;
    }


    private void FireGun()
    {
        GunFireSource.Play();
        muzzleflash.Play();

        currentAmmo--;

        Debug.DrawRay(firePoint.position, firePoint.forward * 100, Color.red, 2f);

        Ray ray = new Ray(firePoint.position, firePoint.forward);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 50))
        {
            var Health = hitInfo.collider.GetComponent<Health>();

            if (Health != null)
            {
                Health.TakeDamage(damage);
            }
        }
    }

    public void SwitchGun(bool OnSwitch)
    {

        StopAllCoroutines();

        isReloading = false;

        gameObject.SetActive(OnSwitch);

    }

}