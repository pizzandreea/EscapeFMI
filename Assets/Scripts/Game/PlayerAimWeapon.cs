using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimWeapon : MonoBehaviour
{
    private Transform aimTransform;
    private Transform aimGunPointPosTransform;
    public event EventHandler<OnShootEventArgs> OnShoot;

    public float fireRate = 0.7f;
    private float nextFire = 0.0f;

    [SerializeField]
    private AudioSource shooting;

    public class OnShootEventArgs : EventArgs
    {
        public Vector3 gunPointPos;
        public Vector3 shootPos;
    }

    void Awake()
    {
        aimTransform = transform.Find("Aim");
        aimGunPointPosTransform = aimTransform.Find("GunPointPos");
    }

    // Update is called once per frame
    void Update()
    {
        Aiming();
        Shooting();
    }

    void Aiming()
    {
        Vector3 mousePos = GetMousePos();
        Vector3 aimDir = (mousePos - transform.position).normalized;
        float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;
        if (transform.localScale.x < 0)
        {
            angle = angle + 180f;
        }
        aimTransform.eulerAngles = new Vector3(0, 0, angle);
    }

    void Shooting()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (!shooting.isPlaying)
                shooting.Play();
            Vector3 mousePos = GetMousePos();
            OnShoot?.Invoke(this, new OnShootEventArgs
            {
                gunPointPos = aimGunPointPosTransform.position,
                shootPos = mousePos,
            }); 
        }
    }

    Vector3 GetMousePos()
    {
        Vector3 result = GetMousePosWithZ(Input.mousePosition, Camera.main);
        result.z = 0f;
        return result;
    }

    Vector3 GetMousePosWithZ(Vector3 pos, Camera camera)
    {
        return camera.ScreenToWorldPoint(pos);
    }
}
