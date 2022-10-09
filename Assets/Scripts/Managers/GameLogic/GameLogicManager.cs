using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogicManager : MonoBehaviour
{
    [SerializeField] private List<Pocket> pocketsInGrid;
    [SerializeField] private Pocket littlePocket;
    [SerializeField] private Pocket bigPocket;
    [SerializeField] private float secondsWaitWin = 1.5f;

    public bool CanPlayGame { get; set; } = true;
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
        CheckGame();
    }

    public void StartGame()
    {
        CanPlayGame = true;
        LoadStates();
        CheckGame();
    }

    private void ResetStates()
    {
        foreach (var state in pocketStates)
        {
            state.DeleteValue();
        }
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

    private bool HaveMadeLostTurn(Pocket fromPocket, Pocket toPocket)
    {
        // return (fromPocket == littlePocket || fromPocket == bigPocket) && 
        //        (toPocket != littlePocket && toPocket != bigPocket) &&
        //        toPocket != pocketsInGrid[4];
        return (fromPocket == littlePocket || fromPocket == bigPocket) &&
               (toPocket != littlePocket && toPocket != bigPocket) &&
               !HaveWon();
    }

    private bool HaveWon()
    {
        return pockets[3].AttachedBlock != null &&
               pockets[4].AttachedBlock != null &&
               pockets[5].AttachedBlock != null;
    }

    private void Lose()
    {
        CanPlayGame = false;
        WindowManager windowManager = GameManager.Instance.GetComponentInChildren<WindowManager>();
        TryAgainDialogue tryAgainDialogue = windowManager.ShowDialogue("TryAgain") as TryAgainDialogue;
        if (tryAgainDialogue != null)
        {
            tryAgainDialogue.UpdateStatus("Mistake");
        }

        ResetStates();
    }

    private IEnumerator WinCoroutine()
    {
        CanPlayGame = false;
        pockets[3].AttachedBlock.PlayWinAnimation();
        pockets[4].AttachedBlock.PlayWinAnimation();
        pockets[5].AttachedBlock.PlayWinAnimation();

        yield return new WaitForSeconds(secondsWaitWin);

        WindowManager windowManager = GameManager.Instance.GetComponentInChildren<WindowManager>();
        TryAgainDialogue tryAgainDialogue = windowManager.ShowDialogue("TryAgain") as TryAgainDialogue;
        if (tryAgainDialogue != null)
        {
            tryAgainDialogue.UpdateStatus("Victory");
        }

        ResetStates();
    }

    public void CheckGame()
    {
        SaveStates();

        if (HaveWon())
        {
            StartCoroutine(WinCoroutine());
        }
    }

    public void CheckTurn(Pocket fromPocket, Pocket toPocket)
    {
        CheckGame();

        if (HaveMadeLostTurn(fromPocket, toPocket))
        {
            Lose();
        }
    }
}