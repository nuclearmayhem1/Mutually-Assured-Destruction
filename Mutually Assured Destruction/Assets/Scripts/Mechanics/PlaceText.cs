using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceText : MonoBehaviour
{
    private List<GameObject> titles = new List<GameObject>();
    [SerializeField] private GameObject titlePrefab;

    private void Start()
    {
        AdjustTitles();
    }

    public void AdjustTitles()
    {
        for (int i = titles.Count; i > 0; i++)
        {
            Destroy(titles[i]);
        }

        List<Nation> nations = GameManager.Instance.nations;

        for (int i = 0; i < nations.Count; i++)
        {
            Vector2 pos = nations[i].bounds.center / 100;

            GameObject newTitle = Instantiate(titlePrefab, pos, Quaternion.identity, transform);
            newTitle.transform.localScale *= nations[i].bounds.size.magnitude / 2000;
            newTitle.GetComponentInChildren<Text>().text = nations[i].name;
            newTitle.GetComponent<CountryTitle>().nation = nations[i];

        }

    }

}
