using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTOutline : MonoBehaviour
{

    public MeshRenderer m_Renderer;

    // Start is called before the first frame update
    void Start()
    {
        Material newMat = Resources.Load("ShaderOutline", typeof(Material)) as Material;
        m_Renderer.material = newMat;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
