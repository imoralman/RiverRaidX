using UnityEngine;

[ExecuteInEditMode]
public class CurvaMundo : MonoBehaviour
{

    [Range(-0.1f, 0.1f)]
    public float forcaDaCurva = 0.01f;

    int m_ForcaDaCurvaID;
    private void OnEnable() {
        m_ForcaDaCurvaID = Shader.PropertyToID("_ForcaDaCurva");    
    }
    
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        Shader.SetGlobalFloat(m_ForcaDaCurvaID, forcaDaCurva);
        
    }
}
