using UnityEngine;

public class MovimentoInimigo : MonoBehaviour
{
    [Header("Movimento")]
    public float _moveSpeed = 3f;
    public float _minPauseTime = 1f;
    public float _maxPauseTime = 3f;

    [Header("Área de Movimento")]
   
    public Vector3 _containerTamanho = new Vector3(13f, 0f, 0f); // só se move no eixo X

    private float _limiteEsquerda;
    private float _limiteDireita;
    private bool _moverDireita = true;
    private float _tempoPausa;
    private bool _pausado = false;

    private Transform player;

    //novo
    private Vector3 _posicaoInicial;

    void Start()
    {
        
        // Calcular limites com base na posição inicial relativa do inimigo
        _posicaoInicial = transform.position;

        _limiteEsquerda = _posicaoInicial.x - _containerTamanho.x / 2f;
        _limiteDireita = _posicaoInicial.x + _containerTamanho.x / 2f;


        _tempoPausa = Random.Range(_minPauseTime, _maxPauseTime);

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
    }

    void Update()
    {
        if (_pausado)
        {
            _tempoPausa -= Time.deltaTime;
            if (_tempoPausa <= 0f)
            {
                _pausado = false;
                _tempoPausa = Random.Range(_minPauseTime, _maxPauseTime);
            }
            return;
        }

        float direction = _moverDireita ? 1f : -1f;
        transform.Translate(Vector3.right * direction * _moveSpeed * Time.deltaTime);

        // Verificar limites do container (apenas eixo X)
        if (transform.position.x >= _limiteDireita)
        {
            transform.position = new Vector3(_limiteDireita, transform.position.y, transform.position.z);
            _moverDireita = false;
            _pausado = false;
        }
        else if (transform.position.x <= _limiteEsquerda)
        {
            transform.position = new Vector3(_limiteEsquerda, transform.position.y, transform.position.z);
            _moverDireita = true;
            _pausado = false;
        }



        void OnDrawGizmosSelected()
        {
            // Visualizar a área no editor
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireCube(transform.position, _containerTamanho);
        }
    }
}
