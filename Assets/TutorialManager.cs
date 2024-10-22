using UnityEngine;
using TMPro; // Asegúrate de incluir este espacio de nombres

public class TutorialManager : MonoBehaviour
{
    public GameObject tutorialCanvas;
    public TMP_Text tutorialText; // Cambiado a TMP_Text

    public string tutorialMessage; // Mensaje del tutorial

    public static TutorialManager Instance { get; private set; }
    public bool IsTutorialActive { get; private set; }

    private void Awake()
    {
        // Singleton para acceder desde otros scripts
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Muestra el mensaje del tutorial al iniciar
        ShowTutorialMessage();
        IsTutorialActive = true;
    }

    private void Update()
    {
        // Cierra el tutorial si se presiona "E"
        if (Input.GetKeyDown(KeyCode.E))
        {
            HideTutorial(); // Oculta el tutorial
        }
    }

    private void ShowTutorialMessage()
    {
        tutorialText.text = tutorialMessage; // Muestra el mensaje del tutorial
        tutorialCanvas.SetActive(true); // Asegúrate de activar el canvas
    }

    private void HideTutorial()
    {
        tutorialCanvas.SetActive(false);
        IsTutorialActive = false; // Actualiza el estado
    }
}
