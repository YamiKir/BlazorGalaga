﻿using System;
using System.Collections.Generic;
using System.Drawing;
using BlazorGalaga.Interfaces;
using BlazorGalaga.Models.Paths.Intros;

namespace BlazorGalaga.Models.Paths.Challenges.Challenge2
{
    public class Challenge3 : IntroBase
    {
        public Challenge3()
        {
            IsChallenge = true;
        }

        public override List<BezierCurve> GetPaths()
        {
            List<BezierCurve> paths = new List<BezierCurve>
            {
                new BezierCurve() {StartPoint = new PointF(-798.4799F,865.9338F),
                ControlPoint1 = new PointF(-798.4799F,865.9338F),
                ControlPoint2 = new PointF(1.520065F,865.9338F),
                EndPoint = new PointF(1.520065F,865.9338F)},

                new BezierCurve() {StartPoint = new PointF(1.520065F,865.9338F),
                ControlPoint1 = new PointF(218.9046F,817.4236F),
                ControlPoint2 = new PointF(514.6467F,785.4837F),
                EndPoint = new PointF(511.0978F,567.8195F)},

                new BezierCurve() {StartPoint = new PointF(512.2808F,565.4536F),
                ControlPoint1 = new PointF(514.6467F,395.1078F),
                ControlPoint2 = new PointF(509.9149F,289.8246F),
                EndPoint = new PointF(447.2175F,306.386F)},

                new BezierCurve() {StartPoint = new PointF(444.8516F,307.5689F),
                ControlPoint1 = new PointF(383.3372F,315.8496F),
                ControlPoint2 = new PointF(409.3625F,493.2932F),
                EndPoint = new PointF(410.5455F,555.99F)},

                new BezierCurve() {StartPoint = new PointF(410.5455F,555.99F),
                ControlPoint1 = new PointF(423.5581F,687.2982F),
                ControlPoint2 = new PointF(598.6375F,597.3935F),
                EndPoint = new PointF(600,250)},
            };

            return paths;
        }
    }
}
