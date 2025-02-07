using System;
using System.Collections.Generic;
using AvalonTesting.Systems;
using AvalonTesting.Tiles;
using AvalonTesting.Walls;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

namespace AvalonTesting.World.Passes;

public class Contagion : GenPass
{
    public Contagion() : base("Contagion", 1094.237f) { }

    protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
    {
        int beachBordersWidth = 275;
        int beachSandRandomCenter = beachBordersWidth + 5 + 40;
        int evilBiomeBeachAvoidance = beachSandRandomCenter + 60;
        int evilBiomeAvoidanceMidFixer = 50;

        int jungleTilesUpperX = Main.maxTilesX;
        int jungleTilesLowerX = 0;
        int snowTilesUpperX = Main.maxTilesX;
        int snowTilesLowerX = 0;
        Tile tile;
        for (int x = 0; x < Main.maxTilesX; x++)
        {
            for (int y = 0; y < Main.worldSurface; y++)
            {
                tile = Main.tile[x, y];
                if (tile.HasTile)
                {
                    tile = Main.tile[x, y];
                    if (tile.TileType == TileID.JungleGrass)
                    {
                        if (x < jungleTilesUpperX)
                        {
                            jungleTilesUpperX = x;
                        }

                        if (x > jungleTilesLowerX)
                        {
                            jungleTilesLowerX = x;
                        }
                    }
                    else
                    {
                        tile = Main.tile[x, y];
                        if (tile.TileType is not TileID.SnowBlock and not TileID.IceBlock)
                        {
                            continue;
                        }

                        // Found snow or ice
                        if (x < snowTilesUpperX)
                        {
                            snowTilesUpperX = x;
                        }

                        if (x > snowTilesLowerX)
                        {
                            snowTilesLowerX = x;
                        }
                    }
                }
            }
        }

        int boundaryOffset = 10;
        jungleTilesUpperX -= boundaryOffset;
        jungleTilesLowerX += boundaryOffset;
        snowTilesUpperX -= boundaryOffset;
        snowTilesLowerX += boundaryOffset;

        const int num500 = 500;
        const int num100 = 100;

        bool notDrunk = true;
        double iterations = Main.maxTilesX * 0.00045;
        if (WorldGen.drunkWorldGen)
        {
            iterations /= 2.0;
            if (WorldGen.genRand.Next(2) == 0)
            {
                notDrunk = false;
            }
        }
        
        progress.Message = "Making the world gross";
        for (int iteration = 0; iteration < iterations; iteration++)
        {
            int snowTilesUpperXInner = snowTilesUpperX;
            int snowTilesLowerXInner = snowTilesLowerX;
            int jungleTilesUpperXInner = jungleTilesUpperX;
            int jungleTilesLowerXInner = jungleTilesLowerX;
            float progressPercent = iteration / (float)iterations;
            progress.Set(progressPercent);
            bool foundGoodSpot = false;
            int randomX = 0;
            int leftBeachAvoidanceCheck = 0;
            int rightBeachAvoidanceCheck = 0;

            while (!foundGoodSpot)
            {
                foundGoodSpot = true;
                int centerX = Main.maxTilesX / 2;
                int minDistanceFromCenter = 200;
                if (WorldGen.drunkWorldGen)
                {
                    minDistanceFromCenter = 100;
                    randomX = !notDrunk
                        ? WorldGen.genRand.Next((int)(Main.maxTilesX * 0.5), Main.maxTilesX - num500)
                        : WorldGen.genRand.Next(num500, (int)(Main.maxTilesX * 0.5));
                }
                else
                {
                    randomX = WorldGen.genRand.Next(num500, Main.maxTilesX - num500);
                }

                leftBeachAvoidanceCheck = randomX - WorldGen.genRand.Next(200) - 100;
                rightBeachAvoidanceCheck = randomX + WorldGen.genRand.Next(200) + 100;
                if (leftBeachAvoidanceCheck < evilBiomeBeachAvoidance)
                {
                    leftBeachAvoidanceCheck = evilBiomeBeachAvoidance;
                }

                if (rightBeachAvoidanceCheck > Main.maxTilesX - evilBiomeBeachAvoidance)
                {
                    rightBeachAvoidanceCheck = Main.maxTilesX - evilBiomeBeachAvoidance;
                }

                if (randomX < leftBeachAvoidanceCheck + evilBiomeAvoidanceMidFixer)
                {
                    randomX = leftBeachAvoidanceCheck + evilBiomeAvoidanceMidFixer;
                }

                if (randomX > rightBeachAvoidanceCheck - evilBiomeAvoidanceMidFixer)
                {
                    randomX = rightBeachAvoidanceCheck - evilBiomeAvoidanceMidFixer;
                }

                if (ModContent.GetInstance<ExxoWorldGen>().DungeonSide < 0 && leftBeachAvoidanceCheck < 400)
                {
                    leftBeachAvoidanceCheck = 400;
                }
                else if (ModContent.GetInstance<ExxoWorldGen>().DungeonSide > 0 &&
                         leftBeachAvoidanceCheck > Main.maxTilesX - 400)
                {
                    leftBeachAvoidanceCheck = Main.maxTilesX - 400;
                }

                if (randomX > centerX - minDistanceFromCenter && randomX < centerX + minDistanceFromCenter)
                {
                    foundGoodSpot = false;
                }

                if (leftBeachAvoidanceCheck > centerX - minDistanceFromCenter &&
                    leftBeachAvoidanceCheck < centerX + minDistanceFromCenter)
                {
                    foundGoodSpot = false;
                }

                if (rightBeachAvoidanceCheck > centerX - minDistanceFromCenter &&
                    rightBeachAvoidanceCheck < centerX + minDistanceFromCenter)
                {
                    foundGoodSpot = false;
                }

                if (randomX > WorldGen.UndergroundDesertLocation.X && randomX <
                    WorldGen.UndergroundDesertLocation.X + WorldGen.UndergroundDesertLocation.Width)
                {
                    foundGoodSpot = false;
                }

                if (leftBeachAvoidanceCheck > WorldGen.UndergroundDesertLocation.X && leftBeachAvoidanceCheck <
                    WorldGen.UndergroundDesertLocation.X + WorldGen.UndergroundDesertLocation.Width)
                {
                    foundGoodSpot = false;
                }

                if (rightBeachAvoidanceCheck > WorldGen.UndergroundDesertLocation.X && rightBeachAvoidanceCheck <
                    WorldGen.UndergroundDesertLocation.X + WorldGen.UndergroundDesertLocation.Width)
                {
                    foundGoodSpot = false;
                }

                if (leftBeachAvoidanceCheck < ModContent.GetInstance<ExxoWorldGen>().DungeonLocation + num100 &&
                    rightBeachAvoidanceCheck > ModContent.GetInstance<ExxoWorldGen>().DungeonLocation - num100)
                {
                    foundGoodSpot = false;
                }

                if (leftBeachAvoidanceCheck < snowTilesLowerXInner && rightBeachAvoidanceCheck > snowTilesUpperXInner)
                {
                    snowTilesUpperXInner++;
                    snowTilesLowerXInner--;
                    foundGoodSpot = false;
                }

                if (leftBeachAvoidanceCheck < jungleTilesLowerXInner &&
                    rightBeachAvoidanceCheck > jungleTilesUpperXInner)
                {
                    jungleTilesUpperXInner++;
                    jungleTilesLowerXInner--;
                    foundGoodSpot = false;
                }
            }

            // Just checked that randomX is valid and now we start
            ContagionRunner(randomX, (int)WorldGen.worldSurfaceLow - 10);

            // Modify jungle
            for (int x = leftBeachAvoidanceCheck; x < rightBeachAvoidanceCheck; x++)
            {
                for (int y = (int)WorldGen.worldSurfaceLow; y < Main.worldSurface - 1.0; y++)
                {
                    tile = Main.tile[x, y];
                    if (tile.HasTile)
                    {
                        int randomY = y + WorldGen.genRand.Next(10, 14);
                        for (int y2 = y; y2 < randomY; y2++)
                        {
                            tile = Main.tile[x, y2];
                            if (tile.TileType is not TileID.Mud and not TileID.JungleGrass)
                            {
                                continue;
                            }

                            if (x >= leftBeachAvoidanceCheck + WorldGen.genRand.Next(5) &&
                                x < rightBeachAvoidanceCheck - WorldGen.genRand.Next(5))
                            {
                                tile.TileType = TileID.Dirt;
                            }
                        }

                        break;
                    }
                }
            }

            // Replace tiles
            double randomYOffset = Main.worldSurface + 40.0;
            for (int x = leftBeachAvoidanceCheck; x < rightBeachAvoidanceCheck; x++)
            {
                randomYOffset += WorldGen.genRand.Next(-2, 3);
                if (randomYOffset < Main.worldSurface + 30.0)
                {
                    randomYOffset = Main.worldSurface + 30.0;
                }

                if (randomYOffset > Main.worldSurface + 50.0)
                {
                    randomYOffset = Main.worldSurface + 50.0;
                }

                bool unusedFlag = false;
                for (int y = (int)WorldGen.worldSurfaceLow; y < randomYOffset; y++)
                {
                    tile = Main.tile[x, y];
                    if (tile.HasTile)
                    {
                        if (tile.TileType == TileID.Sand && x >= leftBeachAvoidanceCheck + WorldGen.genRand.Next(5) &&
                            x <= rightBeachAvoidanceCheck - WorldGen.genRand.Next(5))
                        {
                            tile.TileType = (ushort)ModContent.TileType<Snotsand>();
                        }

                        tile = Main.tile[x, y];
                        if (tile.TileType == TileID.Dirt && y < Main.worldSurface - 1.0 && !unusedFlag)
                        {
                            WorldGen.SpreadGrass(x, y, TileID.Dirt, ModContent.TileType<Ickgrass>());
                        }

                        unusedFlag = true;
                        if (tile.WallType == WallID.HardenedSand)
                        {
                            // Hardened Snotsand wall
                            //tile.WallType = ModContent.WallType<>()
                        }
                        else if (tile.WallType == WallID.Sandstone)
                        {
                            // Snotsandstone wall
                            //tile.WallType = ModContent.WallType<>()
                        }

                        switch (tile.TileType)
                        {
                            case TileID.Stone:
                            {
                                if (x >= leftBeachAvoidanceCheck + WorldGen.genRand.Next(5) &&
                                    x <= rightBeachAvoidanceCheck - WorldGen.genRand.Next(5))
                                {
                                    tile.TileType = (ushort)ModContent.TileType<Chunkstone>();
                                }

                                break;
                            }
                            case TileID.Grass:
                                tile.TileType = (ushort)ModContent.TileType<Ickgrass>();
                                break;
                            case TileID.IceBlock:
                                tile.TileType = (ushort)ModContent.TileType<YellowIce>();
                                break;
                            case TileID.Sandstone:
                                tile.TileType = (ushort)ModContent.TileType<Snotsandstone>();
                                break;
                            case TileID.HardenedSand:
                                tile.TileType = (ushort)ModContent.TileType<HardenedSnotsand>();
                                break;
                        }
                    }
                }
            }

            // Try placing altars
            int altarAttempts = WorldGen.genRand.Next(10, 15);
            for (int i = 0; i < altarAttempts; i++)
            {
                bool finished = false;
                int attemptsAtOffset = 0;
                int offset = 0;
                while (!finished && offset <= 100)
                {
                    attemptsAtOffset++;

                    // Make sure not in the ocean
                    int x = WorldGen.genRand.Next(leftBeachAvoidanceCheck - offset, rightBeachAvoidanceCheck + offset);
                    int y = WorldGen.genRand.Next((int)(Main.worldSurface - (offset / 2.0)),
                        (int)(Main.worldSurface + 100.0 + offset));
                    while (WorldGen.oceanDepths(x, y))
                    {
                        x = WorldGen.genRand.Next(leftBeachAvoidanceCheck - offset, rightBeachAvoidanceCheck + offset);
                        y = WorldGen.genRand.Next((int)(Main.worldSurface - (offset / 2.0)),
                            (int)(Main.worldSurface + 100.0 + offset));
                    }

                    if (attemptsAtOffset > 100)
                    {
                        offset++;
                        attemptsAtOffset = 0;
                    }

                    // Find nearest tile that exists to point and adjust coords
                    tile = Main.tile[x, y];
                    if (!tile.HasTile)
                    {
                        while (true)
                        {
                            tile = Main.tile[x, y];
                            if (tile.HasTile)
                            {
                                break;
                            }

                            y++;
                        }

                        y--;
                    }
                    else
                    {
                        while (true)
                        {
                            tile = Main.tile[x, y];
                            if (!tile.HasTile || !(y > Main.worldSurface))
                            {
                                break;
                            }

                            y--;
                        }
                    }

                    if (offset > 10)
                    {
                        TryPlaceAltar();
                    }

                    tile = Main.tile[x, y + 1];
                    if (tile.HasTile)
                    {
                        tile = Main.tile[x, y + 1];
                        if (tile.TileType == ModContent.TileType<Chunkstone>())
                        {
                            TryPlaceAltar();
                        }
                    }

                    void TryPlaceAltar()
                    {
                        if (!WorldGen.IsTileNearby(x, y, ModContent.TileType<IckyAltar>(), 3))
                        {
                            WorldGen.Place3x2(x, y, (ushort)ModContent.TileType<IckyAltar>());
                            if (Main.tile[x, y].TileType == ModContent.TileType<IckyAltar>())
                            {
                                finished = true;
                            }
                        }
                    }
                }
            }
        }

        //WorldGen.CrimPlaceHearts();
    }

