from dataclasses import dataclass

from Options import Choice, OptionGroup, PerGameCommonOptions, Range, Toggle

class Day(Toggle):
    display_name = "Day"

class TrapChance(Range):
    display_name = "Trap Chance"

    range_start = 0
    range_end = 100
    default = 0

@dataclass
class SFMOptions(PerGameCommonOptions):
    day: Day
    trap_chance: TrapChance
