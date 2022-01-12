using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject panelStart;
    public GameObject panelRestart;
    public Text dinoWin;
    public Text marcadorRojo;
    public Text marcadorAzul;
    public Button start;
    public Button restart;

    public GameObject dinoAzul;
    public GameObject dinoRojo;
    public GameObject spawneableFruits;

    void Update()
    {
        if(marcadorAzul.text == "3")
        {
            dinoWin.text = "Blue";
            dinoWin.color = Color.cyan;
            PauseGame();
        }
        else if (marcadorRojo.text == "3")
        {
            dinoWin.text = "Red";
            dinoWin.color = Color.red;
            PauseGame();
        }
    }

    public void StartGame()
    {
        panelStart.SetActive(false);
        panelRestart.SetActive(false);
        dinoAzul.GetComponent<PlayerController>().IniciarJuego();
        dinoRojo.GetComponent<PlayerController>().IniciarJuego();
        spawneableFruits.GetComponent<SpawneableFruits>().IniciarJuego();
    }

    private void PauseGame()
    {
        panelRestart.SetActive(true);
        dinoAzul.GetComponent<PlayerController>().PararJuego();
        dinoRojo.GetComponent<PlayerController>().PararJuego();
        dinoAzul.GetComponent<Damageable>().ResetPoints();
        dinoRojo.GetComponent<Damageable>().ResetPoints();
        spawneableFruits.GetComponent<SpawneableFruits>().PararJuego();
    }
}
