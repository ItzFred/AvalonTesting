﻿using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;

namespace AvalonTesting.NPCs.Utils;

/// <summary>
/// An advanced extension of ModNPC which allows for the state system to be easily implemented
/// </summary>
/// <typeparam name="T">The top level state parent of this npc</typeparam>
public abstract class AdvancedModNPC<T> : ModNPC where T : StateParent, new()
{
    public T MainStateInstance { get; private set; }
    public override void SendExtraAI(BinaryWriter writer)
    {
        MainStateInstance.Write(writer);
    }

    public override void ReceiveExtraAI(BinaryReader reader)
    {
        if (MainStateInstance == null)
        {
            MainStateInstance = new T();
            MainStateInstance.UpdateBaseData(this);
        }
        MainStateInstance.Read(reader);
    }

    public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
    {
        MainStateInstance?.PreDraw(spriteBatch);
        return base.PreDraw(spriteBatch, screenPos, drawColor);
    }

    public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
    {
        MainStateInstance?.PostDraw(spriteBatch);
        base.PostDraw(spriteBatch, screenPos, drawColor);
    }

    public override void AI()
    {
        (MainStateInstance ?? (MainStateInstance = new T())).StartUpdate(this);
    }
    
    public override void OnKill()
    {
        base.OnKill();
        MainStateInstance?.Unload();
    }
}
