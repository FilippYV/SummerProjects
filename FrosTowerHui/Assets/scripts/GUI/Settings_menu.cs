using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using UnityEditor;
using UnityEngine.LowLevel;



/// <summary>
/// Данный класс обрабатывет взаимодействие пользователя с меню паузы
/// </summary>
public class Settings_menu : MonoBehaviour
{
    /// <summary>
    /// Привязка к созданным аудио микшерам юнити
    /// </summary>
    public AudioMixer VFXaudioMixer;
    public AudioMixer MusicaudioMixer;

    //public float xSensitivity;
    //public float ySensitivity;

    //public Dropdown resDropdown;
    /// <summary>
    /// Cсылка на кнопку с выпадающем меню
    /// </summary>
    public TMP_Dropdown resDropdown;
    Resolution[] resolutions;
    /// <summary>
    /// Метод вызывается при запуске игры, в нем мы передираем расширения экрана пользователя
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
    /// Смена расширения экрана
    /// </summary>
    /// <param name="resIndex"></param> id раcширения при переборе всех возможных
    public void SetResolution(int resIndex)
    {
        Resolution resolution = resolutions[resIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    /// <summary>
    /// Настройка громкости звуковых эффектов
    /// </summary>
    /// <param name="Vvolume"></param> Параметр громкости звуковых эффектов
    public void SetVFXVolume( float Vvolume)
    {
        VFXaudioMixer.SetFloat("Vvolume", Vvolume);
    }
    /// <summary>
    /// Настройка громкости музыки
    /// </summary>
    /// <param name="Mvolume"></param> Параметр громкости музыки
    public void SetMusicVolume(float Mvolume)
    {
        MusicaudioMixer.SetFloat("Mvolume", Mvolume);
    }
    /// <summary>
    /// Метод включающий или выключающий полноэкранный режим
    /// </summary>
    /// <param name="isFullscreen"></param> Параметр отвечающий за настройку полноэкранного режима
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    /// <summary>
    /// Настройка чувствительности через ползунки в настройках
    /// </summary>
    /// <param name="sens"></param> Параметр чувствительности
    public void SetSensitivity(float sens)
    {
        //GameObject go = GameObject.Find("Player");
        //PlayerLook playerLook = go.GetComponent<PlayerLook>();
        //playerLook.xSensitivity = sens;
        //playerLook.ySensitivity = sens;
    }
}