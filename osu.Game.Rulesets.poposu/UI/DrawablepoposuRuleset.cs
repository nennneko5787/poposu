// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System.Collections.Generic;
using osu.Framework.Allocation;
using osu.Framework.Input;
using osu.Game.Beatmaps;
using osu.Game.Input.Handlers;
using osu.Game.Replays;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.poposu.Objects;
using osu.Game.Rulesets.poposu.Objects.Drawables;
using osu.Game.Rulesets.poposu.Replays;
using osu.Game.Rulesets.UI;
using osu.Game.Rulesets.UI.Scrolling;

namespace osu.Game.Rulesets.poposu.UI
{
    [Cached]
    public partial class DrawablepoposuRuleset : DrawableScrollingRuleset<poposuHitObject>
    {
        public DrawablepoposuRuleset(poposuRuleset ruleset, IBeatmap beatmap, IReadOnlyList<Mod> mods = null)
            : base(ruleset, beatmap, mods)
        {
            Direction.Value = ScrollingDirection.Left;
            TimeRange.Value = 6000;
        }

        protected override Playfield CreatePlayfield() => new poposuPlayfield();

        protected override ReplayInputHandler CreateReplayInputHandler(Replay replay) => new poposuFramedReplayInputHandler(replay);

        public override DrawableHitObject<poposuHitObject> CreateDrawableRepresentation(poposuHitObject h) => new DrawablepoposuHitObject(h);

        protected override PassThroughInputManager CreateInputManager() => new poposuInputManager(Ruleset?.RulesetInfo);
    }
}
