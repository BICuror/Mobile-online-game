using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public sealed class WinPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _playerNumberText;

    [SerializeField] private Image _playerImage;

    [SerializeField] private TextMeshProUGUI _coinsCollectedText;

    public void ShowWinPanel(GameObject winner)
    {
        gameObject.SetActive(true);

        PlayerColorChanger playerColorChanger = winner.GetComponent<PlayerColorChanger>();

        _playerImage.color = playerColorChanger.GetPlayerColor();

        _playerNumberText.color = playerColorChanger.GetPlayerColor();

        _playerNumberText.text = winner.GetComponent<PhotonView>().Owner.ActorNumber.ToString();

        PickUpsCollector pickUpsCollector = winner.GetComponent<PickUpsCollector>();

        _coinsCollectedText.text = pickUpsCollector.CollectedPickUps.ToString() + " / " + pickUpsCollector.PickUpsOnMap.ToString();
    }
}
