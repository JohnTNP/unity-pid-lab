using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FourBarLink
{
    public class FourBar
    {
        private float a, b, c, d;
        private float[] angle = {0, 0, 0};
        public FourBar(float _a, float _b, float _c, float _d)
        {
            a = _a;
            b = _b;
            c = _c;
            d = _d;
        }

        public float[] FourBarAngle(float _input)
        {
            float A = b*b + c*c;
            float B = 2*b*c;

            angle[0] = _input;
            float r = d - a*Mathf.Cos(angle[0]);
            float s = a*Mathf.Sin(angle[0]);
            float f2 = r*r + s*s;
            float sigma = Mathf.Acos((A - f2)/B);
            float g = b - c*Mathf.Cos(sigma);
            float h = c*Mathf.Sin(sigma);
            angle[1] = Mathf.Atan2(h*r - g*s, g*r + h*s);
            angle[2] = angle[1] + sigma;
            //angle[2] = 0.0165f*((float)(Math.Pow(angle[0],4))) - 0.2448f*((float)(Math.Pow(angle[0], 3))) + 1.019f*((float)(Math.Pow(angle[0], 2))) - 0.8601f*angle[0] + 1.225f;
            float[] angles = {angle[1], angle[2]};
            return angles;
        }
    }
}