    /// <summary>
    ///     Contagion generation method.
    /// </summary>
    /// <param name="i">The x coordinate to start the generation at.</param>
    /// <param name="j">The y coordinate to start the generation at.</param>
    private static void ContagionRunner(int i, int j)
    {
        int j2 = j;
        int radius = WorldGen.genRand.Next(50, 61);
        int rad2 = WorldGen.genRand.Next(20, 26);
        j = Utils.TileCheck(i) + radius + 50;
        var center = new Vector2(i, j);
        var points = new List<Vector2>();
        var pointsToGoTo = new List<Vector2>();
        var angles = new List<double>();
        var outerCircles = new List<Vector2>(); // the circles at the ends of the first tunnels
        var secondaryCircles = new List<Vector2>(); // the circles at the ends of the outer circles
        var secondCircleStartPoints = new List<Vector2>();
        var secondCircleEndpoints = new List<Vector2>();
        var secondCirclePointsAroundCircle = new List<double>();
        var exclusions = new List<Vector2>();
        var excludedPointsForOuterTunnels = new List<Vector2>();
        //new List<Vector2>();

        #region make the main circle

        for (int k = i - radius; k <= i + radius; k++)
        {
            for (int l = j - radius; l <= j + radius; l++)
            {
                float dist = Vector2.Distance(new Vector2(k, l), new Vector2(i, j));
                if (dist <= radius && dist >= radius - 29)
                {
                    Main.tile[k, l].Active(false);
                }

                if (((dist <= radius && dist >= radius - 7) || (dist <= radius - 22 && dist >= radius - 29)) &&
                    Main.tile[k, l].TileType != (ushort)ModContent.TileType<SnotOrb>())
                {
                    Main.tile[k, l].Active(true);
                    Tile tile = Main.tile[k, l];
                    tile.IsHalfBlock = false;
                    tile.Slope = SlopeType.Solid;
                    Main.tile[k, l].TileType = (ushort)ModContent.TileType<Chunkstone>();
                }

                if (dist <= radius - 6 && dist >= radius - 23)
                {
                    Main.tile[k, l].WallType = (ushort)ModContent.WallType<ChunkstoneWall>();
                }
            }
        }

        #endregion

        int radiusModifier =
            radius - 7; // makes the tunnels go deeper into the main circle (more subtracted means further in)
        Vector2 posToPlaceAnotherCircle = Vector2.Zero;

        #region find the points for making the tunnels to the outer circles

        for (int m = 0; m < 16; m++)
        {
            double positionAroundCircle = WorldGen.genRand.Next(0, 62831852) / 10000000;
            var randPoint = new Vector2(center.X + (int)Math.Round(radiusModifier * Math.Cos(positionAroundCircle)),
                center.Y + (int)Math.Round(radiusModifier * Math.Sin(positionAroundCircle)));
            posToPlaceAnotherCircle = randPoint;
            Vector2 item2 = center;
            if (randPoint.X > center.X)
            {
                if (randPoint.X > center.X + (radius / 2))
                {
                    if (randPoint.Y > center.Y)
                    {
                        if (randPoint.Y > center.Y + (radius / 2))
                        {
                            item2 = new Vector2(randPoint.X + 50f, randPoint.Y + 50f);
                            if (WorldGen.genRand.Next(2) == 0)
                            {
                                outerCircles.Add(item2);
                                secondaryCircles.Add(item2);
                                excludedPointsForOuterTunnels.Add(randPoint);
                            }
                        }
                        else
                        {
                            item2 = new Vector2(randPoint.X + 50f, randPoint.Y + 25f);
                            if (WorldGen.genRand.Next(2) == 0)
                            {
                                outerCircles.Add(item2);
                                secondaryCircles.Add(item2);
                                excludedPointsForOuterTunnels.Add(randPoint);
                            }
                        }
                    }
                    else if (randPoint.Y < center.Y - (radius / 2))
                    {
                        item2 = new Vector2(randPoint.X + 50f, randPoint.Y - 50f);
                        if (WorldGen.genRand.Next(2) == 0)
                        {
                            outerCircles.Add(item2);
                            secondaryCircles.Add(item2);
                            excludedPointsForOuterTunnels.Add(randPoint);
                        }
                    }
                    else
                    {
                        item2 = new Vector2(randPoint.X + 50f, randPoint.Y - 25f);
                        if (WorldGen.genRand.Next(2) == 0)
                        {
                            outerCircles.Add(item2);
                            secondaryCircles.Add(item2);
                            excludedPointsForOuterTunnels.Add(randPoint);
                        }
                    }
                }
                else if (randPoint.Y > center.Y)
                {
                    if (randPoint.Y > center.Y + (radius / 2))
                    {
                        item2 = new Vector2(randPoint.X + 25f, randPoint.Y + 50f);
                        if (WorldGen.genRand.Next(2) == 0)
                        {
                            outerCircles.Add(item2);
                            secondaryCircles.Add(item2);
                            excludedPointsForOuterTunnels.Add(randPoint);
                        }
                    }
                    else
                    {
                        item2 = new Vector2(randPoint.X + 25f, randPoint.Y + 25f);
                        if (WorldGen.genRand.Next(2) == 0)
                        {
                            outerCircles.Add(item2);
                            secondaryCircles.Add(item2);
                            excludedPointsForOuterTunnels.Add(randPoint);
                        }
                    }
                }
                else if (randPoint.Y < center.Y - (radius / 2))
                {
                    item2 = new Vector2(randPoint.X + 25f, randPoint.Y - 50f);
                    if (WorldGen.genRand.Next(2) == 0)
                    {
                        outerCircles.Add(item2);
                        secondaryCircles.Add(item2);
                        excludedPointsForOuterTunnels.Add(randPoint);
                    }
                }
                else
                {
                    item2 = new Vector2(randPoint.X + 25f, randPoint.Y - 25f);
                    if (WorldGen.genRand.Next(2) == 0)
                    {
                        outerCircles.Add(item2);
                        secondaryCircles.Add(item2);
                        excludedPointsForOuterTunnels.Add(randPoint);
                    }
                }
            }
            else if (randPoint.X < center.X - (radius / 2))
            {
                if (randPoint.Y > center.Y)
                {
                    if (randPoint.Y > center.Y + (radius / 2))
                    {
                        item2 = new Vector2(randPoint.X - 50f, randPoint.Y + 50f);
                        if (WorldGen.genRand.Next(2) == 0)
                        {
                            outerCircles.Add(item2);
                            secondaryCircles.Add(item2);
                            excludedPointsForOuterTunnels.Add(randPoint);
                        }
                    }
                    else
                    {
                        item2 = new Vector2(randPoint.X - 50f, randPoint.Y + 25f);
                        if (WorldGen.genRand.Next(2) == 0)
                        {
                            outerCircles.Add(item2);
                            secondaryCircles.Add(item2);
                            excludedPointsForOuterTunnels.Add(randPoint);
                        }
                    }
                }
                else if (randPoint.Y < center.Y - (radius / 2))
                {
                    item2 = new Vector2(randPoint.X - 50f, randPoint.Y - 50f);
                    if (WorldGen.genRand.Next(2) == 0)
                    {
                        outerCircles.Add(item2);
                        secondaryCircles.Add(item2);
                        excludedPointsForOuterTunnels.Add(randPoint);
                    }
                }
                else
                {
                    item2 = new Vector2(randPoint.X - 50f, randPoint.Y - 25f);
                    if (WorldGen.genRand.Next(2) == 0)
                    {
                        outerCircles.Add(item2);
                        secondaryCircles.Add(item2);
                        excludedPointsForOuterTunnels.Add(randPoint);
                    }
                }
            }
            else if (randPoint.Y > center.Y)
            {
                if (randPoint.Y > center.Y + (radius / 2))
                {
                    item2 = new Vector2(randPoint.X - 25f, randPoint.Y + 50f);
                    if (WorldGen.genRand.Next(2) == 0)
                    {
                        outerCircles.Add(item2);
                        secondaryCircles.Add(item2);
                        excludedPointsForOuterTunnels.Add(randPoint);
                    }
                }
                else
                {
                    item2 = new Vector2(randPoint.X - 25f, randPoint.Y + 25f);
                    if (WorldGen.genRand.Next(2) == 0)
                    {
                        outerCircles.Add(item2);
                        secondaryCircles.Add(item2);
                        excludedPointsForOuterTunnels.Add(randPoint);
                    }
                }
            }
            else if (randPoint.Y < center.Y - (radius / 2))
            {
                item2 = new Vector2(randPoint.X - 25f, randPoint.Y - 50f);
                if (WorldGen.genRand.Next(2) == 0)
                {
                    outerCircles.Add(item2);
                    secondaryCircles.Add(item2);
                    excludedPointsForOuterTunnels.Add(randPoint);
                }
            }
            else
            {
                item2 = new Vector2(randPoint.X - 25f, randPoint.Y - 25f);
                if (WorldGen.genRand.Next(2) == 0)
                {
                    outerCircles.Add(item2);
                    secondaryCircles.Add(item2);
                    excludedPointsForOuterTunnels.Add(randPoint);
                }
            }

            points.Add(randPoint);
            pointsToGoTo.Add(item2);
            angles.Add(positionAroundCircle);
        }

        #endregion

        // make outer circles

        #region outer circles and tunnels

        if (secondaryCircles.Count != 0)
        {
            for (int z = 0; z < secondaryCircles.Count; z++)
            {
                if (secondaryCircles[z].Y < center.Y - 10)
                {
                    continue;
                }

                int outerTunnelsRadiusMod = rad2 - 6;
                double pointsAroundCircle2 = WorldGen.genRand.Next(0, 62831852) / 10000000;
                var randPointAroundCircle =
                    new Vector2(
                        outerCircles[z].X + (int)Math.Round(outerTunnelsRadiusMod * Math.Cos(pointsAroundCircle2)),
                        outerCircles[z].Y + (int)Math.Round(outerTunnelsRadiusMod * Math.Sin(pointsAroundCircle2)));
                for (int m = 0; m < 16; m++)
                {
                    Vector2 endpoint = secondaryCircles[z];

                    #region endpoint calculation

                    if (randPointAroundCircle.X > outerCircles[z].X)
                    {
                        if (randPointAroundCircle.X > outerCircles[z].X + (rad2 / 2))
                        {
                            if (randPointAroundCircle.Y > outerCircles[z].Y)
                            {
                                if (randPointAroundCircle.Y > outerCircles[z].Y + (rad2 / 2))
                                {
                                    endpoint = new Vector2(randPointAroundCircle.X + 15f,
                                        randPointAroundCircle.Y + 15f);
                                }
                                else
                                {
                                    endpoint = new Vector2(randPointAroundCircle.X + 15f, randPointAroundCircle.Y + 7f);
                                }
                            }
                            else if (randPointAroundCircle.Y < outerCircles[z].Y - (rad2 / 2))
                            {
                                endpoint = new Vector2(randPointAroundCircle.X + 15f, randPointAroundCircle.Y - 15f);
                            }
                            else
                            {
                                endpoint = new Vector2(randPointAroundCircle.X + 15f, randPointAroundCircle.Y - 7f);
                            }
                        }
                        else if (randPointAroundCircle.Y > outerCircles[z].Y)
                        {
                            if (randPointAroundCircle.Y > outerCircles[z].Y + (rad2 / 2))
                            {
                                endpoint = new Vector2(randPointAroundCircle.X + 7f, randPointAroundCircle.Y + 15f);
                            }
                            else
                            {
                                endpoint = new Vector2(randPointAroundCircle.X + 7f, randPointAroundCircle.Y + 7f);
                            }
                        }
                        else if (randPointAroundCircle.Y < outerCircles[z].Y - (rad2 / 2))
                        {
                            endpoint = new Vector2(randPointAroundCircle.X + 7f, randPointAroundCircle.Y - 15f);
                        }
                        else
                        {
                            endpoint = new Vector2(randPointAroundCircle.X + 7f, randPointAroundCircle.Y - 7f);
                        }
                    }
                    else if (randPointAroundCircle.X < outerCircles[z].X - (rad2 / 2))
                    {
                        if (randPointAroundCircle.Y > outerCircles[z].Y)
                        {
                            if (randPointAroundCircle.Y > outerCircles[z].Y + (rad2 / 2))
                            {
                                endpoint = new Vector2(randPointAroundCircle.X - 15f, randPointAroundCircle.Y + 15f);
                            }
                            else
                            {
                                endpoint = new Vector2(randPointAroundCircle.X - 15f, randPointAroundCircle.Y + 7f);
                            }
                        }
                        else if (randPointAroundCircle.Y < outerCircles[z].Y - (rad2 / 2))
                        {
                            endpoint = new Vector2(randPointAroundCircle.X - 15f, randPointAroundCircle.Y - 15f);
                        }
                        else
                        {
                            endpoint = new Vector2(randPointAroundCircle.X - 15f, randPointAroundCircle.Y - 7f);
                        }
                    }
                    else if (randPointAroundCircle.Y > outerCircles[z].Y)
                    {
                        if (randPointAroundCircle.Y > outerCircles[z].Y + (rad2 / 2))
                        {
                            endpoint = new Vector2(randPointAroundCircle.X - 7f, randPointAroundCircle.Y + 15f);
                        }
                        else
                        {
                            endpoint = new Vector2(randPointAroundCircle.X - 7f, randPointAroundCircle.Y + 7f);
                        }
                    }
                    else if (randPointAroundCircle.Y < outerCircles[z].Y - (rad2 / 2))
                    {
                        endpoint = new Vector2(randPointAroundCircle.X - 7f, randPointAroundCircle.Y - 15f);
                    }
                    else
                    {
                        endpoint = new Vector2(randPointAroundCircle.X - 7f, randPointAroundCircle.Y - 7f);
                    }

                    #endregion

                    secondCircleStartPoints.Add(randPointAroundCircle);
                    secondCircleEndpoints.Add(endpoint);
                    secondCirclePointsAroundCircle.Add(pointsAroundCircle2);
                }
            }
        }

        #endregion

        // make tunnels going outwards from the main circle
        for (int n = 0; n < points.Count; n++)
        {
            if (points[n].Y < center.Y - 10)
            {
                continue;
            }

            BoreTunnel2((int)points[n].X, (int)points[n].Y, (int)pointsToGoTo[n].X, (int)pointsToGoTo[n].Y, 10f,
                (ushort)ModContent.TileType<Chunkstone>());
            BoreTunnel2((int)points[n].X, (int)points[n].Y, (int)pointsToGoTo[n].X, (int)pointsToGoTo[n].Y, 5f, 65535);
            MakeEndingCircle((int)pointsToGoTo[n].X, (int)pointsToGoTo[n].Y, 13f,
                (ushort)ModContent.TileType<Chunkstone>());
            MakeCircle((int)pointsToGoTo[n].X, (int)pointsToGoTo[n].Y, 8f, 65535);
        }

        if (outerCircles.Count != 0)
        {
            for (int q = 0; q < outerCircles.Count; q++)
            {
                if (outerCircles[q].Y < center.Y - 10)
                {
                    continue;
                }

                MakeEndingCircle((int)outerCircles[q].X, (int)outerCircles[q].Y, rad2,
                    (ushort)ModContent.TileType<Chunkstone>());
                MakeCircle((int)outerCircles[q].X, (int)outerCircles[q].Y, rad2 - 6, 65535);
                MakeCircle((int)outerCircles[q].X, (int)outerCircles[q].Y, rad2 - 13,
                    (ushort)ModContent.TileType<Chunkstone>());
                exclusions.Add(outerCircles[q]);
            }
        }

        int num8 = radius - 7;
        for (int num9 = 0; num9 < 20; num9++)
        {
            double d = WorldGen.genRand.Next(0, 62831852) / 10000000;
            var vector2 = new Vector2(center.X + (int)Math.Round(num8 * Math.Cos(d)),
                center.Y + (int)Math.Round(num8 * Math.Sin(d)));
            if (exclusions.Contains(vector2))
            {
                continue;
            }

            MakeCircle((int)vector2.X, (int)vector2.Y, 4f, (ushort)ModContent.TileType<Chunkstone>());
        }

        // make tunnels going outwards from the outer circles
        for (int n = 0; n < secondCircleStartPoints.Count; n++)
        {
            if (excludedPointsForOuterTunnels.Count != 0 && n < excludedPointsForOuterTunnels.Count)
            {
                if (Vector2.Distance(excludedPointsForOuterTunnels[n], secondCircleEndpoints[n]) < 55)
                {
                    continue;
                }
            }

            BoreTunnel2((int)secondCircleStartPoints[n].X, (int)secondCircleStartPoints[n].Y,
                (int)secondCircleEndpoints[n].X, (int)secondCircleEndpoints[n].Y, 7f,
                (ushort)ModContent.TileType<Chunkstone>());
            BoreTunnel2((int)secondCircleStartPoints[n].X, (int)secondCircleStartPoints[n].Y,
                (int)secondCircleEndpoints[n].X, (int)secondCircleEndpoints[n].Y, 3f, 65535);
            // ending circles
            MakeCircle((int)secondCircleEndpoints[n].X, (int)secondCircleEndpoints[n].Y, 3f, 65535); // air
            MakeEndingCircle((int)secondCircleEndpoints[n].X, (int)secondCircleEndpoints[n].Y, 5f,
                (ushort)ModContent.TileType<Chunkstone>()); // chunkstone
        }

        // fill main tunnels with air
        for (int n = 0; n < points.Count; n++)
        {
            if (points[n].Y < center.Y - 10)
            {
                exclusions.Add(pointsToGoTo[n]);
                continue;
            }

            BoreTunnel2((int)points[n].X, (int)points[n].Y, (int)pointsToGoTo[n].X, (int)pointsToGoTo[n].Y, 3f, 65535);
        }

        // make secondary circles inner area filled
        if (outerCircles.Count != 0)
        {
            for (int q = 0; q < outerCircles.Count; q++)
            {
                if (outerCircles[q].Y < center.Y - 10)
                {
                    continue;
                }

                MakeCircle((int)outerCircles[q].X, (int)outerCircles[q].Y, rad2 - 6, 65535);
                MakeCircle((int)outerCircles[q].X, (int)outerCircles[q].Y, rad2 - 13,
                    (ushort)ModContent.TileType<Chunkstone>());
            }
        }

        for (int num5 = i - radius; num5 <= i + radius; num5++)
        {
            for (int num6 = j - radius; num6 <= j + radius; num6++)
            {
                float num7 = Vector2.Distance(new Vector2(num5, num6), new Vector2(i, j));
                if (num7 < radius - 7 && num7 > radius - 22)
                {
                    Main.tile[num5, num6].Active(false);
                }
            }
        }

        for (int num10 = 0; num10 < pointsToGoTo.Count; num10++)
        {
            if (exclusions.Contains(pointsToGoTo[num10]))
            {
                continue;
            }

            AddSnotOrb((int)pointsToGoTo[num10].X, (int)pointsToGoTo[num10].Y);
        }

        for (int num10 = 0; num10 < secondCircleEndpoints.Count; num10++)
        {
            if (exclusions.Contains(secondCircleEndpoints[num10]))
            {
                continue;
            }

            AddSnotOrb((int)secondCircleEndpoints[num10].X, (int)secondCircleEndpoints[num10].Y);
        }

        BoreTunnel2(i, j - radius - 50, i, j - radius + 7, 5, ushort.MaxValue);
        for (int x = i - 12; x < i + 12; x++)
        {
            for (int y = j - radius - 50; y < j - radius + 8; y++)
            {
                if (x >= i + 7 || x <= i - 7)
                {
                    Main.tile[x, y].Active(true);
                    Tile tile = Main.tile[x, y];
                    tile.IsHalfBlock = false;
                    tile.Slope = SlopeType.Solid;
                    Main.tile[x, y].TileType = (ushort)ModContent.TileType<Chunkstone>();
                }

                if (x <= i + 7 && x >= i - 7)
                {
                    Main.tile[x, y].WallType = (ushort)ModContent.WallType<ChunkstoneWall>();
                    Main.tile[x, y].Active(false);
                }
            }
        }

        for (int x = i - 12; x < i + 12; x++)
        {
            for (int y = j - radius - 50; y < j - radius + 8; y++)
            {
                if (x == i + 9 || x == i - 9)
                {
                    int rn = WorldGen.genRand.Next(13, 17);
                    if (y % rn == 0)
                    {
                        MakeCircle(x, y, 3, (ushort)ModContent.TileType<Chunkstone>());
                    }
                }
            }
        }
    }

