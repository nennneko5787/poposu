// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Game.Beatmaps;
using osu.Game.Rulesets.poposu.Objects;
using osu.Game.Rulesets.Replays;

namespace osu.Game.Rulesets.poposu.Replays
{
    public class poposuAutoGenerator : AutoGenerator<poposuReplayFrame>
    {
        public new Beatmap<poposuHitObject> Beatmap => (Beatmap<poposuHitObject>)base.Beatmap;

        public poposuAutoGenerator(IBeatmap beatmap)
            : base(beatmap)
        {
        }

        protected override void GenerateFrames()
        {
            Frames.Add(new poposuReplayFrame());

            foreach (poposuHitObject hitObject in Beatmap.HitObjects)
            {
                Frames.Add(new poposuReplayFrame
                {
                    Time = hitObject.StartTime
                    // todo: add required inputs and extra frames.
                });
            }
        }
    }
}
