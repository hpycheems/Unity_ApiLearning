# A*

![image-20230824092946667](image-20230824092946667.png)

F = G + H

起点的估量代价（G） ： 勾股定理 

![image-20230824093636775](C:\Users\Lenovo\Desktop\系统学习\进阶\image-20230824093636775.png)

最开始，以起点为中心开始计算周边的八个格子，然后在以这算出来的八个格子为中心，继续计算他们周围的八个格子的G值。依此类推，直到找到终点，或遍历完所有的格子，G值的计算结果为：中心点的G值 + 距离值【10

【10 or 14】

![image-20230824100230042](C:\Users\Lenovo\AppData\Roaming\Typora\typora-user-images\image-20230824100230042.png)

开放表格（OpenList）

关闭表格 （CloseList， 中心center）

回退找到最优路径

**寻路步骤**

1. 设置开放列表`OpenList`和关闭列表`CloseList`
2. 将起点放置到`OpenList`
3. 开启循环While(OpenList.count > 0)
   1.  将OpenList排序【F值从小到大】
   2. OpenList[0]必定是F值最小的，命名为center
      1. 发现center就是终点，回溯找到导航路径
   3. 以这个点为中心，去发现它周围的8个格子
   4. 计算发现的每个格子G H F三个值
   5. 如果这个格子没有别计算过或原来G值，比这次计算出来的G要大
      1. 此时，设置新的FGH值给这个格子，并设置该格子的发现者是Center
   6. 如果这个格子被计算过，且原G值，比这次计算出来的G值要小
      1. 此时，就不能替换原来FGH值
   7. 将发现的每个格子放入到OpenList
      1. 放入的时候要检测[该格子不在OpenList、该格子不在CloseList]
   8. 将此次循环的发现者Center放入到CloseList
   9. 判断OpenList是否空
      1. 空了，说明所有可发现的格子都被遍历过了，始终没有找到终点，说明无法到达终点。



终点的估量代价 (H)： 数格子 无视障碍物