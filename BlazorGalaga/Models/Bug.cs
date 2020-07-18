﻿using System;
using System.Collections.Generic;
using System.Drawing;
using BlazorGalaga.Interfaces;

namespace BlazorGalaga.Models
{
    public class Bug : AnimatableBase
    {
        public PointF HomePoint { get; set; }

        public Bug(Sprite.SpriteTypes spritetype)
        {
            Sprite = new Sprite(spritetype);
        }
    }
}
