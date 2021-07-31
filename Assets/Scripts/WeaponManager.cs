using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{

    public Camera camera;

    public Gun PrimaryGun;
    public Gun SecondaryGun;

    [HideInInspector]
    public Gun SelectedGun;


    // Start is called before the first frame update
    void Start()
    {
        PrimaryGun.SwitchGun(true);
        SecondaryGun.SwitchGun(false);
        SelectedGun = PrimaryGun;

        PrimaryGun.Manager = this;
        SecondaryGun.Manager = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PrimaryGun.SwitchGun(true);
            SecondaryGun.SwitchGun(false);
            SelectedGun = PrimaryGun;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            PrimaryGun.SwitchGun(false);
            SecondaryGun.SwitchGun(true);
            SelectedGun = SecondaryGun;
        }
    }
}
