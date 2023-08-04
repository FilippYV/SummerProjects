using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;



/// <summary>
/// ������ ����� ����������� �������������� ������������ � ���� �����
/// </summary>
public class Pausemenu : MonoBehaviour
{
    public static bool GameIsPaused = false;


    public GameObject MainCam;
    public GameObject pauseMenuUI;
    public GameObject settingsMenuUI;
    /// <summary>
    /// ����� � ������� ����
    /// </summary>
    public void SaveAndQuit()
    {
        SceneManager.LoadScene("Main menu");
    }
    /// <summary>
    /// ������ ���� �� ����� ����������� �����
    /// </summary>
    public void Pause()
    {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
    }
    /// <summary>
    /// �� ���������� ������� esc ��� ������� �� ������ resume ���������� ����
    /// </summary>
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        settingsMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    /// <summary>
    /// ������ ���� ���� ��������� ������ �� ����� � �������� ���� ����� ���� ��
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
