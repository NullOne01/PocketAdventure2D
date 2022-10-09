using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pocket : MonoBehaviour, IDropHandler
{
    [field: SerializeField] public Block AttachedBlock { get; private set; }
    [field: SerializeField] public bool ContainBlockOnInit { get; set; }
    [SerializeField] private GameObject blockPrefab;

    private GameLogicManager _gameLogicManager;

    private void Start()
    {
        _gameLogicManager = GameManager.Instance.GetComponentInChildren<GameLogicManager>();
    }

    public void CreateAndAttachBlock()
    {
        if (AttachedBlock != null)
        {
            Destroy(AttachedBlock.gameObject);
        }

        GameObject newBlock = Instantiate(blockPrefab, transform, false);
        AttachBlock(newBlock.GetComponent<Block>());
    }

    public void AttachBlock(Block block)
    {
        if (block.AttachedPocket != null)
        {
            block.AttachedPocket.AttachedBlock = null;
        }

        AttachedBlock = block;
        block.transform.SetParent(transform, false);
        block.AttachedPocket = this;
        block.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
    }

    public void DetachBlock()
    {
        if (AttachedBlock == null)
        {
            return;
        }

        Destroy(AttachedBlock.gameObject);
        AttachedBlock = null;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (!_gameLogicManager.CanPlayGame)
        {
            return;
        }

        Block newBlock = eventData.pointerDrag.GetComponent<Block>();
        if (newBlock == null)
        {
            Debug.LogError("On drop block wasn't found");
            return;
        }

        if (CanTakeBlock())
        {
            AttachBlock(newBlock);
            GameManager.Instance.GetComponentInChildren<GameLogicManager>().CheckGame();
        }
    }

    private bool CanTakeBlock()
    {
        return AttachedBlock == null;
    }
}