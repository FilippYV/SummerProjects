using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockProperties : MonoBehaviour
{
    public string blockType;
    public string resources;
    public string status;

    private Renderer blockRenderer;

    private void Start()
    {
        blockRenderer = GetComponent<Renderer>();

        UpdateBlockColor();
        // Дополнительная логика для настройки блока
    }

    private void UpdateBlockColor()
    {
        Color blockColor = Color.gray; // Цвет по умолчанию

        if (blockType == "grow")
        {
            blockColor = Color.green;
        }
        else if (blockType == "water")
        {
            blockColor = Color.blue;
        }

        blockRenderer.material.color = blockColor;
    }
}