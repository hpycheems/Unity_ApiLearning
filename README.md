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



## HideFlags类

HideFlags类为枚举类，用于控制Object对象的销毁方式及其在检视面板中道德可视性。

DontSave：保留对象到心场景

```
此属性的功能是用来设置是否将Object对象保留到新的场景中，如果使用HideFlags.DontSave,则Object对象将在新场景中被存储下来
```

- 如果GameObject对象被HideFlags.DontSave标识，则在新Scene中GameObject的所有组件将被保留下来，但其子类GameObject对象不会被保留到新Scene中。
- 不可以对GameObject对象的某个组件如Transform进行HideFlags.DontSave标识，否则无效
- 即使程序已经退出，被HideFlags.DontSave标识的对象也会一直存在与程序中，造成内存泄漏，对HideFlags.DontSave标识的对象，在不需要或程序退出时需要使用DestoryImmediate手动销毁。



HideAndDontSave：保留对象到新场景

用来设置是否将Object对象保留到新Scene中，如果使用HideFlags.HideAndDontSave，则Object对象将在新Scene中被保留下来，但不会显示在Hierarchy面板中。



HideInHierarchy:在Hierarchy面板中隐藏

设置Object对象在Hierarchy面板中是否隐藏。

- 若要在Hierarchy面板中隐藏不是在脚本中创建的对象，需要在Awake方法中使用HideFlags.HideInHierarchy才能生效。
- 若隐藏父物体，子物体也会被隐藏掉，但隐藏子物体，父物体不会被影响。



HideInInspector：在Inspector面板中隐藏

- 如果一个GameObject使用了HideFlags.HideInInspector，则其所有组件将在Inspector面板中被隐藏，但其子类带对象的组件仍可在Inspector面板中显示。
- 如果只隐藏了GameObject对象的某个组件，如Transfrom，则并不影响GameObject的其他组件在Inspector面板中的显示状态。



None：HideFlags默认值

不改变Object对象的可见性。

## Mathf类

### 静态字段

Deg2Rad 度到弧度换算常量（只读）

其值为（2 * Mathf.PI） / 360 = 0.01745329

Infinity 正无穷大的表示形式（只读）

### 静态方法

Abs 返回f的绝对值

Clamp方法：在给定的最小浮点值和最大浮点值之间钳制给定值。如果在最小和最大范围内，则返回给定值

Clamp01：将值限制在 0 与 1 之间并返回值。

ClosetPowerOfTwo 返回最接近的 2 的幂值。



DeltaAngle方法：最小增量角度

float DeltaAngle（float current， float target）

其中参数current为当前角度，参数target为目标角度![image-20230905093752670](Imag\image-20230905093752670.png)



InverseLerp方法：计算比例值

float InverseLerp（float from，float to， float value）；

from为起始值，参数to为终点值，参数value为参考值

用来返回value值在从参数from到to中的比例值。



Lerp方法：线性插值

float Lerp（float from， float to， float t）；

参数from为线性插值的起始值，参数to为线性插值的结束值，参数t为插值系数

用来返回一个从from到to范围的线性插值



LerpAngle方法：角度插值

float LerpAngle（float a ， float b， float t）

参数a为起始角度，参数b为结束角度，参数t为插值系数

用来返回从角度a到角度b之间的一个插值。



MoveToWorlds方法：选择性插值

float MoveToWorlds（float current， float target， float maxDelta）

参数current为当前值，参数target为目标值，参数maxDelta为最大约束值。

返回一个从current到target之间的插值，返回值受maxDelta值得约束



MoveToWorldsAngle方法：角度得选择性插值



PingPong方法：往复运动

float PingPong（float t, float lenght）；



Repeat方法：取模运算

float Repeat（float t，float length）；

对值 t 进行循环，使它不会大于长度，并且不会小于 0。



Round方法：浮点数得整型值

float Round（float f）



SmoothDamp方法：模拟阻尼运动



SmoothDampAngle 随时间推移将以度为单位给定的角度逐渐改变为所需目标角度。

SmoothStep 在 min 与 max 之间进行插值，在限制处进行平滑。





## Object类

Object类是Unity中所有对象的基类

### 实例方法

GetInstancelD方法：Object对象ID

public int GetInstaancelD();

返回Object对象的实例化ID

- 每个Object都有一个唯一的ID（int类型）。并且从程序开始运行到结束，除非对象被销毁，否则每个实例对应的ID都不会改变。
- 从GameObject.CreatePrimitive()或Object.Instantiate()中创建出来的对象都有唯一ID

### 静态方法

Destroy 方法:销毁对象

public static void Destroy(Object obj);

public static void Destroy(Object obj, float t);

其中参数obj为待销毁的对象，参数t为销毁延迟时间，默认为0

功能：在执行完本方法t秒后销毁obj对象

```
近似的方法有DestroyImmediate和DestroyObject。方法DestroyImmediate可以立即销毁某个Object对象及其在Assets中的资源文件。
```



DontDestroyOnLoad方法：新场景中保留对象

public static void DontDestroyOnLoad(Object target);

参数target为被保留的对象



FindObjectOfType方法:获取对象

public static T[] FindObjectOfType<T>() where T : Object;

public static Object[] FindObjectOfType(Type type);

参数target为要获取的对象类型，可以是GameObject类型或Component类型。





Instantiate方法:实例化对象

public static Object Instantiate(Object original);

public static Object Instantiate(Object original, Vector3 position, Quaternion rotation);

参数original为实例化对象的类型，参数position为实例化对象的位置，参数rotation为实例化对象的旋转角度。
