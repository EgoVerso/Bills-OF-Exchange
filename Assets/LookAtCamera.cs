using UnityEngine;
using Cinemachine;

public class LookAtCamera : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera; // Referencia a la c�mara virtual

    void Update()
    {
        // Aseg�rate de que la c�mara virtual existe
        if (virtualCamera != null)
        {
            // Obt�n la posici�n de la c�mara desde la c�mara virtual
            Transform cameraTransform = virtualCamera.transform;

            // Encuentra todos los objetos con el tag "LookAtCamera"
            GameObject[] lookAtObjects = GameObject.FindGameObjectsWithTag("LookAtCamera");

            // Recorre cada objeto y ajusta su rotaci�n
            foreach (GameObject obj in lookAtObjects)
            {
                Vector3 directionToCamera = cameraTransform.position - obj.transform.position;

                // Elimina la componente Y para que el sprite no se incline
                directionToCamera.y = 0;

                // Calcula la rotaci�n que necesita el objeto para mirar hacia la c�mara
                Quaternion targetRotation = Quaternion.LookRotation(directionToCamera);

                // Aplica la rotaci�n al objeto
                obj.transform.rotation = Quaternion.Euler(0, targetRotation.eulerAngles.y, 0);
            }
        }
    }
}
