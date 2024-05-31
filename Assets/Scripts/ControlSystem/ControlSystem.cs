using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ControlSystem
{
    public class BallBeamTF
    {
        private float m_b, r_b, j_b;
        private float gain, sampleTime, ballPos;
        private float _pBeamAngle, _pBallPos, _ppBallPos;
        public BallBeamTF(float _m_b, float _r_b)
        {
            m_b = _m_b;
            r_b = _r_b; 

            _pBallPos = 0;
            _ppBallPos = 0;
            _pBeamAngle = 0;
            UpdateGain();
        }
        public float BallPos(float beamAngle)
        {
            _ppBallPos = _pBallPos;
            _pBallPos = ballPos;
            ballPos = gain*Time.deltaTime*Mathf.Sin(_pBeamAngle) + 2*_pBallPos - _ppBallPos;
            //ballPos = gain*sampleTime*_pBeamAngle + 2*_pBallPos - _ppBallPos;

            _pBeamAngle = beamAngle;

            //Debug.Log(ballPos.ToString() +' '+ _pBallPos.ToString() + ' ' + _ppBallPos.ToString());

            return ballPos;
        }
        public void UpdateGain()
        {
            j_b = 2/5*m_b*Mathf.Pow(r_b, 2); 
            gain = m_b*9.81f*Mathf.Pow(r_b, 2)/((m_b*Mathf.Pow(r_b, 2) + j_b));
            gain = 1f;
        }
        public void Gain(float _gain)
        {
            gain = _gain;
        }

        public void Reset()
        {
            _pBallPos = 0;
            _ppBallPos = 0;
            _pBeamAngle = 0;
            ballPos = 0;
        }
    }

    public class WaterLevelTF
    {
        private float r, c;
        private float gain, waterLevel;
        private float _pWaterLevel;
        public WaterLevelTF(float _r, float _c)
        {
            r = _r;
            c = _c;

            _pWaterLevel = 0;
            gain = 1;
        }
        public float WaterLevel(float flowRate)
        {
            _pWaterLevel = waterLevel;
            waterLevel = gain*Time.deltaTime*flowRate + Mathf.Exp(-Time.deltaTime)*_pWaterLevel;

            return waterLevel;
        }
        public void Gain(float _gain)
        {
            gain = _gain;
        }
    }
    public class PID
    {
        private float p, i, d;
        private float actSignal, _pError;
        public PID(float _p, float _i, float _d)
        {
            p = _p;
            i = _i;
            d = _d;
        }
        public void UpdateGain(float _p, float _i, float _d)
        {
            p = _p;
            i = _i;
            d = _d;
        }
        public float ActSignal(float error)
        {
            actSignal = p*error;
            actSignal += i*(error - _pError)*Time.deltaTime/2;
            actSignal += d*(error - _pError)/Time.deltaTime;
            _pError = error;

            return actSignal;
        }
    }
}

