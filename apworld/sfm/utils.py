from rule_builder.rules import Has, HasAll, HasAny, HasAllCounts, Rule, True_

from .rule_utils import *

STAGES = {
    "RA": "Residential Area",
    "CP": "Central Park",
    "CO": "Convenience Store",
    "DT": "Downtown",
    "AP": "Apartment",
    "SM": "Shopping Mall",
    "CL": "Clothes Shop",
}

MODES = {
    "Flash": None,
    "Naked": NAKED,
}



COMMON_FLASH_MISSIONS = {
    "Flash front": None,
    "Flash butt": Has("Flash Butt"),
    "Flash upper body": Has("Progressive Coat"),
    "Pose": POSE,
    "Urinate": None,
    "Dildo": Has("Dildo"),
    "Climax near someone": CLIMAX,
    "Handcuffs near someone": Has("Handcuffs"),
    "Handcuffs object": Has("Handcuffs"),
    "Splash someone": SPLASH,
}

COMMON_NAKED_MISSIONS = {
    "Naked": None,
    "Naked Dildo": Has("Dildo"),
}

COMMON_LARGE_FLASH_MISSIONS = {
    "Flash in light": None,
    "Use vending machine while flashing": None,
    "Flash near someone": None,
    "Flash while watched": None,
    "Show off flashed parts": None,
}
COMMON_LARGE_NAKED_MISSIONS = {
    "Naked in light": None,
    "Vending machine while naked": None,
    "Naked near someone": None,
    "Show off naked body": None,
}

COMMON_SMALL_FLASH_MISSIONS = {
    "Flash near someone": None,
    "Flash while watched": None,
    "Show off flashed parts": None,
}
COMMON_SMALL_NAKED_MISSIONS = {
    "Naked near someone": None,
    "Show off naked body": None,
}

SPECIAL_FLASH_MISSIONS = {
    "RA": {
        "Move 50m with vibe while flashing": Has("Vibrator"),
        "Press intercom and wait while flashing": None,
        "Be in crosswalk while flashing": None,
        "Move 50m while flashing and blindfolded": Has("Eye Mask"),
    },
    "CP": {
        "Sit on chair while flashing": None,
        "Be in plaza while flashing": None,
        "Move 60m with vibe while flashing": Has("Vibrator"),
        "Move 60m while flashing and blindfolded": Has("Eye Mask"),
    },
    "DT": {
        "Be in footbridge while flashing": None,
        "Move 50m with vibe while flashing": Has("Vibrator"),
        "Move 50m while flashing and blindfolded": Has("Eye Mask"),
    },
    "SM": {
        "Sit on chair while flashing": None,
        "Move 50m with vibe while flashing": Has("Vibrator"),
        "Move on escalator while flashing": None,
        "Ride elevator with someone while flashing": None,
        "Move 40m while flashing and blindfolded": Has("Eye Mask"),
    },
    "AP": {
        "Move 25m with vibe while flashing": Has("Vibrator"),
        "Be in entrance while flashing": None,
        "Press intercom and wait while flashing": None,
        "Ride elevator with someone while flashing": None,
        "Move 25m while flashing and blindfolded": Has("Eye Mask"),
    },
    "CO": {
        "Be in counter while flashing": None,
        "Flash while being served": None,
    },
    "CL": {
        "Move 15m with vibe while flashing": Has("Vibrator"),
        "Move 15m while flashing and blindfolded": Has("Eye Mask"),
    },
}

SPECIAL_NAKED_MISSIONS = {
    "RA": {
        "Press intercom and wait while naked": None,
        "Move 60m with vibe while naked": Has("Vibrator"),
        "Move 25m while naked and crouching": None,
        "Be in crosswalk while naked": None,
        "Move 50m while naked and blindfolded": Has("Eye Mask"),
        "Move 90m away from coat": None,
    },
    "CP": {
        "Sit on chair while naked": None,
        "Be in plaza while naked": None,
        "Move 80m away from coat": None,
        "Move 60m with vibe while naked": Has("Vibrator"),
        "Move 25m while naked and crouching": None,
        "Leave coat outside and stay in stall": None,
        "Move 60m while naked and blindfolded": Has("Eye Mask"),
    },
    "DT": {
        "Move 30m with vibe while naked": Has("Vibrator"),
        "Move 15m while naked and crouching": None,
        "Leave coat outside bridge and stand on": None,
        "Wash clothes": None,
        "Move 30m while naked and blindfolded": Has("Eye Mask"),
        "Move 95m away from coat": None,
    },
    "SM": {
        "Sit on chair while naked": None,
        "Ride elevator with someone while naked": None,
        "Move on escalator while naked": None,
        "Move 25m while naked and crouching": None,
        "Leave coat outside elevator and use it": None,
        "Move 1 floor away from coat": None,
        "Move 60m with vibe while naked": Has("Vibrator"),
        "Move 2 floors away from coat": None,
        "Move 100m away from coat": None,
        "Move 40m while naked and blindfolded": Has("Eye Mask"),
    },
    "AP": {
        "Be in entrance while naked": None,
        "Move 25m with vibe while naked": Has("Vibrator"),
        "Press intercom and wait while naked": None,
        "Ride elevator with someone while naked": None,
        "Move 25m while naked and blindfolded": Has("Eye Mask"),
        "Leave coat outside and go to top floor": None,
        "Leave coat outside and stop at every floor": None,
    },
    "CO": {
        "Be in counter while naked": None,
        "Move 12m away from coat": None,
        "Move 7m while naked and crouching": None,
    },
    "CL": {
        "Leave coat in fitting room and move 17m away": None,
        "Move 15m with vibe while naked": Has("Vibrator"),
        "Move 10m while naked and crouching": None,
        "Move 15m while naked and blindfolded": Has("Eye Mask"),
    },
}


LARGE_STAGES = [
    "RA",
    "CP",
    "DT",
    "SM",
]
MEDIUM_STAGES = [
    "AP",
]
SMALL_STAGES = [
    "CO",
    "CL",
]
