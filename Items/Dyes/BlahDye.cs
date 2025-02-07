﻿using AvalonTesting.Rarities;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Items.Dyes;

public class BlahDye : ModItem
{
    public override void SetStaticDefaults()
    {
        // Avoid loading assets on dedicated servers. They don't use graphics cards.
        if (!Main.dedServ)
        {
            // The following code creates an effect (shader) reference and associates it with this item's type Id.
            GameShaders.Armor.BindShader(
                Item.type,
                new ArmorShaderData(
                    new Ref<Effect>(Mod.Assets.Request<Effect>("Effects/BlahDye", AssetRequestMode.ImmediateLoad)
                        .Value), "BlahDye") // Be sure to update the effect path and pass name here.
            );
        }

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
    }

    public override void SetDefaults()
    {
        // Item.dye will already be assigned to this item prior to SetDefaults because of the above GameShaders.Armor.BindShader code in Load().
        // This code here remembers Item.dye so that information isn't lost during CloneDefaults.
        int dye = Item.dye;

        Item.CloneDefaults(ItemID
            .GelDye); // Makes the item copy the attributes of the item "Gel Dye" Change "GelDye" to whatever dye type you want.
        Item.rare = ModContent.RarityType<BlahRarity>();
        Item.dye = dye;
    }
}
