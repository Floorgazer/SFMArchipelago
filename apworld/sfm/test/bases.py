from test.bases import WorldTestBase

from ..world import SFMWorld

class SFMTestBase(WorldTestBase):
    game = "SFM"
    world = SFMWorld
