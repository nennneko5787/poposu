// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using System.Collections.Generic;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Input.Bindings;
using osu.Game.Beatmaps;
using osu.Game.Graphics;
using osu.Game.Rulesets.Difficulty;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.poposu.Beatmaps;
using osu.Game.Rulesets.poposu.Mods;
using osu.Game.Rulesets.poposu.UI;
using osu.Game.Rulesets.UI;

namespace osu.Game.Rulesets.poposu
{
    public class poposuRuleset : Ruleset
    {
        public override string Description => "pop'n";

        public override DrawableRuleset CreateDrawableRulesetWith(IBeatmap beatmap, IReadOnlyList<Mod> mods = null) => new DrawablepoposuRuleset(this, beatmap, mods);

        public override IBeatmapConverter CreateBeatmapConverter(IBeatmap beatmap) => new poposuBeatmapConverter(beatmap, this);

        public override DifficultyCalculator CreateDifficultyCalculator(IWorkingBeatmap beatmap) => new poposuDifficultyCalculator(RulesetInfo, beatmap);

        public override IEnumerable<Mod> GetModsFor(ModType type)
        {
            switch (type)
            {
                case ModType.Automation:
                    return new[] { new poposuModAutoplay() };

                default:
                    return Array.Empty<Mod>();
            }
        }

        public override string ShortName => "poposu";

        public override IEnumerable<KeyBinding> GetDefaultKeyBindings(int variant = 0) => new[]
        {
            new KeyBinding(InputKey.Z, poposuAction.Button1),
            new KeyBinding(InputKey.S, poposuAction.Button2),
            new KeyBinding(InputKey.X, poposuAction.Button3),
            new KeyBinding(InputKey.D, poposuAction.Button4),
            new KeyBinding(InputKey.C, poposuAction.Button5),
            new KeyBinding(InputKey.F, poposuAction.Button6),
            new KeyBinding(InputKey.V, poposuAction.Button7),
            new KeyBinding(InputKey.G, poposuAction.Button8),
            new KeyBinding(InputKey.B, poposuAction.Button9),
        };

        public override Drawable CreateIcon() => new SpriteText
        {
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,
            Text = ShortName[0].ToString(),
            Font = OsuFont.Default.With(size: 18),
        };

        // Leave this line intact. It will bake the correct version into the ruleset on each build/release.
        public override string RulesetAPIVersionSupported => CURRENT_RULESET_API_VERSION;
    }
}