    /// <summary>
    ///     A helper method to generate a tunnel using MakeCircle().
    /// </summary>
    /// <param name="x0">Starting x coordinate.</param>
    /// <param name="y0">Starting y coordinate.</param>
    /// <param name="x1">Ending x coordinate.</param>
    /// <param name="y1">Ending y coordinate.</param>
    /// <param name="r">Radius.</param>
    /// <param name="type">Type to generate.</param>
    public static void BoreTunnel2(int x0, int y0, int x1, int y1, float r, ushort type)
    {
        bool flag = Math.Abs(y1 - y0) > Math.Abs(x1 - x0);
        if (flag)
        {
            Utils.Swap(ref x0, ref y0);
            Utils.Swap(ref x1, ref y1);
        }

        if (x0 > x1)
        {
            Utils.Swap(ref x0, ref x1);
            Utils.Swap(ref y0, ref y1);
        }

        int num = x1 - x0;
        int num2 = Math.Abs(y1 - y0);
        int num3 = num / 2;
        int num4 = y0 < y1 ? 1 : -1;
        int num5 = y0;
        for (int i = x0; i <= x1; i++)
        {
            if (flag)
            {
                MakeCircle(num5, i, r, type);
            }
            else
            {
                MakeCircle(i, num5, r, type);
            }

            num3 -= num2;
            if (num3 < 0)
            {
                num5 += num4;
                num3 += num;
            }
        }
    }

