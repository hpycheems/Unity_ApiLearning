using System;
using UnityEngine;

public class CameraExample : MonoBehaviour
{
    private Camera _camera;
    public Cubemap renderToCubemap;
    public Shader Shader;

    public RenderBuffer colorBuffer;
    public RenderBuffer depthBuffer;
    void Start()
    {
        #region 实例属性

        _camera = Camera.main;
        
        Debug.Log(_camera.actualRenderingPath.ToString());
        Debug.Log(_camera.aspect);
        Debug.Log(_camera.cameraToWorldMatrix);
        Debug.Log(_camera.cullingMask);
        _camera.cullingMask = -1;

        //_camera.eventMask = 0;
        Debug.Log(_camera.eventMask);

        Debug.Log(_camera.worldToCameraMatrix);

        RenderTexture renderTexture = _camera.targetTexture;
        if(renderTexture != null)
            Debug.Log(renderTexture.width + " " + renderTexture.height);

        Debug.Log(_camera.rect);

        Debug.Log(_camera.projectionMatrix);
        Debug.Log(_camera.pixelRect);

        Debug.Log(_camera.orthographic);

        #endregion

        #region 实例方法

        _camera.RenderToCubemap(renderToCubemap);
        _camera.RenderWithShader(Shader, "");
    
        //_camera.SetTargetBuffers(colorBuffer, depthBuffer);

        Debug.Log( _camera.ScreenToWorldPoint(new Vector3(0, 0, 0)));

        

        #endregion


        Debug.Log("Start \n =======================================");
    }

    private void Update()
    {
        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            //Debug.Log(hit.collider.name);
        }

        ray = _camera.ViewportPointToRay(new Vector3(0.5f, 0.4f, 0));
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.collider.name);
        }
        
        //Debug.Log(Input.mousePosition);
        //Debug.Log( _camera.ScreenToViewportPoint(Input.mousePosition));
        
        Debug .Log( "World To Screen :"+_camera.WorldToScreenPoint(transform.position));
    }

    //鼠标进入物体
    private void OnMouseEnter()
    {
        Debug.Log("Mouse Enter Object");
    }

    private void OnMouseExit()
    {
        Debug.Log("Mouse Exit Object");
    }

    private void OnMouseDrag()
    {
        
    }
}
