﻿using UnityEngine;
using UnityEngine.UI;
public static class ScrollRectExtensions
{
    public static void ScrollToTop(ScrollRect scrollRect)
    {
        scrollRect.normalizedPosition = new Vector2(0, 1);
    }
    public static void ScrollToBottom(ScrollRect scrollRect)
    {
        Canvas.ForceUpdateCanvases();
        scrollRect.velocity=new Vector2(0f,1000f);

    }
}