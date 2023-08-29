using UnityEngine;

public class BuildingBlocks : MonoBehaviour
{
    public Renderer MainRenderer;
    public Vector2Int Size = Vector2Int.one;
    public bool IsAvailable { get; private set; } = true; // Добавили флаг доступности

    public void SetTransparent(bool available)
    {
        IsAvailable = available; // Обновляем флаг доступности

        if (available)
        {
            MainRenderer.material.color = Color.green;
        }
        else
        {
            MainRenderer.material.color = Color.red;
        }
    }

    public void SetNormal()
    {
        IsAvailable = true; // Сбрасываем флаг доступности в нормальное состояние
        MainRenderer.material.color = Color.white;
    }

    // Удалите OnDrawGizmos, так как это не требуется для функционирования в вашем проекте
    
}