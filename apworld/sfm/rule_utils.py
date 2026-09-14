from rule_builder.rules import Has, HasAll, HasAny, HasAllCounts, Rule, True_

POSE = HasAny("Spread-Leg BJ",
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
        "Spread-Leg Urination",
        "Standing Pee",
        "Dog Pee",
        "Masturbate",
        "Three-Leg Masturbation",
        "Supine Masturbation",
        "Doggy Masturbation",
        "Nipple Play",
        "Clit Play") | HasAll("Futanari Pill", "Stroking")

CLIMAX = HasAny("Masturbate",
        "Three-Leg Masturbation",
        "Supine Masturbation",
        "Doggy Masturbation",
        "Nipple Play",
        "Clit Play") | HasAny("Vibrator", "Piston", "Dildo") | HasAll("Futanari Pill", "Stroking")

SPLASH = Has("Futanari Pill") & (HasAny("Masturbate",
        "Three-Leg Masturbation",
        "Supine Masturbation",
        "Doggy Masturbation",
        "Nipple Play",
        "Clit Play") | HasAny("Vibrator", "Piston", "Dildo"))

NAKED = Has("Progressive Coat", count=2)

ALL_NEEDED = NAKED & Has("Flash Butt") & POSE & HasAll("Vibrator", "Eye Mask", "Handcuffs", "Futanari Pill") & HasAll("Residential Area", "Central Park", "Convenience Store", "Apartment", "Downtown", "Shopping Mall", "Clothes Shop")
