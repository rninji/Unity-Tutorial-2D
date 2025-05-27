using UnityEngine;

public class StudyMaterial : MonoBehaviour
{
    public Material mat;
    public string hexCode;
    
    void Start()
    {
        // this.GetComponent<Material>() = mat; // Material을 바꾸는 방식 X
        // this.GetComponent<MeshRenderer>().sharedMaterial = mat; // MeshRender에 접근해서 바꾸는 방식

        // this.GetComponent<MeshRenderer>().material.color = Color.black;
        // this.GetComponent<MeshRenderer>().sharedMaterial.color = Color.black;
        
        // this.GetComponent<MeshRenderer>().material.color = new Color(0.8f,0.5f, 0.4f,1f);

        mat = this.GetComponent<MeshRenderer>().material;
        Color ouputColor;
        if (ColorUtility.TryParseHtmlString(hexCode, out ouputColor))
        {
            mat.color = ouputColor;
        }
    }
}
