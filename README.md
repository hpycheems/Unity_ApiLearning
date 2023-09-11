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



## Quaternion类

### 实例属性

eulerAngles 属性：欧拉角

Vector3 eulerAngles {get ；set；}

用来返回或设置Quaternion实例对应的欧拉角

- 对GameObject对象的Transform进行欧拉角的变换次序是，先绕z轴旋转相应的角度，再绕x轴旋转相应的角度，最后再绕y轴旋转相应的角度。不同的旋转次序得到的最终态是不同的。
- 对GameObject对象的旋转进行赋值的方式通常有两种：将Quaternion实例赋值给transfrom的rotation，将三维向量代表的欧拉角直接赋值给transform的eulerAngles

### 实例方法

SetFromToRotation方法：创建rotation实例

void SetFromToRotation（Vector3 fromDirection， Vector3 toDirection）；

用于创建一个从fromDirection到toDirection的rotation。



SetLockRotation 方法：设置Quaternion实例的朝向

public void SetLookRotation(Vector3 view);

public void SetLookRotation(Vector3 view, vector3 Up);

Quaternion q1 = Quaternion.identity

q1.SetLookRotation(v1,v2);

transfrom.rotation = q1;

- transform.forward方向与v1方向相同
- transform.right 垂直于由Vector3.zero、v1和v2这3个点构成的平面
- v2除了与Vector3.zero和v1构成平面来决定transform.right的方向外，还用来决定transform.up的朝向，



ToAngleAxis 方法：Quaternion实例的角轴表示

public void ToAngleAxis（out float angle， out vector3 axis）

参数angle为旋转角，参数axis为轴向量



### 静态方法

Angle方法：Quaternion实例间夹角

public static float Angle(Quaternion a, Quaternion b);

返回从参数a到参数b变换的夹角。



Dot方法：点乘

public static float Dot（Quaternion a，Quaternion b）；





Euler方法：欧拉角对应的四元数

public static Quaternion Euler(Vector3 euler);

public static Quaternion Euler(float x,float y,float z);



FromToRotation 方法：创建一个从 fromDirection 旋转到 toDirection 的旋转。



Inverse方法：返回 rotation 的反转。



Lerp方法：线性插值

public static Quaternion Lerp（Quaternion from，Quaternion to，float t）



LookRotation方法：设置Quaternion的朝向

public static Quaternion LookRotation（Vector3 forward）

public static Quaternion LookRotation（Vector3 forward， Vector3 upwards）



Slerp方法：球面插值

public static Quaternion Slerp（Quaternion from，Quaternion to，float t）；



## Random类

### 静态属性

insideUnitCircle 属性：圆内随机点

返回一个半径为1的圆内的随机点坐标，返回值为Vector2类型



insideUnitSphere属性：返回一个半径为1的求内的随机点坐标，返回值为Vector3类型

onUnitSphere属性：返回一个半径为1的球面的随机点，返回值为Vecotr3类型



rotationUniform属性：均匀分布（随机数出现的概率是相等的）特征

返回一个随机其符合均匀分布特征的rotation值。

rotation属性只是产生一个随机的rotation值，不符合均匀分布特征



seed属性：随机数种子

用来设置随机数的种子，在计算机中产生随机数的方法有很多，但每种方法都需要一个种子。



value 返回介于 0.0 [含] 与 1.0 [含] 之间的随机数（只读）
<<<<<<< HEAD
=======



## RigidBody

### 实例属性

collisionDetectionMode属性：碰撞检测模式

用于设置刚体的碰撞检测模式

- Discrete：静态离散检查模式，为系统的默认设置。
- Continuous：静态连续检测模式，一般用在高速运动刚体的目标碰撞体上，防止被穿越，检测强度比Discrete强
- ContinuousDynamic：最强的连续动态检测模式



drag 属性：刚体阻力

用于给刚体添加一个阻力，drag值越大刚体速度减慢得越快。当drag>0时，刚体在增加到一定速度后会匀速运动。

```
刚体在自由落体运动中的最大速度值只与Gravity和drag值有关，与质量Mass无关。
```





inertiaTensor属性：惯性张量

用于设置刚体的惯性张量。在距离重心同等的条件下，刚体会向张量值大的一边倾斜。



mass属性：刚体质量

用于设置或返回刚体的质量。一般刚体质量取值在0.1附近模拟最佳，最大不要超过10，否则容易出现出模拟不稳定的情况。

- 对于自由落体运动，物体的速度只与重力加速度Gravity和空气阻力drag有关，与质量mass无关。
- mass的主要作用是在物体发生碰撞时计算碰撞后物体的速度。当一个物体分别去撞击mass大的物体和mass小的物体时，根据动量守恒定律，较重的物体被碰撞后的速度要慢于较轻的物体。





velocity属性：刚体速度

用于设置或返回刚体的速度值

