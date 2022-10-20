using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenToTexture : MonoBehaviour
{
    [SerializeField] private List<MeshRenderer> _meshes = new List<MeshRenderer>();
    [SerializeField] private Material _defaultMaterial;
    [SerializeField] private Material _screenMaterial;
    [SerializeField] private Camera _camera;
    private bool _firstTrigger;

    private void Awake()
    {
        _firstTrigger = false;
        _meshes.Clear();
        MeshRenderer[] meshes = FindObjectsOfType<MeshRenderer>();
        foreach (MeshRenderer r in meshes) 
        {
            if(r.tag == "World")
                _meshes.Add(r);
        }
        foreach (MeshRenderer r in _meshes) 
        {
            r.material = _defaultMaterial;
        }
    }

    public void CaptureTexture() 
    {
        _camera.Render();
        if (!_firstTrigger) 
        {
            _firstTrigger = true;
            foreach (MeshRenderer r in _meshes) 
            {
                r.material = _screenMaterial;
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            CaptureTexture();
        }
    }
}
