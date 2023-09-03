using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class AStar : MonoBehaviour
{
    /// <summary>
    /// grid 预设体
    /// </summary>
    public GameObject cubePrefab;
    /// <summary>
    /// grid的大小
    /// </summary>
    public float cubeLength = 0.5f;
    /// <summary>
    /// grid与地形的比例
    /// </summary>
    public int gridScale = 10;
    
    /// <summary>
    /// 地形的长度
    /// </summary>
    public int gridLenght;
    /// <summary>
    /// 地形的宽度
    /// </summary>
    public int gridWidth;

    //起点位置
    public int startX;
    public int startY;
    //终点位置
    public int endX;
    public int endY;

    [Range(0,100)]
    public float ObstaclePercent;//障碍物出现概率
    //grid列表
    private GridItem[,] gridItems;


    /// <summary>
    /// 存储待计算的grid
    /// </summary>
    private List<GridItem> openList;
    /// <summary>
    /// 存储所有发现者
    /// </summary>
    private List<GridItem> closeList;
    /// <summary>
    /// 路径回溯栈
    /// </summary>
    private Stack<GridItem> pathStack;
    
    private int pathCount;
    
    private void Start()
    {
        GridInit();
        AStarPathFinding();
    }

    void GridInit()
    {
        gridLenght = (int)(transform.localScale.z * gridScale / cubeLength);
        gridWidth = (int)(transform.localScale.x * gridScale / cubeLength);
        gridItems = new GridItem[gridLenght, gridWidth];
        pathStack = new Stack<GridItem>();

        //地形偏移量
        Vector3 gridOffset = new Vector3(-gridScale * .5f * transform.localScale.x, 0,
            -gridScale * .5f * transform.localScale.z);
        //grid自身偏移量
        Vector3 cubeOffset = new Vector3(cubeLength * .5f, 0, cubeLength * .5f);
        
        for (int i = 0; i < gridLenght; i++)
        {
            for (int j = 0; j < gridWidth; j++)
            {
                //实例化grid
                GameObject cube = Instantiate(cubePrefab, new Vector3(i * cubeLength, 0, j * cubeLength)
                    + gridOffset + cubeOffset, Quaternion.identity);
                //设置父级
                cube.transform.SetParent(transform);
                //获取grid对象
                GridItem gridItem = cube.GetComponent<GridItem>();
                //添加到grid列表
                gridItems[i, j] = gridItem;
                //设置grid位置
                gridItem.x = i;
                gridItem.y = j;
                //随机生成障碍物
                int ran = Random.Range(1, 101);
                if(ran <= ObstaclePercent)
                    gridItem.SetItemType(ItemType.Obstacle);
            }
        }
        
        //设置起点 终点
        try
        {
            gridItems[startX, startY].SetItemType(ItemType.Start);
            gridItems[endX, endY].SetItemType(ItemType.End);
        }
        catch (Exception e)
        {
            startX = 0;
            startY = 0;
            endX = gridLenght - 1;
            endY = gridWidth - 1;
            gridItems[startX, startY].SetItemType(ItemType.Start);
            gridItems[endX, endY].SetItemType(ItemType.End);
            
        }
    }

    void AStarPathFinding()
    {
        openList = new List<GridItem>();
        closeList = new List<GridItem>();
        //将起点放入到带计算列表
        openList.Add(gridItems[startX, startY]);
        //开启循环
        while (true)
        {
            //按照开放列表中元素的F值来排序
            openList.Sort();
            //获取F值最小的grid
            GridItem center = openList[0];
            //如果当前中心grid是终点
            if (center.type == ItemType.End)
            {
                //TODO：回溯
                GeneratePath(center);
                break;
            }
            
            //以中心格子去发现周围8个格子
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    //排除自身
                    if (j == 0 && i == 0)
                        continue;
                    int x = center.x + i;
                    int y = center.y + j;
                    //越界
                    if(x < 0 || x > gridLenght - 1)
                        continue;
                    if(y < 0 || y > gridWidth -1)
                        continue;

                    //记录当前格子
                    GridItem crtItem = gridItems[x, y];
                    //如果是障碍物 则跳过
                    if(crtItem.type == ItemType.Obstacle)
                        continue;
                    //跳过发现者
                    if(closeList.Contains(gridItems[x, y]))
                        continue;
                    
                    int G = CountOffsetG(i, j) + center.G;
                    if (crtItem.G == 0 || crtItem.G > G)
                    {
                        crtItem.G = G;
                        crtItem.parent = center;
                        int H = CountH(x, y);
                        crtItem.H = H;
                        crtItem.F = H + G;
                    }

                    if (!openList.Contains(crtItem))
                    {
                        openList.Add(crtItem);
                    }
                }
            }

            openList.Remove(center);
            closeList.Add(center);
            if (openList.Count <= 0)
            {
                Debug.Log("无法找到路径");
                return;
            }
        }
    }
    
    //路径回溯
    void GeneratePath(GridItem grid)
    {
        pathStack.Push(grid);
        if (grid.parent != null)
        {
            GeneratePath(grid.parent);
        }
        else
        {
            pathCount = pathStack.Count;
            StartCoroutine( ShowPath());
            //找到起点
            //生成路径
        }
    }

    IEnumerator ShowPath()
    {
        while (pathStack.Count > 0)
        {
            GridItem grid = pathStack.Pop();
            yield return new WaitForSeconds(.2f);
            if (grid.type == ItemType.Normal)
                grid.SetColor(Color.Lerp(Color.green, Color.red, (float)(pathCount - pathStack.Count) / pathCount));
        }
    }
    /// <summary>
    /// 计算H值
    /// </summary>
    /// <param Name="x"></param>
    /// <param Name="y"></param>
    /// <returns></returns>
    int CountH(int x, int y)
    {
        int newX = x - endX;
        newX = newX > 0 ? newX : -newX;
        
        int newY = x - endX;
        newY = newY > 0 ? newY : -newY;

        return 10 * (newX + newY);
    }
    /// <summary>
    /// 计算G值 i，y为【-1-1】之间的整数
    /// </summary>
    /// <param Name="i"></param>
    /// <param Name="j"></param>
    /// <returns></returns>
    int CountOffsetG(int i, int j)
    {
        if (i == 0 || j == 0)
            return 10;
        return 14;
    }
}
