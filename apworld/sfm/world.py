from collections.abc import Mapping
from typing import Any

from worlds.AutoWorld import World

from . import items, locations, regions, rules, web_world
from . import options as sfm_options

class SFMWorld(World):
    game = "SFM"

    web = web_world.SFMWebWorld()

    options_dataclass = sfm_options.SFMOptions
    options: sfm_options.SFMOptions

    location_name_to_id = locations.LOCATION_NAME_TO_ID
    item_name_to_id = items.ITEM_NAME_TO_ID

    origin_region_name = "Home"

    explicit_indirect_conditions = True

    def create_regions(self) -> None:
        regions.create_and_connect_regions(self)
        locations.create_all_locations(self)

    def set_rules(self) -> None:
        rules.set_all_rules(self)

    def create_items(self) -> None:
        items.create_all_items(self)

    def create_item(self, name: str) -> items.SFMItem:
        return items.create_item_with_correct_classification(self, name)

    def get_filler_item_name(self) -> str:
        return items.get_random_filler_item_name(self)

    # May need fill_slot_data ?
    def fill_slot_data(self) -> Mapping[str, Any]:
        # TODO: Make ranges options
        data = {}
        data["height"] = self.random.randint(140,180)
        data["boob_size"] = self.random.randint(0,100)
        data["penis_size"] = self.random.randint(0,50)

        data["skin_col"] = self.random.randint(0,18)
        data["eye_col"] = self.random.randint(0,49)
        data["heterochromia"] = self.random.randint(0,1) == 1
        data["left_eye_col"] = self.random.randint(0,49)
        data["fang"] = self.random.randint(0,1) == 1

        data["hair"] = self.random.randint(0,20)
        data["hair_col_pattern"] = self.random.randint(0,6)
        data["hair_R"] = self.random.randint(0,100)
        data["hair_G"] = self.random.randint(0,100)
        data["hair_B"] = self.random.randint(0,100)

        return data
