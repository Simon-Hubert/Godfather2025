using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private SpriteRenderer _sr;
    [SerializeField] private Sprite _bgNormal;
    [SerializeField] private Sprite _bgFanta;
    
    // Start is called before the first frame update
    void Start() {
        _sr = GetComponent<SpriteRenderer>();
    }

    public void StartFanta() {
        _sr.sprite = _bgFanta;
    }
    
    public void EndFanta() {
        _sr.sprite = _bgNormal;
    }
}
