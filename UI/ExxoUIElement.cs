﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.UI;

namespace AvalonTesting.UI;

public abstract class ExxoUIElement : UIElement
{
    public delegate void ExxoUIElementEventHandler(ExxoUIElement sender, EventArgs e);

    public readonly Queue<UIElement> ElementsForRemoval = new();

    private bool mouseWasOver;
    public bool IsVisible => Active && !Hidden && GetOuterDimensions().Width > 0 && GetOuterDimensions().Height > 0;
    public bool Active { get; set; } = true;
    public bool Hidden { get; set; }
    public int ElementCount => Elements.Count;
    public bool IsRecalculating { get; private set; }
    public string Tooltip { get; set; } = "";

    public abstract bool IsDynamicallySized
    {
        get;
    }

    public event MouseEvent OnMouseHovering;
    public event MouseEvent OnFirstMouseOver;
    public event MouseEvent OnLastMouseOut;
    public event ExxoUIElementEventHandler OnRecalculateFinish;

    public sealed override void Update(GameTime gameTime)
    {
        if (!Active)
        {
            return;
        }

        if (IsMouseHovering)
        {
            OnMouseHovering?.Invoke(new UIMouseEvent(this, UserInterface.ActiveInstance.MousePosition), this);
        }

        UpdateSelf(gameTime);
        base.Update(gameTime);
        while (ElementsForRemoval.Count > 0)
        {
            RemoveChild(ElementsForRemoval.Dequeue());
        }
    }

    protected virtual void UpdateSelf(GameTime gameTime)
    {
    }

    public override bool ContainsPoint(Vector2 point)
    {
        return IsVisible && base.ContainsPoint(point);
    }

    public sealed override void Draw(SpriteBatch spriteBatch)
    {
        if (IsVisible)
        {
            if (IsMouseHovering && !string.IsNullOrEmpty(Tooltip))
            {
                Main.hoverItemName = Tooltip;
            }

            base.Draw(spriteBatch);
        }
    }

    public sealed override void Recalculate()
    {
        IsRecalculating = true;
        PreRecalculate();
        RecalculateSelf();
        RecalculateChildren();
        PostRecalculate();
        if (!(Parent is ExxoUIElement))
        {
            RecalculateFinish();
        }

        IsRecalculating = false;
    }

    private void RecalculateFinish()
    {
        foreach (UIElement element in Elements)
        {
            if (element is ExxoUIElement exxoElement)
            {
                exxoElement.RecalculateFinish();
            }
        }

        OnRecalculateFinish?.Invoke(this, EventArgs.Empty);
    }

    // Optimised method that only moves positions, only to be used if the elements have already previously been recalculated
    public void RecalculateChildrenSelf()
    {
        RecalculateSelf();
        foreach (UIElement element in Elements)
        {
            if (element is ExxoUIElement exxoElement)
            {
                exxoElement.RecalculateChildrenSelf();
            }
            else
            {
                element.Recalculate();
            }
        }
    }

    // This works because the UIChanges.ILUIElementRecalculate hook doesn't recalulate children if the element is an ExxoUIElement
    public void RecalculateSelf()
    {
        base.Recalculate();
    }

    protected virtual void PreRecalculate()
    {
    }

    protected virtual void PostRecalculate()
    {
    }

    public override void MouseOver(UIMouseEvent evt)
    {
        base.MouseOver(evt);
        if (!mouseWasOver)
        {
            mouseWasOver = true;
            FirstMouseOver(evt);
        }
    }

    public override void MouseOut(UIMouseEvent evt)
    {
        base.MouseOut(evt);
        if (!ContainsPoint(evt.MousePosition))
        {
            mouseWasOver = false;
            LastMouseOut(evt);
        }
    }

    protected virtual void FirstMouseOver(UIMouseEvent evt)
    {
        OnFirstMouseOver?.Invoke(evt, this);
    }

    protected virtual void LastMouseOut(UIMouseEvent evt)
    {
        OnLastMouseOut?.Invoke(evt, this);
    }

    public static void BeginDefaultSpriteBatch(SpriteBatch spriteBatch)
    {
        spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, DepthStencilState.None, null, null,
            Main.UIScaleMatrix);
    }
}
