using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{

    public int stateId;

    public GameObject BaseCam;
    public GameObject StratCam;
    public GameObject TempCam;
    public GameObject ResCam;
    public GameObject DefCam;
    public GameObject HordCam;

    void Start()
    {
        BaseCam.SetActive(true);
        StratCam.SetActive(false);
        TempCam.SetActive(false);
        ResCam.SetActive(false);
        DefCam.SetActive(false);
        HordCam.SetActive(false);
        stateId = 0;
    }
    void Update()
    {
        ExitAllViewLayers();
    }

    public void ExitAllViewLayers()
    {
        if (Input.GetKey(KeyCode.Escape) & stateId !=0)
        {
            BaseCam.SetActive(true);
            StratCam.SetActive(false);
            TempCam.SetActive(false);
            ResCam.SetActive(false);
            DefCam.SetActive(false);
            HordCam.SetActive(false);
            stateId = 0;
        }
    }

    public void ExitAllViewLayersOnButton()
    {
        if (stateId != 0)
        {
            BaseCam.SetActive(true);
            StratCam.SetActive(false);
            TempCam.SetActive(false);
            ResCam.SetActive(false);
            DefCam.SetActive(false);
            HordCam.SetActive(false);
            stateId = 0;
        }
    }


    public void SetStratCamActive(bool stratButton)
    {
        if (stratButton)
        {
            BaseCam.SetActive(false);
            StratCam.SetActive(true);
            TempCam.SetActive(false);
            ResCam.SetActive(false);
            DefCam.SetActive(false);
            HordCam.SetActive(false);
            stateId = 1;

        }
    }


    public void SetTempCamActive(bool tempButton)
    {
        if(tempButton)
        {
            BaseCam.SetActive(false);
            StratCam.SetActive(false);
            TempCam.SetActive(true);
            ResCam.SetActive(false);
            DefCam.SetActive(false);
            HordCam.SetActive(false);
            stateId = 2;
        }
    }


    public void SetResCamActive(bool resButton)
    {
        if (resButton)
        {
            BaseCam.SetActive(false);
            StratCam.SetActive(false);
            TempCam.SetActive(false);
            ResCam.SetActive(true);
            DefCam.SetActive(false);
            HordCam.SetActive(false);
            stateId = 3;
        }
    }


    public void SetDefCamActive(bool defButton)
    {
        if (defButton)
        {
            BaseCam.SetActive(false);
            StratCam.SetActive(false);
            TempCam.SetActive(false);
            ResCam.SetActive(false);
            DefCam.SetActive(true);
            HordCam.SetActive(false);
            stateId = 4;
        }
    }


    public void SetHordCamActive(bool hordButton)
    {
        if (hordButton)
        {
            BaseCam.SetActive(false);
            StratCam.SetActive(false);
            TempCam.SetActive(false);
            ResCam.SetActive(false);
            DefCam.SetActive(false);
            HordCam.SetActive(true);
            stateId = 5;
        }
    }


}

