﻿using BlazorGalaga.Models;
using BlazorGalaga.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGalaga.Static.GameServiceHelpers
{
    public static class BugMorphMananger
    {
        private static int MorphCount = 0;
        private static Sprite preMorphedSprite;
        private static Sprite preMorphedSpriteDownFlap;

        public static void DoMorph(List<Bug> bugs, Bug bug, AnimationService animationService, Ship ship)
        {
            if (MorphCount == 1)
            {
                preMorphedSpriteDownFlap = bug.SpriteBank[0];
                preMorphedSprite = bug.Sprite;
                bug.SpriteBank.Clear();
                bug.SpriteBank.Add(new Sprite(Sprite.SpriteTypes.RedGreenBug_DownFlap));
            }
            else if (MorphCount == 10)
            {
                bug.Sprite = new Sprite(Sprite.SpriteTypes.RedGreenBug);
            }
            else if (MorphCount == 15)
            {
                var morphedbug = CreateMorphedBug(animationService, bug, true);
                EnemyDiveManager.DoEnemyDive(bugs, animationService, ship, Constants.BugDiveSpeed, morphedbug, false, false);
            }
            else if (MorphCount == 17)
            {
                var morphedbug = CreateMorphedBug(animationService, bug, false);
                EnemyDiveManager.DoEnemyDive(bugs, animationService, ship, Constants.BugDiveSpeed, morphedbug, false, false);
            }
            else if (MorphCount == 19)
            {
                var morphedbug = CreateMorphedBug(animationService, bug, false);
                EnemyDiveManager.DoEnemyDive(bugs, animationService, ship, Constants.BugDiveSpeed, morphedbug, false, false);
            }
            else if (MorphCount == 20)
            {
                bug.DestroyImmediately = true;
            }

            MorphCount++;
        }

        private static Bug CreateMorphedBug(AnimationService animationService, Bug bug, bool hashomepoint)
        {
            var morphedbug = new Bug(Sprite.SpriteTypes.GreenBugShip)
            {
                Paths = new List<BezierCurve>(),
                Started = true,
                ZIndex = 100,
                RotateAlongPath = true,
                Location = bug.Location,
                IsMorphedBug = true,
                PreMorphedSprite = preMorphedSprite,
                PreMorphedSpriteDownFlap = preMorphedSpriteDownFlap
            };

            if (hashomepoint)
                morphedbug.HomePoint = bug.HomePoint;

            animationService.Animatables.Add(morphedbug);

            return morphedbug;
        }
    }
}