- 在脚本中无论是给刚体赋予一个Verctor3类型的速度向量v，还是获取当前刚体速度v，v的方向都是相对世界坐标而言的。
- velocity的单位是米每秒，而不是帧每秒，其中米是Unity默认的长度单位。



### 实例方法

AddExplosionForce方法：模拟爆炸力

public void AddExplosionForce（float explosionForce， Vector3 explosionPosition， float explosionRadius）

public void AddExplosionForce（float explosionForce， Vector3 explosionPosition， float explosionRadius， float upwardsModifier）

public void AddExplosionForce（float explosionForce， Vector3 explosionPosition， float explosionRadius， float upwardsModifier， ForceMode mode）

参数explosionForce为爆炸点施加的力的大小，参数explosionPosition为爆炸点坐标（相对世界坐标），参数explosionRadius为爆炸作用力有效半径，参数upwardsModifier为爆炸力作用点在y轴方向上的偏移，参数mode为爆炸力的作用模式，默认为ForceMode .Force



AddForceAtPosition方法：增加刚体点作用力

public void AddForceAtPosition(Vector3 force, Vector3 position);

public void AddForceAtPosition(Vector3 force, Vector3 position, ForceMode mode);

参数force为扭矩向量，参数position为作用点坐标值，参数mode为力的作用方式

用于为参数position点增加一个力force，其参考坐标为世界坐标



AddTorque方法：刚体添加扭矩

public void AddTorque（Vector3 torque）；

public void AddTorque（Vector3 torque，ForceMode mode）；

public void AddTorque（float x, float y, float z）；

public void AddTorque（float x, float y, float z, ForceMode mode）；

参数torque为扭矩向量，参数mode为力的作用方式



ClosestPointOnBounds方法：爆炸点到刚体最短距离

public Vector3 ColosestPointOnBounds（Vector3 position）；

参数position为爆炸点坐标

用于求爆炸点到刚体Collider表面的作用点。



GetPointVelocity方法：刚体点速度

参数worldPoint为世界坐标系中的点坐标

用于获取世界坐标系中worldPoint点在刚体坐标系中的速度。



GetRelativePointVelocity方法：刚体点相对速度

public void GetRelativePointVelocity（Vector3 relativePoint）

参数relativePoint为刚体自身坐标系中的点坐标



MovePosition方法：刚体位置移动

public void MovePosition（Vector3 position）；

参数position为刚体组件要移动到的位置坐标



Sleep方法：刚体休眠

使刚体进入休眠状态，至少休眠一帧



SweepTest方法：检测碰撞器

public bool SweepTest（Vector3 direction， out RaycastHit hitInfo）；

public bool SweepTest（Vector3 direction， out RaycastHit hitInfo，float distance）；

direction为探测方向，参数distance为有效检测距离，默认为无穷大。

用于检测在刚体的direction方向是否有碰撞器对象，且对象有效探测距离不大于distance。



SweepTestAll方法：检测碰撞器，返回所有的碰撞器



WakeUp方法：唤醒刚体

用于将休从眠状态唤醒



### 一些属性

- useGravity属性用来确定刚体是否接收重力加速度的感应
- isKinematic属性用来确定刚体是否接受动力模拟



###  OnTriggerXXX 、OnCollisionXXX

OnTriggerEnter、Exit 、Stay

OnCollisionEnter、Exit、Stay



## Time类

### 静态属性

realtimeSinceStartup属性：程序运行实时时间

返回从游戏启动到现在已经运行的实时时间。



smoothDeltaTime 属性：平滑时间间隔

用于返回Time.deltaTime的平滑输出值



time属性：程序运行时间

返回从游戏启动到现在的运行时间

### 其他属性介绍

- captureFramerate属性：用于设置或返回帧速率的值

- dealtaTime属性：用于返回从上一帧到现在所经历的时间
- fixedDeltaTime属性：返回以固定帧率跟新时，相邻两帧的时间间隔
- fixedTime属性：返回从游戏启动到现在以固定帧率更新的时间
- framCount属性：返回从游戏启动到现在已经更新的帧率总数
- maximumDeltaTime属性：设置或返回每帧更新可以消耗的最大时间
- timeScale属性：用于控制时间的流逝速度，默认为1
- timeSinceLevelLoad属性：用于返回从最后关卡加载完成到现在所经历的时间

<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> develop


## Transform类

Transform实现了IEnumerable接口，可以在程序中使用foreach方法快速遍历子物体的Transform结构

### 实例属性

eulerAngles属性：欧拉角

返回或设置GameObject对象的欧拉角

- Unity中使用四元数来存储和表示GameObject的旋转角度，无论是在Inspector面板中对Rotation设置了怎么样的数值，还是在脚本中对transform.eulerAngles赋予了怎么样的值，程序在编译运行时都会把它们转换成Quaternion类型再计算。
- 只能对transform.eulerAngles进行整体赋值
- transform.eulerAngles.x返回值的范围为[0，90]和[270 360];y和z返回值的范围为[0,360]
- 相对世界坐标
- 旋转顺序zxy