    /// <summary>
    ///     Makes a circle for the Contagion generation. Fills all tiles with Chunkstone Walls.
    /// </summary>
    /// <param name="x">The x coordinate of the center of the circle.</param>
    /// <param name="y">The y coordinate of the center of the circle.</param>
    /// <param name="r">The radius of the circle.</param>
    /// <param name="type">The type to generate - if ushort.MaxValue, will generate air.</param>
    public static void MakeCircle(int x, int y, float r, ushort type)
    {
        int num = (int)(x - r);
        int num2 = (int)(y - r);
        int num3 = (int)(x + r);
        int num4 = (int)(y + r);
        for (int i = num; i < num3 + 1; i++)
        {
            for (int j = num2; j < num4 + 1; j++)
            {
                if (Vector2.Distance(new Vector2(i, j), new Vector2(x, y)) <= r &&
                    Main.tile[i, j].TileType != TileID.ShadowOrbs)
                {
                    if (type == 65535)
                    {
                        Main.tile[i, j].Active(false);
                        Main.tile[i, j].WallType = (ushort)ModContent.WallType<ChunkstoneWall>();
                    }
                    else
                    {
                        Main.tile[i, j].Active(true);
                        Main.tile[i, j].TileType = type;
                        Main.tile[i, j].WallType = (ushort)ModContent.WallType<ChunkstoneWall>();
                        WorldGen.SquareTileFrame(i, j);
                    }
                }
                //else if (Vector2.Distance(new Vector2(i, j), new Vector2(x, y)) == r - 1)
                //{
                //    Main.tile[i, j].wall = 0;
                //}
            }
        }
    }

