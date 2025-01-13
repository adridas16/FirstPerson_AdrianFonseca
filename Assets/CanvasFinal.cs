using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasFinal : MonoBehaviour
{
    [SerializeField] GameObject CanvasParar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EmpezarPartida()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    public void Salir()
    {
        Application.Quit();
        
    }
    public void Menu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }
    public void Respawn()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);

    }
    public void botonSelectLevel()
    {

        SceneManager.LoadScene(1);

    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        CanvasParar.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }



}
