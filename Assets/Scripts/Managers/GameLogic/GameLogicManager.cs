using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogicManager : MonoBehaviour
{
    [SerializeField] private List<Pocket> pocketsInGrid;
    [SerializeField] private Pocket littlePocket;
    [SerializeField] private Pocket bigPocket;
    
    private List<Pocket> pockets = new List<Pocket>();
    private List<IntSaveVariable> pocketStates = new List<IntSaveVariable>();

    private void Awake()
    {
        pockets.AddRange(pocketsInGrid);
        pockets.Add(littlePocket);
        pockets.Add(bigPocket);
        
        for (int i = 0; i < pockets.Count; i++)
        {
            pocketStates.Add(new IntSaveVariable("Pocket" + i, -1));
        }
    }

    private void Start()
    {
        LoadStates();
    }

    private void SaveStates()
    {
        for (int i = 0; i < pockets.Count; i++)
        {
            pocketStates[i].Value = pockets[i].AttachedBlock == null ? 0 : 1;
        }
    }

    private void LoadStates()
    {
        for (int i = 0; i < pockets.Count; i++)
        {
            if (pocketStates[i].Value == -1 && pockets[i].ContainBlockOnInit)
            {
                pockets[i].CreateAndAttachBlock();
                continue;
            }

            if (pocketStates[i].Value == 1)
            { 
                pockets[i].CreateAndAttachBlock();
            }
            else
            {
                pockets[i].DetachBlock();
            }
        }
    }

    private void Lose()
    {
    }

    public void CheckGame()
    {
        SaveStates();
    }
}