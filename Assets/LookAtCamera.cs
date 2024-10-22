using UnityEngine;
using Cinemachine;

public class LookAtCamera : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera; // Referencia a la cámara virtual

    void Update()
    {
        // Asegúrate de que la cámara virtual existe
        if (virtualCamera != null)
        {
            // Obtén la posición de la cámara desde la cámara virtual
            Transform cameraTransform = virtualCamera.transform;

            // Encuentra todos los objetos con el tag "LookAtCamera"
            GameObject[] lookAtObjects = GameObject.FindGameObjectsWithTag("LookAtCamera");

            // Recorre cada objeto y ajusta su rotación
            foreach (GameObject obj in lookAtObjects)
            {
                Vector3 directionToCamera = cameraTransform.position - obj.transform.position;

                // Elimina la componente Y para que el sprite no se incline
                directionToCamera.y = 0;

                // Calcula la rotación que necesita el objeto para mirar hacia la cámara
                Quaternion targetRotation = Quaternion.LookRotation(directionToCamera);

                // Aplica la rotación al objeto
                obj.transform.rotation = Quaternion.Euler(0, targetRotation.eulerAngles.y, 0);
            }
        }
    }
}
