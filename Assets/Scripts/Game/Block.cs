using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Block : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [field: SerializeField] public Pocket AttachedPocket { get; set; }
    
    private GameLogicManager _gameLogicManager;
    private Vector2 _startPosition;
    private CanvasGroup _canvasGroup;
    private Animator _animator;

    private void Awake()
    {
        _gameLogicManager = GameManager.Instance.GetComponentInChildren<GameLogicManager>();
        _canvasGroup = GetComponent<CanvasGroup>();
        _animator = GetComponent<Animator>();
    }

    public void PlayWinAnimation()
    {
        _animator.SetBool("IsWin", true);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!_gameLogicManager.CanPlayGame)
        {
            return;
        }

        _canvasGroup.blocksRaycasts = false;
        _startPosition = GetComponent<RectTransform>().anchoredPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!_gameLogicManager.CanPlayGame)
        {
            return;
        }

        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!_gameLogicManager.CanPlayGame)
        {
            return;
        }

        _canvasGroup.blocksRaycasts = true;
        GetComponent<RectTransform>().anchoredPosition = _startPosition;
    }
}