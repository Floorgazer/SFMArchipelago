from __future__ import annotations

from typing import TYPE_CHECKING

from rule_builder.options import OptionFilter
from rule_builder.rules import Has, HasAll, HasAny, Rule

from BaseClasses import Entrance

#from .options import HardMode
from .utils import *
from .rule_utils import ALL_NEEDED

if TYPE_CHECKING:
    from .world import SFMWorld


def set_all_rules(world: SFMWorld) -> None:
    set_all_entrance_rules(world)
    set_all_locations_rules(world)
    set_completion_condition(world)

def set_all_entrance_rules(world: SFMWorld) -> None:

    for stage_short, stage in STAGES.items():
        main_entrance: Entrance = world.get_entrance("Warp to " + stage)
        world.set_rule(main_entrance, Has(stage))
        for mode, rule in MODES.items():
            if rule is not None:
                mode_entrance = world.get_entrance(stage_short + ": With " + mode)
                world.set_rule(mode_entrance, rule)

def set_all_locations_rules(world: SFMWorld) -> None:

    for stage in LARGE_STAGES:
        for mission, rule in COMMON_FLASH_MISSIONS.items():
            if rule is not None:
                name = stage + ": " + mission
                location = world.get_location(name)
                world.set_rule(location, rule)
        for mission, rule in COMMON_LARGE_FLASH_MISSIONS.items():
            if rule is not None:
                name = stage + ": " + mission
                location = world.get_location(name)
                world.set_rule(location, rule)
        for mission, rule in SPECIAL_FLASH_MISSIONS[stage].items():
            if rule is not None:
                name = stage + ": " + mission
                location = world.get_location(name)
                world.set_rule(location, rule)
        for mission, rule in COMMON_NAKED_MISSIONS.items():
            if rule is not None:
                name = stage + ": " + mission
                location = world.get_location(name)
                world.set_rule(location, rule)
        for mission, rule in COMMON_LARGE_NAKED_MISSIONS.items():
            if rule is not None:
                name = stage + ": " + mission
                location = world.get_location(name)
                world.set_rule(location, rule)
        for mission, rule in SPECIAL_NAKED_MISSIONS[stage].items():
            if rule is not None:
                name = stage + ": " + mission
                location = world.get_location(name)
                world.set_rule(location, rule)
    for stage in MEDIUM_STAGES:
        for mission, rule in COMMON_FLASH_MISSIONS.items():
            if rule is not None:
                name = stage + ": " + mission
                location = world.get_location(name)
                world.set_rule(location, rule)
        for mission, rule in SPECIAL_FLASH_MISSIONS[stage].items():
            if rule is not None:
                name = stage + ": " + mission
                location = world.get_location(name)
                world.set_rule(location, rule)
        for mission, rule in COMMON_NAKED_MISSIONS.items():
            if rule is not None:
                name = stage + ": " + mission
                location = world.get_location(name)
                world.set_rule(location, rule)
        for mission, rule in SPECIAL_NAKED_MISSIONS[stage].items():
            if rule is not None:
                name = stage + ": " + mission
                location = world.get_location(name)
                world.set_rule(location, rule)
    for stage in SMALL_STAGES:
        for mission, rule in COMMON_FLASH_MISSIONS.items():
            if rule is not None:
                name = stage + ": " + mission
                location = world.get_location(name)
                world.set_rule(location, rule)
        for mission, rule in COMMON_SMALL_FLASH_MISSIONS.items():
            if rule is not None:
                name = stage + ": " + mission
                location = world.get_location(name)
                world.set_rule(location, rule)
        for mission, rule in SPECIAL_FLASH_MISSIONS[stage].items():
            if rule is not None:
                name = stage + ": " + mission
                location = world.get_location(name)
                world.set_rule(location, rule)
        for mission, rule in COMMON_NAKED_MISSIONS.items():
            if rule is not None:
                name = stage + ": " + mission
                location = world.get_location(name)
                world.set_rule(location, rule)
        for mission, rule in COMMON_SMALL_NAKED_MISSIONS.items():
            if rule is not None:
                name = stage + ": " + mission
                location = world.get_location(name)
                world.set_rule(location, rule)
        for mission, rule in SPECIAL_NAKED_MISSIONS[stage].items():
            if rule is not None:
                name = stage + ": " + mission
                location = world.get_location(name)
                world.set_rule(location, rule)

        all_missions = world.get_location("All missions complete")
        world.set_rule(all_missions, ALL_NEEDED)

def set_completion_condition(world: SFMWorld) -> None:

    world.set_completion_rule(Has("Victory"))

