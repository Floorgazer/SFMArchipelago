from BaseClasses import Tutorial
from worlds.AutoWorld import WebWorld

#from .options import option_groups, option_presets


# For our game to display correctly on the website, we need to define a WebWorld subclass.
class SFMWebWorld(WebWorld):
    # We need to override the "game" field of the WebWorld superclass.
    # This must be the same string as the regular World class.
    game = "SFM"

    # Your game pages will have a visual theme (affecting e.g. the background image).
    # You can choose between dirt, grass, grassFlowers, ice, jungle, ocean, partyTime, and stone.
    theme = "grassFlowers"


    # If we have option groups and/or option presets, we need to specify these here as well.
    #option_groups = option_groups
    #options_presets = option_presets
