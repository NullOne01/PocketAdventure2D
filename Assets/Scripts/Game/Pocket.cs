using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pocket : MonoBehaviour, IDropHandler
{
    [SerializeField] private Block attachedBlock;
    [SerializeField] private bool containBlockOnInit;
    [SerializeField] private GameObject blockPrefab;

    private void Start()
    {
        if (containBlockOnInit && attachedBlock == null)
        {
            GameObject newBlock = Instantiate(blockPrefab, transform, false);
            AttachBlock(newBlock.GetComponent<Block>());
        }
    }

    public void AttachBlock(Block block)
    {
        if (block.AttachedPocket != null)
        {
            block.AttachedPocket.attachedBlock = null;
        }

        attachedBlock = block;
        block.transform.SetParent(transform, false);
        block.AttachedPocket = this;
        block.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
    }

    public void OnDrop(PointerEventData eventData)
    {
        Block newBlock = eventData.pointerDrag.GetComponent<Block>();
        if (newBlock == null)
        {
            Debug.LogError("On drop block wasn't found");
            return;
        }

        if (CanTakeBlock())
        {
            AttachBlock(newBlock);
        }
    }

    private bool CanTakeBlock()
    {
        return attachedBlock == null;
    }
}