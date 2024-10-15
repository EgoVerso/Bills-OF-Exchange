using UnityEngine;

public class AimSystem : MonoBehaviour
{
    public GameObject normalState; // El objeto para el estado sin apuntar
    public GameObject aimingState; // El objeto para el estado de apuntado
    public GameObject reloadObject; // Objeto de recarga (del otro script)

    void Update()
    {
        // Solo permitir apuntar si no se est� recargando
        if (!reloadObject.activeInHierarchy)
        {
            // Detectar si el bot�n derecho del mouse es presionado
            if (Input.GetMouseButtonDown(1)) // 1 es el bot�n derecho del mouse
            {
                ToggleAim(true); // Activar modo de apuntado
            }

            // Detectar si el bot�n derecho del mouse es soltado
            if (Input.GetMouseButtonUp(1))
            {
                ToggleAim(false); // Desactivar modo de apuntado
            }
        }
    }

    void ToggleAim(bool isAiming)
    {
        // Cambiar entre los dos objetos seg�n el estado de apuntado
        normalState.SetActive(!isAiming);
        aimingState.SetActive(isAiming);
    }
}
