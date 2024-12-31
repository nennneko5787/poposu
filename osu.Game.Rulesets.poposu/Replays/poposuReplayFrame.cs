// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System.Collections.Generic;
using osu.Game.Rulesets.Replays;

namespace osu.Game.Rulesets.poposu.Replays
{
    public class poposuReplayFrame : ReplayFrame
    {
        public List<poposuAction> Actions = new List<poposuAction>();

        public poposuReplayFrame(poposuAction? button = null)
        {
            if (button.HasValue)
                Actions.Add(button.Value);
        }
    }
}
