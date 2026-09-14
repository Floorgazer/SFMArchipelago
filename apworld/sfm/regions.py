from __future__ import annotations

from typing import TYPE_CHECKING

from BaseClasses import Entrance, Region

from .utils import STAGES, MODES

if TYPE_CHECKING:
    from .world import SFMWorld

def create_and_connect_regions(world: SFMWorld) -> None:
    create_all_regions(world)
    connect_regions(world)

def create_all_regions(world: SFMWorld) -> None:

    regions = []

    def reg(str) -> Region:
        regions.append(Region(str, world.player, world.multiworld))

    reg("Home")

    for stage_short, stage in STAGES.items():
        reg(stage)
        for mode in MODES:
            reg(stage_short + ": " + mode)

    world.multiworld.regions += regions

def connect_regions(world: SFMWorld) -> None:
    home = world.get_region("Home")
    residential = world.get_region("Residential Area")
    park = world.get_region("Central Park")
    store = world.get_region("Convenience Store")
    downtown = world.get_region("Downtown")
    apartment = world.get_region("Apartment")
    mall = world.get_region("Shopping Mall")
    shop = world.get_region("Clothes Shop")

    for stage_short, stage in STAGES.items():
        main_region = world.get_region(stage)
        home.connect(main_region, "Warp to " + stage),
        for mode in MODES:
            mode_region = world.get_region(stage_short + ": " + mode)
            main_region.connect(mode_region, stage_short + ": With " + mode)
