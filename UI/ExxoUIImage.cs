﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;

namespace AvalonTesting.UI;

internal class ExxoUIImage : ExxoUIElement
{
    protected Color Color = Color.White;
    private Vector2 inset;
    public float LocalRotation;
    public float LocalScale = 1f;
    private float scale = 1f;

    public ExxoUIImage(Asset<Texture2D> texture)
    {
        SetImage(texture);
    }

    public override bool IsDynamicallySized => false;
    protected Asset<Texture2D> Texture { get; private set; }

    public Vector2 Inset
    {
        get => inset;
        set
        {
            inset = value;
            UpdateDimensions();
        }
    }

    public float Scale
    {
        get => scale;
        set
        {
            scale = value;
            UpdateDimensions();
        }
    }

    public void SetImage(Asset<Texture2D> texture)
    {
        Texture = texture;
        UpdateDimensions();
    }

    private void UpdateDimensions()
    {
        if (Texture != null)
        {
            MinWidth.Set((Texture.Width() - (Inset.X * 2)) * Scale, 0f);
            MinHeight.Set((Texture.Height() - (Inset.Y * 2)) * Scale, 0f);
        }
    }

    protected override void DrawSelf(SpriteBatch spriteBatch)
    {
        if (Texture != null)
        {
            spriteBatch.Draw(Texture.Value,
                (GetDimensions().Position() + (Texture.Size() * Scale / 2) - (Inset * Scale)).ToNearestPixel(), null,
                Color, LocalRotation, Texture.Size() / 2, Scale * LocalScale, SpriteEffects.None, 0f);
        }
    }
}
