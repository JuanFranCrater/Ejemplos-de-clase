using System;

namespace MyTweens
{
   [Serializable]
    public class Ease
    {
        public EaseCurve Curve;

        public float InterpolateSwitch(float time, float baseValue, float change, float duration)
        {
            float value = 0;
            switch (Curve)
            {
                case EaseCurve.linear:
                    value = Linear(time, baseValue, change, duration);
                    break;
                case EaseCurve.EaseInOutQuad:
                    break;
                case EaseCurve.EaseInQuad:
                    value = QuadIn(time, baseValue, change, duration);
                    break;
                case EaseCurve.EaseOutQuad:
                    value = QuadOut(time, baseValue, change, duration);
                    break;
                default:
                    value = 0;
                    break;
            }
            return value;
        }
        #region
        public float Interpolate(float time, float baseValue, float change, float duration)
        {
            return (methods[(int)Curve](time, baseValue, change, duration));
        }

        delegate float EaseDelegate(float time, float baseValue, float change, float duration);

        static EaseDelegate[] methods = new EaseDelegate[]
        {
            Linear,
            QuadIn,
            QuadOut,
            QuadInOut
        };

        private static float QuadInOut(float time, float baseValue, float change, float duration)
        {
            return 1;
        }

        public static float Linear(float time, float baseValue, float change, float duration)
        {
            return change * time / duration + baseValue;
        }
        public static float QuadIn(float time, float baseValue, float change, float duration)
        {
            return change * (time /= duration) * (time) + baseValue;
        }
        public static float QuadOut(float time, float baseValue, float change, float duration)
        {
            return -change * (time /= duration) * (time - 2) + baseValue;
        }

        #endregion
    }
}