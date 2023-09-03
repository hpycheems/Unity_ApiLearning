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

## GameObject类

### 变量

activeSelf 次GameObject在本地活动状态

activeInHierarchy 定义GameObject在Scene中是否处于活动状态

```
activeSelf与activeInHierarchy的区别，activeInHierarchy属性的功能是返回GameObject实例在程序运行时的激活状态，它只有当GameObject实例的状态被激活时才会返回true。而且会受其父类对象激活状态的影响，如果其父类至最顶层的对象中有一个对象未被激活，activeInHierarchy就会返回false
```

layer 游戏对象所在的图层

tag 此游戏对象的标记

### 构造函数

public GameObject();

public GameObject(string name); 参数name为构造GameObject对象的名字

public GameObject(string name, params Type[] components);

components为构造对象要添加的组件类型集合，多个组件之间用逗号隔开。

## 公共函数

**GetComponent**

```c#
public T GetComponent<T>() where T: Component;
public Component GetComponent(string type);//type为组件名
public Component GetComponent(Type type);//type为组件类型
```

用于获取GameObject中第一个符合Type类型的Component

GetComponents<T>(); 获取对游戏对象上类型T的所有组件的引用

GetComponentInChildren<T>(); (即现在自身获取，如果获取不到则在子物体中获取)获取对指定游戏对象上类型 T 的组件或游戏对象的任何子级的引用

GetComponentsInChildren<T>();（当对象不是激活状态时，查找不到）获取指定游戏对象上类型T的所有组件以及游戏对象的任何子组件的引用

GetComponentInParent<T>(); 获取对指定游戏对象上 T 类型的组件或游戏对象的任何父级的引用。

GetComponentsInParent<T>(); 获取对指定游戏对象上类型 T 的所有组件以及游戏对象的任何父级的引用



SetActive 根据给定的值 true 或 /false/，激活/停用 GameObject。

TryGetCompoennt 尝试获取指定类型组件

**SendMessage**（不推荐使用，性能消耗大）

```c#
public void SendMessage(string methodName);
public void SendMessage(string methodName, object value);
public void SendMessage(string methodName, SendMessageOptions options);
public void SendMessage(string methodName, object value, SendMessageOptions options);
```

methodName为接受信息的方法名，参数value为信息的内容，参数options为信息的接收方式，默认为SendMessageOptions.RequireReceive.

功能：向GameObject自身发送消息，对其作用范围说明：

- 和自身同级的物体不会收到消息
- SendMessageOptions有两个可选方式：SendMessageOptions.RequireReceiver和SendMessageOptions.DontRequireReceiver。前者要求信息的接收方必须有接收信息的方法，否则程序会报错。

```c#
BroadcastMessage() 向自身及所有子类发送消息
SendMessageUpwards() 向GameObject自身及其所有父级发送消息
```

### 静态方法

CreatePrimitive() 创建具有基元网格渲染器和适当碰撞体的游戏对象

