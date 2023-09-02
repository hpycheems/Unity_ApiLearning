# Unity API

## Application类

### 静态属性

dataPath 包含游戏数据文件夹的路径 //E:/work/Unity_ApiLearning/Assets



isEditor 是否在Unity Eidtor内运行

isPlaying 在任何类型的已构建播放器中调用时，或者在播放模式的编辑器中调用时，返回 true



persistentDataPath 包含持久数据目录的路径 

//C:/Users/Administrator/AppData/LocalLow/DefaultCompany/UnityAPILeaning



streamingAssetsPath StreamingAssets 文件夹的路径

//E:/ work / Unity_ApiLearning / Assets / StreamingAssets



temporaryCachePath 包含临时数据/缓存目录的路径

C:/Users/ADMINI~1/AppData/Local/Temp/DefaultCompany/UnityAPILeaning



targetFrameRate 指示游戏尝试以指定的帧率渲染

### 静态方法

Quit() 退出播放器应用程序。

**编辑器模式下退出**

UnityEditor.EditorApplication.isPlaing = false;

## Camera

### 实例属性

actualRenderingPath 当前正在使用的渲染路径

渲染路径：Forward（前向）、Deferred（延迟）、VertexLit(顶点照明)

aspect 屏幕宽高比

cameraToWorldMatrix 摄像机空间到世界空间的变换矩阵

cullingMask 用于选择性的渲染场景的某些部分

depth 摄像机在摄像机渲染顺序中的深度

eventMask 用于选择哪些层可以在摄像机上触发事件的遮罩。

```c#
//前提，物体必须存在碰撞体组件
OnMouseEnter();
OnMouseUp();
OnMouseDown();
OnMouseDrag();
OnMouseExit();
OnMouseOverr();
```

farClipPlane 远裁剪平面

fieldOfView 摄像机的视野（以度为单位）

nearClipPlane 近裁剪平面

renderingPath 应尽可能使用的渲染路径

worldToCameraMatrix 

targetTexture  目标渲染纹理

rect 摄像机在屏幕上的渲染位置（Viewport Recr属性）

projectionMatrix 设置自定义投影矩阵

pixelRect 摄像机在屏幕上的渲染位置（像素位置）

orthographic 此为正交摄像机 (true) 还是透视摄像机 (false)

layerCullDistance 每层剔除距离。

### 实例方法

RenderToCubemap 从该摄像机渲染到一个静态立方体贴图。

RenderWithShader 使用其他shader渲染

ScreenPointToRay 返回从摄像机通过屏幕点的光线

ScreenToViewportPoint 将 position 从屏幕空间变换为视口空间

```
Screen 是以像素为单位的
Viewport 是标准化的 [-1, 1] 左下角为0，0 右上角为 1，1
```

ScreenToWorldPoint 将 position 从屏幕空间变换为世界空间

SetTargetBuffer 将摄像机设置为渲染到一个或多个 RenderTexture 的选定缓冲区

WorldToScreenPoint 将 position 从世界空间变换为屏幕空间

WorldToViewportPoint 将 position 从世界空间变换为视口空间。
