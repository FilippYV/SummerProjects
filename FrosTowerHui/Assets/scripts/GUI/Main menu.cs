using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




/// <summary>
/// ������ ����� ����������� �������������� ������������ � ������� ����
/// </summary>
public class Mainmenu : MonoBehaviour
{
    /// <summary>
    /// ���� ����� ��������� ���� �� ������� ������ Play
    /// </summary>
    public void PlayGame ()
    {
        SceneManager.LoadScene("GameplayZone");
    }
    /// <summary>
    /// ���� ����� ��������� ����
    /// </summary>
    public void Exit ()
    {
        Application.Quit();
    }
}
