using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationManager : MonoBehaviour
{
    [SerializeField] private RandomSpellGenerator randomSpellGenerator;
    [SerializeField] private RandomItemGenerator randomItemGenerator;
    [SerializeField] private GameObject player;

    void Start()
    {
        GenerateRandomSpell();
        GenerateStartingItem();
    }

    private void GenerateRandomSpell()
    {
        Vector3 startingSpellForwardOffset = Vector3.forward * -1 * 3;
        Vector3 startingSpellHeightOffset = Vector3.up * 1.5f;
        Vector3 startingSpellRightOffset = Vector3.right;
        randomSpellGenerator.Generate(player.transform.position + startingSpellForwardOffset +
                                      startingSpellHeightOffset + startingSpellRightOffset);
    }

    private void GenerateStartingItem()
    {
        Vector3 startingItemForwardOffset = Vector3.forward * -1 * 3;
        Vector3 startingItemHeightOffset = Vector3.up * 1.5f;
        Vector3 startingItemRightOffset = Vector3.right * -1;
        randomItemGenerator.Generate(player.transform.position + startingItemForwardOffset +
                                     startingItemHeightOffset + startingItemRightOffset);
    }

    // Update is called once per frame
    void Update()
    {
    }
}