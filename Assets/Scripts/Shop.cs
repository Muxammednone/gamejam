using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
class Price
{
    public int index;
    public int iron_price;
    public int poison_price;
}
public class Shop : MonoBehaviour
{
    [SerializeField] private Price[] prices;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Text textIron;
    [SerializeField] private Text textPoison;
    [SerializeField] private SetupManager setupManager;
    [SerializeField] private GameObject deadWindow;
    [SerializeField] private Text hpText;
    public void buy(int index)
    {
        if (gameManager.iron >= prices[index].iron_price && gameManager.poison >= prices[index].poison_price)
        {
            gameManager.iron -= prices[index].iron_price;
            gameManager.poison -= prices[index].poison_price;
            gameManager.isSetupping = true;
            setupManager.setuppingIndex = index;

        }
    }
    private void Update()
    {
        hpText.text = gameManager.hp.ToString();
        textIron.text = gameManager.iron.ToString();
        textPoison.text = gameManager.poison.ToString();
        if (gameManager.hp <= 0)
        {
            deadWindow.SetActive(true);
        }
    }
    public void startGame()
    {
        gameManager.isStarted = true;
    }

}
