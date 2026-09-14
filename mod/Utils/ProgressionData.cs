using System.Collections.Generic;

using ExposureUnnoticed2.Master.Stage;
using ExposureUnnoticed2.Master.Skill;
using ExposureUnnoticed2.Master.RankRelease;

namespace SFMArchipelago;

public class ProgressionData
{
    public int progressiveCoatCount = 0;
    public int progressiveUpgradeCount = 0;
    public int progressiveSlowMotionCount = 0;
    public int progressiveCostumeCount = 0;

    public Dictionary<StageType,bool> StageRelease = new();
    public Dictionary<SkillType,bool> SkillRelease = new();
    public Dictionary<RankReleaseType,bool> RankRelease = new();
}
