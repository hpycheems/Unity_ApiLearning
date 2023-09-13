# Editor 

- **EditorWindow类**：用于创建自定义的编辑器窗口。通过继承EditorWindow类，可以实现自定义窗口的UI布局和功能，并响应用户的操作。
- **EditorGUI和EditorGUILayout类**：用于创建编辑器界面的控件。这些类提供了一系列方法，用于创建标签、按钮、文本框、滑动条等各种UI元素。
- **SerializedObject类和SerializedProperty类**：用于访问和修改Unity对象的序列化数据。通过SerializedObject类，可以获取目标对象的序列化数据，并通过SerializedProperty类对其中的属性进行访问和修改。
- **EditorGUIUtility类**：提供了一些编辑器工具函数，用于绘制纹理、图标、颜色选择器等。可以使用这些函数增加一些视觉效果和交互功能。
- **AssetDatabase类**：用于管理项目中的资源。可以通过AssetDatabase类进行资源的导入、导出、重命名等操作。
- **EditorStyles类**：提供了一系列预定义的样式，用于设置和修改编辑器界面中的元素样式。可以使用EditorStyles类设置按钮、标签、文本框等元素的样式。
- **MenuCommand类**：用于处理自定义菜单选项和工具栏按钮的点击事件。可以通过MenuCommand类获取当前操作的目标对象，并执行相应的操作。
- **SceneView类**：用于创建和管理场景视图。可以在场景视图中绘制图形、处理鼠标输入等。
- **Undo类**：用于实现撤销和重做功能。可以使用Undo类记录和回访编辑操作。
- **Callbacks类**：提供了一些回调函数，可以在特定事件发生时执行自定义的操作，如OnOpenAsset、OnSceneGUI等。