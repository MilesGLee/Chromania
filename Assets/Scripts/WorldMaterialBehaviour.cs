using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMaterialBehaviour : MonoBehaviour
{
    [SerializeField] private List<Material> _materials;
    [SerializeField] private List<MeshRenderer> _meshes;
    

    private void Start()
    {
        MeshRenderer[] meshes = FindObjectsOfType<MeshRenderer>();
        foreach (MeshRenderer r in meshes) 
        {
            if (r.tag == "World") 
            {
                _meshes.Add(r);
            }
        }
    }

    public void RNGChangeMesh() 
    {
        foreach (MeshRenderer r in _meshes) 
        {
            int rng = Mathf.RoundToInt(Random.Range(0, _materials.Count));
            r.material = _materials[rng];
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
            RNGChangeMesh();
    }
}
