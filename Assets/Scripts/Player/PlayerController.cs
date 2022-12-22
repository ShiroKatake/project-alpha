using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Ammo ammo;

	private void Start()
	{
        ammo = new Ammo();
	}

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

	private void Update()
	{
		if (true)
		{
            ammo.ChargeAmmo(Time.deltaTime);
        }
    }
}
 