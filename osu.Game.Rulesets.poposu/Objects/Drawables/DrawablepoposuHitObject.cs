using System.Collections.Generic;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Framework.Graphics.Textures;
using osu.Game.Rulesets.poposu.UI;
using osu.Game.Audio;
using osuTK;
using osuTK.Graphics;
using osu.Framework.Graphics.Shapes;

namespace osu.Game.Rulesets.poposu.Objects.Drawables
{
    public partial class DrawablepoposuHitObject : DrawableHitObject<poposuHitObject>
    {
        public DrawablepoposuHitObject(poposuHitObject hitObject)
            : base(hitObject)
        {
            Size = new Vector2(40);
            Origin = Anchor.BottomCentre;
            Anchor = Anchor.TopCentre;

            if (hitObject.Lane % 2 == 0)
            {
                X = hitObject.Lane * poposuPlayfield.WIDE_LANE_WIDTH;
            }
            else
            {
                X = hitObject.Lane * poposuPlayfield.NARROW_LANE_WIDTH;
            }

        }

        [BackgroundDependencyLoader]
        private void load(poposuPlayfield playfield, TextureStore textures)
        {
            AddInternal(new Circle
            {
                Origin = Anchor.Centre,
                RelativeSizeAxes = Axes.Both,
                Colour = Color4.White, // ノーツの色
            });
        }

        public override IEnumerable<HitSampleInfo> GetSamples() => new[]
        {
            new HitSampleInfo(HitSampleInfo.HIT_NORMAL)
        };

        protected override void CheckForResult(bool userTriggered, double timeOffset)
        {
            if (timeOffset >= 0)
            {
                ApplyMaxResult();
            }
        }

        protected override void UpdateHitStateTransforms(ArmedState state)
        {
            switch (state)
            {
                case ArmedState.Hit:
                    this.ScaleTo(5, 1500, Easing.OutQuint).FadeOut(1500, Easing.OutQuint).Expire();
                    break;

                case ArmedState.Miss:

                    const double duration = 1000;

                    this.ScaleTo(0.8f, duration, Easing.OutQuint);
                    this.MoveToOffset(new Vector2(0, 10), duration, Easing.In);
                    this.FadeColour(Color4.Red, duration / 2, Easing.OutQuint).Then().FadeOut(duration / 2, Easing.InQuint).Expire();
                    break;
            }
        }
    }
}
