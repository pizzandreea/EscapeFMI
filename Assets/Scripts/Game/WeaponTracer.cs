using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTracer : MonoBehaviour
{
    public Transform firePoint;
    public GameObject projectilePrefab;

    public float bulletForce = 10f;

    [SerializeField] private PlayerAimWeapon playerAimWeapon;
    // Start is called before the first frame update
    void Start()
    {
        playerAimWeapon.OnShoot += PlayerAimWeapon_OnShoot;

    }

    private void PlayerAimWeapon_OnShoot(object sender, PlayerAimWeapon.OnShootEventArgs e)
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
