from __future__ import annotations

from typing import TYPE_CHECKING

from BaseClasses import Item, ItemClassification

from .utils import STAGES

if TYPE_CHECKING:
    from .world import SFMWorld

ITEM_NAME_TO_ID = {
        # TODO: fill this

        # Stages
        "Residential Area": 1,
        "Central Park": 2,
        "Convenience Store": 3,
        "Apartment": 4,
        "Downtown": 5,
        "Shopping Mall": 6,
        "Clothes Shop": 7,
        "Daytime": 8, # For later ideas

        # Flash Options
        "Progressive Coat": 10, # Two stages, Upper Body and Naked
        "Flash Butt": 11,

        # Key Items
        "Drone": 20,
        "Futanari Pill": 21,
        "Handcuffs": 22,
        "Vibrator": 23,
        "Dildo": 24,
        "Eye Mask": 25,

        # Important but not progression
        "Piston": 26,
        "Body Paint": 27,
        "Progressive Upgrades": 28, # 3 tiers

        # General Poses
        "Spread-Leg BJ": 100,
        "I-Split Balance": 101,
        "Dogeza": 102,
        "Butt Wiggle": 103,
        "Hand Bra": 104,
        "Double Peace": 105,
        "All-Fours": 106,
        "Spread-Leg Walk": 107,
        "Penis": 108,
        "One-Leg Raise": 109,
        "Armpit Squat": 110,
        "High-Leg": 111,
        "Hip Thrust": 112,
        # Urination Poses
        "Spread-Leg Urination": 120,
        "Standing Pee": 121,
        "Dog Pee": 122,
        # Ecstacy Poses
        "Masturbate": 130,
        "Three-Leg Masturbation": 131,
        "Supine Masturbation": 132,
        "Doggy Masturbation": 133,
        "Nipple Play": 134,
        "Clit Play": 135,
        "Stroking": 136, # Futa Only!

        # General Skills
        "Show NPC Direction": 150,
        "Progressive Slow Motion": 151, # 5 tiers
        "Auto Slow": 152, # Needs slow motion
        "Frequent Urination": 153,
        "X-Ray Vision": 154,
        "Casual Outfit Anywhere": 155,
        "Equipment Effects Disabled": 156,
        "Walker": 157,
        "Mission Cannot Be Interrupted": 158,
        "Fixed First-Person View": 159,
        "Fixed Third-Person View": 160,
        "Hard Mode": 161,
        "Progressive Costume Slot Expansion": 162, # 3 tiers
        # Irrelevant Skills
        "Ah, I'm Finished": 170,
        "Time Stop": 171,
        "Exhibitionist Urge": 172,

        # Infinite Filler Items
        "Small RP Bonus": 200,
        "Big RP Bonus": 201,
        # Traps
        "Handcuff Trap": 210, # Handcuffs you and drops the key randomly
        "Big Trap": 211, # Makes you really big for a while
        "Small Trap": 212, # Makes you really small for a while
        "Suspicious Trap": 213, # Changes your costume set to a suspicious one for a while

}

DEFAULT_ITEM_CLASSIFICATIONS = {
        # TODO: fill this too

        # Stages
        "Residential Area": ItemClassification.progression,
        "Central Park": ItemClassification.progression,
        "Convenience Store": ItemClassification.progression,
        "Apartment": ItemClassification.progression,
        "Downtown": ItemClassification.progression,
        "Shopping Mall": ItemClassification.progression,
        "Clothes Shop": ItemClassification.progression,
        "Daytime": ItemClassification.progression,

        # Flash Options
        "Progressive Coat": ItemClassification.progression,
        "Flash Butt": ItemClassification.progression,

        # Key Items
        "Drone": ItemClassification.progression,
        "Futanari Pill": ItemClassification.progression,
        "Handcuffs": ItemClassification.progression,
        "Vibrator": ItemClassification.progression,
        "Dildo": ItemClassification.progression,
        "Eye Mask": ItemClassification.progression,

        # Important but not strictly necessary
        "Piston": ItemClassification.progression,
        "Body Paint": ItemClassification.useful,
        "Progressive Upgrades": ItemClassification.useful,

        # General Poses
        "Spread-Leg BJ": ItemClassification.progression,
        "I-Split Balance": ItemClassification.progression,
        "Dogeza": ItemClassification.progression,
        "Butt Wiggle": ItemClassification.progression,
        "Hand Bra": ItemClassification.progression,
        "Double Peace": ItemClassification.progression,
        "All-Fours": ItemClassification.progression,
        "Spread-Leg Walk": ItemClassification.progression,
        "Penis": ItemClassification.progression,
        "One-Leg Raise": ItemClassification.progression,
        "Armpit Squat": ItemClassification.progression,
        "High-Leg": ItemClassification.progression,
        "Hip Thrust": ItemClassification.progression,
        # Urination Poses
        "Spread-Leg Urination": ItemClassification.progression,
        "Standing Pee": ItemClassification.progression,
        "Dog Pee": ItemClassification.progression,
        # Ecstacy Poses
        "Masturbate": ItemClassification.progression,
        "Three-Leg Masturbation": ItemClassification.progression,
        "Supine Masturbation": ItemClassification.progression,
        "Doggy Masturbation": ItemClassification.progression,
        "Nipple Play": ItemClassification.progression,
        "Clit Play": ItemClassification.progression,
        "Stroking": ItemClassification.progression,

        # General Skills
        "Show NPC Direction": ItemClassification.useful,
        "Progressive Slow Motion": ItemClassification.useful,
        "Auto Slow": ItemClassification.useful,
        "Frequent Urination": ItemClassification.useful,
        "X-Ray Vision": ItemClassification.useful,
        "Casual Outfit Anywhere": ItemClassification.useful,
        "Equipment Effects Disabled": ItemClassification.useful,
        "Walker": ItemClassification.useful,
        "Mission Cannot Be Interrupted": ItemClassification.useful,
        "Fixed First-Person View": ItemClassification.useful,
        "Fixed Third-Person View": ItemClassification.useful,
        "Hard Mode": ItemClassification.useful,
        "Progressive Costume Slot Expansion": ItemClassification.useful,
        # Irrelevant Skills
        "Ah, I'm Finished": ItemClassification.filler,
        "Time Stop": ItemClassification.filler,
        "Exhibitionist Urge": ItemClassification.filler,

        # Infinite Filler Items
        "Small RP Bonus": ItemClassification.filler,
        "Big RP Bonus": ItemClassification.filler,
        # Traps
        "Handcuff Trap": ItemClassification.trap,
        "Big Trap": ItemClassification.trap,
        "Small Trap": ItemClassification.trap,
        "Suspicious Trap": ItemClassification.trap,
}

