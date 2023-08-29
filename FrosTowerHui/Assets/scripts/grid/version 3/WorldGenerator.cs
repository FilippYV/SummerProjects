using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WorldGenerator : MonoBehaviour
{
    public int worldWidth = 50;
    public int worldLength = 50;
    public float scale = 10f;
    public GameObject blockPrefab;

    private Dictionary<string, GameObject> blocksDictionary = new Dictionary<string, GameObject>();

    private void Start()
    {
        GenerateWorld();
    }

    private void GenerateWorld()
    {
        // Генерируем случайные смещения по X и Y для шумов Перлина
        float offsetX = Random.Range(0, 1000000); // Рандомное смещение по X
        float offsetY = Random.Range(0, 1000000); // Рандомное смещение по Y

        // Проходимся по координатам мира и создаем блоки
        for (int x = 0; x < worldWidth; x++)
        {
            for (int z = 0; z < worldLength; z++)
            {
                // Получаем значения шумов Перлина для типа блока и ресурсов
                float perlinValue = Mathf.PerlinNoise((float)(x + offsetX) / scale, (float)(z + offsetY) / scale);
                float resourcesX =
                    Mathf.PerlinNoise((float)(x + offsetX) / scale,
                        (float)(z + offsetY) / scale); // X смещение для ресурсов
                float resourcesY =
                    Mathf.PerlinNoise((float)(x + offsetY) / scale,
                        (float)(z + offsetX) / scale); // Y смещение для ресурсов

                // Создаем блок с заданными значениями
                CreateBlock(x, z, perlinValue, resourcesX, resourcesY);
            }
        }
    }

    private void CreateBlock(int x, int z, float perlinValue, float resourcesX, float resourcesY)
    {
        GameObject block = Instantiate(blockPrefab, new Vector3(x, 0, z), Quaternion.identity, transform);

        string blockType = GetBlockType(perlinValue);
        block.GetComponent<BlockProperties>().blockType = blockType;

        string resourcesType = GetResourcesType(resourcesX, resourcesY, blockType);
        block.GetComponent<BlockProperties>().resources = resourcesType;

        string status = GetBlockStatus(blockType, resourcesType); // Новая логика для определения status
        block.GetComponent<BlockProperties>().status = status;

        // Задаем имя блока и добавляем его в словарь
        string blockName = "Block_" + x + "_" + z;
        block.name = blockName;
        blocksDictionary[blockName] = block;

        // Дополнительная логика для настройки блока
    }

    private string GetBlockType(float perlinValue)
    {
        if (perlinValue >= 0f && perlinValue <= 0.15f)
        {
            return "water";
        }
        else if (perlinValue > 0.15f && perlinValue <= 1f)
        {
            return "grow";
        }

        // Если значение шума Перлина не находится в ожидаемых диапазонах, возвращаем "grow" (по умолчанию)
        Console.WriteLine(perlinValue);
        return "grow";
    }

    private string GetResourcesType(float resourcesX, float resourcesY, string blockType)
    {
        // Вычисляем значение ресурсов на основе шумов Перлина
        float resourcesValue = Mathf.PerlinNoise(resourcesX, resourcesY);

        if (blockType == "water")
        {
            // Если тип блока "water", то ресурсы зависят от значения шума Перлина
            if (resourcesValue < 0.5f)
            {
                return "stone";
            }
            else
            {
                return "metal";
            }
        }
        else
        {
            // Если тип блока не "water", то тип ресурсов зависит от значения шума Перлина
            if (resourcesValue >= 0f && resourcesValue <= 0.3f)
            {
                return "metal";
            }
            else if (resourcesValue > 0.3f && resourcesValue <= 0.6f)
            {
                return "wood";
            }
            else if (resourcesValue > 0.6f && resourcesValue <= 1f)
            {
                return "stone";
            }
        }

        // Если значение шума Перлина не находится в ожидаемых диапазонах, возвращаем "unknown" (по умолчанию)
        return "unknown";
    }
    
    private string GetBlockStatus(string blockType, string resourcesType)
    {
        if (blockType == "water")
        {
            return "unavailable"; // Вода делает блок недоступным
        }
        else
        {
            if (resourcesType == "metal")
            {
                return "available"; // Металлические блоки доступны
            }
            else
            {
                return "normal"; // Все остальные блоки имеют обычный статус
            }
        }
    }

    

    public GameObject GetBlockByName(string blockName)
    {
        // Получаем блок по имени из словаря
        if (blocksDictionary.ContainsKey(blockName))
        {
            return blocksDictionary[blockName];
        }

        return null;
    }
}