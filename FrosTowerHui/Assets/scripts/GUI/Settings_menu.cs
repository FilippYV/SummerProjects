using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using UnityEditor;
using UnityEngine.LowLevel;



/// <summary>
/// ������ ����� ����������� �������������� ������������ � ���� �����
/// </summary>
public class Settings_menu : MonoBehaviour
{
    /// <summary>
    /// �������� � ��������� ����� �������� �����
    /// </summary>
    public AudioMixer VFXaudioMixer;
    public AudioMixer MusicaudioMixer;

    //public float xSensitivity;
    //public float ySensitivity;

    //public Dropdown resDropdown;
    /// <summary>
    /// C����� �� ������ � ���������� ����
    /// </summary>
    public TMP_Dropdown resDropdown;
    Resolution[] resolutions;
    /// <summary>
    /// ����� ���������� ��� ������� ����, � ��� �� ���������� ���������� ������ ������������
    /// </summary>
    void Start()
    {
        


        resolutions = Screen.resolutions;
        resDropdown.ClearOptions();
        List<string> options = new List<string>();
        
        int currentResolutionIndex = 0;
        for (int i = 0;i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        
        resDropdown.AddOptions(options);
        resDropdown.value = currentResolutionIndex;
        resDropdown.RefreshShownValue();
    }
    /// <summary>
    /// ����� ���������� ������
    /// </summary>
    /// <param name="resIndex"></param> id ��c������� ��� �������� ���� ���������
    public void SetResolution(int resIndex)
    {
        Resolution resolution = resolutions[resIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    /// <summary>
    /// ��������� ��������� �������� ��������
    /// </summary>
    /// <param name="Vvolume"></param> �������� ��������� �������� ��������
    public void SetVFXVolume( float Vvolume)
    {
        VFXaudioMixer.SetFloat("Vvolume", Vvolume);
    }
    /// <summary>
    /// ��������� ��������� ������
    /// </summary>
    /// <param name="Mvolume"></param> �������� ��������� ������
    public void SetMusicVolume(float Mvolume)
    {
        MusicaudioMixer.SetFloat("Mvolume", Mvolume);
    }
    /// <summary>
    /// ����� ���������� ��� ����������� ������������� �����
    /// </summary>
    /// <param name="isFullscreen"></param> �������� ���������� �� ��������� �������������� ������
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    /// <summary>
    /// ��������� ���������������� ����� �������� � ����������
    /// </summary>
    /// <param name="sens"></param> �������� ����������������
    public void SetSensitivity(float sens)
    {
        //GameObject go = GameObject.Find("Player");
        //PlayerLook playerLook = go.GetComponent<PlayerLook>();
        //playerLook.xSensitivity = sens;
        //playerLook.ySensitivity = sens;
    }
}