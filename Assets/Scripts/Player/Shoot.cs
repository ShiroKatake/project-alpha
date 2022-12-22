using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Ammo))]
public class Shoot : MonoBehaviour
{
    public void ChargeAmmo(InputAction.CallbackContext context)
    {
        float timeHeld = context.ReadValue<float>();
        Debug.Log(timeHeld);
        Debug.Log("Charging");
    }

    public void ShootAmmo(InputAction.CallbackContext context)
    {
        if (context.duration >= 2d)
        {
            Debug.Log("Small Ammo");
        }
        Debug.Log("Release");
    }
}
