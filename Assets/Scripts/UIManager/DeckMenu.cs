using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckMenu : MonoBehaviour
{
    [Header("UI Containers")]
    public GameObject playerDeckContainer;
    public GameObject systemCardsContainer;
    [Header("Card Prefab UI")]
    public GameObject cardUIPrefab;
    [SerializeField]
    private List<FlowerPreset> playerDeck, systemDeck;
    [SerializeField]
    private List<GameObject> cardsPrefabList = new();

    private void Awake()
    {
        Debug.Log("DeckMenu: Player deck reference: " + GameObject.FindGameObjectsWithTag("GameController").Length);
        GameObject.FindGameObjectsWithTag("GameController")[0].GetComponent<GameManager>().presets = new List<FlowerPreset>();
        playerDeck = GameObject.FindGameObjectsWithTag("GameController")[0].GetComponent<GameManager>().presets;
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("DeckMenu: Instantiate system Deck");
        OnStartInstantiateSystemCards();
        //Debug.Log("DeckMenu: Instantiate Player Deck");
        //instantiatePlayerCard(playerDeck.GetCards());
    }
    #region Methods
    private void OnStartInstantiateSystemCards()
    {
        Debug.Log("DeckMenu: Deleting Prefabs");
        cardsPrefabList.ForEach(card => Destroy(card));
        cardsPrefabList.Clear();
        Debug.Log("DeckMenu: Instantiating Prefabs");
        InstantiateCardList(CardListSorting(systemDeck), systemCardsContainer.transform);
    }
    private void InstantiateCardList(List<FlowerPreset> flowerPresets, Transform parent)
    {
        Debug.Log("DeckMenu: Instantiating List");
        if (flowerPresets.Count == 0)
            return;
        for (int i = 0; i < flowerPresets.Count; i++)
        {
            GameObject prefab = Instantiate(cardUIPrefab, parent);
            prefab.GetComponent<CardUI>().setImage(flowerPresets[i].Sprite);
            prefab.GetComponent<CardUI>().inDeck = IsInPlayerDeck(flowerPresets[i]);
            prefab.GetComponent<CardUI>().preset = flowerPresets[i];
            cardsPrefabList.Add(prefab);
            Debug.Log("___Nombre: " + prefab.name);
        }
        MovePlayerCard();
    }
    private void MovePlayerCard()
    {
        foreach (GameObject card in cardsPrefabList)
        {
            if (card.GetComponent<CardUI>().inDeck)
            {
                card.transform.SetParent(playerDeckContainer.transform);
            }
            else
            {
               card.transform.SetParent(systemCardsContainer.transform);
            }
        }
    }
    #endregion
    public int SortFunction(FlowerPreset a, FlowerPreset b)
    {
        if (a.Type < b.Type)
            return -1;
        if (a.Type > b.Type)
            return 1;
        return 0;
    }
    public List<FlowerPreset> CardListSorting(List<FlowerPreset> deck)
    {
        deck.Sort(SortFunction);
        return deck;
    }
    public bool IsInPlayerDeck(FlowerPreset a)
    {
        foreach (FlowerPreset b in playerDeck)
        {
            if (a == b) return true;
        }
        return false;
    }

    public bool IsValid(List<FlowerPreset> deck)
    {
        int validateNum = 0;
        foreach (FlowerPreset i in deck)
        {
            validateNum += i.Type;
        }

        if (validateNum <= 5)
            return true;

        return false;
    }

    #region OnClick
    public void ChangeAndUpdateList(GameObject Prefab)
    {
        Debug.Log("DeckMenu: OnClickChange Activated");
        if (Prefab.GetComponent<CardUI>().inDeck)
            playerDeck.Remove(Prefab.GetComponent<CardUI>().preset);
        else
        {
            List<FlowerPreset> temp = new List<FlowerPreset>();
            playerDeck.ForEach(p => temp.Add(p));
            temp.Add(Prefab.GetComponent<CardUI>().preset);
            if (!IsValid(temp))
            {
                Prefab.GetComponent<Animator>().Play("Can`tDoThis", 0);
                return;
            }
            playerDeck.Add(Prefab.GetComponent<CardUI>().preset);
        }
        //InstantiateSystemCard(CardListSorting(systemDeck.GetCards()), systemCardsContainer.transform);
        OnStartInstantiateSystemCards();
    }
    #endregion
}