using DG.Tweening;
using UnityEngine;

public class SpaceshipController : MonoBehaviour{
    public float speed = 10f; // Speed of movement

    public  Vector3 rotacaoAlvo = new Vector3(0,0,20);
    public float duracaoRotacao;

    void Update() {
        // Get input from the player
        float moveInput = Input.GetAxis("Horizontal"); // Left (-1) | Right (1)

            if(moveInput < 0){
                Quaternion targetQuaternion = Quaternion.Euler(rotacaoAlvo);

                // Faz a rotação suave para o alvo ao longo do tempo especificado
                transform.DORotateQuaternion(targetQuaternion, duracaoRotacao).SetEase(Ease.OutQuad); // Interpolação suave
            
            } else if(moveInput > 0) {
                Quaternion targetQuaternion = Quaternion.Euler(-rotacaoAlvo);

                // Faz a rotação suave para o alvo ao longo do tempo especificado
                transform.DORotateQuaternion(targetQuaternion, duracaoRotacao).SetEase(Ease.OutQuad); // Interpolação suave
            }
        
        // Calculate new position
        Vector3 newPosition = transform.position + new Vector3(moveInput * speed * Time.deltaTime, 0, 0);
        
        // Apply movement
        transform.position = newPosition;
    }

    void InclinaNave(){

    }
}
