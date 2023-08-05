using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;



/// <summary>
/// ƒанный класс обрабатывет взаимодействие пользовател€ с меню паузы
/// </summary>
public class Pausemenu : MonoBehaviour
{
    public static bool GameIsPaused = false;


    public GameObject MainCam;
    public GameObject pauseMenuUI;
    public GameObject settingsMenuUI;
    public GameObject GameUi;

    /// <summary>
    /// ¬ыход в главное меню
    /// </summary>
    public void SaveAndQuit()
    {
        SceneManager.LoadScene("Main menu");
    }
    /// <summary>
    /// —тавит игру на паузу заморажива€ врем€
    /// </summary>
    public void Pause()
    {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            pauseMenuUI.SetActive(true);
            GameUi.SetActive(false);
            Time.timeScale = 0f;
            GameIsPaused = true;
    }
    /// <summary>
    /// по повторному нажатию esc или нажатию по кнопке resume продолжает игру
    /// </summary>
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        settingsMenuUI.SetActive(false);
        GameUi.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    /// <summary>
    ///  аждый кадр игра провер€ет нажата ли пауза и вызывает меню паузы если да
    /// </summary>
    public void Update()
    {
        if (MainCam.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (GameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }
    }
}
