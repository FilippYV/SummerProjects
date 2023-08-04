using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




/// <summary>
/// Данный класс обрабатывет взаимодействие пользователя с главным меню
/// </summary>
public class Mainmenu : MonoBehaviour
{
    /// <summary>
    /// Этот метод загружает игру по нажатию кнопки Play
    /// </summary>
    public void PlayGame ()
    {
        SceneManager.LoadScene("GameplayZone");
    }
    /// <summary>
    /// Этот метод закрывает игру
    /// </summary>
    public void Exit ()
    {
        Application.Quit();
    }
}
