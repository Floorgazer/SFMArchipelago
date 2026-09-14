from __future__ import annotations

from typing import TYPE_CHECKING

from BaseClasses import ItemClassification, Location

from . import items
from .utils import *

if TYPE_CHECKING:
    from .world import SFMWorld

# TODO: Normalise this stuff through utils


LOCATION_NAME_TO_ID = {
    #TODO: Fill this
}

LOCATIONS_BY_STAGE_FLASH = {

}
LOCATIONS_BY_STAGE_NAKED = {

}

for istage, stage in enumerate(LARGE_STAGES):
    LOCATIONS_BY_STAGE_FLASH[stage] = []
    LOCATIONS_BY_STAGE_NAKED[stage] = []
    id_val = 100 * istage
    for mission in COMMON_FLASH_MISSIONS:
        name = stage + ": " + mission
        LOCATION_NAME_TO_ID[name] = id_val
        LOCATIONS_BY_STAGE_FLASH[stage].append(name)
        id_val += 1
    for mission in COMMON_LARGE_FLASH_MISSIONS:
        name = stage + ": " + mission
        LOCATION_NAME_TO_ID[name] = id_val
        LOCATIONS_BY_STAGE_FLASH[stage].append(name)
        id_val += 1
    for mission in SPECIAL_FLASH_MISSIONS[stage]:
        name = stage + ": " + mission
        LOCATION_NAME_TO_ID[name] = id_val
        LOCATIONS_BY_STAGE_FLASH[stage].append(name)
        id_val += 1
    for mission in COMMON_NAKED_MISSIONS:
        name = stage + ": " + mission
        LOCATION_NAME_TO_ID[name] = id_val
        LOCATIONS_BY_STAGE_NAKED[stage].append(name)
        id_val += 1
    for mission in COMMON_LARGE_NAKED_MISSIONS:
        name = stage + ": " + mission
        LOCATION_NAME_TO_ID[name] = id_val
        LOCATIONS_BY_STAGE_NAKED[stage].append(name)
        id_val += 1
    for mission in SPECIAL_NAKED_MISSIONS[stage]:
        name = stage + ": " + mission
        LOCATION_NAME_TO_ID[name] = id_val
        LOCATIONS_BY_STAGE_NAKED[stage].append(name)
        id_val += 1
for istage, stage in enumerate(MEDIUM_STAGES):
    LOCATIONS_BY_STAGE_FLASH[stage] = []
    LOCATIONS_BY_STAGE_NAKED[stage] = []
    id_val = 100 * (istage + len(LARGE_STAGES))
    for mission in COMMON_FLASH_MISSIONS:
        name = stage + ": " + mission
        LOCATION_NAME_TO_ID[name] = id_val
        LOCATIONS_BY_STAGE_FLASH[stage].append(name)
        id_val += 1
    for mission in SPECIAL_FLASH_MISSIONS[stage]:
        name = stage + ": " + mission
        LOCATION_NAME_TO_ID[name] = id_val
        LOCATIONS_BY_STAGE_FLASH[stage].append(name)
        id_val += 1
    for mission in COMMON_NAKED_MISSIONS:
        name = stage + ": " + mission
        LOCATION_NAME_TO_ID[name] = id_val
        LOCATIONS_BY_STAGE_NAKED[stage].append(name)
        id_val += 1
    for mission in SPECIAL_NAKED_MISSIONS[stage]:
        name = stage + ": " + mission
        LOCATION_NAME_TO_ID[name] = id_val
        LOCATIONS_BY_STAGE_NAKED[stage].append(name)
        id_val += 1
for istage, stage in enumerate(SMALL_STAGES):
    LOCATIONS_BY_STAGE_FLASH[stage] = []
    LOCATIONS_BY_STAGE_NAKED[stage] = []
    id_val = 100 * (istage + len(LARGE_STAGES) + len(MEDIUM_STAGES))
    for mission in COMMON_FLASH_MISSIONS:
        name = stage + ": " + mission
        LOCATION_NAME_TO_ID[name] = id_val
        LOCATIONS_BY_STAGE_FLASH[stage].append(name)
        id_val += 1
    for mission in COMMON_SMALL_FLASH_MISSIONS:
        name = stage + ": " + mission
        LOCATION_NAME_TO_ID[name] = id_val
        LOCATIONS_BY_STAGE_FLASH[stage].append(name)
        id_val += 1
    for mission in SPECIAL_FLASH_MISSIONS[stage]:
        name = stage + ": " + mission
        LOCATION_NAME_TO_ID[name] = id_val
        LOCATIONS_BY_STAGE_FLASH[stage].append(name)
        id_val += 1
    for mission in COMMON_NAKED_MISSIONS:
        name = stage + ": " + mission
        LOCATION_NAME_TO_ID[name] = id_val
        LOCATIONS_BY_STAGE_NAKED[stage].append(name)
        id_val += 1
    for mission in COMMON_SMALL_NAKED_MISSIONS:
        name = stage + ": " + mission
        LOCATION_NAME_TO_ID[name] = id_val
        LOCATIONS_BY_STAGE_NAKED[stage].append(name)
        id_val += 1
    for mission in SPECIAL_NAKED_MISSIONS[stage]:
        name = stage + ": " + mission
        LOCATION_NAME_TO_ID[name] = id_val
        LOCATIONS_BY_STAGE_NAKED[stage].append(name)
        id_val += 1


class SFMLocation(Location):
    game = "SFM"

def get_location_names_with_ids(location_names: list[str]) -> dict[str, int | None]:
    return {location_name: LOCATION_NAME_TO_ID[location_name] for location_name in location_names}


def create_all_locations(world: SFMWorld) -> None:
    create_regular_locations(world)
    create_events(world)

def create_regular_locations(world: SFMWorld) -> None:

    for stage in LARGE_STAGES + MEDIUM_STAGES + SMALL_STAGES:
        flash_region = world.get_region(stage + ": Flash");
        flash_region.add_locations(get_location_names_with_ids(LOCATIONS_BY_STAGE_FLASH[stage]), SFMLocation)
        naked_region = world.get_region(stage + ": Naked");
        naked_region.add_locations(get_location_names_with_ids(LOCATIONS_BY_STAGE_NAKED[stage]), SFMLocation)

def create_events(world: SFMWorld) -> None:

    home = world.get_region("Home");
    home.add_event("All missions complete", "Victory", location_type=SFMLocation, item_type=items.SFMItem)

