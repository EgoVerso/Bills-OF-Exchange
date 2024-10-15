using UnityEngine;

public class AimSystem : MonoBehaviour
{
    public GameObject normalState; // Objeto para el estado sin apuntar
    public GameObject aimingState; // Objeto para el estado de apuntado
    public GameObject reloadObject; // Objeto de recarga

    void Update()
    {
        // Solo permitir apuntar si no se está recargando
        if (!reloadObject.activeInHierarchy)
        {
            // Detectar si el botón derecho del mouse es presionado
            if (Input.GetMouseButtonDown(1)) // 1 es el botón derecho del mouse
            {
                ToggleAim(true); // Activar modo de apuntado
            }

            // Detectar si el botón derecho del mouse es soltado
            if (Input.GetMouseButtonUp(1))
            {
                ToggleAim(false); // Desactivar modo de apuntado
            }
        }
    }

    void ToggleAim(bool isAiming)
    {
        // Cambiar entre los dos objetos según el estado de apuntado
        normalState.SetActive(!isAiming);
        aimingState.SetActive(isAiming);
    }
}