    /// <summary>
    ///     Makes an ending circle for the Contagion generation.
    /// </summary>
    /// <param name="x">The x coordinate of the center of the circle.</param>
    /// <param name="y">The y coordinate of the center of the circle.</param>
    /// <param name="r">The radius of the circle.</param>
    /// <param name="type">The type to generate - if ushort.MaxValue, will generate air.</param>
    public static void MakeEndingCircle(int x, int y, float r, ushort type)
    {
        int num = (int)(x - r);
        int num2 = (int)(y - r);
        int num3 = (int)(x + r);
        int num4 = (int)(y + r);
        for (int i = num; i < num3 + 1; i++)
        {
            for (int j = num2; j < num4 + 1; j++)
            {
                if (Vector2.Distance(new Vector2(i, j), new Vector2(x, y)) <= r &&
                    Main.tile[i, j].TileType != TileID.ShadowOrbs)
                {
                    if (type == 65535)
                    {
                        Main.tile[i, j].Active(false);
                        Main.tile[i, j].WallType = (ushort)ModContent.WallType<ChunkstoneWall>();
                    }
                    else
                    {
                        Main.tile[i, j].Active(true);
                        Main.tile[i, j].TileType = type;
                        //Main.tile[i, j].wall = (ushort)ModContent.WallType<Walls.ChunkstoneWall>();
                        WorldGen.SquareTileFrame(i, j);
                    }
                }
                else if (Vector2.Distance(new Vector2(i, j), new Vector2(x, y)) == r - 1)
                {
                    Main.tile[i, j].WallType = (ushort)ModContent.WallType<ChunkstoneWall>();
                }
            }
        }
    }