class SFMItem(Item):
    game = "SFM"


def get_random_filler_item_name(world: SFMWorld) -> str:
    traps = [
        "Handcuff Trap",
        "Big Trap",
        "Small Trap",
        "Suspicious Trap",
    ]
    filler = [
        "Small RP Bonus",
        "Big RP Bonus",
    ]
    if world.random.randint(0,99) < world.options.trap_chance:
        return traps[world.random.randint(0,len(traps)-1)]
    return filler[world.random.randint(0,len(filler)-1)]

def create_item_with_correct_classification(world: SFMWorld, name: str) -> SFMItem:
    classification = DEFAULT_ITEM_CLASSIFICATIONS[name]

    return SFMItem(name, classification, ITEM_NAME_TO_ID[name], world.player)

def create_all_items(world: SFMWorld) -> None:

    items = [
        # Stages
        "Residential Area",
        "Central Park",
        "Convenience Store",
        "Apartment",
        "Downtown",
        "Shopping Mall",
        "Clothes Shop",
        "Daytime",

        # Flash Options
        "Progressive Coat",
        "Progressive Coat",
        "Flash Butt",

        # Key Items
        "Drone",
        "Futanari Pill",
        "Handcuffs",
        "Vibrator",
        "Dildo",
        "Eye Mask",
        # Important but not progression
        "Piston",
        "Body Paint",
        "Progressive Upgrades",
        "Progressive Upgrades",
        "Progressive Upgrades",

        # General Poses
        "Spread-Leg BJ",
        "I-Split Balance",
        "Dogeza",
        "Butt Wiggle",
        "Hand Bra",
        "Double Peace",
        "All-Fours",
        "Spread-Leg Walk",
        "Penis",
        "One-Leg Raise",
        "Armpit Squat",
        "High-Leg",
        "Hip Thrust",
        # Urination Poses
        "Spread-Leg Urination",
        "Standing Pee",
        "Dog Pee",
        # Ecstacy Poses
        "Masturbate",
        "Three-Leg Masturbation",
        "Supine Masturbation",
        "Doggy Masturbation",
        "Nipple Play",
        "Clit Play",
        "Stroking", # Futa Only!

        # General Skills
        "Show NPC Direction",
        "Progressive Slow Motion",
        "Progressive Slow Motion",
        "Progressive Slow Motion",
        "Progressive Slow Motion",
        "Progressive Slow Motion",
        "Auto Slow",
        "Frequent Urination",
        "X-Ray Vision",
        "Casual Outfit Anywhere",
        "Equipment Effects Disabled",
        "Walker",
        "Mission Cannot Be Interrupted",
        "Fixed First-Person View",
        "Fixed Third-Person View",
        "Hard Mode",
        "Progressive Costume Slot Expansion",
        "Progressive Costume Slot Expansion",
        "Progressive Costume Slot Expansion",
        # Irrelevant Skills
        "Ah, I'm Finished",
        "Time Stop",
        "Exhibitionist Urge",
    ]

    itempool: list[Item] = [world.create_item(i) for i in items]
    starting_stage = itempool.pop(world.random.randint(0,6));

    number_of_items = len(itempool)
    number_of_unfilled_locations = len(world.multiworld.get_unfilled_locations(world.player))
    needed_filler_items = number_of_unfilled_locations - number_of_items
    itempool += [world.create_filler() for _ in range(needed_filler_items)]

    world.multiworld.itempool += itempool

    # TODO: Starting items?

    world.push_precollected(starting_stage)


