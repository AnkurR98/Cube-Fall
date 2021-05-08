using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{
    public float scroll_speed = 0.3f;
    private MeshRenderer mesh_renderer;

    void Awake()
    {
        mesh_renderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        Scroll();
    }

    void Scroll()
    {
        Vector2 offset = mesh_renderer.sharedMaterial.GetTextureOffset("_MainTex");
        offset.y += Time.deltaTime * scroll_speed;

        mesh_renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