    /// <summary>
    ///     Adds a Snot Orb at the given coordinates. For the Contagion.
    /// </summary>
    /// <param name="x">X coordinate.</param>
    /// <param name="y">Y coordinate.</param>
    /// <param name="style">Unused.</param>
    public static void AddSnotOrb(int x, int y, int style = 0)
    {
        if (x < 10 || x > Main.maxTilesX - 10)
        {
            return;
        }

        if (y < 10 || y > Main.maxTilesY - 10)
        {
            return;
        }

        for (int i = x - 1; i < x + 1; i++)
        {
            for (int j = y - 1; j < y + 1; j++)
            {
                if (Main.tile[i, j].HasTile && Main.tile[i, j].TileType == (ushort)ModContent.TileType<SnotOrb>())
                {
                    return;
                }
            }
        }

        short num = 0;
        Main.tile[x - 1, y - 1].Active(true);
        Main.tile[x - 1, y - 1].TileType = (ushort)ModContent.TileType<SnotOrb>();
        Main.tile[x - 1, y - 1].TileFrameX = num;
        Main.tile[x - 1, y - 1].TileFrameY = 0;
        Main.tile[x, y - 1].Active(true);
        Main.tile[x, y - 1].TileType = (ushort)ModContent.TileType<SnotOrb>();
        Main.tile[x, y - 1].TileFrameX = (short)(18 + num);
        Main.tile[x, y - 1].TileFrameY = 0;
        Main.tile[x - 1, y].Active(true);
        Main.tile[x - 1, y].TileType = (ushort)ModContent.TileType<SnotOrb>();
        Main.tile[x - 1, y].TileFrameX = num;
        Main.tile[x - 1, y].TileFrameY = 18;
        Main.tile[x, y].Active(true);
        Main.tile[x, y].TileType = (ushort)ModContent.TileType<SnotOrb>();
        Main.tile[x, y].TileFrameX = (short)(18 + num);
        Main.tile[x, y].TileFrameY = 18;
    }
}
