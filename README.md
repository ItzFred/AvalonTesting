# Exxo Avalon Origins

Exxo Avalon Origins is the tModLoader reimplementation of the tConfig Terraria Avalon mod.

Stay updated and join the discord community: <https://discord.gg/rtm99Uq>

## Todo List

### General

* Update to-do list

### Pre-Release

* Fix even more consumables
* Fix more buffs
* Do late-game world gen
* Make sure some less major stuff works
* Do even more World Gen
* Add NPC Gore
* Do many minor (usually decorative) tile things
* Fix a few NPC AIs
* Implement Dusts
* Rewrite Team Mirror
* Fit Avalon progression within the 1.3.x progression
* Fix more bugs
* Add missing stuff
* Fit expert mode items (and maybe AIs) in and disable expert mode
* Do Primordial Ore
* Fix Oblivion
* FIX ISSUES
* Remove items that were added in vanilla 1.3

### Extra

* Redo Desert Beak and Bacterium Prime
* Get many sprites updated
* Add better boss health bars (using event progress bars)
* Add Ultrablivion and other TConfig only stuff
* Dye Slimes
* Add Death point mirror
* Clean up code
* Add more content
* Cross mod compatibility
* Potion campfires
* Moar campfires, heart lanterns and such
* Add and implement Contagion
* Add the Tropics

### Easier Recipes

* Chlorophyte armor and weapons

# Compiling shaders on linux

Download fxcompiler and reach
from https://github.com/tModLoader/tModLoader/wiki/Expert-Shader-Guide#compiling-your-shader

Extract fxcompiler.zip and move the fxcompiler_reach.exe to the fxcompiler folder

Create a new wineprefix using the following commnand `WINEPREFIX=~/.dotnet winecfg`

Open winetricks using the command `WINEPREFIX=~/.dotnet winetricks` and select default wineprefix and install component
xna40

Use the the following command to now run fxcompiler_reach.exe `WINEPREFIX=~/.dotnet wine ./fxcompiler_reach.exe`

You can also create a helper shell script containing the following:

```shell
#!/bin/sh
WINEPREFIX=~/.dotnet wine ./fxcompiler_reach.exe
```