forward属性：z轴单位向量

用于返回或设置transform自身坐标系中z轴方向的单位向量对应的世界坐标系中的单位向量。transform.forward即为transform.TransformDirection(new Vector3(0,0,1))的简化方式



hasChanged属性：transform组件是否被修改

判断GameObject对象从上次将此属性设为false依赖，transform组件的属性是否被修改过。



localPosition属性：局部坐标系位置

用于设置或返回GameObject对象在局部坐标系中的位置，若无父级对象则和属性Transform.position返回值相同。transform.localPosition的值受父级对象lossyScale的影响，当transform.localPosition的值增加1时，transform.position值的增量不一定是一，而是相对父级坐标系中增加了父级的lossyScale倍大小的值。



localToWorldMatrix属性：转换矩阵

返回从transform局部坐标系向世界坐标系转换的Matrix4x4矩阵



parent属性：父物体Transform实例

返回父物体的Transform实例



worldToLocalMatrix属性

返回从世界坐标向transform自身坐标系转换的Matrix4x4矩阵。



### 实例方法

DetachChildren方法：分离物体层级关系

使GameObject对象的所有子物体和自身分离层级关系



GetChild方法：获取GameObject对象子类

index为子物体索引值

参数index的值要小于transform的childCount值



InverseTransformDirection方法：坐标系转换

public Vector3 InverseTransformDirection(Vector3 direction);

public Vector3 InverseTransformDirection(float x,float y,float z);

参数direction为待转换的向量

将参数direction 从世界坐标系转换到GameObject对象的局部坐标系。



InversTransformPoint方法：点的相对坐标系向量

public Vector3 InverseTransformPoint（Vector3 position）

public Vector3 InverseTransformPoint（float x,float y,float z）

返回参数position向量相对于GameObject对象局部坐标系的差向量，返回向量position和向量transform.position的差值。



IsChildOf方法：是否为子物体

public bool IsChildOf（Transform parent）；

参数parent为父物体的Transform实例

用于判断transform对应的Gameobject对象是否为参数parent的子物体。



LookAt方法：物体朝向

public void LookAt（Transform target）；

public void LookAt（Vector3 worldPosition）；

public void LookAt（Transform target，Vector3 worldUp）；

public void LookAt（Vector3 worldPosition，Vector3 worldUp）；

参数target为transform自身坐标系中z轴指向的目标，参数worldUp为transform组自身坐标系中y轴最大限度指向的方向。

使GameObject对象自身坐标系中的z轴指向target，y轴方向最大限度地指向worldUp方向。worldUp指的是世界坐标系中的方向。此方法通常被用在Camera上，使得Camera的Transform看向目标target。





Rotate方法：绕坐标轴旋转

public void Rotate（Vector3 eulerAngles）；

public void Rotate（Vector3 eulerAngles，Space relativeTo）；

public void Rotate（float xAngle，float yAngle，float zAngle）；

public void Rotate（float xAngle，float yAngle，float zAngle，Space relativeTo ）；

参数eulerAngles为transform要旋转的欧拉角，参数relativeTo为transform旋转时参考的坐标系，默认为Space.Self

使transform实例在相对参数relativeTo的坐标系中旋转欧拉角eulerAngles



Rotate方法：绕某个向量旋转

public void Rotate（Vector3 axis， float angle）；

public void Rotate（Vector3 axis， float angle， Space relativeTo）；

axis为旋转轴方向，参数angle为旋转角度，参数relativeTo为参考坐标系

GameObject对象在relativeTo坐标系中绕轴向量axis旋转angle度。



RotateAround方法：绕轴点旋转

public void RotateAround（Vector3 axis，float angle）；

public void RotateAround（Vector3 point，Vector3 axis， float angle）；

point为参考点坐标，参数axis为旋转轴方向，参数algle为旋转角度。





TransformDirection方法：坐标系转换

public Vector3 TransformDirection（Vector3 direction）；

public Vector3 TransformDirection（float x,float y,float z）;

将向量direction从transform局部坐标系转换到世界坐标系。



TransformPoint方法：点的世界坐标位置

public Vector3 TransformPoint（Vector3 position）

public Vector3 TransformDirection（float x,float y,float z）;

返回GameObject对象局部坐标系中向量position在世界坐标系中的位置。



Translate方法：相对坐标移动

public void Translate（Vector3 translation）；

public void Translate（Vector3 translation，Space relativeTo）；

public void Translate（float x,float y,float z）；

public void Translate（float x,float y,float z，Space relativeTo）；

参数transform为移动向量，包括方向和大小，参数relativeTo为参考坐标系空间，默认为Space.Self.



public void Translate(Vector3 translation, Transform relativeTo);

public void Translate(float x,float y,float z, Transform relativeTo);

参数transform为移动向量，包括方向和大小，参数relativeTo为参考坐标系空间，默认为Space.World.



## Vector3 类
