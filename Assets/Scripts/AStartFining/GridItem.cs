using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public enum ItemType
{
    Normal,
    Start,
    End,
    Obstacle
}
public class GridItem : MonoBehaviour , IComparable<GridItem>
{
    private MeshRenderer _meshRenderer;

    //grid位置
    public int x;
    public int y;
    /// <summary>
    /// grid类型
    /// </summary>
    public ItemType type;

    //F = G + H
    public int F;
    public int G;
    public int H;

    /// <summary>
    /// 发现者
    /// </summary>
    public GridItem parent;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    public void SetColor(Color color)
    {
        _meshRenderer.material.color = color;
    }
    
    public void SetItemType(ItemType itemType)
    {
        switch (itemType)
        {
            case ItemType.Normal:
                type = ItemType.Normal;
                break;
            case ItemType.Obstacle:
                SetColor(Color.blue);
                type = ItemType.Obstacle;
                break;
            case ItemType.Start:
                SetColor(Color.green);
                type = ItemType.Start;
                break;
            case ItemType.End:
                SetColor(Color.red);
                type = ItemType.End;
                break;
        }
    }


    public int CompareTo(GridItem other)
    {
        if (F < other.F)
            return -1;
        
        if (F > other.F)
            return 1;
        
        return 0;
    }
}
