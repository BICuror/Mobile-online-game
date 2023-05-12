using UnityEngine;
using UnityEngine.UI;

public sealed class PlayerColorChanger : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    
    [SerializeField] private Image _healthBarImage;

    private Color _playerColor;

    public Color GetPlayerColor() => _playerColor;

    public void SetPlayerColor(Color colorToSet)
    {
        _playerColor = colorToSet;

        _spriteRenderer.color = _playerColor;

        _healthBarImage.color = _playerColor;
    }   
}
